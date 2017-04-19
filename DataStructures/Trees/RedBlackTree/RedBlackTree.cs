using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Trees;

namespace DataStructures.Trees
{
    public class RedBlackTree<TData> where TData : IComparable<TData>
    {
        public RBTreeNode<TData> TNil { get; private set; }

        public RBTreeNode<TData> Root { get; private set; }

        public RedBlackTree()
        {
            this.TNil = RBTreeNode<TData>.TNil;
        }

        public void Insert(RBTreeNode<TData> newNode)
        {
            RBTreeNode<TData> cur = this.Root;
            RBTreeNode<TData> prev = this.TNil;

            while (cur != this.TNil)
            {
                prev = cur;

                if (newNode.CompareTo(cur) < 0)
                {
                    cur = cur.LeftChild;
                }
                else
                {
                    cur = cur.RightChild;
                }
            }

            newNode.SetParent(prev);

            if (prev == this.TNil)
            {
                this.Root = newNode;
            }
            else if (newNode.CompareTo(prev) < 0)
            {
                prev.SetLeftChild(newNode);
            }
            else
            {
                prev.SetRightChild(newNode);
            }

            newNode.SetLeftChild(this.TNil);
            newNode.SetRightChild(this.TNil);

            this.RBInsertFixUp(newNode);
        }

        public void Delete(RBTreeNode<TData> node)
        {
            RBTreeNode<TData> replacingNode = node;
            RBTreeNodeColor yOrginalColor = replacingNode.Color;
            RBTreeNode<TData> replacedNode = this.TNil;

            if (node.Parent.LeftChild == this.TNil)
            {
                replacedNode = node.RightChild;
                node.Parent.SetRightChild(node.RightChild);
            }
            else if (node.Parent.RightChild == this.TNil)
            {
                replacedNode = node.LeftChild;
                node.Parent.SetLeftChild(node.LeftChild);
            }
            else
            {
                replacingNode = (RBTreeNode<TData>)node.RightChild.Successor();
                yOrginalColor = replacingNode.Color;
                replacedNode = replacingNode.RightChild;

                if (replacedNode.Parent == node)
                {
                    replacedNode.SetParent(replacedNode);
                }
                else if (replacingNode.Parent != node)
                {
                    this.RBTransplant(replacingNode, replacingNode.RightChild);
                    replacingNode.SetRightChild(node.RightChild);
                    replacingNode.RightChild.SetParent(replacingNode);
                }

                this.RBTransplant(node, replacingNode);
                replacingNode.SetLeftChild(node.LeftChild);
                replacingNode.LeftChild.SetParent(replacingNode);

                replacingNode.SetColor(node.Color);
            }

            if (yOrginalColor == RBTreeNodeColor.Black)
            {
                this.RBDeleteFixUp(replacedNode);
            }
        }

        protected void RBTransplant(RBTreeNode<TData> curNode, RBTreeNode<TData> nextNode)
        {
            if (curNode.Parent == this.TNil)
            {
                this.Root = nextNode;
            }
            else if (curNode.Parent.LeftChild == curNode)
            {
                curNode.Parent.SetLeftChild(nextNode);
            }
            else
            {
                curNode.Parent.SetRightChild(nextNode);
            }

            nextNode.SetParent(curNode.Parent);
        }

        protected void RotateLeft(RBTreeNode<TData> node)
        {
            // [NOTE:] Nodes and its properties getting affected are

            // node - parent, right
            // y (node.right) - parent, left
            // y.left (node.right.left) -  parent
            // node.parent - left or right child

            RBTreeNode<TData> y = node.RightChild;

            // Replace node right child as y's left child.
            node.SetRightChild(y.LeftChild);
            if (y.LeftChild != this.TNil)
            {
                y.LeftChild.SetParent(node);
            }

            // node's parent becomes y's parent            
            y.SetParent(node.Parent);

            // If node's parent is TNil, then y becomes a root
            if (node.Parent == this.TNil)
            {
                this.Root = y;
            }
            else if (node.Parent.LeftChild == node)
            {
                // If node is a left child of its parent, then y become left child of node's parent.
                node.Parent.SetLeftChild(y);
            }
            else
            {
                // If node is a right child of its parent, then y become right child of node's parent.
                node.Parent.SetRightChild(y);
            }

            // node becomes y's left child
            y.SetLeftChild(node);
            node.SetParent(y);
        }

        protected void RotateRight(RBTreeNode<TData> node)
        {
            RBTreeNode<TData> x = node.LeftChild;

            // x's right child becomes left child of node.
            node.SetLeftChild(x.RightChild);
            if (x.RightChild != null)
            {
                x.RightChild.SetParent(node);
            }

            x.SetParent(node.Parent);

            if (node.Parent == null)
            {
                this.Root = x;
            }
            else if (node.Parent.LeftChild == node)
            {
                node.Parent.SetLeftChild(x);
            }
            else
            {
                node.Parent.SetRightChild(x);
            }

            x.SetRightChild(node);
            node.SetParent(x);
        }

        protected void RBInsertFixUp(RBTreeNode<TData> newNode)
        {
            while (newNode.Parent.Color == RBTreeNodeColor.Red)
            {
                if (newNode.Parent == newNode.Parent.Parent.LeftChild)
                {
                    RBTreeNode<TData> uncle = newNode.Parent.Parent.RightChild;

                    if (uncle.Color == RBTreeNodeColor.Red)
                    {
                        newNode.Parent.SetColor(RBTreeNodeColor.Black);
                        uncle.SetColor(RBTreeNodeColor.Black);
                        newNode.SetColor(RBTreeNodeColor.Red);

                        newNode = newNode.Parent.Parent;
                    }
                    else if (newNode == newNode.Parent.RightChild)
                    {
                        newNode = newNode.Parent;
                        this.RotateLeft(newNode);
                    }

                    newNode.Parent.SetColor(RBTreeNodeColor.Black);
                    newNode.Parent.Parent.SetColor(RBTreeNodeColor.Red);

                    this.RotateRight(newNode.Parent.Parent);
                }
                else
                {
                    RBTreeNode<TData> uncle = newNode.Parent.Parent.LeftChild;

                    if (uncle.Color == RBTreeNodeColor.Red)
                    {
                        newNode.Parent.SetColor(RBTreeNodeColor.Black);
                        uncle.SetColor(RBTreeNodeColor.Black);
                        newNode.Parent.Parent.SetColor(RBTreeNodeColor.Red);

                        newNode = newNode.Parent.Parent;
                    }
                    else if (newNode == newNode.Parent.LeftChild)
                    {
                        newNode = newNode.Parent;
                        this.RotateRight(newNode);
                    }

                    newNode.Parent.SetColor(RBTreeNodeColor.Black);
                    newNode.Parent.SetColor(RBTreeNodeColor.Red);

                    this.RotateLeft(newNode.Parent.Parent);
                }
            }

            this.Root.SetColor(RBTreeNodeColor.Black);
        }

        protected void RBDeleteFixUp(RBTreeNode<TData> node)
        {
            while (node != this.Root && node.Color == RBTreeNodeColor.Black)
            {
                if (node.Parent.LeftChild == node)
                {
                    RBTreeNode<TData> sibling = node.Parent.RightChild;

                    if (sibling.Color == RBTreeNodeColor.Red)
                    {
                        sibling.SetColor(RBTreeNodeColor.Black);
                        node.Parent.SetColor(RBTreeNodeColor.Red);

                        this.RotateLeft(node.Parent);
                        sibling = node.Parent.RightChild;
                    }

                    if (sibling.LeftChild.Color == RBTreeNodeColor.Black
                        && sibling.RightChild.Color == RBTreeNodeColor.Black)
                    {
                        sibling.SetColor(RBTreeNodeColor.Red);
                        node = node.Parent;
                    }
                    else if (sibling.LeftChild.Color == RBTreeNodeColor.Black)
                    {
                        sibling.LeftChild.SetColor(RBTreeNodeColor.Black);
                        sibling.SetColor(RBTreeNodeColor.Red);

                        this.RotateRight(sibling);
                        sibling = node.RightChild.RightChild;
                    }

                    sibling.SetColor(node.Parent.Color);
                    sibling.RightChild.SetColor(RBTreeNodeColor.Black);
                    node.Parent.SetColor(RBTreeNodeColor.Black);

                    node = this.Root;
                }
                else
                {
                    RBTreeNode<TData> sibling = node.Parent.LeftChild;

                    if (sibling.Color == RBTreeNodeColor.Red)
                    {
                        sibling.SetColor(RBTreeNodeColor.Black);
                        node.Parent.SetColor(RBTreeNodeColor.Red);

                        this.RotateRight(node.Parent);
                        sibling = node.Parent.LeftChild;
                    }

                    if (sibling.LeftChild.Color == RBTreeNodeColor.Black
                        && sibling.RightChild.Color == RBTreeNodeColor.Black)
                    {
                        sibling.SetColor(RBTreeNodeColor.Red);
                        node = node.Parent;
                    }
                    else if (sibling.RightChild.Color == RBTreeNodeColor.Black)
                    {
                        sibling.RightChild.SetColor(RBTreeNodeColor.Black);
                        sibling.SetColor(RBTreeNodeColor.Red);

                        this.RotateLeft(sibling);
                        sibling = node.Parent.LeftChild;
                    }

                    sibling.SetColor(node.Parent.Color);
                    sibling.LeftChild.SetColor(RBTreeNodeColor.Black);
                    node.Parent.SetColor(RBTreeNodeColor.Black);

                    node = this.Root;
                }
            }

            node.SetColor(RBTreeNodeColor.Black);
        }
    }
}
