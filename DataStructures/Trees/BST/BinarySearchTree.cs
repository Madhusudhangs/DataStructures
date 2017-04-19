namespace DataStructures.Trees
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DataStructures.Trees;

    public class BinarySearchTree<TData> where TData : IComparable<TData>
    {
        public BinaryTreeNodeBase<TData> Root { get; private set; }


        public void Insert(BinaryTreeNodeBase<TData> newNode)
        {
            if (newNode == null)
            {
                return;
            }

            BinaryTreeNodeBase<TData> prev = null;
            BinaryTreeNodeBase<TData> cur = this.Root;

            while (cur != null)
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

            newNode.Parent.SetParent(prev);

            if (prev == null)
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
        }

        public void Delete(BinaryTreeNodeBase<TData> node)
        {
            // If there is no left child, then replace node with right subtree.
            if (node.LeftChild == null)
            {
                this.Transplant(node, node.RightChild);
            }
            else if (node.RightChild == null) // If there is no right child, then replace node with left subtree
            {
                this.Transplant(node, node.LeftChild);
            }
            else
            {
                BinaryTreeNodeBase<TData> successor = node.RightChild.Successor<TData>();

                // If successor is not a right child of node.
                if (successor.Parent != node)
                {
                    this.Transplant(successor, successor.RightChild); // Replace successor with right subtree of successor.
                    successor.SetRightChild(node.RightChild);// Set successor right subtree as node's right subtree.
                    successor.RightChild.SetParent(successor.Parent);// Set sucessor right subtree parent as successor parent.
                }

                this.Transplant(node, successor); // Replace node with succesor.
                successor.SetLeftChild(node.LeftChild); // Set successor left subtree as node's left subtree.
                successor.SetParent(node.Parent); // Set successor parent as node's parent.
            }
        }

        public void Transplant(BinaryTreeNodeBase<TData> curSubTree, BinaryTreeNodeBase<TData> nextSubTree)
        {
            // If curSubTree's parent is null which means it is a root of the node. [ Only root node's parent should be null]
            if (curSubTree.Parent == null)
            {
                this.Root = nextSubTree;
            }
            else if (curSubTree.Parent.LeftChild == curSubTree) // If it is a left subtree, then replace current subtree with nextSubTree.
            {
                curSubTree.Parent.SetLeftChild(nextSubTree);
            }
            else
            {
                curSubTree.Parent.SetRightChild(nextSubTree); // If it is a right subtree, then replace current subtree with nextSubTree.
            }

            if (nextSubTree != null)
            {
                nextSubTree.SetParent(curSubTree.Parent);
            }
        }

        public BinaryTreeNodeBase<TData> Search(TData data)
        {
            BinaryTreeNodeBase<TData> cur = this.Root;

            while (cur != null && cur.Data.CompareTo(data) == 0)
            {
                if (data.CompareTo(cur.Data) < 0)
                {
                    cur = cur.LeftChild;
                }
                else
                {
                    cur = cur.RightChild;
                }
            }

            return cur;
        }

        public BinaryTreeNodeBase<TData> Minimun()
        {
            BinaryTreeNodeBase<TData> cur = this.Root;

            while (cur.LeftChild != null)
            {
                cur = cur.LeftChild;
            }

            return cur;
        }

        public BinaryTreeNodeBase<TData> Maximum()
        {
            BinaryTreeNodeBase<TData> cur = this.Root;

            while (cur.RightChild != null)
            {
                cur = cur.RightChild;
            }

            return cur;
        }

        public BinaryTreeNodeBase<TData> GetSuccessor(BinaryTreeNodeBase<TData> node)
        {
            if (node.RightChild != null)
            {
                return node.RightChild.Successor<TData>();
            }

            BinaryTreeNodeBase<TData> currentNode = node;
            BinaryTreeNodeBase<TData> parentNode = node.Parent;

            while (currentNode != null && currentNode == parentNode.RightChild)
            {
                currentNode = parentNode;
                parentNode = parentNode.Parent;
            }

            return parentNode;
        }

        public void InorderTraversal()
        {
            this.InorderRecursive(this.Root);
        }

        public void InorderRecursive(BinaryTreeNodeBase<TData> cur)
        {
            if (cur == null)
            {
                return;
            }

            this.InorderRecursive(cur.LeftChild);

            Console.WriteLine(cur.Data.ToString()); ;

            this.InorderRecursive(cur.RightChild);
        }

        public void InorderIterative()
        {
            var cur = this.Root;

            Stack<BinaryTreeNodeBase<TData>> stack = new Stack<BinaryTreeNodeBase<TData>>();

            do
            {
                if (cur != null)
                {
                    stack.Push(cur);
                    cur = cur.LeftChild;
                }
                else
                {
                    cur = stack.Pop();
                    Console.WriteLine(cur.Data.ToString());
                    cur = cur.RightChild;
                }
            }
            while (cur != null & stack.Any());
        }

        public void PreOrderIterative()
        {
            var cur = this.Root;

            Stack<BinaryTreeNodeBase<TData>> stack = new Stack<BinaryTreeNodeBase<TData>>();

            do
            {
                if (cur != null)
                {
                    stack.Push(cur);
                    Console.WriteLine(cur.Data.ToString());
                    cur = cur.LeftChild;
                }
                else
                {
                    cur = stack.Pop();
                    cur = cur.RightChild;
                }
            }
            while (cur != null & stack.Any());
        }

        public void PostOrderIterative()
        {
            var cur = this.Root;

            Stack<BinaryTreeNodeBase<TData>> stack = new Stack<BinaryTreeNodeBase<TData>>();

            do
            {
                if (cur != null)
                {                                      
                    cur = cur.LeftChild;
                }
                else
                {
                    cur = stack.Pop();
                    cur = cur.RightChild;                    
                }
            }
            while (cur != null & stack.Any());
        }

        public BinaryTreeNodeBase<TData> GetPredeccessor(BinaryTreeNodeBase<TData> node)
        {
            if (node.LeftChild != null)
            {
                return node.LeftChild.Predecessor<TData>();
            }

            BinaryTreeNodeBase<TData> currentNode = node;
            BinaryTreeNodeBase<TData> parentNode = node.Parent;

            while (currentNode != null && currentNode == parentNode.LeftChild)
            {
                currentNode = parentNode;
                parentNode = parentNode.Parent;
            }

            return parentNode;
        }

        public void RecursiveInsert(BinaryTreeNodeBase<TData> cur, BinaryTreeNodeBase<TData> newNode)
        {
            if (this.Root == null)
            {
                this.Root = newNode;
                return;
            }

            if (cur == null)
            {
                return;
            }

            if (newNode.CompareTo(cur) < 0)
            {
                this.RecursiveInsert(cur.LeftChild, newNode);
                cur.SetLeftChild(newNode);
            }
            else
            {
                this.RecursiveInsert(cur.RightChild, newNode);
                cur.SetRightChild(newNode);
            }

            newNode.SetParent(cur);
        }

        //public BinaryTreeNodeBase<TData> SearchRecursive(TData )
        //{
        //    return this.SearchRecursive(this.Root, key);
        //}

        //private BinaryTreeNodeBase<TData> SearchRecursive(BinaryTreeNodeBase<TData> cur, int key)
        //{
        //    if (cur == null || cur.Key.CompareTo(key) == 0)
        //    {
        //        return cur;
        //    }

        //    return cur.CompareTo(key) < 0 ? this.SearchRecursive(cur.LeftChild, key) : this.SearchRecursive(cur.RightChild, key);
        //}
    }
}
