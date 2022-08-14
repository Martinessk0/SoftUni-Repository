using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace T01ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private readonly List<T> list;
        private int currIndex;

        public ListyIterator(params T[] data)
        {
            list = new List<T>(data);
            currIndex = 0;
        }

        public bool Move()
        {
            bool canMove = HasNext();
            if (canMove)
            {
                currIndex++;
            }

            return canMove;
        }
        public bool HasNext()
        {
            bool result = currIndex < list.Count - 1;
            return result;
        }

        public void Print()
        {
            if (list.Count==0)
            {
                throw new InvalidOperationException("Invalid Operation");
            }
            Console.WriteLine($"{list[currIndex]}");
        }

        public void PrintAll()
        {
            Console.WriteLine(string.Join(" ",list));
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var element in list)
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
