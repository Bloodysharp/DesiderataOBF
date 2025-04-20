using BitObfuscator.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitObfuscator.Core
{
    public class ObfuscationContext
    {
        public string SourcePath { get; set; }
        public string OutputPath { get; set; }
        public List<ObfuscationFeature> Features { get; set; }
    }
}
