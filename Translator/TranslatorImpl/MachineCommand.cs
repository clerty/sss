using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslatorImpl
{
    public struct MachineCommand
    {
        public int p, f, l, g, k;
        public void SetCommand(string com)
        {
            int int0 = Convert.ToInt32('0');
            this.p = Convert.ToInt32(com[0]) - int0;
            this.f = Convert.ToInt32(com[1]) - int0;
            this.l = Convert.ToInt32(com[2]) - int0;
            this.g = Convert.ToInt32(com[3]) - int0;
            this.k = Convert.ToInt32(com[4]) - int0;
        }
    }
}