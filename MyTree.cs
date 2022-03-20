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

        public void insert(Vertex data, MyTreeNode node)
        {
            node.addChild(data);
        }

        public void inorder(MyTreeNode root)
        {
            Console.Write(root.Data.Id.ToString());

            for(int i=0; i< root.ChildrenCount; i++) {
                inorder(root.getChildAt(i));
                Console.Write(root.Data.Id.ToString());
            }
        }

    }
}
