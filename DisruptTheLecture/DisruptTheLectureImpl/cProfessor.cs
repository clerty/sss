using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisruptTheLectureImpl
{
    struct ProfessorsMood
    {
        int _maxReprimandedStudents;
        public int maxReprimandedStudents
        {
            get { return _maxReprimandedStudents; }
            set { _maxReprimandedStudents = value; }
        }
        int _maxReprimandPerStudent;
        public int maxReprimandsPerStudent
        {
            get { return _maxReprimandsPerStudent; }
            set { _maxReprimandsPerStudent = value; }
        }
    }
    class cProfessor : IPlayersListener
    {
        ProfessorsMood mood;
        bool lineOfSight;
        int hearingDistance;
        public void MakeReprimand(cStudentAtLecture target)
        {
            target.reprimands++;
            if (target.reprimands > mood.maxReprimandsPerStudent)
        }
        public void MakeReprimand(cPlayer target)
        {
            target.reprimands++;
        }
        public override bool CanHear(cStudent source) //TODO
        {
            return true;
        }
    }
}
