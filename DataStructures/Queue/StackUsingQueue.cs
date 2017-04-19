using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Queue
{
    public class StackUsingQueue<T>
    {
        public Queue<T> inbox;
        public Queue<T> outbox;

        public StackUsingQueue()
        {
            this.inbox = new Queue<T>();
            this.outbox = new Queue<T>();
        }

        /// <summary>
        /// Recursive solution O(n^2)
        /// </summary>
        /// <param name="item"></param>
        public void PushRecursive(T item)
        {
            if(this.inbox.Any())
            {
                T longWaitingElement = inbox.Dequeue();
                this.PushRecursive(item);
                this.inbox.Enqueue(longWaitingElement);
            }
            else
            {
                this.inbox.Enqueue(item);
            }
        }

        /// <summary>
        /// Recursive solution
        /// </summary>
        /// <returns></returns>
        public T PopRecursive()
        {
            return this.inbox.Dequeue();
        }
        

        /// <summary>
        /// Non recursive solution
        /// </summary>
        /// <param name="item"></param>
        public void Push(T item)
        {
            this.inbox.Enqueue(item);
        }

        /// <summary>
        /// Non recursive solution
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            if(!this.outbox.Any())
            {
                while(this.inbox.Any())
                {
                    this.outbox.Enqueue(this.inbox.Dequeue());
                }
            }

            return this.outbox.Dequeue();
        }

    }
}
