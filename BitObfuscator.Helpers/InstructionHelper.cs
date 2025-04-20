using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mono.Cecil.Cil;

namespace BitObfuscator.Helpers
{
    public static class InstructionHelper
    {
        public static void ReplaceInstruction(ILProcessor processor, Instruction oldInstr, IEnumerable<Instruction> newInstrs)
        {
            foreach (var instr in newInstrs)
            {
                processor.InsertBefore(oldInstr, instr);
            }
            processor.Remove(oldInstr);
        }
    }
}

