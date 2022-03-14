using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemAlgoritmia
{
    internal class VisitedPaths
    {
        int vertexIndex;
        int edgeIndex;

        public VisitedPaths() { }

        public VisitedPaths(int vertex, int edgeIndex)
        {
            this.vertexIndex = vertex;
            this.edgeIndex = edgeIndex;
        }

        public int VertexIndex
        {
            get { return vertexIndex; }
            set { vertexIndex = value; }
        }

        public int EdgeIndex
        {
            get { return edgeIndex; }
            set { edgeIndex = value; }
        }

        public override string ToString()
        {
            string s;
            s = "Del vertice -> " + (vertexIndex + 1) + " por su arista: " + (edgeIndex + 1);

            return s;
        }


    }
}
