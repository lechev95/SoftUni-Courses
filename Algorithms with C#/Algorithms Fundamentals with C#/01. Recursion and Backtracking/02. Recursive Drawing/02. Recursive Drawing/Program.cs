namespace _02._Recursive_Drawing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            PrintN(n);
        }

        private static void PrintN(int n)
        {
            if(n <= 0 )
            {
                return;
            }

            Console.WriteLine(new string('*', n));
            PrintN(n - 1);
            Console.WriteLine(new string('#', n));
        }
    }
}