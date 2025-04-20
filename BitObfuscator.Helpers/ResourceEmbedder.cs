using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace BitObfuscator.Helpers
{
    public static class ResourceEmbedder
    {
        public static void EmbedResource(ModuleDefinition module, string name, byte[] data)
        {
            var resource = new EmbeddedResource(name, ManifestResourceAttributes.Private, data);
            module.Resources.Add(resource);
        }
    }
}