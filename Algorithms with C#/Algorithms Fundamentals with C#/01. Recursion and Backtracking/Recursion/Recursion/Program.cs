namespace Recursion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(ArrSum(arr, 0));
        }

        private static int ArrSum(int[] arr, int index)
        {
            if(index >= arr.Length)
            {
                return 0;
            }

            return arr[index] + ArrSum(arr, index + 1);
        }
    }
}