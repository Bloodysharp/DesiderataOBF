using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitObfuscator.Core.Enums
{
    public enum ObfuscationFeature
    {
        StringsEncryption,
        UnmanagedString,
        BitDotNet,
        BitMethodDotnet,
        DotNetHook,
        CallToCalli,
        ObjectReturnType,
        NoNamespaces,
        FullRenamer,
        AntiDebugBreakpoints,
        AntiDecompiler,
        BitDecompiler,
        BitDateTimeStamp,
        BitMono,
        BillionNops,
        AntiDe4dot,
        AntiILdasm
    }
}
