using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStackSort
{
    internal class Stack
    {
        public Item tail = null;
        public Item Pop()
        {
            if (tail == null) { throw new Exception("Stack is empty"); }
            Item tmp = tail;
            tail = tail.Previous;
            tmp.Previous = null;
            return tmp;
        }
        public void Push(Item item)
        {
            if (tail == null)
            {
                tail = item;
                tail.Previous = null;

            }
            else
            {
                item.Previous = tail;
                tail = item;
            }
        }
        public int Get(int index)
        {
            Stack tmp = new Stack();
            int counter = 0;
            for (counter = 0; counter < index; counter++)
            {
                tmp.Push(Pop());
            }
            int itemToGet = tail.Value;
            while (counter != 0)
            {
                Push(tmp.Pop());
                counter--;
            }
            return itemToGet;
        }
        public void Set(int index, int value)
        {
            Stack tmp = new Stack();
            int counter = 0;
            for (counter = 0; counter < index; counter++)
            {
                tmp.Push(Pop());
            }
            tail.Value = value;
            while (counter != 0)
            {
                Push(tmp.Pop());
                counter--;
            }
        }
        public void Print()
        {
            Item current = tail;
            while (current != null)
            {
                Console.Write(current.Value + " ");
                current = current.Previous;
            }
        }
    }
}
