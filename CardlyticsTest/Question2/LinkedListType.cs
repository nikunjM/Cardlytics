using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardlyticsTest
{
    public class LinkedListType<T>
    {
        Node head; 
        public class Node
        {
            public T data;
            public Node next;
            private T new_data;
            public Node(T d)
            {
                data = d;
                next = null;
            }
        }
        public void add(T val)
        {
            Node newNode = new Node(val);
            newNode.next = head;
            head = newNode;
        }

        public T print5thFromLast()
        {
        int len = 0;
        Node temp = head;
        Queue<T> q = new Queue<T>();//This will be always size of 5 ...
        while (temp!= null)
        {
            if (len < 5) {
                q.Enqueue(temp.data);
            }
            if (len >= 5) {
                q.Dequeue();
                q.Enqueue(temp.data);
            }
            temp = temp.next;
            len++;
        }
        if (q.Count <5) {
            try
            {
                genralException(true, "LinkedList has less then 5 values, Please add more values to get fifth number.");
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Console.WriteLine("----------------------------------------------------------------------");
                Console.Read();
            }
        }
        return q.Peek();        
        }
        private void genralException(bool check, string message)
        {
            if (check)
            {
                throw new ArgumentException(message);
            }
        }

    }
}
