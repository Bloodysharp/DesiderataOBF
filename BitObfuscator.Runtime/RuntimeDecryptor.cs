using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitObfuscator.Runtime
{
    public class RuntimeDecryptor
    {
        public static string DecryptWithRuntime(string encryptedText, string key)
        {
            return AESRuntime.Decrypt(encryptedText, key);
        }
    }
}
