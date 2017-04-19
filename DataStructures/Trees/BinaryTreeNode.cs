using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Trees
{
    public class BinaryTreeNodeBase<TData> : IComparable<BinaryTreeNodeBase<TData>> where TData : IComparable<TData>
    {
        public TData Data { get; set; }

        public BinaryTreeNodeBase<TData> LeftChild
        {
            get;
            protected set;
        }

        public BinaryTreeNodeBase<TData> RightChild
        {
            get;
            protected set;
        }

        public BinaryTreeNodeBase<TData> Parent
        {
            get;
            protected set;
        }

        public void SetLeftChild(BinaryTreeNodeBase<TData> leftChild)
        {
            this.LeftChild = leftChild;
        }

        public void SetRightChild(BinaryTreeNodeBase<TData> rightChild)
        {
            this.RightChild = rightChild;
        }

        public void SetParent(BinaryTreeNodeBase<TData> parent)
        {
            this.Parent = parent;
        }

        public int CompareTo(BinaryTreeNodeBase<TData> other)
        {
            return this.Data.CompareTo(other.Data);
        }
    }
}
