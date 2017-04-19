using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Stack
{
    public class SortableStack<T> where T : struct, IComparable
    {
        private Stack<T> stack;

        public SortableStack()
        {
            this.stack = new Stack<T>();
        }

        /// <summary>
        /// Iterative approach takes 2 * O(n) => O(n)
        /// </summary>
        /// <param name="item"></param>
        public void Push(T item)
        {
            if (!stack.Any())
            {
                this.stack.Push(item);
            }
            else
            {
                Stack<T> temperaryStack = new Stack<T>();

                while (this.stack.Any()
                    && this.stack.Peek().CompareTo(item) < 0)
                {
                    T element = this.stack.Pop();
                    temperaryStack.Push(element);
                }

                this.stack.Push(item);

                while (temperaryStack.Any())
                {
                    T element = temperaryStack.Pop();
                    this.stack.Push(element);
                }
            }
        }

        public T Pop()
        {
            return this.stack.Pop();
        }
    }

    public class SortedStack<T> where T : struct, IComparable<T>
    {
        private int top;

        private T[] sortableStack;

        public SortedStack()
        {
            top = -1;
            this.sortableStack = new T[100];
        }

        public void Push(T item)
        {
            if (top == -1)
            {
                this.sortableStack[++top] = item;               

                return;
            }

            if (item.CompareTo(this.sortableStack[top]) > 0)
            {
                T popedItem = this.Pop();

                this.Push(item);                
                this.Push(popedItem);                
            }
            else
            {
                this.sortableStack[++this.top] = item;                
            }
        }

        public T Pop()
        {
            if (!this.sortableStack.Any())
            {
                throw new InvalidOperationException("Stack Underflow");
            }

            return this.sortableStack[top--];
        }
    }
}
