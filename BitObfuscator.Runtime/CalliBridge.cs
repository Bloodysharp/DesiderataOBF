using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BitObfuscator.Runtime
{
    public class CalliBridge
    {
        public static void CallWithCalli(string methodName, object[] parameters)
        {
            var method = typeof(CalliBridge).GetMethod(methodName, BindingFlags.Public | BindingFlags.Static);
            var calliPointer = method.MethodHandle.GetFunctionPointer();
            var delegateType = typeof(Action); // For example, adjust for proper delegate type

            var del = (Action)Activator.CreateInstance(delegateType, calliPointer);
            del();
        }
    }
}
