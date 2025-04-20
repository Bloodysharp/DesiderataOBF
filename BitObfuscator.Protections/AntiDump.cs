using BitObfuscator.Core;
using Mono.Cecil;
using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitObfuscator.Protections
{
    public class AntiDump : IObfuscationProtection
    {
        public void Apply(ObfuscationContext context)
        {
            var module = context.Module;

            var type = new TypeDefinition("", "AntiDump", TypeAttributes.Class | TypeAttributes.Public | TypeAttributes.Abstract | TypeAttributes.Sealed, module.TypeSystem.Object);
            module.Types.Add(type);


            var cctor = new MethodDefinition(".cctor", MethodAttributes.Static | MethodAttributes.Private | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName, module.TypeSystem.Void);
            type.Methods.Add(cctor);

            var il = cctor.Body.GetILProcessor();


            var methodRef = module.ImportReference(typeof(AntiDumpNative).GetMethod(nameof(AntiDumpNative.Protect), System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public));
            il.Append(il.Create(OpCodes.Call, methodRef));
            il.Append(il.Create(OpCodes.Ret));

         
            var entry = module.EntryPoint ?? module.Types.SelectMany(t => t.Methods).FirstOrDefault(m => m.IsStatic && m.HasBody);
            if (entry != null)
            {
                var proc = entry.Body.GetILProcessor();
                var call = proc.Create(OpCodes.Call, cctor);
                proc.InsertBefore(entry.Body.Instructions[0], call);
            }
        }

        public static class AntiDumpNative
        {
            [System.Runtime.InteropServices.DllImport("kernel32.dll", SetLastError = true)]
            private static extern IntPtr GetCurrentProcess();

            [System.Runtime.InteropServices.DllImport("kernel32.dll", SetLastError = true)]
            private static extern bool VirtualProtect(IntPtr lpAddress, uint dwSize, uint flNewProtect, out uint lpflOldProtect);

            public static void Protect()
            {
                unsafe
                {
                    byte* baseAddr = (byte*)System.Diagnostics.Process.GetCurrentProcess().MainModule.BaseAddress;
                    
                    for (int i = 0; i < 30; i++)
                    {
                        baseAddr[i] = 0;
                    }
                }
            }
        }
    }
}
