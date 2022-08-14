namespace Tuple
{
    public class Tuple<TFirst,TSecond>
    {
        public TFirst FirstElement { get; set; }
        public TSecond SecondElement { get; set; }

        public Tuple(TFirst firstElement,TSecond secondElement)
        {
            FirstElement = firstElement;
            SecondElement = secondElement;
        }

        public override string ToString()
        {
            return $"{FirstElement} -> {SecondElement}";
        }
    }
}
