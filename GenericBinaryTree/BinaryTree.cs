using System.Collections.Generic;

namespace BinaryTreeLibrary
{
    public class BinaryTree<T>
    {
        private Node<T> root;
        private IComparer<T> comparer;

        public BinaryTree(IComparer<T> _comparer)
        {
            comparer = _comparer;
        }

        public Node<T> Find(T key)
        {
            if (root == null)
            {
                return null;
            }

            return Find(root, key);
        }

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

        public void Insert(T data)
        {
            if (root == null)
            {
                root = new Node<T>();
                root.data = data;
            }

            Insert(root, root, data);
        }

        private void Insert(Node<T> node, Node<T> parent, T data)
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
                Insert(node.left, node, data);
            }
            else
            {
                Insert(node.right, node, data);
            }
        }

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

        public IEnumerable<T> PreorderPrint(int max)
        {
            List<T> nodes = new List<T>();

            PreorderPrint(root, nodes);

            foreach (T arg in nodes)
            {
                yield return arg;
            }
        }

        private void PreorderPrint(Node<T> node, List<T> nodes)
        { 
            if (root == null)
            {
                return ;
            }

            nodes.Add(node.data);

            PreorderPrint(node.left, nodes);
            PreorderPrint(node.right, nodes);
        }

        public IEnumerable<T> InorderPrint(int max)
        {
            List<T> nodes = new List<T>();

            InorderPrint(root, nodes);

            foreach (T arg in nodes)
            {
                yield return arg;
            }
        }

        private void InorderPrint(Node<T> node, List<T> nodes)
        {
            if (root == null)
            {
                return;
            }

            InorderPrint(node.left, nodes);

            nodes.Add(node.data);

            InorderPrint(node.right, nodes);
        }

        public IEnumerable<T> PostorderPrint(int max)
        {
            List<T> nodes = new List<T>();

            PreorderPrint(root, nodes);

            foreach (T arg in nodes)
            {
                yield return arg;
            }
        }

        private void PostorderPrint(Node<T> node, List<T> nodes)
        {
            if (root == null)
            {
                return;
            }

            PostorderPrint(node.left, nodes);
            PostorderPrint(node.right, nodes);

            nodes.Add(node.data);
        }
    }

    public class Node<T>
    {
        public Node<T> left;
        public Node<T> right;
        public Node<T> parent;
        public T data;
    }
}
