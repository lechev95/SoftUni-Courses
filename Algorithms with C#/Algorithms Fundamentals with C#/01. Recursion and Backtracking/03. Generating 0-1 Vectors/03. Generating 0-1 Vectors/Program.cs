namespace _03._Generating_0_1_Vectors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            GenerateVector(arr, 0);
        }

        private static void GenerateVector(int[] arr, int n)
        {
            if(n >= arr.Length)
            {
                Console.WriteLine(string.Join(string.Empty, arr));
                return;
            }

            for (int i = 0; i < 2; i++)
            {
                arr[n] = i;

                GenerateVector(arr, n + 1); 
            }
        }
    }
}