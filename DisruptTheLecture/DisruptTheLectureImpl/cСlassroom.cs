using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisruptTheLectureImpl
{
    static class cСlassroom
    {
        static cStudent[,] _classroom = new cStudent[4, 10];
        public static cStudent[,] classroom
        {
            get { return _classroom; }
            set { _classroom = value; }
        }
    }
}
