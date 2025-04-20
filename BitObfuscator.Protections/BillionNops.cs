using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitObfuscator.Core;
using Mono.Cecil.Cil;
namespace BitObfuscator.Protections
{
    public class BillionNops : IObfuscationProtection
    {
        public void Apply(ObfuscationContext context)
        {
            foreach (var method in context.Module.Types.SelectMany(t => t.Methods).Where(m => m.HasBody))
            {
                var proc = method.Body.GetILProcessor();
                for (int i = 0; i < 100; i++)
                    proc.InsertBefore(method.Body.Instructions[0], proc.Create(OpCodes.Nop));
            }
        }
    }
}
