namespace DataStructures.Trees
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class BinarySearchTreeExtension
    {
        public static BinaryTreeNodeBase<TData> Successor<TData>(this BinaryTreeNodeBase<TData> node) where TData:IComparable<TData>
        {
            BinaryTreeNodeBase<TData> cur = node;

            while (cur.LeftChild != null)
            {
                cur = cur.LeftChild;
            }

            return cur;
        }

        public static BinaryTreeNodeBase<TData> Predecessor<TData>(this BinaryTreeNodeBase<TData> node) where TData : IComparable<TData>
        {
            BinaryTreeNodeBase<TData> cur = node;

            while (cur.RightChild != null)
            {
                cur = cur.RightChild;
            }

            return cur;
        }
    }
}
