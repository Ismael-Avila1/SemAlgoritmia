using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemAlgoritmia
{
    internal class Circle
    {
        int id;
        Point center;
        int r;


        public Circle() { }

        public Circle(int id, Point center, int r)
        {
            this.id = id;
            this.center = center;
            this.r = r;
        }


        public int ID
        {
            get { return id; }
        }

        public Point Center
        {
            get { return center; }
        }

        public int R
        {
            get { return r; }
        }

    }
}
