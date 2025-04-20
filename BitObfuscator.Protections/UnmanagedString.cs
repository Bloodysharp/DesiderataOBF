using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitObfuscator.Core;
using BitObfuscator.Helpers;
namespace BitObfuscator.Protections
{
    public class UnmanagedString : IObfuscationProtection
    {
        public void Apply(ObfuscationContext context)
        {
            // Внедрение вызовов нативной DLL для получения строк
            var dllPath = NativeDllHelper.EmbedNativeDll(context.Module, "native.dll", "NativeLib");
            Logger.Info($"Embedded native DLL: {dllPath}");
        }
    }
}
