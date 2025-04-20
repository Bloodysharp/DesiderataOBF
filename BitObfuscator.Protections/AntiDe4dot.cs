using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitObfuscator.Core;
using Mono.Cecil;

namespace BitObfuscator.Protections
{
    public class AntiDe4dot : IObfuscationProtection
    {
        public void Apply(ObfuscationContext context)
        {
            var attrCtor = context.Module.ImportReference(typeof(System.ObsoleteAttribute).GetConstructor(Type.EmptyTypes));
            var attr = new CustomAttribute(attrCtor);
            context.Module.CustomAttributes.Add(attr);
        }
    }
}
