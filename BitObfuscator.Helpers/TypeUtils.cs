using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

using Mono.Cecil;

namespace BitObfuscator.Helpers
{
    public static class TypeUtils
    {
        public static bool IsUserType(Mono.Cecil.TypeDefinition type)
        {
            return !type.Namespace.StartsWith("System") && !type.IsInterface && !type.IsEnum && !type.IsSpecialName;
        }
    }
}