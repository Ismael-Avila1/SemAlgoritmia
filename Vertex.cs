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
        Circle circle;

        public Vertex()
        {
            edgesList = new List<Edge>();
        }

        public Vertex(Circle circle)
        {
            edgesList = new List<Edge>();

            this.circle = circle;
        }


        public List<Edge> EdgesList
        {
            get { return edgesList; }
        }

        public int Id
        {
            get { return circle.ID; }
        }

        public Point Position
        {
            get { return circle.Center; }
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
            return "Vertice " + circle.ID.ToString();
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
