using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStackSort
{
    internal class Item
    {
        public int Value { get; set; }
        public Item Previous { get; set; }
        public Item(int value, Item previous)
        {
            Value = value;
            Previous = previous;
        }
    }
}
