using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitObfuscator.Core;
namespace BitObfuscator.Protections
{
    public class ObjectReturnType : IObfuscationProtection
    {
        public void Apply(ObfuscationContext context)
        {
            foreach (var method in context.Module.Types.SelectMany(t => t.Methods))
            {
                if (method.ReturnType.FullName != "System.Void" && method.HasBody)
                {
                    method.MethodReturnType.ReturnType = context.Module.TypeSystem.Object;
                }
            }
        }
    }

}
