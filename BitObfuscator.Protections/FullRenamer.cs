using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitObfuscator.Core;
namespace BitObfuscator.Protections
{
    public class FullRenamer : IObfuscationProtection
    {
        public void Apply(ObfuscationContext context)
        {
            int counter = 0;
            foreach (var type in context.Module.Types)
            {
                type.Name = "Type" + counter++;
                foreach (var method in type.Methods) method.Name = "Method" + counter++;
                foreach (var field in type.Fields) field.Name = "Field" + counter++;
                foreach (var prop in type.Properties) prop.Name = "Prop" + counter++;
            }
        }
    }
}
