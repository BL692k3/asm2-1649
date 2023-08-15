using System.Collections;
using System.Collections.Generic;

namespace asm2_1649
{
    public class MyQueue<T> : IEnumerable<T>
    {
        private readonly List<T> items;

        public MyQueue()
        {
            items = new List<T>();
        }

        public void Enqueue(T item)
        {
            items.Add(item);
        }

        public T Dequeue()
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException("No items available in the queue.");
            }

            T item = items[0];
            items.RemoveAt(0);
            return item;
        }

        public int Count => items.Count;

        public IEnumerator<T> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}