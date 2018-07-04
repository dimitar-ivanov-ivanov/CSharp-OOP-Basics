namespace StackOfStrings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StackOfStrings
    {
        public StackOfStrings()
        {
            data = new List<string>();
        }

        private List<String> data;
        public void Push(string element)
        {
            this.data.Add(element);
        }

        public string Pop()
        {
            if (isEmpty())
            {
                throw new InvalidOperationException("Stack is empty");
            }
            var element = this.data.Last();
            this.data.Remove(element);
            return element;
        }

        public bool isEmpty()
        {
            return data.Count == 0;
        }

        public string Peek()
        {
            if (isEmpty())
            {
                throw new InvalidOperationException("Stack is empty");
            }
            return data[data.Count - 1];
        }
    }
}