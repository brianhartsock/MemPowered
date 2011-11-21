using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enyim.Caching.Configuration;
using System.Net;
using Enyim.Caching;
using Enyim.Caching.Memcached;

namespace MemPowered
{
    public static class Registry
    {        
        static MemcachedConfigBuilder configBuilder = new MemcachedConfigBuilder();

        static MemcachedClientConfiguration config;
        static MemcachedClient client;

        static Registry()
        {
            config = new MemcachedClientConfiguration();
            client = new MemcachedClient(config);
        }

        public static MemcachedClient GetClient()
        {
            return client;
        }

        public static MemcachedConfigBuilder GetConfigBuilder()
        {
            return configBuilder;
        }

        public static void Register(this MemcachedConfigBuilder builder)
        {
            client = new MemcachedClient(builder.Build());
        }
    }
}
