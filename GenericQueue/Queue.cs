using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomCollections
{
    /// <summary>
    /// Class realizes queue data structure for any type of elements
    /// </summary>
    /// <typeparam name="T">Universal type, that must be define according the type of data in queue</typeparam>
    public class Queue<T> : IEnumerable, IEnumerator, IEnumerator<T>
    {
        private const int DefaultSize = 10;
        private T[] array;
        private int head, tail, position;

        /// <summary>
        /// Constructor sets default size of array of stored elements
        /// </summary>
        public Queue() : this(DefaultSize)
        {
        }

        /// <summary>
        /// Constructor sets default size of array of stored elements
        /// </summary>
        /// <param name="size">Initial size of array for T elements</param>
        public Queue(int size)
        {
            array = new T[size];
            tail = head = array.Length - 1;
            position = array.Length;
        }

        public T Current
        {
            get
            {
                return array[position];
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        /// <summary>
        /// Method allows to add new element to the queue
        /// </summary>
        /// <param name="value">Object for adding to the collection</param>
        public void Enqueue(T value)
        {
            array[tail] = value;
            tail--;

            if (tail < 0)
            {
                tail = array.Length - 1;
            }

            if (tail == head)
            {
                CreateNewArray();
            }
        }

        /// <summary>
        /// Method allows to get first element of queue and delete it from the collection 
        /// </summary>
        /// <returns>First element in the queue</returns>
        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Oueue is empty");
            }

            position = head;
            T temp = array[head];
            array[head--] = default(T);

            if (head < 0)
            {
                head = array.Length - 1;
            }

            return temp;
        }

        /// <summary>
        /// Method allows to get first element of queue without deleting it from the collection 
        /// </summary>
        /// <returns>First element in the queue</returns>
        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Oueue is empty");
            }

            return array[head];
        }

        /// <summary>
        /// Method verifies count the elements in the queue
        /// </summary>
        /// <returns>True(if queue is empty) or False(elemets count in the queue != 0)</returns>
        public bool IsEmpty()
        {
            if (head == tail)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Method gives enumerator for collection
        /// </summary>
        /// <returns>Enumerator for going throw collection with help of foreach</returns>
        public IEnumerator GetEnumerator()
        {
            return this;
        }
        
        /// <summary>
        /// Method disposes unmanaged resources
        /// </summary>
        void IDisposable.Dispose()
        {
        }

        /// <summary>
        /// Method changes current index fot elements collection
        /// </summary>
        /// <returns>True(current != end) of False(current == end)</returns>
        public bool MoveNext()
        {
            position--;

            if (position < 0)
            {
                position = array.Length - 1;
            }

            if (position != tail)
            {
                return true;
            }
            else
            {
                Reset();

                return false;
            }
        }

        /// <summary>
        /// Method sets value of the current index to head of the queue
        /// </summary>
        public void Reset()
        {
            position = array.Length;
        }

        /// <summary>
        /// Method creates new array for T elements if current array length
        /// is not enough for adding new elemets to the queue
        /// </summary>
        private void CreateNewArray()
        {
            T[] buffArray = new T[2 * array.Length];

            for (int i = head; i >= 0; i--)
            {
                buffArray[(buffArray.Length - 1) - (head - i)] = array[i];
            }

            for (int i = array.Length - 1; i > tail; i--)
            {
                buffArray[(buffArray.Length - 1) - head - (array.Length - i)] = array[i];
            }

            head = buffArray.Length - 1;
            tail = head - array.Length;
            position = buffArray.Length;
            array = buffArray;
        }
    }
}
