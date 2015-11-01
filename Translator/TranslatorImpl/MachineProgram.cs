using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslatorImpl
{
    public class MachineProgram
    {
        public const int L = 3;
        MachineCommand[] _R = new MachineCommand[L];
        public MachineCommand[] R
        {
            get { return _R; }
            set { _R = value; }
        }
        void ReadProgram()
        {
            System.IO.StreamReader pr = new System.IO.StreamReader(@"c:\test.txt");
            char[] unnecessary = new char[] { 'p', 'f' };
            string rawCommand;
            string[] arr;
            int z = 0;
            while (!pr.EndOfStream)
            {
                rawCommand = pr.ReadLine();
                arr = rawCommand.Split(unnecessary, System.StringSplitOptions.RemoveEmptyEntries);
                rawCommand = "";
                foreach (string s in arr)
                {
                    rawCommand = rawCommand + s;
                }
                _R[z].SetCommand(rawCommand);
                rawCommand = "";
                z++;
            }
        }
        public MachineProgram()
        {
            ReadProgram();
        }
    }
}