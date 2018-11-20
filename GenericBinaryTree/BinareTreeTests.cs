using System;
using System.Collections.Generic;
using BinaryTreeLibrary;

namespace BinaryTree.Tests
{
    public class BinaryTreeTests
    {
        public static void Main(string[] args)
        {
            int[] intArray = new int[] { 1, 5, 0, 20, 3, 2, 9};
            string[] stringArray = new string[] { "a", "h", "p", "b", "l", "c" };

            BinaryTree<int> intTree = new BinaryTree<int>(new IntComparer());
            BinaryTree<string> stringTree = new BinaryTree<string>(new BinaryTreeLibrary.StringComparer());

            TreeFilling<int>(intTree, intArray);
            TreeFilling<string>(stringTree, stringArray);

            List<int> intResult = TreePreorderPrint<int>(intTree);
            List<string> stringResult = TreePreorderPrint<string>(stringTree);

            Print(intResult);
            Print(stringResult);

            Console.ReadKey();
        }

        private static void TreeFilling<T>(BinaryTree<T> tree, T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                tree.Insert(array[i]);
            }
        }

        private static List<T> TreePreorderPrint<T>(BinaryTree<T> tree)
        {
            List<T> list = new List<T>();

            foreach(T entry in tree.PreorderPrint())
            {
                list.Add(entry);
            }

            return list;
        }

        private static void Print<T>(List<T> list)
        {
            foreach (T entry in list)
            {
                Console.WriteLine(entry);
            }

            Console.WriteLine("--------");
        }
    }
}
