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
        public abstract void TalkWithNeighbour(bool direction);
        public abstract void StudentPlayerTalkWithNeighbourEventHandler(cPlayer sender);
        public abstract void NeighbourPlayerTalkWithNeighbourEventHandler(cPlayer sender);
        public abstract void ThrowPaper(cStudent target);
        public abstract void StudentPlayerThrowPaperEventHandler(cPlayer sender);
        public abstract void ChangeSeat(int row, int seat);
        public abstract void TellOn(cStudent target);
    }
}
