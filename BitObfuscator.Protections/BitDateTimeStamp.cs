using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitObfuscator.Core;

namespace BitObfuscator.Protections
{
    public class BitDateTimeStamp : IObfuscationProtection
    {
        public void Apply(ObfuscationContext context)
        {
            //PEHeaderEditor.ClearTimeDateStamp(context.FilePath);
        }
    }

}
