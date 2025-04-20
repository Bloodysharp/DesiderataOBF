using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitObfuscator.Core
{
    using System.Collections.Generic;
    using System.IO;

    namespace BitObfuscator.Core
    {
        public static class ProjectScanner
        {
            public static IEnumerable<string> ScanAssemblies(string rootDirectory)
            {
                return Directory.EnumerateFiles(rootDirectory, "*.dll", SearchOption.AllDirectories);
            }
        }
    }
}
