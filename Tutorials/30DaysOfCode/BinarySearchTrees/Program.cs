﻿using System;

namespace HackerRank.Tutorials._30DaysOfCode.BinarySearchTrees
{
    class Program
    {
        static void Main()
        {
            Node root = null;
            int T = Int32.Parse(Console.ReadLine());
            while (T-- > 0)
            {
                int data = Int32.Parse(Console.ReadLine());
                root = insert(root, data);
            }
            int height = getHeight(root);
            Console.WriteLine(height);

        }

        static Node insert(Node root, int data)
        {
            if (root == null)
            {
                return new Node(data);
            }
            else
            {
                Node cur;
                if (data <= root.data)
                {
                    cur = insert(root.left, data);
                    root.left = cur;
                }
                else
                {
                    cur = insert(root.right, data);
                    root.right = cur;
                }
                return root;
            }
        }

        static int getHeight(Node root)
        {
            var leftHeight = 0;
            var rightHeight = 0;

            if (root.left != null)
            {
                leftHeight = getHeight(root.left) + 1;
            }

            if (root.right != null)
            {
                rightHeight = getHeight(root.right) + 1;
            }

            if (leftHeight > rightHeight)
            {
                return leftHeight;
            }
            else if (rightHeight > leftHeight)
            {
                return rightHeight;
            }
            else
            {
                return 0;
            }
        }
    }

    class Node
    {
        public Node left, right;
        public int data;

        public Node(int data)
        {
            this.data = data;
            left = right = null;
        }
    }
}
