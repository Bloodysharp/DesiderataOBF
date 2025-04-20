using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BitObfuscator.Core
{
    public class ObfuscatorEngine
    {
        public void Run(ObfuscationContext context)
        {
            var module = ModuleDefinition.ReadModule(context.SourcePath);

            foreach (var feature in context.Features)
            {
                var protection = ProtectionFactory.Get(feature);
                protection.Execute(module, context);
            }

            module.Write(context.OutputPath);
        }
    }
}
