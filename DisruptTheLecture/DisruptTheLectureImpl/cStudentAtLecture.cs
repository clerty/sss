using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisruptTheLectureImpl
{
    class cStudentAtLecture : cStudent, IPlayersListener, IProfessorsListener
    {
        int patience = 100;
        int interest;
        bool IsNeighbour(cPlayer source) //TODO
        {
            return true;
        }
        public override bool CanHear(cPlayer source) //TODO
        {
            return true;
        }
        private cPlayer PlayerTalkWithNeighbourSender;
        public void SetPlayerTalkWithNeighbourSender(cPlayer x)
        {
            PlayerTalkWithNeighbourSender = x;
            if (IsNeighbour(x))
                PlayerTalkWithNeighbourSender.PlayerTalkWithNeighbourEventList += new cPlayer.PlayerTalkWithNeighbourEventHandler(NeighbourPlayerTalkWithNeighbourEventHandler);
            else if (CanHear(x))
                PlayerTalkWithNeighbourSender.PlayerTalkWithNeighbourEventList += new cPlayer.PlayerTalkWithNeighbourEventHandler(StudentPlayerTalkWithNeighbourEventHandler);
        }
        public override void StudentPlayerTalkWithNeighbourEventHandler(cPlayer sender)
        {
            if (interest != 0)
                patience-=17;
        }
        public override void NeighbourPlayerTalkWithNeighbourEventHandler(cPlayer sender)
        {
            Random rand = new Random();
            switch (interest)
            {
                case 0:
                    break;
                case 1:
                    if (rand.Next(0, 1) == 0) {};
                    patience-=34;
                    break;
                case 2:
                    patience-=50;
                    break;
            }
        }
        public override void StudentPlayerThrowPaperEventHandler(cPlayer sender)
        {

        }
        public override void StudentProfessorMakeReprimandEventHandler(cProfessor sender, cPlayer pl)
        {
            if (sender.CanHear(this))
            {
                sender.MakeReprimand(this);
                TellOn(pl, sender);
            }
        }
        public override void TellOn(cPlayer culprit, cProfessor target)
        {
            target.MakeReprimand(culprit);
        }
    }
}
