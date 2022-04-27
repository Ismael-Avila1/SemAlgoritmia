using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemAlgoritmia
{
    internal class MyTree
    {
        MyTreeNode root;


        public MyTree()
        {
            root = new MyTreeNode();
        }

        public MyTree(Vertex data)
        {
            root = new MyTreeNode(data, null);
        }


        public MyTreeNode Root
        {
            get { return root; }
            set { root = value; }
        }
        
        
        public List<Vertex> inorder()
        {
            List<Vertex> vertices = new List<Vertex>();
            inorder(root, vertices);
            return vertices;
        }

        void inorder(MyTreeNode root, List<Vertex> vertices)
        {
            vertices.Add(root.Data);

            for(int i=0; i<root.ChildrenCount; i++) {
                inorder(root.getChildAt(i), vertices);
                vertices.Add(root.Data);
            }
        }

        
        public MyTreeNode find(Vertex v)
        {
            return find(root, v);
        }
        
        MyTreeNode find(MyTreeNode node, Vertex v)
        {
            if(node.Data.Id == v.Id)
                return node;

            MyTreeNode foundNode;

            for(int i=0; i<node.ChildrenCount; i++) {
                MyTreeNode aux = node.getChildAt(i);

                foundNode = find(aux, v);
                if(foundNode != null)
                    return foundNode;
            }

            return null;
        }

    }
}
