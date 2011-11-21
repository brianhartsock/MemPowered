using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Enyim.Caching.Configuration;
using Enyim.Caching.Memcached;

namespace MemPowered
{
    public class MemcachedConfigBuilder
    {
        IList<IPEndPoint> eps = new List<IPEndPoint>();
        Type locator;

        public MemcachedConfigBuilder AddServer(string ip, int port)
        {
            eps.Add(new IPEndPoint(IPAddress.Parse(ip), port));

            return this;
        }

        public IEnumerable<IPEndPoint> GetServers()
        {
            return eps;
        }

        public MemcachedClientConfiguration Build()
        {
            var config = new MemcachedClientConfiguration();
            foreach (IPEndPoint ep in eps)
            {
                config.Servers.Add(ep);
            }

            config.NodeLocator = locator ?? typeof(NodeLocatorNotifierDecorator<DefaultNodeLocator>);

            return config;
        }

        public MemcachedConfigBuilder SetNodeLocator(Type type)
        {
            locator = type;

            return this;
        }

        public MemcachedConfigBuilder RemoveServer(string ip, int port)
        {
            eps.Remove(new IPEndPoint(IPAddress.Parse(ip), port));

            return this;
        }
    }
}
