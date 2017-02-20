using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class Program
    {
        public static void display(Node head)
        {
            Node start = head;
            while (start != null)
            {
                Console.Write(start.data + " ");
                start = start.next;
            }
        }
        static void Main(String[] args)
        {

            Node head = null;
            int T = Int32.Parse(Console.ReadLine());
            while (T-- > 0)
            {
                int data = Int32.Parse(Console.ReadLine());
                head = insert(head, data);
            }
            display(head);
        }

        private static Node insert(Node head, int data)
        {
            var newNode = new Node(data);

            if (head == null)
            {
                return newNode;
            }

            Node lastNode = null;
            Node currentNode = head;
            while (true)
            {
                if (currentNode.next != null)
                {
                    currentNode = currentNode.next;
                    continue;
                }
                lastNode = currentNode;
                break;
            }

            lastNode.next = newNode;

            return head;
        }
    }

    class Node
    {
        public int data;
        public Node next;
        public Node(int d)
        {
            data = d;
            next = null;
        }

    }
}
