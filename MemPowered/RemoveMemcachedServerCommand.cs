using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;

namespace MemPowered
{
    /// <summary>
    /// Cmdlet to remove a new memcached server from the config.
    /// </summary>
    [Cmdlet("Remove", "MemcachedServer")]
    public class RemoveMemcachedServerCommand : Cmdlet
    {
        [Parameter(Mandatory=true, Position=0)]
        public string Server;

        [Parameter(Mandatory = true, Position = 1)]
        public int Port;

        protected override void ProcessRecord()
        {
            Registry.GetConfigBuilder()
                .RemoveServer(Server, Port)
                .Register();
        }
    }
}
