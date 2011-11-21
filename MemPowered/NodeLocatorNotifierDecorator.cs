using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enyim.Caching.Memcached;

namespace MemPowered
{
    /// <summary>
    /// Decorator for IMemcachedNodeLocator's that publishes events when the method is called.  
    /// 
    /// This class actually instantiates the inner class, because of how Enyim's config works.  
    /// Normally, it would be injected.
    /// </summary>
    /// <typeparam name="T">Concrete type to decorate.</typeparam>
    public class NodeLocatorNotifierDecorator<T> : IMemcachedNodeLocator
       where T : IMemcachedNodeLocator
    {
        IMemcachedNodeLocator inner;

        public NodeLocatorNotifierDecorator()
        {
            inner = Activator.CreateInstance<T>();
        }

        #region IMemcachedNodeLocator Members

        public void Initialize(IList<MemcachedNode> nodes)
        {
            inner.Initialize(nodes);
        }

        public MemcachedNode Locate(string key)
        {
            var node = inner.Locate(key);
            Publisher.Publish(node);
            return node;
        }

        #endregion
    }
}
