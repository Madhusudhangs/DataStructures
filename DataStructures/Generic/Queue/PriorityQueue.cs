using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Generic.Queue
{
    public class PriorityQueue<T> : Heap<T> where T : IComparable<T>, IEquatable<T>
    {
        private IHeapify<T> heapify;

        public PriorityQueue()
            : this(new MaxHeapify<T>())
        {
        }

        public PriorityQueue(IHeapify<T> heapify)
            : base(Enumerable.Empty<T>(), heapify)
        {
        }

        /// <summary>
        /// Time Complexity: O(log(n))
        /// </summary>
        /// <param name="item"></param>
        public void Enqueue(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            this.Insert(item);
        }

        /// <summary>
        /// Time Complexity: O(1)
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            return this.Top();
        }

        /// <summary>
        /// Time Complexity: O(1)
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            if (this.Size == 0)
            {
                throw new ArithmeticException("Queue is empty");
            }

            return this.ExtractTop();
        }

        /// <summary>
        /// Time Complexity: O(n) + 2 * O(log(n)) => O(n)
        /// </summary>
        /// <param name="oldItem"></param>
        /// <param name="newItem"></param>
        public void ChangePriority(T oldItem, T newItem)
        {
            // Time consuming operation, it will search through the heap and return the index if the element exists.
            // Time Complexity : O(n) 
            int index = this.FindIndex(oldItem);

            if (index < 0)
            {
                throw new InvalidOperationException("Item doesn't exist");
            }

            this.HeapCollection[index] = newItem;

            this.heapify.HeapifyBottomUp(this.HeapCollection, index, (int)this.Size);
            this.heapify.HeapifyTopDown(this.HeapCollection, index, (int)this.Size);
        }
    }
}
