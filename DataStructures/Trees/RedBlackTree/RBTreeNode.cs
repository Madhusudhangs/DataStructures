using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Trees
{
    public class RBTreeNode<TData> : BinaryTreeNodeBase<TData>, IComparable<RBTreeNode<TData>> where TData : IComparable<TData>
    {
        private static RBTreeNode<TData> tnil;

        public static RBTreeNode<TData> TNil
        {
            get
            {
                if (tnil == null)
                {
                    tnil = new RBTreeNode<TData>(RBTreeNodeColor.Black);
                }

                return tnil;
            }
        }

        public new RBTreeNode<TData> LeftChild
        {
            get
            {
                if( base.LeftChild == null)
                {
                    return TNil;
                }

                return (RBTreeNode<TData>)base.LeftChild;
            }
            set
            {
                base.LeftChild = value;
            }
        }

        public new RBTreeNode<TData> RightChild
        {
            get
            {
                if (base.RightChild == null)
                {
                    return TNil;
                }

                return (RBTreeNode<TData>)base.RightChild;
            }
            set
            {
                base.RightChild = value;
            }
        }

        public new RBTreeNode<TData> Parent
        {
            get
            {
                if (base.Parent == null)
                {
                    return TNil;
                }

                return (RBTreeNode<TData>)base.Parent;
            }
            set
            {
                base.Parent = value;
            }
        }
        

        public RBTreeNodeColor Color { get; private set; }

        public RBTreeNode(RBTreeNodeColor color)
            : this(default(TData), color)
        {
        }

        public RBTreeNode(TData satelliteData, RBTreeNodeColor color)
        {
            this.Data = satelliteData;
            this.Color = color;

            this.SetLeftChild(TNil);
            this.SetRightChild(TNil);
            this.SetParent(TNil);
        }

        public void SetParent(RBTreeNode<TData> parent)
        {
            this.Parent = parent;
        }

        public void SetRightChild(RBTreeNode<TData> rightChild)
        {
            this.RightChild = rightChild;
        }

        public void SetLeftChild(RBTreeNode<TData> leftChild)
        {
            this.LeftChild = leftChild;
        }

        public void SetColor(RBTreeNodeColor color)
        {
            this.Color = color;
        }

        public static RBTreeNode<TData> GetRBTreeNode(TData satteliteData)
        {
            RBTreeNode<TData> treeNode = new RBTreeNode<TData>(satteliteData, RBTreeNodeColor.Red);

            return treeNode;
        }

        public int CompareTo(RBTreeNode<TData> other)
        {
            return this.Data.CompareTo(other.Data);
        }
    }
}
