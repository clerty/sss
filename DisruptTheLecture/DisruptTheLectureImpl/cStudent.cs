using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisruptTheLectureImpl
{
    abstract class cStudent
    {
        int _reprimands = 0;
        public int reprimands
        {
            get { return _reprimands; }
            set { _reprimands = value; }
        }
        int _volume;
        public int volume
        {
            get { return _volume; }
        }

        public abstract void ChangeSeat(sCoords coords);
        public abstract void NeighbourPlayerTalkWithNeighbourEventHandler(cPlayer sender);
        public abstract void VictimPlayerThrowPaperEventHandler(cPlayer sender/*, cProfessor pr*/);
        public abstract void StudentProfessorMakeReprimandEventHandler(cProfessor sender);
    }
}
