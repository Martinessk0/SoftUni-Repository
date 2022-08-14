﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Threeuple
{
    public class Threeuple<TFirst,TSecond,TThird>
    {
        public TFirst FirstElement { get; set; }
        public TSecond SecondElement { get; set; }
        public TThird ThirdElement { get; set; }

        public Threeuple(TFirst firstElement, TSecond secondElement,TThird thirdElement)
        {
            FirstElement = firstElement;
            SecondElement = secondElement;
            ThirdElement = thirdElement;
        }

        public override string ToString()
        {
            return $"{FirstElement} -> {SecondElement} -> {ThirdElement}";
        }
    }
}
