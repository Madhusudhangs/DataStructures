using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Stack
{
    public class SetOfStacks<T> where T : struct
    {
        private int innerStackSize;

        private class StackContainer
        {
            public Stack<T> nestedStack;

            public StackContainer(int capacity)
            {
                this.nestedStack = new Stack<T>(capacity);
            }
        }

        private LinkedList<StackContainer> stack;

        public SetOfStacks(int innerStackSize)
        {
            this.stack = new LinkedList<StackContainer>();
            this.innerStackSize = innerStackSize;
        }

        public void Push(T item)
        {
            if (this.stack.First == null)
            {
                StackContainer topStackContainer = new StackContainer(this.innerStackSize);
                LinkedListNode<StackContainer> topStack = new LinkedListNode<StackContainer>(topStackContainer);

                this.stack.AddFirst(topStack);
            }
            else if (this.stack.First.Value.nestedStack.Count == innerStackSize)
            {
                StackContainer topStackContainer = new StackContainer(this.innerStackSize);
                this.stack.AddFirst(topStackContainer);
            }

            this.stack.First.Value.nestedStack.Push(item);
        }

        public T Pop()
        {
            if (this.stack.First == null)
            {
                throw new Exception("Stack Underflow");
            }

            T popedItem = default(T);

            if (this.stack.First.Value.nestedStack.Any())
            {
                popedItem = this.stack.First.Value.nestedStack.Pop();
            }

            if (!this.stack.First.Value.nestedStack.Any())
            {
                this.stack.RemoveFirst();
            }

            return popedItem;
        }
    }
}
