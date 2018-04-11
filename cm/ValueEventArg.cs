using System;

namespace cm
{
    public class ValueEventArg<T> : EventArgs
    {
        public T Value { get; }

        public ValueEventArg(T value)
        {
            Value = value;
        }
    }
}