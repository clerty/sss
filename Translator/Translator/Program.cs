using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranslatorImpl;

namespace Translator
{
    class Program
    {
        static char ReadChar(string S)
        {
            Console.Write(S);
            string input = Console.ReadLine();
            return input[0];
        }
        static void Main(string[] args)
        {
            MachineProgram program = new MachineProgram();
            CalculatingMachine machine = new CalculatingMachine();
            machine.x = ReadChar("Исходное значение: ");
            machine.Execute(program);
        }
    }
}