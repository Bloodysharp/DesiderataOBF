using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using BitObfuscator.Core;
using Mono.Cecil.Cil;
namespace BitObfuscator.Protections
{

    public class BitMethodDotnet : IObfuscationProtection
    {
        public void Apply(ObfuscationContext context)
        {
            foreach (var method in context.Module.Types.SelectMany(t => t.Methods))
            {
                if (method.HasBody)
                {
                    var processor = method.Body.GetILProcessor();
                    var rand = new Random();
                    for (int i = 0; i < rand.Next(3, 6); i++)
                    {
                        processor.InsertBefore(method.Body.Instructions[0], processor.Create(OpCodes.Nop));
                    }
                }
            }
        }
    }
}
