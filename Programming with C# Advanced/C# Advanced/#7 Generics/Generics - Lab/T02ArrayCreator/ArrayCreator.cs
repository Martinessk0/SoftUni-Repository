namespace GenericArrayCreator
{
    public class ArrayCreator
    {
        public static T[] Create<T>(int length, T element)
        {
            T[] arr = new T[length];
            for (int i = 0; i < length; i++)
            {
                arr[i] = element;
            }

            return arr;
        }

    }
}
