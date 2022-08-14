using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Generic
{
    public class Box<T>:IComparable<T> where T:IComparable<T>
    {
        private readonly List<T> list;
        public T Element { get; }
        public Box(T element)
        {
            Element = element;
        }

        public Box(List<T> list)
        {
            new List<T>();
            this.list = list;
        }

        public void Swap(List<T> list,int indexOne,int indexTwo)
        {
            T temp = list[indexOne];
            list[indexOne] = list[indexTwo];
            list[indexTwo] = temp;
        }

        public int CompareTo(T other) => Element.CompareTo(other);

        public int CountOfGreaterElemenets<T>(List<T> list, T readline) where T : IComparable
            => list.Count(word => word.CompareTo(readline) > 0);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in list)
            {
                sb.AppendLine($"{item.GetType()}: {item}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
