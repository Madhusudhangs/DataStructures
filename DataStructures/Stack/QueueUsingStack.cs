using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Stack
{
    /// <summary>
    /// Courtesy: http://stackoverflow.com/questions/69192/how-to-implement-a-queue-using-two-stacks
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class QueueUsingStack<T>
    {
        private Stack<T> inbox;
        private Stack<T> outbox;

        public QueueUsingStack()
        {
            this.inbox = new Stack<T>();
            this.outbox = new Stack<T>();
        }


        /// <summary>
        /// Recursive solution O(n^2) - because for every push there will (n-1)^2 push and pop operations.
        /// </summary>
        /// <param name="item"></param>
        public void EnQueueRecursion(T item)
        {
            if (this.inbox.Any())
            {
                T topElement = this.inbox.Pop();
                this.EnQueueRecursion(item);
                this.inbox.Push(topElement);
            }
            else
            {
                this.inbox.Push(item);
            }
        }

        /// <summary>
        /// Recursive solution
        /// </summary>
        /// <returns></returns>
        public T DeQueueRecursion()
        {
            return this.inbox.Pop();
        }

        /// <summary>
        /// Non Recursive push solution O(1)
        /// </summary>
        /// <param name="item"></param>
        public void EnQueue(T item)
        {
            this.inbox.Push(item);
        }


        /// <summary>
        /// Non Recursive solution O(n): Efficient solution
        /// </summary>
        /// <param name="item"></param>
        public T DeQueue()
        {
            if (!this.outbox.Any())
            {
                while (this.inbox.Any())
                {
                    this.outbox.Push(this.inbox.Pop());
                }
            }

            return this.outbox.Pop();
        }
    }
}
