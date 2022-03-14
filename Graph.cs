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

        public Graph(List<Circle> circlesList)
        {
            vertexList = new List<Vertex>();

            foreach (Circle c_i in circlesList)
                vertexList.Add(new Vertex(c_i.ID, c_i.Center));


            Vertex vertexOrigin;
            Vertex vertexDestination;

            for (int i = 0; i < vertexList.Count; i++) {
                vertexOrigin = vertexList[i];
                for (int j = i + 1; j < vertexList.Count; j++) {
                    vertexDestination = vertexList[j];

                    vertexOrigin.addEdge(vertexDestination, 0, makePath(vertexOrigin, vertexDestination));
                    vertexDestination.addEdge(vertexOrigin, 0, makePath(vertexDestination, vertexOrigin));
                }
            }

        }

        public int VertexCount { get { return vertexList.Count; } }

        public Vertex getVertexAt(int pos) { return vertexList[pos]; }

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

            if (x_f - x_0 == 0) { // Si es una linea recta vertical

                if (y_0 > y_f) // Si el primer click se dio abajo y el segundo arriba
                    inc = -1;

                for (y_k = (int)y_0; y_k != y_f; y_k += inc)
                    path.Add(new Point((int)Math.Round(x_0), y_k));
            }
            else {

                m = (y_f - y_0) / (x_f - x_0);  // m representa la inclnacion de la pendiente en la ecuacion lineal
                b = y_f - m * x_f;              // b es el termino constante de la ecuacion linea. represenra el desplazamiento

                if (m > -1 && m < 1) {

                    if (x_0 > x_f) // Si el primer click se dio a la derecha y el segundo a la izquerda
                        inc = -1;

                    for (x_k = (int)x_0; x_k != x_f; x_k += inc) {
                        y_k = (int)(m * x_k + b);
                        path.Add(new Point(x_k, y_k));
                    }
                }
                else {
                    if (y_0 > y_f) // Si se dio el primer click abajo y el segundo arriba
                        inc = -1;

                    for (y_k = (int)y_0; y_k != y_f; y_k += inc) {
                        x_k = (int)((1 / m) * (y_k - b));
                        path.Add(new Point(x_k, y_k));

                    }
                }
            }

            return path;
        }

    }
}
