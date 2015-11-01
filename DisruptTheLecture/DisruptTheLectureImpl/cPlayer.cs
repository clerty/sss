using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisruptTheLectureImpl
{
    class cPlayer : cStudent, IProfessorsListener
    {
        int volume = 4;
        int radiusOfGettingPaper = 6;
        public delegate void PlayerTalkWithNeighbourEventHandler(cPlayer sender);
        public event PlayerTalkWithNeighbourEventHandler PlayerTalkWithNeighbourEventList;
        public override void TalkWithNeighbour(bool direction)
        {
            if (PlayerTalkWithNeighbourEventList != null) PlayerTalkWithNeighbourEventList(this);
        }
        public delegate void PlayerThrowPaperEventHandler(cPlayer sender);
        public event PlayerThrowPaperEventHandler PlayerThrowPaperEventList;
        public override void ThrowPaper(cStudent target)
        {
            if (PlayerThrowPaperEventList != null) PlayerThrowPaperEventList(this);
        }
        public override void ChangeSeat(cStudent target)
        {

        }
    }
}
