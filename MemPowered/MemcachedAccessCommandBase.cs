using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;
using Enyim.Caching.Memcached;

namespace MemPowered
{
    /// <summary>
    /// Base class for all Memcached commands which access key/value pair data somehow.
    /// </summary>
    public abstract class MemcachedAccessCommandBase : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0)]
        public string Key;

        protected override void BeginProcessing()
        {
            Publisher.Register(WriteNodeInfo);
        }
        protected override void EndProcessing()
        {
            Publisher.Unregister(WriteNodeInfo);
        }

        protected abstract void WriteNodeInfo(MemcachedNode node);
    }
}
