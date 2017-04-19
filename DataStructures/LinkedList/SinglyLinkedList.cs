using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedList
{
    public class SinglyLinkedList<T>
    {
        private Node<T> head;

        public Node<T> Head
        {
            get
            {
                return this.head;
            }
        }

        public SinglyLinkedList()
        {
            this.head = null;
        }

        public void AddFront(T item)
        {
            Node<T> newElement = new Node<T>();
            newElement.Data = item;

            newElement.Next = head;
            head = newElement;
        }

        public T RemoveFront()
        {
            Node<T> temp = head;

            head = head.Next;
            temp.Next = null;

            return temp.Data;
        }

        private Node<T> ReverseWhenTravesingBackFromRecursiveCall(Node<T> cur, ref Node<T> rcur)
        {
            if (cur == null)
            {
                return cur;
            }

            if (cur.Next == null)
            {
                return new Node<T> { Data = cur.Data, Next = null };
            }

            var rhead = ReverseWhenTravesingBackFromRecursiveCall(cur.Next, ref rcur);

            if (rcur == null)
            {
                rcur = rhead;
            }

            rcur.Next = new Node<T> { Data = cur.Data, Next = null };
            rcur = rcur.Next;

            return rhead;
        }

        public Node<T> Reverse(Node<T> cur, Node<T> rhead)
        {
            if (cur == null)
            {
                return rhead;
            }

            Node<T> temp = cur;
            cur = cur.Next;
            temp.Next = rhead;
            rhead = temp;

            return this.Reverse(cur, rhead);
        }

        public Node<T> Reverse()
        {
            Node<T> rcur = null;
            return this.ReverseWhenTravesingBackFromRecursiveCall(this.head, ref rcur);
        }

        public Node<T> ReverseIterative()
        {
            Node<T> cur = null;
            Node<T> rhead = null;
            Node<T> temp = this.head;

            while (temp != null)
            {
                cur = temp;
                temp = temp.Next;
                cur.Next = rhead;
                rhead = cur;
            }

            return rhead;
        }
    }
}
