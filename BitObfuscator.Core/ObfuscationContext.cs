using BitObfuscator.Core.Enums;
using System;
using System.Collections.Generic;
using Mono.Cecil;
using System.Reflection.Metadata;
using BitObfuscator.Helpers;

namespace BitObfuscator.Core
{
    public class ObfuscationContext
    {
        public Mono.Cecil.ModuleDefinition Module { get; set; }
        public string EncryptionKey { get; set; }
        public MethodReference RuntimeDecryptMethod { get; set; }

        public ObfuscationContext(Mono.Cecil.ModuleDefinition module, string encryptionKey)
        {
            Module = module;
            EncryptionKey = encryptionKey;
            RuntimeDecryptMethod = module.ImportReference(typeof(CryptoHelper).GetMethod("Decrypt", new[] { typeof(string), typeof(string) }));
        }
    }
}
