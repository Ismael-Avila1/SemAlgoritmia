using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemAlgoritmia
{
    internal class Objetive
    {
        int vertexIndex;

        public Objetive() { }

        public Objetive(int vertexIndex)
        {
            this.vertexIndex = vertexIndex;
        }

        public int VertexIndex
        {
            get { return vertexIndex; }
        }

    }
}
