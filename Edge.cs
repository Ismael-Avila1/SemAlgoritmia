using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemAlgoritmia
{
    internal class Edge
    {
        Vertex origin;
        Vertex destination;
        float weight;
        List<Point> path;


        public Edge() { }

        public Edge(Vertex origin, Vertex destination, float weight, List<Point> path)
        {
            this.origin = origin;
            this.destination = destination;
            this.weight = weight;
            this.path = path;
        }

        public Vertex Origin
        {
            get { return origin; }
        }

        public Vertex Destination
        {
            get { return destination; }
        }

        public float Weight
        {
            get { return weight; }
        }

        public List<Point> Path
        {
            get { return path; }
            set { path = value; }
        }

    }
}
