using System;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Cil;
using BitObfuscator.Helpers;
using BitObfuscator.Core;


namespace BitObfuscator.Protections
{
    public class StringsEncryption : IObfuscationProtection
    {
        public void Apply(ObfuscationContext context)
        {
            foreach (var type in context.Module.Types)
                foreach (var method in type.Methods.Where(m => m.HasBody))
                {
                    var processor = method.Body.GetILProcessor();
                    for (int i = 0; i < method.Body.Instructions.Count; i++)
                    {
                        var instr = method.Body.Instructions[i];
                        if (instr.OpCode == Mono.Cecil.Cil.OpCodes.Ldstr)
                        {
                            var encrypted = CryptoHelper.Encrypt(instr.Operand.ToString(), context.EncryptionKey);
                            var loadEncrypted = processor.Create(OpCodes.Ldstr, encrypted);
                            var callDecrypt = processor.Create(OpCodes.Call, context.RuntimeDecryptMethod);

                            processor.Replace(instr, loadEncrypted);
                            processor.InsertAfter(loadEncrypted, callDecrypt);
                            i++;
                        }
                    }
                }
        }
    }
}