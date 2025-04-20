using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitObfuscator.Core;
using Mono.Cecil.Cil;
namespace BitObfuscator.Protections
{
    public class CallToCalli : IObfuscationProtection
    {
        public void Apply(ObfuscationContext context)
        {
            //calli method
            foreach (var method in context.Module.Types.SelectMany(t => t.Methods).Where(m => m.HasBody && m.Body.Instructions.Count > 2))
            {
                var processor = method.Body.GetILProcessor();
                var first = method.Body.Instructions[0];

                processor.InsertBefore(first, processor.Create(OpCodes.Ldc_I4, 0));
                processor.InsertAfter(processor.Body.Instructions[0], processor.Create(OpCodes.Conv_U));
                //processor.InsertAfter(processor.Body.Instructions[1], processor.Create(OpCodes.Calli, MethodSigFactory.CreateCalliSig(context.Module))); // Требует реализации
            }
        }
    }
}
