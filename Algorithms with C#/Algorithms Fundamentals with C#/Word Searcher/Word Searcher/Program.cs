using System;
using System.Collections.Generic;

namespace Word_Searcher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            char[,] grid = new char[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                string row = Console.ReadLine();
                for (int j = 0; j < cols; j++)
                {
                    grid[i, j] = row[j];
                }
            }

            string[] words = Console.ReadLine().Split();

            HashSet<string> foundWords = new HashSet<string>();

            foreach (string word in words)
            {
                bool[,] visited = new bool[rows, cols];
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (grid[i, j] == word[0])
                        {
                            if (DFS(grid, visited, i, j, word, 0))
                            {
                                foundWords.Add(word);
                            }
                        }
                    }
                }
            }

            foreach (string word in foundWords)
            {
                Console.WriteLine(word);
            }
        }

        static bool IsValidCell(int currentRow, int currentCol, int rows, int cols)
        {
            return currentRow >= 0 && currentRow < rows && currentCol >= 0 && currentCol < cols;
        }

        static bool DFS(char[,] grid, bool[,] visited, int currentRow, int currentCol, string word, int currentIndex)
        {
            if (currentIndex == word.Length)
            {
                return true;
            }

            if (!IsValidCell(currentRow, currentCol, grid.GetLength(0), grid.GetLength(1)) || visited[currentRow, currentCol] || grid[currentRow, currentCol] != word[currentIndex])
            {
                return false;
            }

            visited[currentRow, currentCol] = true;

            for (int newRow = currentRow - 1; newRow <= currentRow + 1; newRow++)
            {
                for (int newCol = currentCol - 1; newCol <= currentCol + 1; newCol++)
                {
                    if (newRow != currentRow || newCol != currentCol)
                    {
                        if (DFS(grid, visited, newRow, newCol, word, currentIndex + 1))
                        {
                            return true;
                        }
                    }
                }
            }

            visited[currentRow, currentCol] = false;

            return false;
        }


    }
}