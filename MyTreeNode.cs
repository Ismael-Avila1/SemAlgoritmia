using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemAlgoritmia
{
    internal class MyTreeNode
    {
        List<MyTreeNode> children;
        Vertex data;
        MyTreeNode father;


        public MyTreeNode()
        {
            children = new List<MyTreeNode>();
        }

        public MyTreeNode(Vertex data, MyTreeNode father)
        {
            children = new List<MyTreeNode>();

            this.data = data;
            this.father = father;
        }

        public void addChild(MyTreeNode child)
        {
            children.Add(child);
        }

        public MyTreeNode getChildAt(int pos)
        {
            return children[pos];
        }

        public Vertex Data
        {
            get { return data; }
            set { data = value; }
        }

        public int ChildrenCount
        {
            get { return children.Count; }
        }

        public MyTreeNode Father
        {
            get { return father; }
        }

    }
}
