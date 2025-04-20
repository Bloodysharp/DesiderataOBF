using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitObfuscator.Core;
namespace BitObfuscator.Protections
{

    public class NoNamespaces : IObfuscationProtection
    {
        public void Apply(ObfuscationContext context)
        {
            foreach (var type in context.Module.Types)
            {
                type.Namespace = string.Empty;
            }
        }
    }
}
