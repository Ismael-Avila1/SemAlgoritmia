﻿using System;
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

        //public void insert(Vertex data, MyTreeNode node)
        //{
        //    node.addChild(data);
        //}

        public void inorder(Label lbl)
        {
            inorder(root, lbl);
        }

        void inorder(MyTreeNode root, Label lbl)
        {
            //Console.Write(root.Data.Id.ToString());
            lbl.Text = lbl.Text + root.Data.Id.ToString() + ", ";

            for(int i=0; i< root.ChildrenCount; i++) {
                inorder(root.getChildAt(i), lbl);
                //Console.Write(root.Data.Id.ToString());
                lbl.Text = lbl.Text + root.Data.Id.ToString() + ", ";
            }
        }

        public MyTreeNode find(MyTreeNode node, Vertex v)
        {
            if(node.Data.Id == v.Id)
                return node;

            for(int i=0;i<node.ChildrenCount;i++) {
                MyTreeNode child = node.getChildAt(i);
                if (child.Data == v)
                    return child;
                find(child, v);
            }
            return null;
        }


        public MyTreeNode Root { get { return root; } }
    }
}