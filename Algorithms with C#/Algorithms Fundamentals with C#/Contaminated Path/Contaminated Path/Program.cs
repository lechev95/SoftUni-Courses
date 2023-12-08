using System;
using System.Collections.Generic;

namespace Contaminated_Path
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[][] grid = new int[n][];
            for (int i = 0; i < n; i++)
            {
                string[] cells = Console.ReadLine().Split();
                grid[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    grid[i][j] = int.Parse(cells[j]);
                }
            }

            string[] contaminatedCells = Console.ReadLine().Split();
            HashSet<(int, int)> contaminatedSet = new HashSet<(int, int)>();
            foreach (var cell in contaminatedCells)
            {
                string[] parts = cell.Split(',');
                int row = int.Parse(parts[0]);
                int col = int.Parse(parts[1]);
                contaminatedSet.Add((row, col));
            }

            int[][] fertilityGrid = new int[n][];
            for (int i = 0; i < n; i++)
            {
                fertilityGrid[i] = new int[n];
            }

            fertilityGrid[0][0] = grid[0][0];

            for (int col = 1; col < n; col++)
            {
                if (contaminatedSet.Contains((0, col)))
                {
                    fertilityGrid[0][col] = -1;
                }
                else
                {
                    fertilityGrid[0][col] = fertilityGrid[0][col - 1] + grid[0][col];
                }
            }

            for (int row = 1; row < n; row++)
            {
                if (contaminatedSet.Contains((row, 0)))
                {
                    fertilityGrid[row][0] = -1;
                }
                else
                {
                    fertilityGrid[row][0] = fertilityGrid[row - 1][0] + grid[row][0];
                }
            }

            for (int row = 1; row < n; row++)
            {
                for (int col = 1; col < n; col++)
                {
                    if (contaminatedSet.Contains((row, col)))
                    {
                        fertilityGrid[row][col] = -1;
                    }
                    else
                    {
                        int maxFertility = Math.Max(fertilityGrid[row - 1][col], fertilityGrid[row][col - 1]);
                        if (maxFertility == -1)
                        {
                            fertilityGrid[row][col] = -1;
                        }
                        else
                        {
                            fertilityGrid[row][col] = maxFertility + grid[row][col];
                        }
                    }
                }
            }

            List<(int, int)> path = new List<(int, int)>();
            int currentRow = n - 1;
            int currentCol = n - 1;
            while (currentRow != 0 || currentCol != 0)
            {
                path.Add((currentRow, currentCol));
                if (currentRow == 0)
                {
                    currentCol--;
                }
                else if (currentCol == 0)
                {
                    currentRow--;
                }
                else if (fertilityGrid[currentRow - 1][currentCol] > fertilityGrid[currentRow][currentCol - 1])
                {
                    currentRow--;
                }
                else
                {
                    currentCol--;
                }
            }
            path.Add((0, 0));
            path.Reverse();

            int maxTotalFertility = fertilityGrid[n - 1][n - 1];
            Console.WriteLine($"Max total fertility: {maxTotalFertility}");
            Console.Write("[");
            for (int i = 0; i < path.Count; i++)
            {
                Console.Write($"({path[i].Item1}, {path[i].Item2})");
                if (i < path.Count - 1)
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine("]");
        }
    }
}