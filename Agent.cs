using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemAlgoritmia
{
    internal class Agent
    {
        int vertexIndex;
        List<Point> path;

        List<VisitedPaths> visitedPaths;

        public Agent()
        {
            path = new List<Point>();
            visitedPaths = new List<VisitedPaths>();
        }

        public Agent(int vertexIndex)
        {
            path = new List<Point>();
            visitedPaths = new List<VisitedPaths>();

            this.vertexIndex = vertexIndex;
        }

        public int VertexIndex
        {
            get { return vertexIndex; }
            set { vertexIndex = value; }
        }

        public List<Point> Path
        {
            get { return path; }
            set { path = value; }
        }

        public List<VisitedPaths> VisitedPaths { get { return visitedPaths; } }


        public void addVisitedPath(VisitedPaths path) { visitedPaths.Add(path); }

        public bool pathAlreadyVisited(VisitedPaths path)
        {
            for (int i = 0; i < visitedPaths.Count; i++)
                if (visitedPaths[i].VertexIndex == path.VertexIndex && visitedPaths[i].EdgeIndex == path.EdgeIndex)
                    return true;

            return false;
        }

    }
}
