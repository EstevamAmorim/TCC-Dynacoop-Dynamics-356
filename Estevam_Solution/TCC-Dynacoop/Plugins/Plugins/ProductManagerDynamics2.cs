using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins.Plagins
{
    public class ProductManagerDynamics2 : PluginImplement
    {
        public override void ExecutePlugin(IServiceProvider ServiceProvider)
        {
            throw new InvalidPluginExecutionException("Products cannot be registered in this environment");
        }
    } 
}
