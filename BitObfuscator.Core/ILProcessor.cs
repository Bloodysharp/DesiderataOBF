using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mono.Cecil.Cil;

namespace BitObfuscator.Core
{
    public static class ILProcessorExtensions
    {
        public static void ReplaceInstruction(this ILProcessor processor, Instruction oldInstruction, Instruction newInstruction)
        {
            var instructions = processor.Body.Instructions;
            for (int i = 0; i < instructions.Count; i++)
            {
                if (instructions[i] == oldInstruction)
                {
                    instructions[i] = newInstruction;
                    break;
                }
            }
        }
    }
}
