using System.Collections;
using System.Collections.Generic;

namespace asm2_1649
{
    public class MyStack<T> : IEnumerable<T>
    {
        private readonly List<T> items;

        public MyStack()
        {
            items = new List<T>();
        }

        public void Push(T item)
        {
            items.Add(item);
        }

        public T Pop()
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException("No items available in the stack.");
            }

            T item = items[^1];
            items.RemoveAt(items.Count - 1);
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