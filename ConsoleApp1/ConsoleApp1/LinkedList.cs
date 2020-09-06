using System;
using System.Collections.Generic;
using System.Text;

namespace Interview
{
    public class LinkedList
    {
        public Node Head { get; set; }
        public void InsertFront(int data)
        {
            Node n = new Node { data = data };
            n.Next = this.Head;
            this.Head = n;
        }

        public Node GetLastNode(LinkedList list)
        {
            Node temp = list.Head;
            while(temp.Next != null)
            {
                temp = temp.Next;
            }
            return temp;
        }

        public void InsertLast(int data)
        {
            Node n = new Node { data = data };
            if(this.Head == null)
            {
                this.Head = n;
            }
            else
            {
                Node node = GetLastNode(this);
                node.Next = n;
            }
        }

        public void PrintList(LinkedList list)
        {
            Node temp = list.Head;
            while (temp!= null)
            {
                Console.Write("{0} ->", temp.data);
                temp = temp.Next;
            }
        }

        public void FindMiddleElement(LinkedList list)
        {
            Node fast = list.Head;
            Node slow = list.Head;
            while(fast !=null && fast.Next !=null)
            {
                fast = fast.Next.Next;
                slow = slow.Next;
            }
            Console.WriteLine("Middle element is :: {0}", slow.data);
        }

        //public void DeleteNode()
    }
}
