using NUnit.Framework;
using System.Collections.Generic;

namespace Queue.Tests
{
    [TestFixture]
    public class QueueTests
    {
        [TestCase(new int[] { 1, 2, 3, -4, 5, 6, 7, 8, 9, 10, -11, -12 })]
        [TestCase(new int[] { 1, 2, -5, 8, 9, -15})]
        [TestCase(new int[] { 0 })]

        public void Foreach_IntArray_IntArray(int [] array)
        {
            CustomCollections.Queue<int> queue = InsertToQueue<int>(array);

            int[] result = GetFromQueue<int>(queue);

            Assert.AreEqual(array, result);
        }

        [TestCase(new double[] { 0.23, 2.265, -3.4844, 4.0, -0.999, 6.5455, 7.121, -8.9898, 9.1111, 50.12345 })]
        [TestCase(new double[] { 0.6565, -2.0025, -5.0, -8.000001, 9.15, -15.1333 })]
        [TestCase(new double[] { 0.00000001 })]

        public void Foreach_DoubleArray_DoubleArray(double[] array)
        {
            CustomCollections.Queue<double> queue = InsertToQueue<double>(array);

            double[] result = GetFromQueue<double>(queue);

            Assert.AreEqual(array, result);
        }

        [TestCase(new char[] { 'a', 'b', 'c', 'd', 'e', 'f' })]
        [TestCase(new char[] { 'a' })]

        public void Foreach_CharArray_CharArray(char[] array)
        {
            CustomCollections.Queue<char> queue = InsertToQueue<char>(array);

            char[] result = GetFromQueue<char>(queue);

            Assert.AreEqual(array, result);
        }

        private CustomCollections.Queue<T> InsertToQueue<T>(T[] array)
        {
            CustomCollections.Queue<T> queue = new CustomCollections.Queue<T>();

            for (int i = 0; i < array.Length; i++)
            {
                queue.Enqueue(array[i]);
            }

            return queue;
        }

        private T[] GetFromQueue<T>(CustomCollections.Queue<T> queue)
        {
            List<T> list = new List<T>();

            foreach (T element in queue)
            {
                list.Add(element);
            }

            return list.ToArray();
        }
    }
}
