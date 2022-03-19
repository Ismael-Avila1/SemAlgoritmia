using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemAlgoritmia
{
    internal class Vertex
    {
        List<Edge> edgesList;
        int id;
        Point position;

        public Vertex()
        {
            edgesList = new List<Edge>();
        }

        public Vertex(int id, Point position)
        {
            edgesList = new List<Edge>();

            this.id = id;
            this.position = position;
        }

        public int Id { get { return id; } }
        public Point Position { get { return position; } }
        public int EdgesCount { get { return edgesList.Count; } }


        public void addEdge(Vertex vertexDestination, float weight, List<Point> path)
        {
            Edge newEdge = new Edge(vertexDestination, weight, path);
            edgesList.Add(newEdge);
        }

        public Vertex getDestinationAt(int pos) { return edgesList[pos].Destination; }

        public List<Point> getEdgePath(int pos) { return edgesList[pos].Path; } 

        public override string ToString()
        {
            return "Vertice " + id;
        }

        //public int findDestinationVertexIndex(int edgeIndex, int vertexToFind)
        //{
        //    for(int i=0; i<edgesList.Count-1; i++) {
        //        if (edgesList[edgeIndex].Destination.Id - 1 == vertexToFind)
        //            return edgesList[edgeIndex].Destination.Id - 1;
        //    }
        //    return -1;
        //}



    }
}
