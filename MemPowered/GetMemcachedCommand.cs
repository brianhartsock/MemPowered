using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;
using Enyim.Caching.Configuration;
using Enyim.Caching.Memcached;

namespace MemPowered
{
    /// <summary>
    /// Cmdlet to retrieve a value for a given key from memcached.
    /// </summary>
    [Cmdlet("Get", "Memcached")]
    public class GetMemcachedCommand : MemcachedAccessCommandBase
    {
        protected override void ProcessRecord()
        {
            var client = Registry.GetClient();
            var result = client.Get(Key);

            if (result == null)
            {
                WriteVerbose(Key + " - not found");
            }
            else
            {
                WriteObject(result);
            }
        }

        protected override void WriteNodeInfo(MemcachedNode node)
        {
            WriteVerbose(Key + " - retrieving from - " + node.EndPoint.ToString());
        }
    }
}
