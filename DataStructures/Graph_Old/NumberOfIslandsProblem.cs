using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.GraphOld
{
    public class NumberOfIslandsProblem
    {
        private int[,] inputMatrix;
        private bool[,] visited;
        int numberOfIslands = 0;

        public NumberOfIslandsProblem(int[,] inputMatrix)
        {
            if (inputMatrix == null)
            {
                throw new ArgumentNullException("inputMatrix");
            }

            this.inputMatrix = inputMatrix;

            this.visited = new bool[inputMatrix.GetLength(0), inputMatrix.GetLength(1)];
        }

        private void DFS(int row, int col)
        {
            this.visited[row, col] = true;            

            // Neighbors
            for (int i = row - 1; i <= row + 1; i++)
            {
                for (int j = col - 1; j <= col + 1; j++)
                {
                    if (i >= 0 && i < this.inputMatrix.GetLength(0)
                        && j >= 0 && j < this.inputMatrix.GetLength(1) && inputMatrix[i, j] == 1)
                    {
                        if (!this.visited[i, j])
                        {
                            Console.WriteLine("DFS:({0},{1})", i, j);
                            this.DFS(i, j);
                        }
                    }
                }
            }
        }

        public int CountNumberOfIslands()
        {
            for (int i = 0; i < this.inputMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < this.inputMatrix.GetLength(1); j++)
                {
                    if (this.inputMatrix[i, j] == 1 && !this.visited[i, j])
                    {
                        Console.WriteLine("DFS :({0},{1})",i,j);
                        this.DFS(i, j);

                        Console.WriteLine("--------------------------------------------");
                        this.numberOfIslands++;
                    }
                }
            }

            return this.numberOfIslands;
        }
    }
}
