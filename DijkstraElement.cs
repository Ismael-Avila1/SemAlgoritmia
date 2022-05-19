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


        public DijkstraElement()
        {

        }

        public DijkstraElement(bool definitive, float accumulatedWeight, Vertex comimgFrom) 
        {
            this.definitive = definitive;
            this.accumulatedWeight = accumulatedWeight;
            this.comimgFrom = comimgFrom;
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
