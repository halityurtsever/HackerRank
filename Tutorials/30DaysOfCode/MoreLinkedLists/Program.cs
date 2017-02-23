using System;
using System.Collections.Generic;

namespace HackerRank.Tutorials._30DaysOfCode.MoreLinkedLists
{
    class Program
    {
        public static Node insert(Node head, int data)
        {
            Node p = new Node(data);


            if (head == null)
                head = p;
            else if (head.next == null)
                head.next = p;
            else
            {
                Node start = head;
                while (start.next != null)
                    start = start.next;
                start.next = p;

            }
            return head;
        }
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
            head = removeDuplicates(head);
            display(head);
        }

        private static List<int> distinctList = new List<int>();
        private static Node removeDuplicates(Node head)
        {
            var start = head;
            var previous = start;

            while (start != null)
            {
                if(distinctList.Contains(start.data))
                {
                    previous.next = start.next;
                    start = start.next;
                    continue;
                }
                distinctList.Add(start.data);
                previous = start;
                start = start.next;
            }

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
