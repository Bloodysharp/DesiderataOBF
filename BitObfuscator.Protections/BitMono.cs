using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitObfuscator.Core;
using Mono.Cecil.Cil;
namespace BitObfuscator.Protections
{
    public class BitMono : IObfuscationProtection
    {
        public void Apply(ObfuscationContext context)
        {
            var entry = context.Module.EntryPoint;
            if (entry != null)
            {
                var processor = entry.Body.GetILProcessor();
                var method = typeof(Type).GetMethod("GetType", new[] { typeof(string) });
                var refTypeGet = context.Module.ImportReference(method);

                processor.InsertBefore(entry.Body.Instructions[0], processor.Create(OpCodes.Ldstr, "Mono.Runtime"));
                processor.InsertAfter(processor.Body.Instructions[0], processor.Create(OpCodes.Call, refTypeGet));
                processor.InsertAfter(processor.Body.Instructions[1], processor.Create(OpCodes.Pop));
            }
        }
    }
}
