using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;
using Enyim.Caching.Memcached;

namespace MemPowered
{
    /// <summary>
    /// Cmdlet to decrement a value for a given key in memcached.
    /// </summary>
    [Cmdlet("Decrement", "Memcached")]
    public class DecrementMemcachedCommand : MemcachedAccessCommandBase
    {
        [Parameter]
        public uint Amount = 1;

        protected override void ProcessRecord()
        {
            var client = Registry.GetClient();
            WriteObject(client.Decrement(Key, 0));
        }

        protected override void WriteNodeInfo(MemcachedNode node)
        {
            WriteVerbose(Key + " - decrementing on - " + node.EndPoint.ToString());
        }
    }
}
