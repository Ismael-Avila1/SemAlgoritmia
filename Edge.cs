using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemAlgoritmia
{
    internal class Edge
    {
        Vertex destination;
        float weight;
        List<Point> path;


        public Edge() { }

        public Edge(Vertex destination, float weight, List<Point> path)
        {
            this.destination = destination;
            this.weight = weight;
            this.path = path;
        }


        public Vertex Destination
        {
            get { return destination; }
        }

        public List<Point> Path
        {
            get { return path; }
            set { path = value; }
        }

    }
}
