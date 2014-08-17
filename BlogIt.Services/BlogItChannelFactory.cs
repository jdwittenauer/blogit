using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;

namespace BlogIt.Services
{
    /// <summary>
    /// Overrides the default channel factory implementation to add an endpoint behavior
    /// that increases the maximum number of objects allowed in an object graph.
    /// </summary>
    /// <typeparam name="T">Service interface</typeparam>
    public class BlogItChannelFactory<T> : ChannelFactory<T>
    {
        public BlogItChannelFactory(Binding binding) :
            base(binding) { }

        public BlogItChannelFactory(ServiceEndpoint endpoint) :
            base(endpoint) { }

        public BlogItChannelFactory(string endpointConfigurationName) :
            base(endpointConfigurationName) { }

        public BlogItChannelFactory(Binding binding, EndpointAddress remoteAddress) :
            base(binding, remoteAddress) { }

        public BlogItChannelFactory(Binding binding, string remoteAddress) :
            base(binding, remoteAddress) { }

        public BlogItChannelFactory(string endpointConfigurationName,
            EndpointAddress remoteAddress) :
            base(endpointConfigurationName, remoteAddress) { }

        protected override void OnOpening()
        {
            foreach (var operation in Endpoint.Contract.Operations)
            {
                var behavior = operation.Behaviors.Find<DataContractSerializerOperationBehavior>();
                if (behavior != null)
                {
                    behavior.MaxItemsInObjectGraph = int.MaxValue;
                }
            }
            base.OnOpening();
        }
    }
}
