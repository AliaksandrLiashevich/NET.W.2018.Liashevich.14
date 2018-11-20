using System.Collections.Generic;

namespace BinaryTreeLibrary
{
    /// <summary>
    /// Class represents binary tree
    /// </summary>
    /// <typeparam name="T">Value or reference type</typeparam>
    public class BinaryTree<T>
    {
        private Node<T> root;
        private IComparer<T> comparer;

        /// <summary>
        /// Constructor that initialize way of comparing
        /// </summary>
        /// <param name="_comparer">Object that has compare method</param>
        public BinaryTree(IComparer<T> _comparer)
        {
            comparer = _comparer;
        }

        /// <summary>
        /// Method allows to find element of the tree according the key
        /// </summary>
        /// <param name="key">Data for searching process</param>
        /// <returns>Reference on object(if this object exist) or null(object doesn't exist)</returns>
        public Node<T> Find(T key)
        {
            if (root == null)
            {
                return null;
            }

            return Find(root, key);
        }

        /// <summary>
        /// Method helper for Find, execute recursive search
        /// </summary>
        /// <param name="node">Node of the tree</param>
        /// <param name="key">Data for searching process</param>
        /// <returns>Reference on object(if this object exist) or null(object doesn't exist)</returns>
        private Node<T> Find(Node<T> node, T key)
        {
            if (node == null)
            {
                return null;
            }

            if (comparer.Compare(key, node.data) == 0)
            {
                return node;
            }

            if (comparer.Compare(key, node.data) == -1)
            {
                return Find(node.left, key);
            }
            else
            {
                return Find(node.right, key);
            }
        }

        /// <summary>
        /// Method inserts data on definite position in the tree
        /// </summary>
        /// <param name="data">Some data for storing in the tree node</param>
        public void Insert(T data)
        {
            if (root == null)
            {
                root = new Node<T>();
                root.data = data;

                return;
            }

            Insert(ref root, ref root, data);
        }

        /// <summary>
        /// Method inserts data on definite position in the tree
        /// </summary>
        /// <param name="node">Current node of the tree on recursive step</param>
        /// <param name="parent">Node parent</param>
        /// <param name="data">Some data for storing in the tree node</param>
        private void Insert(ref Node<T> node, ref Node<T> parent, T data)
        {
            if (node == null)
            {
                node = new Node<T>();
                node.data = data;
                node.parent = parent;

                return; 
            }

            if (comparer.Compare(data, node.data) == -1)
            {
                Insert(ref node.left, ref node, data);
            }
            else
            {
                Insert(ref node.right, ref node, data);
            }
        }

        /// <summary>
        /// Method allows to remove node with the same key as input
        /// </summary>
        /// <param name="key">Key of deletiong object</param>
        public void Remove(T key)
        {
            Node<T> markNode = Find(key);

            if (markNode.left == null && markNode.right == null)
            {
                Remove(markNode, null, key);
            }
            else if (markNode.left == null || markNode.right == null)
            {
                Node<T> child = markNode.left == null ? markNode.right : markNode.left;

                Remove(markNode, child, key);
            }
            else
            {
                Node<T> minNode = markNode.right;

                while (minNode.left != null)
                {
                    minNode = minNode.left;
                }

                Remove(minNode.data);

                Node<T> parentLink = markNode.parent.left == markNode ?
                    markNode.parent.left : markNode.parent.right;

                parentLink = minNode;

                minNode.left = markNode.left;
                minNode.right = markNode.right;
            }
        }

        /// <summary>
        /// Method helper for Remove, determines what child is for the parent node
        /// </summary>
        /// <param name="markNode"></param>
        /// <param name="child"></param>
        /// <param name="key"></param>
        private void Remove(Node<T> markNode, Node<T> child, T key)
        {
            if (comparer.Compare(key, markNode.parent.data) == -1)
            {
                markNode.parent.left = child;
            }
            else
            {
                markNode.parent.right = child;
            }
        }

        /// <summary>
        /// Named iterator for Preorder bypass => (parent, left child, right child)
        /// </summary>
        /// <returns>Enumerator for steping throw the collection</returns>
        public IEnumerable<T> PreorderPrint()
        {
            List<T> list = new List<T>();

            PreorderPrint(root, list);

            foreach (T arg in list)
            {
                yield return arg;
            }
        }

        /// <summary>
        /// Method collects all elements of the tree into List
        /// following the ruler => (parent, left child, right child)
        /// </summary>
        /// <param name="node">Current node of the tree</param>
        /// <param name="nodes">List of nodes data</param>
        private void PreorderPrint(Node<T> node, List<T> nodes)
        { 
            if (node == null)
            {
                return;
            }

            nodes.Add(node.data);
            
            PreorderPrint(node.left, nodes);
            PreorderPrint(node.right, nodes);
        }

        /// <summary>
        /// Named iterator for Preorder bypass => (left child, parent, right child)
        /// </summary>
        /// <returns>Enumerator for steping throw the collection</returns>
        public IEnumerable<T> InorderPrint()
        {
            List<T> nodes = new List<T>();

            InorderPrint(root, nodes);

            foreach (T arg in nodes)
            {
                yield return arg;
            }
        }

        /// <summary>
        /// Method collects all elements of the tree into List
        /// following the ruler => (left child, parent, right child)
        /// </summary>
        /// <param name="node">Current node of the tree</param>
        /// <param name="nodes">List of nodes data</param>
        private void InorderPrint(Node<T> node, List<T> nodes)
        {
            if (node == null)
            {
                return;
            }

            InorderPrint(node.left, nodes);

            nodes.Add(node.data);

            InorderPrint(node.right, nodes);
        }

        /// <summary>
        /// Named iterator for Preorder bypass => (left child, right child, parent)
        /// </summary>
        /// <returns>Enumerator for steping throw the collection</returns>
        public IEnumerable<T> PostorderPrint()
        {
            List<T> nodes = new List<T>();

            PreorderPrint(root, nodes);

            foreach (T arg in nodes)
            {
                yield return arg;
            }
        }

        /// <summary>
        /// Method collects all elements of the tree into List
        /// following the ruler => (left child, right child, parent
        /// </summary>
        /// <param name="node">Current node of the tree</param>
        /// <param name="nodes">List of nodes data</param>
        private void PostorderPrint(Node<T> node, List<T> nodes)
        {
            if (node == null)
            {
                return;
            }

            PostorderPrint(node.left, nodes);
            PostorderPrint(node.right, nodes);

            nodes.Add(node.data);
        }
    }

    /// <summary>
    /// Class provides using of node of the treee structure
    /// </summary>
    /// <typeparam name="T">Value or reference type</typeparam>
    public class Node<T>
    {
        public Node<T> left;
        public Node<T> right;
        public Node<T> parent;
        public T data;
    }
}
