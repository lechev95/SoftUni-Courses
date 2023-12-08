namespace RecursionTasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool outOfBounds = false;
            string result = "Here is your output: ";

            while (!outOfBounds)
            {

                Console.WriteLine("------------Recusion tasks program------------");
                Console.WriteLine("--    1. Print Natural Numbers              --");
                Console.WriteLine("--    2. Print Positive Numbers             --");
                Console.WriteLine("--    3. Print Sum of first N numbers       --");
                Console.WriteLine("--    4. Print Separate digits of number    --");
                Console.WriteLine("--    5. Print Number of digits of a number --");
                Console.WriteLine("----------------------------------------------");

                int input = int.Parse(Console.ReadLine());

                if (input <= 0 || input > 7)
                {
                    outOfBounds = true;
                }
                else
                {
                    outOfBounds = false;
                    switch (input)
                    {
                        case 1:
                            Console.WriteLine("Input starting number:");
                            int number = int.Parse(Console.ReadLine());
                            Console.WriteLine("Input count of numbers to print:");
                            int range = int.Parse(Console.ReadLine());
                            Console.WriteLine(result);
                            PrintNatural(number, range);
                            Console.WriteLine();
                            break;
                        case 2:
                            Console.WriteLine("This option will print numbers from 1 to N! ");
                            Console.WriteLine("Keep in mind to set a positive number for the end range,");
                            Console.WriteLine("otherwise there won't be any output");
                            Console.WriteLine("Input the last number of the range:");
                            range = int.Parse(Console.ReadLine());
                            Console.WriteLine(result);
                            PrintPositive(range);
                            Console.WriteLine();
                            break;
                        case 3:
                            Console.WriteLine("This option will print sum of first numbers from the input");
                            range = int.Parse(Console.ReadLine());
                            Console.WriteLine(result);
                            Console.WriteLine(SumFirstN(range));
                            Console.WriteLine();
                            break;
                        case 4:
                            Console.WriteLine("This option will print separate digits of a number from the input");
                            range = int.Parse(Console.ReadLine());
                            Console.WriteLine(result);
                            SeparateDigits(range);
                            Console.WriteLine();
                            break;
                        case 5:
                            Console.WriteLine("This option will print number of digits of a number from the input");
                            range = int.Parse(Console.ReadLine());
                            Console.WriteLine(result);
                            Console.WriteLine(NumberDigits(range));
                            Console.WriteLine();
                            break;
                    }
                }
            }
        }

        private static void PrintNatural(int number, int n) 
        {
            if(n + 1 < 1)
            {
                return;
            }
            Console.Write(number + " ");
            n--;
            PrintNatural(number + 1, n);
        }

        private static void PrintPositive(int n)
        {
            if(n < 1)
            {
                return;
            }

            Console.Write(n + " ");
            n--;
            PrintPositive(n);
        }

        private static int SumFirstN(int n) 
        {
            if(n == 1)
            {
                return n;
            }

            return n + SumFirstN(n - 1);

        }

        private static void SeparateDigits(int n)
        {
            if(n < 10)
            {
                Console.Write(n + " ");
                return;
            }

            SeparateDigits(n / 10);
            Console.Write($"{n % 10} ");
        }

        private static int NumberDigits(int n)
        {
            if (n == 0)
            {
                return 0;
            }

            return 1 + NumberDigits(n / 10);
        }
    }
}