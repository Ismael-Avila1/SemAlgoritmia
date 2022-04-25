using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemAlgoritmia
{
    internal class Graph
    {
        List<Vertex> vertexList;


        public Graph()
        {
            vertexList = new List<Vertex>();
        }

        public Graph(List<Circle> circlesList, Bitmap bmp)
        {
            vertexList = new List<Vertex>();

            foreach(Circle c_i in circlesList)
                vertexList.Add(new Vertex(c_i.ID, c_i.Center));

            Vertex vertexOrigin;
            Vertex vertexDestination;

            for(int i=0; i<vertexList.Count; i++) {
                vertexOrigin = vertexList[i];
                
                for(int j=i+1; j<vertexList.Count; j++) {
                    vertexDestination = vertexList[j];

                    List<Point> pathOriginToDestination;

                    pathOriginToDestination = makePath(vertexOrigin, vertexDestination);

                    if(existEdge(pathOriginToDestination, bmp)) {

                        List<Point> pathDestinationToOrigin = makePath(vertexDestination, vertexOrigin);

                        vertexOrigin.addEdge(new Edge(vertexOrigin, vertexDestination, pathOriginToDestination));
                        vertexDestination.addEdge(new Edge(vertexDestination, vertexOrigin, pathDestinationToOrigin));
                    }
                }
            }

        }


        public Vertex getVertexAt(int pos)
        {
            return vertexList[pos];
        }

        public List<Point> makePath(Vertex vertexOrigin, Vertex vertexDestination)
        {
            float x_0, y_0;
            float x_f, y_f;

            int x_k, y_k; // estas variables se usan para iterar

            float m, b;

            int inc = 1;

            List<Point> path = new List<Point>();


            x_0 = vertexOrigin.Position.X;
            y_0 = vertexOrigin.Position.Y;

            x_f = vertexDestination.Position.X;
            y_f = vertexDestination.Position.Y;

            if(x_f - x_0 == 0) { // Si es una linea recta vertical
                if(y_0 > y_f) // Si el primer click se dio abajo y el segundo arriba
                    inc = -1;

                for(y_k=(int)y_0; y_k!=y_f; y_k+=inc)
                    path.Add(new Point((int)Math.Round(x_0), y_k));
            }
            else {
                m = (y_f - y_0) / (x_f - x_0);  // m representa la inclnacion de la pendiente en la ecuacion lineal
                b = y_f - m * x_f;              // b es el termino constante de la ecuacion linea. represenra el desplazamiento

                if(m > -1 && m < 1) {
                    if (x_0 > x_f) // Si el primer click se dio a la derecha y el segundo a la izquerda
                        inc = -1;

                    for (x_k=(int)x_0; x_k!=x_f; x_k+=inc) {
                        y_k = (int)(m * x_k + b);
                        path.Add(new Point(x_k, y_k));
                    }
                }
                else {
                    if(y_0 > y_f) // Si se dio el primer click abajo y el segundo arriba
                        inc = -1;

                    for(y_k=(int)y_0; y_k!=y_f; y_k+=inc) {
                        x_k = (int)((1 / m) * (y_k - b));
                        path.Add(new Point(x_k, y_k));
                    }
                }
            }

            return path;
        }

        bool isWhite(Color color)
        {
            if (color.R == 255)
                if (color.G == 255)
                    if (color.B == 255)
                        return true;
            return false;
        }

        bool isBlack(Color color)
        {
            if (color.R == 0)
                if (color.G == 0)
                    if (color.B == 0)
                        return true;
            return false;
        }

        bool existEdge(List<Point> path, Bitmap bmp)
        {
            int i = 0;

            while (isBlack(bmp.GetPixel(path[i].X, path[i].Y)))     // mientras estemos dentro del circulo negro de origen
                i++;
            // ya salimos del circulo de origen


            while(isWhite(bmp.GetPixel(path[i].X, path[i].Y))) { // mientras no encontremos algo diferente de blanco
                if (!isWhite(bmp.GetPixel(path[i].X, path[i].Y)) && !isBlack(bmp.GetPixel(path[i].X, path[i].Y))) // color diferente de negro y blanco
                    return false; // Se encontro con un obstaculo
                i++;
            } // llegamos a un circulo


            while(i < path.Count-1) {
                if (isWhite(bmp.GetPixel(path[i].X, path[i].Y))) // llegamos a un pixel blanco, o sea, no era el ciruclo destino y i está afuera del circulo
                    return false;
                i++;
            }

            return true;
        }


        public MyTree DFS(Agent agent, Objetive objetive)
        {
            agent.VisitedVertices.Clear();

            Vertex v_o = getVertexAt(agent.VertexIndex);
            Vertex v_obj = getVertexAt(objetive.VertexIndex);

            MyTree tree = new MyTree(v_o);

            bool exist = true;

            DFS(v_o, agent.VisitedVertices, tree.Root, exist, v_obj);

            return tree;
        }

        Vertex DFS(Vertex v_o, List<Vertex> visited, MyTreeNode root, bool exist, Vertex v_obj)
        {
            visited.Add(v_o);

            if (v_o.Id == v_obj.Id) // si ya se llego al objetivo
                return v_o;

            List<Vertex> unvisitedFromV_O = new List<Vertex>();

            for (int i=0; i<v_o.EdgesCount; i++) {
                exist = false;

                Vertex v_i = v_o.getDestinationAt(i);
                for (int j=0; j<visited.Count; j++)
                    if (visited[j] == v_i) {
                        exist = true;
                        break;
                    }
                if (!exist)
                    unvisitedFromV_O.Add(v_i);
            }


            Random rand = new Random(DateTime.Now.Millisecond);

            while (unvisitedFromV_O.Count > 0) {
                int r = rand.Next(0, unvisitedFromV_O.Count);

                MyTreeNode child = new MyTreeNode(unvisitedFromV_O[r], root);
                root.addChild(child);

                Vertex vSol = DFS(unvisitedFromV_O[r], visited, child, exist, v_obj);

                if (vSol != null)
                    return vSol;

                unvisitedFromV_O.Clear();

                for (int i=0; i<v_o.EdgesCount; i++) {
                    exist = false;

                    Vertex v_i = v_o.getDestinationAt(i);
                    for (int j=0; j<visited.Count; j++)
                        if (visited[j] == v_i) {
                            exist = true;
                            break;
                        }
                    if (!exist)
                        unvisitedFromV_O.Add(v_i);
                }
            }

            return null;
        }


        public MyTree BFS(Agent agent, Objetive objetive)
        {
            agent.VisitedVertices.Clear();

            Vertex v_o = getVertexAt(agent.VertexIndex);
            Vertex v_obj = getVertexAt(objetive.VertexIndex);

            Queue<Vertex> q = new Queue<Vertex>();

            agent.VisitedVertices.Add(v_o);
            q.Enqueue(v_o);


            MyTree tree = new MyTree(v_o);

            BFS(q, agent, v_o, tree.Root, v_obj, tree);

            return tree;
        }

        void BFS(Queue<Vertex> q, Agent agent, Vertex v_o, MyTreeNode root, Vertex v_obj, MyTree tree)
        {
            if (q.Count == 0)
                return;

            v_o = q.Dequeue();
            root = tree.find(tree.Root, v_o);

            for (int i=0; i<v_o.EdgesCount; i++)
                if (!agent.isVertexVisited(v_o.getDestinationAt(i))) {
                    q.Enqueue(v_o.getDestinationAt(i));

                    MyTreeNode child = new MyTreeNode(v_o.getDestinationAt(i), root);
                    root.addChild(child);

                    agent.VisitedVertices.Add(v_o.getDestinationAt(i));

                    if (v_o.getDestinationAt(i) == v_obj) {
                        q.Clear();
                        return;
                    }
                }

            BFS(q, agent, v_o, root, v_obj, tree);
        }

        public int VertexCount
        {
            get { return vertexList.Count; }
        }

    }
}
