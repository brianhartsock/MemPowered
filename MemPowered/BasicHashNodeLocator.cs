using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enyim.Caching.Memcached;
using System.Management.Automation.Runspaces;

namespace MemPowered
{
    /// <summary>
    /// Memcached Node Locator that uses basic hashing concepts to determine the server a given key
    /// is associated with.  
    /// 
    /// This class is for educational purposes, and will normally yield a very low hit rate when 
    /// adding/removing servers from configuration.
    /// </summary>
    public class BasicHashNodeLocator : IMemcachedNodeLocator
    {
        private IList<MemcachedNode> nodes;

        #region IMemcachedNodeLocator Members

        public void Initialize(IList<MemcachedNode> _nodes)
        {
            nodes = _nodes;
        }

        public MemcachedNode Locate(string key)
        {
            return nodes[Math.Abs(key.GetHashCode() % nodes.Count)];
        }

        #endregion
    }
}
