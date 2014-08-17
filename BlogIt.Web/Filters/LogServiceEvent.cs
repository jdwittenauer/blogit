using System;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Web.Mvc;
using BlogIt.Domain.Entities;
using BlogIt.Domain.Interfaces;

namespace BlogIt.Web.Filters
{
    /// <summary>
    /// WCF extension point that allows us to hook into operation calls and run code
    /// before/after an operation completes.  This custom attribute will log important
    /// details about the operation call.
    /// </summary>
    public class LogServiceEvent : IParameterInspector
    {
        public object BeforeCall(string operationName, object[] inputs)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            return timer;
        }

        public void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState)
        {
            Stopwatch timer = (Stopwatch)correlationState;
            double loadTime = 0;
            if (timer != null)
            {
                timer.Stop();
                loadTime = Math.Round(double.Parse(timer.ElapsedMilliseconds.ToString()) / 1000, 3);
            }

            // WCF occasionally makes additional calls to set up security context -
            // ignore operations with a name of "Get" since we don't need to log these
            if (operationName != "Get" && operationName != "SaveLogEntry")
            {
                // Log important information about the operation call
                Log log = new Log
                {
                    User = "Unknown",
                    EventType = EventType.Service,
                    EventDetail = String.Format("{0}", operationName),
                    Metric = loadTime,
                    MetricDescription = "Elapsed Time",
                    MetricUnit = "Seconds"
                };

                if (OperationContext.Current.ServiceSecurityContext != null)
                {
                    log.User = OperationContext.Current.ServiceSecurityContext.PrimaryIdentity.Name.ToString();
                }

                var repository = DependencyResolver.Current.GetService<ILogRepository>();
                repository.Insert(log);
            }
        }
    }

    /// <summary>
    /// Creates the custom attribute and adds the above parameter inspector to each
    /// service operation on the channel.
    /// </summary>
    public class LogServiceEvents : Attribute, IServiceBehavior
    {
        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (ChannelDispatcher channelDispatcher in serviceHostBase.ChannelDispatchers)
            {
                foreach (EndpointDispatcher endpointDispatcher in channelDispatcher.Endpoints)
                {
                    foreach (DispatchOperation dispatchOperation in endpointDispatcher.DispatchRuntime.Operations)
                    {
                        dispatchOperation.ParameterInspectors.Add(new LogServiceEvent());
                    }
                }
            }
        }
    }
}