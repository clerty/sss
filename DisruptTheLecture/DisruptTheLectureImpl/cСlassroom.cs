using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisruptTheLectureImpl
{
    public struct sCoords
    {
        public int x, y;
        public sCoords(int p1, int p2)
        {
            x = p1;
            y = p2;
        }
    }
    public static class cСlassroom
    {
        static cStudent[][] _classroom = new cStudent[4][]
    {
        new cStudent[10],
        new cStudent[10],
        new cStudent[10],
        new cStudent[10] 
    };
        public static cStudent[][] classroom
        {
            get { return _classroom; }
            set { _classroom = value; }
        }
        public static sCoords Seat(cStudent soughtFor)
        {
            bool found = false;
            int i = 0, j = 0;
            while (!found && (i <= _classroom.Length))
                while (!found && (j <= _classroom[i].Length))
                {
                    found = _classroom[i][j] == soughtFor;
                    if (!found)
                    {
                        i++;
                        j++;
                    }
                }
            return new sCoords(i, j);
        }
    }
}
