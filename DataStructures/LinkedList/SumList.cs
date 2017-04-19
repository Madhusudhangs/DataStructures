using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedList
{
    public class SumList
    {
        private SinglyLinkedList<int> linkedList1;
        private SinglyLinkedList<int> linkedList2;

        public SumList(List<int> list1, List<int> list2)
        {
            this.linkedList1 = new SinglyLinkedList<int>();
            this.linkedList2 = new SinglyLinkedList<int>();

            foreach (var item in list1)
            {
                this.linkedList1.AddFront(item);
            }

            foreach (var item in list2)
            {
                this.linkedList2.AddFront(item);
            }
        }

        public double Sum()
        {
            double sum = 0;
            int digit = 0;
            int carry = 0;
            int digitSum = 0;

            Node<int> h1 = this.linkedList1.Head;
            Node<int> h2 = this.linkedList2.Head;

            while (h1 != null || h2 != null)
            {
                int partialSum = ((h1 != null ? h1.Data : 0) + (h2 != null ? h2.Data : 0) + carry);
                digitSum = partialSum % 10;

                if (h1 != null)
                {
                    h1 = h1.Next;
                }

                if (h2 != null)
                {
                    h2 = h2.Next;
                }

                sum = sum + digitSum * (Math.Pow(10,digit));

                carry = partialSum / 10;
                digit++;
            }

            return sum;
        }
    }
}
