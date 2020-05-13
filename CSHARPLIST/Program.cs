using System;
using System.IO;

namespace list
{
    public class Node
    {
        public int data;
        public Node next;
        public Node(int data)
        {
            this.data = data;
            next = null;
        }
        public void Print()
        {
            Console.Write(data);
            if (next != null)
            {
                next.Print();
            }

        }

        public void AddtoEnd(int data)
        {
            if (next == null)
            {
                next = new Node(data);
            }
            else
            {
                next.AddtoEnd(data);
            }
        }
        public void Sort(int data)
        {
            if (next == null)
            {
                next = new Node(data);
            }
            else if (data < next.data)
            {
                Node temp = new Node(data);
                temp.next = this.next;
                this.next = temp;
            }
            else
            {
                next.Sort(data);
            }

        }

        public class Mylist
        {
            public Node headNode;
            public int length;
            public Mylist()
            {
                length = 0;
                headNode = null;
            }
            public void AddToBegin(int data)
            {
                Node node = new Node(data);
                length++;
                if (headNode == null) headNode = node;
                else
                {
                    node.next = headNode;
                    headNode = node;
                }
            }
            public void Print()
            {
                Node node = headNode;
                for (int i = 0; i < length; i++)
                {
                    Console.Out.Write(node.data + " ");
                    node = node.next;
                }
                Console.Out.WriteLine();
            }
            public void Add(int ind, int data)
            {
                length++;
                Node node = headNode;
                if (ind == 0) AddToBegin(data);
                else
                {
                    for (int i = 0; i < ind - 1; i++)
                    {
                        node = node.next;
                    }
                    Node temp = node.next;
                    node.next = new Node(data)
                    {
                        next = temp
                    };
                }
            }
            public void AddToEnd(int data)
            {
                Add(length, data);
            }
            public int Find(int key)
            {
                Node node = headNode;
                for (int i = 0; i < length; i++)
                {
                    if (node.data == key) return i;
                    node = node.next;
                }
                return -1;
            }
            public void Delete(int ind)
            {
                Node node = headNode;
                length--;
                if (ind == 0) headNode = headNode.next;
                else
                {
                    for (int i = 0; i < ind - 1; i++)
                        node = node.next;
                    node.next = node.next.next;
                }
            }
            public void Sort(int data)
            {
                if (headNode == null)
                {
                    headNode = new Node(data);
                }
                else if (data < headNode.data)
                {
                    AddToBegin(data);

                }
                else
                {
                    headNode.Sort(data);
                }

            }
            public void PrintFile(string path)
            {
                Node node = headNode;
                for (int i = 0; i < length; i++)
                {
                    File.AppendAllText(path, node.data + " ");
                    node = node.next;
                }
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                Mylist l = new Mylist();
                l.AddToBegin(3);
                l.AddToBegin(4);
                l.AddToBegin(0);
                l.Add(3, 6);
                l.Add(2, 7);
                l.AddToEnd(6);
                l.Print();
                l.Sort(-1);
                l.Print();
                l.PrintFile("output.txt");
            }
        }
    }
}