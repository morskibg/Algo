using System;

namespace SpiralMatrix
{
   
    class Program
    {
        static int[,] matrix;
        static int rows;
        static int cols;
        static int currCounter = 0;
        static int currRow = 0;
        static int currCol = 0;
        static int directions = 0;
        static void Main(string[] args)
        {
            rows = 5;// int.Parse(Console.ReadLine());
            cols = 5;// int.Parse(Console.ReadLine());
            matrix = new int[rows, cols];
            FillMatrix(0);
            Print();
           
        }

        private static void Print()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        private static void FillMatrix(int direction)                              // 0 - down
        {                                                                          // 1 - right
            if(currCounter == cols * rows)                                         // 2 - up
            {                                                                      // 3 - left
                return;
            }
            //down
            if(direction == 0)
            {
                for (int i = 0; i < rows; i++)
                {
                    if(matrix[i, currCol] != 0)
                    {
                        continue;
                    }
                    ++currCounter;
                    matrix[i, currCol] = currCounter;                    
                    currRow = i;
                }
                FillMatrix(1);
            }
            //right
            else if(direction == 1)
            {
                for (int i = 0; i < cols; i++)
                {
                    if(matrix[currRow, i] != 0)
                    {
                        continue;
                    }
                    ++currCounter;
                    matrix[currRow, i] = currCounter;
                    
                    currCol = i;
                    
                }
                FillMatrix(2);
            }
            //up
            else if(direction == 2)
            {
                for (int i = rows - 1; i >= 0; i--)
                {
                    if (matrix[i, currCol] != 0)
                    {
                        continue;
                    }
                    ++currCounter;
                    matrix[i, currCol] = currCounter;
                    
                    currRow = i;
                }
                FillMatrix(3);
            }
            //left
            else if (direction == 3)
            {
                for (int i = cols - 1; i >= 0; i--)
                {
                    if (matrix[currRow, i] != 0)
                    {
                        continue;
                    }
                    ++currCounter;
                    matrix[currRow, i] = currCounter;
                    currCol = i;
                    
                }
                FillMatrix(0);
            }

        }

        private static bool IsInBound(int currRow, int currCol)
        {
            return currRow >= 0 && currRow < rows && currCol >= 0 && currCol < cols;
        }
       
        
    }
}
