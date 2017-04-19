using DataStructures.Stack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public static class StackTestCases
    {
        public static void TestQueueUsingStack()
        {
            Stack.QueueUsingStack<int> queue = new DataStructures.Stack.QueueUsingStack<int>();
            queue.EnQueueRecursion(1);
            queue.EnQueueRecursion(2);
            queue.EnQueueRecursion(3);

            Console.WriteLine(queue.DeQueueRecursion());
            Console.WriteLine(queue.DeQueueRecursion());
            Console.WriteLine(queue.DeQueueRecursion());
        }

        public static void TestSetOfStack()
        {
            Stack.SetOfStacks<int> multiStack = new DataStructures.Stack.SetOfStacks<int>(2);

            multiStack.Push(1);
            multiStack.Push(2);
            multiStack.Push(3);
            multiStack.Push(4);
            multiStack.Push(5);
            multiStack.Push(6);

            Console.WriteLine(multiStack.Pop());
            Console.WriteLine(multiStack.Pop());
            Console.WriteLine(multiStack.Pop());
            Console.WriteLine(multiStack.Pop());
            Console.WriteLine(multiStack.Pop());
            Console.WriteLine(multiStack.Pop());

            try
            {
                Console.WriteLine(multiStack.Pop());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void TestMinStack()
        {
            Stack.MinStack<int> minStack = new DataStructures.Stack.MinStack<int>();

            minStack.Push(4);
            minStack.Push(2);
            minStack.Push(1);
            minStack.Push(13);

            Console.WriteLine(minStack.Min());

            minStack.Pop();
            minStack.Pop();

            Console.WriteLine(minStack.Min());

            minStack.Pop();
            Console.WriteLine(minStack.Min());

            minStack.Pop();

            try
            {
                Console.WriteLine(minStack.Min());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void TestSortableStack()
        {
            SortableStack<int> stack = new SortableStack<int>();
            stack.Push(6);
            stack.Push(2);
            stack.Push(4);
            stack.Push(5);
            stack.Push(1);

            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());            
        }

        public static void TestSortedStack()
        {
            SortedStack<int> stack = new SortedStack<int>();
            stack.Push(6);
            stack.Push(2);
            stack.Push(4);
            stack.Push(5);
            stack.Push(1);

            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
        }
    }
}
