using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemAlgoritmia
{
    internal class Objetive
    {
        Vertex objetiveVertex;

        public Objetive() { }

        public Objetive(Vertex objetiveVertex)
        {
            this.objetiveVertex = objetiveVertex;
        }


        public Vertex ObjetiveVertex
        {
            get { return objetiveVertex; }
            set { objetiveVertex = value; }
        }

    }
}
