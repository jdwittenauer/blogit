using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Web.Mvc;
using MyBlog.Domain.Entities;
using MyBlog.Domain.Interfaces;

namespace MyBlog.Web.Filters
{
    /// <summary>
    /// WCF extension point that allows us to hook into the error handling mechanism.  This
    /// class will log exceptions to the database before passing them on to be handled.
    /// </summary>
    public class LogServiceError : IErrorHandler
    {
        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
        }

        public bool HandleError(Exception e)
        {
            // Log the exception
            Error error = new Error
            {
                User = "Unknown",
                EventType = EventType.Service,
                EventDetail = null,
                Description = e.Message,
                StackTrace = e.StackTrace
            };

            if (e.InnerException != null)
            {
                error.Description = e.InnerException.Message;
                error.StackTrace = e.InnerException.StackTrace;
            }

            if (OperationContext.Current.ServiceSecurityContext != null)
                error.User = OperationContext.Current.ServiceSecurityContext.PrimaryIdentity.Name.ToString();

            var repository = DependencyResolver.Current.GetService<IErrorRepository>();
            repository.Insert(error);

            return true;
        }
    }

    /// <summary>
    /// Adds our custom error handler to the channel dispatcher, which allows it to used
    /// as an attribute decorating a service class.
    /// </summary>
    public sealed class ErrorBehaviorAttribute : Attribute, IServiceBehavior
    {
        Type errorHandlerType;

        public ErrorBehaviorAttribute(Type errorHandlerType)
        {
            this.errorHandlerType = errorHandlerType;
        }

        public Type ErrorHandlerType
        {
            get { return this.errorHandlerType; }
        }

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            IErrorHandler errorHandler = (IErrorHandler)Activator.CreateInstance(errorHandlerType);

            foreach (ChannelDispatcherBase channelDispatcherBase in serviceHostBase.ChannelDispatchers)
            {
                ChannelDispatcher channelDispatcher = channelDispatcherBase as ChannelDispatcher;
                channelDispatcher.ErrorHandlers.Add(errorHandler);
            }   
        }
    }
}