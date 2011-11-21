using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;
using Enyim.Caching.Memcached;

namespace MemPowered
{
    /// <summary>
    /// Cmdlet to change the node locator in the memcached config.  Default is consistent.
    /// </summary>
    [Cmdlet("Set", "MemcachedServerLocator")]
    public class SetMemcachedServerLocator : Cmdlet
    {
        public enum NodeLocator
        {
            Basic,
            Consistent
        }

        [Parameter(Mandatory = true, Position = 0)]
        public NodeLocator Locator;

        protected override void ProcessRecord()
        {
            switch(Locator)
            {
                case NodeLocator.Basic:
                    Registry.GetConfigBuilder()
                        .SetNodeLocator(typeof(NodeLocatorNotifierDecorator<BasicHashNodeLocator>))
                        .Register();
                    break;
                case NodeLocator.Consistent:
                default:
                    //Use default
                    Registry.GetConfigBuilder()
                        .SetNodeLocator(typeof(NodeLocatorNotifierDecorator<DefaultNodeLocator>))
                        .Register();
                    break;
            };
        }
    }
}
