using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            if (this.Count < 0)
            {
                return true;
            }
            return false;
        }
        public void AddRange()
        {
            foreach (var stackOfString in this)
            {
                this.Push(stackOfString);
            }
        }
    }
}
