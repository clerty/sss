using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisruptTheLectureImpl
{
    public struct ProfessorsMood
    {
        int _maxReprimandedStudents;
        public int maxReprimandedStudents
        {
            get { return _maxReprimandedStudents; }
            set { _maxReprimandedStudents = value; }
        }
        int _maxReprimandsPerStudent;
        public int maxReprimandsPerStudent
        {
            get { return _maxReprimandsPerStudent; }
            set { _maxReprimandsPerStudent = value; }
        }
    }
    enum LineOfSight
    {
        classroom, blackboard
    }
    public class cProfessor
    {
        public ProfessorsMood mood;
        LineOfSight lineOfSight;
        public int hearingDistance;
        public int reprimandedStudents;

        private cPlayer PlayerTalkWithNeighbourSender;
        public void SetPlayerTalkWithNeighbourSender(cPlayer x)
        {
            PlayerTalkWithNeighbourSender = x;
            if (CanHear(x))
                PlayerTalkWithNeighbourSender.PlayerTalkWithNeighbourEventList += new cPlayer.PlayerTalkWithNeighbourEventHandler(ProfessorPlayerTalkWithNeighbourEventHandler);
        }
        public void ProfessorPlayerTalkWithNeighbourEventHandler(cPlayer sender)
        {
            sender.heard = true;
            MakeReprimand(sender);
        }

        private cPlayer PlayerThrowPaperSender;
        public void SetPlayerThrowPaperSender(cPlayer x)
        {
            PlayerThrowPaperSender = x;
            PlayerThrowPaperSender.PlayerThrowPaperEventList += new cPlayer.PlayerThrowPaperEventHandler(ProfessorPlayerThrowPaperEventHandler);
        }
        public void ProfessorPlayerThrowPaperEventHandler(cPlayer sender)
        {
            if (lineOfSight == LineOfSight.classroom)
            {
                sender.heard = true;
                MakeReprimand(sender);
            }
        }

        public void MakeReprimand(cStudent target)
        {
            target.reprimands++;
            target.StudentProfessorMakeReprimandEventHandler(this);
        } //TODO
        public bool CanHear(cStudent source)
        {
            sCoords playerCoords = cСlassroom.Seat(source);
            return playerCoords.x >= source.volume;
        }
    }
}
