using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitObfuscator.Core;
using Mono.Cecil.Cil;
namespace BitObfuscator.Protections
{

    public class AntiDebugBreakpoints : IObfuscationProtection
    {
        public void Apply(ObfuscationContext context)
        {
            foreach (var method in context.Module.Types.SelectMany(t => t.Methods).Where(m => m.HasBody))
            {
                var processor = method.Body.GetILProcessor();
                var brk = processor.Create(OpCodes.Break);
                processor.InsertBefore(method.Body.Instructions[0], brk);
                for (int i = 0; i < 5; i++)
                    processor.InsertBefore(method.Body.Instructions[0], processor.Create(OpCodes.Nop));
            }
        }
    }

}
