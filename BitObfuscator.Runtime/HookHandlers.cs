using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitObfuscator.Runtime
{
    public class HookHandlers
    {
        public static void AntiDebugHook()
        {
            if (Debugger.IsAttached || Debugger.IsLogging())
            {
                throw new InvalidOperationException("Debugger detected!");
            }
        }
    }
}
