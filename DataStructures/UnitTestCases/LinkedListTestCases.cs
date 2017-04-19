using DataStructures.LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.UnitTestCases
{
    public class LinkedListTestCases
    {
        public static void TestListSum()
        {
            List<int> list1 = new List<int> { 6, 1, 7, 8 };
            List<int> list2 = new List<int> { 2, 9, 5, 9, 9, 6 };

            SumList sumList = new SumList(list1, list2);

            double result = sumList.Sum();

            Console.WriteLine("Sum:{0}", result); ;
        }

        public static void TestReverseSinglyLinkedList()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>();

            list.AddFront(2);
            list.AddFront(3);
            list.AddFront(4);
            list.AddFront(5);
            list.AddFront(7);
            list.AddFront(8);
            list.AddFront(9);
            list.AddFront(10);
            list.AddFront(11);

            Console.WriteLine("Before");
            Console.WriteLine("---------------------");
            var cur = list.Head;

            while (cur != null)
            {
                Console.WriteLine(cur.Data);
                cur = cur.Next;
            }

            // Recursive reverse
            var reversedListHead = list.Reverse(list.Head, null);

            // Iterative reverse
            //var reversedListHead = list.ReverseIterative();
            var temp = reversedListHead;

            Console.WriteLine("Reversed list:");
            Console.WriteLine("------------------------");
            while (temp != null)
            {
                Console.WriteLine(temp.Data);
                temp = temp.Next;
            }
        }
    }
}
