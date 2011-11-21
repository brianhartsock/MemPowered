using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;

namespace MemPowered
{
    /// <summary>
    /// Cmdlet to add a new memcached server to the config.
    /// </summary>
    [Cmdlet("Add", "MemcachedServer")]
    public class AddMemcachedServerCommand : PSCmdlet
    {
        [Parameter(Mandatory=true, Position=0)]
        public string Server;

        [Parameter(Mandatory = true, Position = 1)]
        public int Port;

        protected override void ProcessRecord()
        {
            Registry.GetConfigBuilder()
                .AddServer(Server, Port)
                .Register();
        }
    }
}
