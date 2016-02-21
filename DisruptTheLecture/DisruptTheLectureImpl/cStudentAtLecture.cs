using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisruptTheLectureImpl
{
    class cStudentAtLecture : cStudent
    {
        int patience = 100;
        int interest;
        bool IsNeighbour(cPlayer source)
        {
            sCoords studCoords = cСlassroom.Seat(this);
            sCoords playerCoords = cСlassroom.Seat(source);
            return (studCoords.x == playerCoords.x) && (Math.Abs(studCoords.y - playerCoords.y) == 1);
        }
        bool CanHear(cPlayer source)
        {
            sCoords studCoords = cСlassroom.Seat(this);
            sCoords playerCoords = cСlassroom.Seat(source);
            return (Math.Abs(studCoords.x - playerCoords.x) <= source.volume) | (Math.Abs(studCoords.y - playerCoords.y) <= source.volume);
        }
        bool InRadius(cPlayer source)
        {
            sCoords studCoords = cСlassroom.Seat(this);
            sCoords playerCoords = cСlassroom.Seat(source);
            return (Math.Abs(studCoords.x - playerCoords.x) <= source.radiusOfGettingPaper) | (Math.Abs(studCoords.y - playerCoords.y) <= source.radiusOfGettingPaper);
        }

        cPlayer Player;

        //private cPlayer PlayerTalkWithNeighbourSender;
        public void SetPlayerTalkWithNeighbourSender(cPlayer x)
        {
            Player = x;
            if (CanHear(x) && !IsNeighbour(x))
                Player.PlayerTalkWithNeighbourEventList += new cPlayer.PlayerTalkWithNeighbourEventHandler(StudentPlayerTalkWithNeighbourEventHandler);
        }
        public void StudentPlayerTalkWithNeighbourEventHandler(cPlayer sender)
        {
            if (interest != 0)
            {
                patience -= 17;
                if (patience <= 0)
                    TellOn(sender); //TODO
            }
        }
        public override void NeighbourPlayerTalkWithNeighbourEventHandler(cPlayer sender)
        {
            Random rand = new Random();
            switch (interest)
            {
                case 0:
                    break;
                case 1:
                    if (rand.Next(0, 1) == 0)
                    {
                        NeighbourPlayerTalkWithNeighbourEventHandler(sender);
                    };
                    patience-=34;
                    if (patience <= 0)
                        TellOn(sender);
                    break;
                case 2:
                    patience-=50;
                    if (patience <= 0)
                        TellOn(sender);
                    else
                        ChangeSeat(); //TODO
                    break;
            }
        }

        //private cPlayer PlayerThrowPaperSender;
        public void SetPlayerThrowPaperSender(cPlayer x)
        {
            Player = x;
            if (InRadius(x))
                Player.PlayerThrowPaperEventList += new cPlayer.PlayerThrowPaperEventHandler(StudentPlayerThrowPaperEventHandler);
        }
        public void StudentPlayerThrowPaperEventHandler(cPlayer sender/*, cProfessor pr*/)
        {
            patience -= 17;
            if (patience <= 0)
                TellOn(sender); //TODO
        }
        public override void VictimPlayerThrowPaperEventHandler(cPlayer sender/*, cProfessor pr*/)
        {
            
        }

        public override void StudentProfessorMakeReprimandEventHandler(cProfessor sender)
        {
            TellOn(Player, sender);
        }
        public void TellOn(cPlayer guilty, cProfessor target)
        {
            target.MakeReprimand(guilty);
        }

        public cStudentAtLecture()
        {

        }
    }
}
