using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DisruptTheLectureImpl;

namespace DisruptTheLecture
{
    class Program
    {
        static cСlassroom classroom;
        static cPlayer player;
        static cProfessor professor;
        static void Main(string[] args)
        {
            // рассадка в аудиторию
            FillClassroom();
            // пока не кончилась пара && игрок не выгнан && макс. кол-во студентов с замечаниями не превышено
            while (!lectionIsEnded && !player.expelled && (professor.reprimandedStudents < professor.mood.maxReprimandedStudents))
            {
                chooseAction();
            }
        }
    }
}
