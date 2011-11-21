using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;
using Enyim.Caching.Memcached;

namespace MemPowered
{
    /// <summary>
    /// Cmdlet to store a value for a given key in memcached.
    /// </summary>
    [Cmdlet("Set", "Memcached")]
    public class SetMemcachedCommand : MemcachedAccessCommandBase
    {
        [Parameter(Mandatory = true, Position = 1)]
        public string Value;

        [Parameter]
        public StoreMode Mode = StoreMode.Set;

        protected override void ProcessRecord()
        {            
            var client = Registry.GetClient();
            client.Store(Mode, Key, Value);
        }

        protected override void WriteNodeInfo(MemcachedNode node)
        {
            WriteVerbose(Key + " - storing in - " + node.EndPoint.ToString());
        }
    }
}