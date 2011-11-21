using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enyim.Caching.Memcached;

namespace MemPowered
{
    public static class Publisher
    {
        static List<Action<MemcachedNode>> registrants = new List<Action<MemcachedNode>>();

        public static void Register(Action<MemcachedNode> action)
        {
            registrants.Add(action);
        }

        public static void Publish(MemcachedNode node)
        {
            registrants.ForEach(a => a.Invoke(node));
        }

        public static void Unregister(Action<MemcachedNode> action)
        {
            registrants.Remove(action);
        }
    }
}
