using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslatorImpl
{
    public class CalculatingMachine
    {
        char _x;
        public char x
        {
            get { return _x; }
            set { _x = value; }
        }
        const int k = 7;
        char[] A;
        char[,] F;
        bool[,] P;
        MachineCommand GetCommand(MachineProgram prog, int num)
        {
            return prog.R[num - 1];
        }
        void Apply(MachineCommand com, ref int num, ref int c)
        {
            int ordX = Array.IndexOf(A, this._x);
            if (P[com.p - 1, ordX])
            {
                _x = F[com.f - 1, ordX];
                num = com.l;
            }
            else
            {
                _x = F[com.g - 1, ordX];
                num = com.k;
            }
            c++;
        }
        public void Execute(MachineProgram progr)
        {
            bool cycled = false, endOfProgram = false;
            const int counterMax = k * MachineProgram.L;
            int commandNumber = 1, counter = 0;
            MachineCommand currentCommand = new MachineCommand();
            while (!endOfProgram & !cycled)
            {
                currentCommand = GetCommand(progr, commandNumber);
                Apply(currentCommand, ref commandNumber, ref counter);
                endOfProgram = commandNumber == 0;
                cycled = counter >= counterMax;
            }
            Console.Write("Результат: ");
            if (!cycled)
            {
                Console.WriteLine(_x);
            }
            else
            {
                Console.WriteLine("Программа зациклилась");
            }
            Console.ReadKey(false);
        }
        public CalculatingMachine()
        {
            A = new char[k] { '+', '-', '*', '=', '/', '[', ']' };
            const int n = 3;
            F = new char[n, k] { 
                { '-', '*', '/', '+', '[', ']', '=' }, 
                { '*', '*', '[', '[', '[', '-', '-' }, 
                { '/', '/', '/', '/', '-', '-', '-' } };
            const int m = 2;
            //'u' = true, 'л' = false
            P = new bool[m, k] { { true, true, true, true, true, false, false }, { true, true, false, false, false, true, true } };
        }
    }
}