using System;
using System.Collections.Generic;
using System.ServiceModel;
using MyBlog.Domain.Entities;

namespace MyBlog.Services
{
    /// <summary>
    /// Provides an abstraction from the details of working with WCF channels on the
    /// client side by handling initial setup and configuration, and managing the
    /// channel and connection lifetimes automatically.
    /// </summary>
    public class MyBlogServiceFactory
    {
        public string Environment { get; set; }
        public Dictionary<string, object> OpenChannels { get; private set; }
        private BasicHttpBinding binding;

        /// <summary>
        /// Default constructor.  Initializes the environment to production.  The environment
        /// property is used to determine the default location to look for the services.
        /// </summary>
        public MyBlogServiceFactory()
        {
            if (Environment == EnvironmentType.None)
                Environment = EnvironmentType.Production;

            binding = new BasicHttpBinding();
            binding.MaxBufferPoolSize = int.MaxValue;
            binding.MaxBufferSize = int.MaxValue;
            binding.MaxReceivedMessageSize = int.MaxValue;
            binding.SendTimeout = TimeSpan.FromMinutes(10);
            binding.ReceiveTimeout = TimeSpan.FromMinutes(10);
            binding.OpenTimeout = TimeSpan.FromMinutes(1);
            binding.CloseTimeout = TimeSpan.FromMinutes(1);
            binding.ReaderQuotas.MaxArrayLength = int.MaxValue;
            binding.ReaderQuotas.MaxBytesPerRead = int.MaxValue;
            binding.ReaderQuotas.MaxDepth = int.MaxValue;
            binding.ReaderQuotas.MaxNameTableCharCount = int.MaxValue;
            binding.ReaderQuotas.MaxStringContentLength = int.MaxValue;

            binding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Windows;

            OpenChannels = new Dictionary<string, object>();
        }

        /// <summary>
        /// Constructor that overrides the default environment designation.  The environment
        /// property is used to determine the default location to look for the services.
        /// </summary>
        /// <param name="environment">Environment</param>
        public MyBlogServiceFactory(string environment) : this()
        {
            this.Environment = environment;

            if (Environment != EnvironmentType.Production)
            {
                binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Ntlm;
            }
        }

        /// <summary>
        /// Initializes and returns a service channel of type TChannel, where TChannel
        /// is a service interface.
        /// </summary>
        /// <typeparam name="TChannel">Service interface</typeparam>
        /// <returns>Initialized service channel</returns>
        public TChannel GetService<TChannel>()
        {
            return GetService<TChannel>(GetServiceURI(typeof(TChannel).Name));
        }

        /// <summary>
        /// Initializes and returns a service channel of type TChannel, where TChannel
        /// is a service interface.  Overrides the default implementation by manually
        /// specifying the location of the service rather than using the cached location.
        /// </summary>
        /// <typeparam name="TChannel">Service interface</typeparam>
        /// <param name="uri">Service URI</param>
        /// <returns>Initialized service channel</returns>
        public TChannel GetService<TChannel>(string uri)
        {
            string key = typeof(TChannel).Name;
            if (!OpenChannels.ContainsKey(key))
            {
                EndpointAddress endpoint = new EndpointAddress(uri);
                MyBlogChannelFactory<TChannel> factory = new MyBlogChannelFactory<TChannel>(binding, endpoint);

                factory.Credentials.Windows.ClientCredential = 
                    System.Net.CredentialCache.DefaultNetworkCredentials;
                factory.Credentials.Windows.AllowedImpersonationLevel =
                    System.Security.Principal.TokenImpersonationLevel.Identification;
                OpenChannels.Add(key, factory);
            }

            TChannel service = ((MyBlogChannelFactory<TChannel>)OpenChannels[key]).CreateChannel();
            ((IClientChannel)service).OperationTimeout = TimeSpan.FromMinutes(10);
            ((IClientChannel)service).Open();

            return (TChannel)service;
        }

        /// <summary>
        /// Dynamically creates and uses a service channel to invoke a method that
        /// does not return a value.  The type TChannel should be a service interface.
        /// </summary>
        /// <typeparam name="TChannel">Service interface</typeparam>
        /// <param name="action">Invocation method</param>
        public void UseService<TChannel>(Action<TChannel> action)
        {
            UseService<TChannel>(action, GetServiceURI(typeof(TChannel).Name));
        }

        /// <summary>
        /// Dynamically creates and uses a service channel to invoke a method that
        /// does not return a value.  The type TChannel should be a service interface.
        /// Overrides the default implementation by manually specifying the location 
        /// of the service rather than using the cached location.
        /// </summary>
        /// <typeparam name="TChannel">Service interface</typeparam>
        /// <param name="action">Invocation method</param>
        /// <param name="uri">Service URI</param>
        public void UseService<TChannel>(Action<TChannel> action, string uri)
        {
            TChannel service = GetService<TChannel>(uri);
            bool error = true;
            try
            {
                action(service);
                CloseService((IClientChannel)service);
                error = false;
            }
            finally
            {
                if (error)
                {
                    ((IClientChannel)service).Abort();
                }
            }
        }

        /// <summary>
        /// Dynamically creates and uses a service channel to invoke a method that
        /// returns a value.  The type TChannel should be a service interface.
        /// </summary>
        /// <typeparam name="TChannel">Service interface</typeparam>
        /// <typeparam name="TReturn">Return type</typeparam>
        /// <param name="function">Invocation method</param>
        /// <returns>Result of the invoked service method</returns>
        public TReturn UseService<TChannel, TReturn>(Func<TChannel, TReturn> function)
        {
            return UseService<TChannel, TReturn>(function, GetServiceURI(typeof(TChannel).Name));
        }

        /// <summary>
        /// Dynamically creates and uses a service channel to invoke a method that
        /// returns a value.  The type TChannel should be a service interface.
        /// Overrides the default implementation by manually specifying the location 
        /// of the service rather than using the cached location.
        /// </summary>
        /// <typeparam name="TChannel">Service interface</typeparam>
        /// <typeparam name="TReturn">Return type</typeparam>
        /// <param name="function">Invocation method</param>
        /// <param name="uri">Service URI</param>
        /// <returns>Result of the invoked service method</returns>
        public TReturn UseService<TChannel, TReturn>(Func<TChannel, TReturn> function, string uri)
        {
            TChannel service = GetService<TChannel>(uri);
            bool error = true;
            try
            {
                TReturn result = function(service);
                CloseService((IClientChannel)service);
                error = false;
                return result;
            }
            finally
            {
                if (error)
                {
                    ((IClientChannel)service).Abort();
                }
            }
        }

        /// <summary>
        /// Close a service channel created by GetService.  The service channel must
        /// be cast to IClientChannel.
        /// </summary>
        /// <param name="service">Service channel</param>
        public void CloseService(IClientChannel service)
        {
            if (service != null)
            {
                bool error = true;
                try
                {
                    service.Close();
                    service.Dispose();
                    service = null;
                    error = false;
                }
                finally
                {
                    if (error)
                    {
                        service.Abort();
                    }
                }
            }
        }

        /// <summary>
        /// Closes and disposes of all cached channel resources.  Call this once when the
        /// service factory is no longer needed.
        /// </summary>
        public void Close()
        {
            foreach (KeyValuePair<string, object> channelFactory in OpenChannels)
            {
                ((ChannelFactory)channelFactory.Value).Close();
            }
        }

        /// <summary>
        /// Helper method that determines the current known location of the desired
        /// service based on the environment property and service name.
        /// </summary>
        /// <param name="type">Service interface name</param>
        /// <returns>Service URI</returns>
        private string GetServiceURI(string type)
        {
            string baseURI = String.Empty;
            if (Environment == EnvironmentType.Production)
                baseURI = Constants.WebServerProd;
            else if (Environment == EnvironmentType.Test)
                baseURI = Constants.WebServerTest;
            else if (Environment == EnvironmentType.Development)
                baseURI = Constants.WebServerDev;
            else
                baseURI = Constants.WebServerLocal;

            string path = String.Empty;
            switch (type)
            {
                case ("IAuthorService"):
                    path = Constants.AuthorService;
                    break;
                case ("IBlogService"):
                    path = Constants.BlogService;
                    break;
                case ("ICommentService"):
                    path = Constants.CommentService;
                    break;
                case ("IPostService"):
                    path = Constants.PostService;
                    break;
				default:
					path = null;
                    break;
            }

            return baseURI + path;
        }
    }
}
