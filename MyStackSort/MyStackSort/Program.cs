using System.IO.Pipes;
using System.Reflection;

namespace MyStackSort
{
    internal class Program
    {
        static void merge(Stack stack, int left, int middle, int right) // Merges two subarrays of []arr.
            // First subarray is arr[left..middle]
            // Second subarray is arr[middle..right]
        {
            Stack temp = new Stack();
            int i = 0, j = 0;
            int lenLeft = middle - left + 1;
            int lenRight = right - middle;
            while (i < lenLeft && j < lenRight)
            {
                if (stack.Get(left + i) <= stack.Get(middle + 1 + j))
                {
                    temp.Push(new Item(stack.Get(left + i), null));
                    i++;
                }
                else
                {
                    temp.Push(new Item(stack.Get(middle + 1 + j), null));
                    j++;
                }
            }
            while (i < lenLeft)
            {
                temp.Push(new Item(stack.Get(left + i), null));
                i++;
            }
            while (j < lenRight)
            {
                temp.Push(new Item(stack.Get(middle + 1 + j), null));
                j++;
            }
            for (i = 0; i < lenLeft + lenRight; i++)
            {
                stack.Set(left + i, temp.Get(lenLeft + lenRight - 1 - i));
            }
        }
        static void sort(Stack stack, int left, int right)// Main function that sorts arr[left..right] using merge()
        {
            if (left < right)
            {
                // Finding the middle
                int middle = (left + right) / 2;
                // Now we will recursively sort left and right parts
                sort(stack, left, middle);
                sort(stack, middle + 1, right);
                // And merge them
                merge(stack, left, middle, right);
            }
        }
        static void Main(string[] args)
        {
            //Init////////////////////////////////////
            Stack stack = new Stack();
            Random rand = new Random();
            int N = 5;
            for (int a = 0; a < N; a++)
            {
                stack.Push(new Item(rand.Next(1, 100), null));
            }
            stack.Print();
            Console.WriteLine();
            //Sort////////////////////////////////////
            sort(stack, 0, N - 1);
            ///////////////////////////////////////////
            stack.Print();
        }
    }
}