using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;

namespace Kittyhawk.Services
{
    /// <summary>
    /// Overrides the default channel factory implementation to add an endpoint behavior
    /// that increases the maximum number of objects allowed in an object graph.
    /// </summary>
    /// <typeparam name="T">Service interface</typeparam>
    public class MyBlogChannelFactory<T> : ChannelFactory<T>
    {
        public MyBlogChannelFactory(Binding binding) :
            base(binding) { }

        public MyBlogChannelFactory(ServiceEndpoint endpoint) :
            base(endpoint) { }

        public MyBlogChannelFactory(string endpointConfigurationName) :
            base(endpointConfigurationName) { }

        public MyBlogChannelFactory(Binding binding, EndpointAddress remoteAddress) :
            base(binding, remoteAddress) { }

        public MyBlogChannelFactory(Binding binding, string remoteAddress) :
            base(binding, remoteAddress) { }

        public MyBlogChannelFactory(string endpointConfigurationName,
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
