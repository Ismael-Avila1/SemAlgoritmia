using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemAlgoritmia
{
    internal class DijkstraElement
    {
        bool definitive;
        float accumulatedWeight;
        Vertex comimgFrom;
        Vertex vertex;

        public DijkstraElement()
        {

        }

        public DijkstraElement(bool definitive, float accumulatedWeight, Vertex comimgFrom, Vertex vertex) 
        {
            this.definitive = definitive;
            this.accumulatedWeight = accumulatedWeight;
            this.comimgFrom = comimgFrom;
            this.vertex = vertex;
        }


        public bool Definitive
        {
            get { return definitive; }
            set { definitive = value; }
        }

        public float AccumulatedWeight
        {
            get { return accumulatedWeight; }
            set { accumulatedWeight = value; }
        }

        public Vertex ComimgFrom
        {
            get { return comimgFrom; }
            set { comimgFrom = value; }
        }


    }
}
