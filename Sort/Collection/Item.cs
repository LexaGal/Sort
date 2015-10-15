using System;
using System.Globalization;

namespace Sort.Collection
{
    public class Item : IComparable<Item>
    {
        public Item(double value)
        {
            Value = value;
        }

        public double Value { get; private set; }

        public override bool Equals(object obj)
        {
            Item item = obj as Item;
            return item != null && Math.Abs(Math.Abs(Value - item.Value)) < 0.001;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return Value.ToString(CultureInfo.InvariantCulture);
        }

        public int CompareTo(Item other)
        {
            return Value > other.Value ? 1 : Value < other.Value ? -1 : 0;
        }
    }
}