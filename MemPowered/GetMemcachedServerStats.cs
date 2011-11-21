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
    /// Cmdlet which returns stats for all memcached servers configured.
    /// </summary>
    [Cmdlet("Get", "MemcachedServerStats")]
    public class GetMemcachedServerStats : Cmdlet
    {
        protected override void ProcessRecord()
        {
            var client = Registry.GetClient();

            var stats = client.Stats();
            var servers = Registry.GetConfigBuilder().GetServers();

            foreach (var server in servers)
            {
                foreach (var e in Enum.GetValues(typeof(StatItem)))
                {
                    //HACK - Enyim library has a bug for the version statitem (tries to cast to an int...)
                    if (((StatItem)e) != StatItem.Version)
                    {
                        WriteObject(server.ToString() + " - " + e.ToString() + " - " +
                            stats.GetValue(server, ((StatItem)e)));
                    }
                }
            }
        }
    }
}