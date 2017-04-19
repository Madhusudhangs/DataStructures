using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Stack
{
    public class MinStack<T> where T : IComparable
    {
        private class StackElement
        {
            public T ActualValue { get; set; }

            public T Min { get; set; }
        }

        private const int Size = 10;
        private int top = -1;

        private T[] input;
        private T[] minStack;

        private Stack<StackElement> stack;

        public MinStack()
        {
            this.input = new T[Size];
            this.minStack = new T[Size];

            this.stack = new Stack<StackElement>(Size);
        }

        #region Solution 1 using Input Array and Min Array
        public void Push(T item)
        {
            if (this.top == Size - 1)
            {
                throw new StackOverflowException();
            }

            this.input[++top] = item;

            if (top == 0)
            {
                this.minStack[top] = item;
            }
            else
            {
                T previousTop = this.minStack[top - 1];
                if (previousTop.CompareTo(item) < 0)
                {
                    this.minStack[top] = this.minStack[top - 1];
                }
                else
                {
                    this.minStack[top] = item;
                }
            }
        }

        public T Pop()
        {
            if (this.top == -1)
            {
                throw new Exception("Stack Underflow");
            }

            return this.input[top--];
        }

        public T Min()
        {
            if (this.top == Size || this.top == -1)
            {
                throw new InvalidOperationException("No items found in the stack");
            }

            return this.minStack[top];
        }
        #endregion

        #region Solution 2: using class
        public void PushStackElement(T item)
        {
            StackElement stackItem = new StackElement
            {
                ActualValue = item,
                Min = item
            };

            if (!stack.Any())
            {
                stack.Push(stackItem);
            }
            else
            {
                StackElement previousTop = this.stack.Peek();

                if (previousTop.Min.CompareTo(item) < 0)
                {
                    stackItem.Min = previousTop.Min;
                }

                this.stack.Push(stackItem);
            }
        }

        public T PopStackElement()
        {
            return this.stack.Pop().ActualValue;
        }

        public T MinStackElement()
        {
            return this.stack.Peek().Min;
        }
        #endregion
    }
}
