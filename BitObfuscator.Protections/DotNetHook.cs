using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitObfuscator.Core;
using Mono.Cecil.Cil;
namespace BitObfuscator.Protections
{
    public class DotNetHook : IObfuscationProtection
    {
        public void Apply(ObfuscationContext context)
        {
            //hook v main
            var main = context.Module.EntryPoint;
            if (main != null)
            {
                var processor = main.Body.GetILProcessor();
                var writeLineRef = context.Module.ImportReference(typeof(Console).GetMethod("WriteLine", new[] { typeof(string) }));
                processor.InsertBefore(main.Body.Instructions[0], processor.Create(OpCodes.Ldstr, "Hooked Entry"));
                processor.InsertAfter(processor.Body.Instructions[0], processor.Create(OpCodes.Call, writeLineRef));
            }
        }
    }
}
