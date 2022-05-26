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


        public List<Edge> EdgesList
        {
            get { return edgesList; }
        }

        public int Id
        {
            get { return id; }
        }

        public Point Position
        {
            get { return position; }
        }

        public int EdgesCount
        {
            get { return edgesList.Count; }
        }
        
        
        public void addEdge(Edge newEdge)
        {
            edgesList.Add(newEdge);
        }

        public Vertex getDestinationAt(int pos)
        {
            return edgesList[pos].Destination;
        }

        public List<Point> getEdgePath(int pos)
        {
            return edgesList[pos].Path;
        }

        public override string ToString()
        {
            return "Vertice " + id;
        }

        public int findDestinationVertexIndex(Vertex vertexOrigin, Vertex vertexDestination)
        {
            for (int i=0; i < vertexOrigin.EdgesCount; i++)
                if(vertexOrigin.getDestinationAt(i) == vertexDestination)
                    return i;
            return -1;
        }

        public Edge getEdge(Vertex destination)
        {
            for(int i=0; i<edgesList.Count; i++)
                if(edgesList[i].Destination == destination)
                    return edgesList[i];

            return null;
        }


    }
}
