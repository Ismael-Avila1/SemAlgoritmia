using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemAlgoritmia
{
    internal class Agent
    {
        Vertex agentVertex;
        List<Point> path;
        List<VisitedPaths> visitedPaths;
        List<Vertex> visitedVertices;
        
        Queue<Edge> shortestPath;
        int indexPath;
        Point position;
        Vertex currentVertex;


        public Agent()
        {
            path = new List<Point>();
            visitedPaths = new List<VisitedPaths>();
            visitedVertices = new List<Vertex>();
        }

        public Agent(Vertex agentVertex)
        {
            path = new List<Point>();
            visitedPaths = new List<VisitedPaths>();
            visitedVertices = new List<Vertex>();

            this.agentVertex = agentVertex;
            currentVertex = agentVertex;
            indexPath = 0;
        }


        public Vertex AgentVertex
        {
            get { return agentVertex; }
            set { agentVertex = value; }
        }

        public List<Point> Path
        {
            get { return path; }
            set { path = value; }
        }

        public List<VisitedPaths> VisitedPaths
        {
            get { return visitedPaths; }
        }

        public List<Vertex> VisitedVertices
        {
            get { return visitedVertices; }
        }

        public Queue<Edge> ShortestPath
        {
            get { return shortestPath; }
            set { shortestPath = value; }
        }

        public Point Position
        {
            get { return position; }
        }

        public Vertex CurrentVertex
        {
            get { return currentVertex; }
            set { CurrentVertex = value; }
        }


        public int IndexPath
        {
            get { return IndexPath; }
            set { indexPath = value; }
        }


        public void addVisitedPath(VisitedPaths path)
        {
            visitedPaths.Add(path);
        }

        public bool pathAlreadyVisited(VisitedPaths path)
        {
            for(int i=0; i<visitedPaths.Count; i++)
                if(visitedPaths[i].VertexIndex == path.VertexIndex && visitedPaths[i].EdgeIndex == path.EdgeIndex)
                    return true;
            return false;
        }

        public void addVisitedVertex(Vertex vertex) 
        {
            visitedVertices.Add(vertex);
        }

        public bool isVertexVisited(Vertex vertex)
        {
            for(int i=0; i<visitedVertices.Count; i++)
                if(visitedVertices[i].Id == vertex.Id)
                    return true;
            return false;
        }


        public bool walk()
        {
            if(indexPath == shortestPath.Peek().Path.Count - 1) {
                Edge e = shortestPath.Dequeue();
                
                currentVertex = e.Destination;
                indexPath = 0;

                if(shortestPath.Count == 0)
                    return false;
            }

            if(indexPath + 8 < shortestPath.Peek().Path.Count)
                indexPath += 8;
            else 
                indexPath = shortestPath.Peek().Path.Count - 1;
            
            position = shortestPath.Peek().Path[indexPath];
            return true;
        }


        public bool fisishEdge()
        {
            if(shortestPath.Count == 0)
                return false;

            if(indexPath + 8 <= shortestPath.Peek().Path.Count -1) {
                if(indexPath + 8 < shortestPath.Peek().Path.Count - 1)
                    indexPath += 8;
                else
                    indexPath = shortestPath.Peek().Path.Count - 1;
                return true;
            }

            Edge e = shortestPath.Dequeue();
            currentVertex = e.Destination;
            indexPath = 0;

            return false;
        }




    }
}
