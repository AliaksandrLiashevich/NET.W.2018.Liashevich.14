using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace Queue.Tests
{
    [TestFixture]
    public class QueueTests
    {
        [TestCase(new int[] { 1, 2, 5, 8, 9})]
        public void TestMethod1(int [] array)
        {
            CustomCollections.Queue<int> queue = InsertToQueue<int>(array);

            int[] result = GetFromQueue<int>(queue);

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
