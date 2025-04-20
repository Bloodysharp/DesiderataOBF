using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BitObfuscator.Core;
using Mono.Cecil;
namespace BitObfuscator.Protections
{
    public class BitDotNet : IObfuscationProtection
    {
        public void Apply(ObfuscationContext context)
        {
            // Добавление dummy-классов
            for (int i = 0; i < 10; i++)
            {
                var dummy = new TypeDefinition("DummyNamespace", "DummyClass" + i,
                    Mono.Cecil.TypeAttributes.Public | Mono.Cecil.TypeAttributes.Class,
                    context.Module.TypeSystem.Object);
                context.Module.Types.Add(dummy);
            }
        }
    }
}
