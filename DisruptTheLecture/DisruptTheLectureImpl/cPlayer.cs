using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisruptTheLectureImpl
{
    public enum Direction
    {
        left, right
    }
    public class cPlayer : cStudent
    {
        int _volume = 4;
        public int volume
        {
            get { return _volume; }
        }

        int _radiusOfGettingPaper = 6;
        public int radiusOfGettingPaper
        {
            get { return _radiusOfGettingPaper; }
        }

        bool _heard = false;
        public bool heard
        {
            get { return _heard; }
            set { _heard = value; }
        }
        bool _seen = false;
        public bool seen
        {
            get { return _seen; }
            set { _seen = value; }
        }

        bool _expelled = false;
        public bool expelled
        {
            get { return _expelled; }
            set { _expelled = value; }
        }

        public delegate void PlayerTalkWithNeighbourEventHandler(cPlayer sender);
        public event PlayerTalkWithNeighbourEventHandler PlayerTalkWithNeighbourEventList;
        public override void TalkWithNeighbour(Direction direction)
        {
            if (PlayerTalkWithNeighbourEventList != null) PlayerTalkWithNeighbourEventList(this);
            if (!_heard)
            {
                sCoords playerCoords = cСlassroom.Seat(this);
                switch (direction)
                {
                    case Direction.left:
                        cСlassroom.classroom[playerCoords.x][playerCoords.y - 1].NeighbourPlayerTalkWithNeighbourEventHandler(this);
                        break;
                    case Direction.right:
                        cСlassroom.classroom[playerCoords.x][playerCoords.y + 1].NeighbourPlayerTalkWithNeighbourEventHandler(this);
                        break;
                }
            }
        }

        public delegate void PlayerThrowPaperEventHandler(cPlayer sender, cStudentAtLecture target);
        public event PlayerThrowPaperEventHandler PlayerThrowPaperEventList;
        public void ThrowPaper(cStudent target)
        {

            if (PlayerThrowPaperEventList != null) PlayerThrowPaperEventList(this, target);
            if (!_seen)
            {
                target.VictimPlayerThrowPaperEventHandler(this);
            }
        }

        public override void StudentProfessorMakeReprimandEventHandler(cProfessor sender)
        {
            
        }
        public override void ChangeSeat(sCoords coords)
        {
            
        }
    }
}
