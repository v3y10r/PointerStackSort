//TODO: заменить sorting на фиксированное двухпутевое слияние
namespace MyStackSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack stack = new Stack();
            Random rand = new Random();
            int N = 5;
            for (int i = 0; i < N; i++)
            {
                stack.Push(new Item(rand.Next(1, 100), null));
            }
            stack.Print();
            for (int i = 0; i < N; i++)
            {
                bool flag = false;
                for (int j = 0; j < N - 1 - i; j++)
                {
                    if (stack.Get(j) > stack.Get(j + 1))
                    {
                        int f = stack.Get(j);
                        stack.Set(j, stack.Get(j + 1));
                        stack.Set(j + 1, f);
                        flag = true;
                    }
                }
                if (!flag)
                {
                    break;
                }
            } //Sorting
            Console.WriteLine();
            stack.Print();
        }
    }
}