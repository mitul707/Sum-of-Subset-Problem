using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOfSubsetProblem
{
    class Program
    {
        // This program checks if sum of subset of array contains the given sum

        /*
         * For example 
         * 1) given array Arr = {5,2,8} and find sum = 15
         * Then it gives output as 'The array contains the sum of its subset...' 
         *              5 + 2 + 8 = 15
         * 2) given array Arr = {5,2,8} and find sum = 10
         * Then it gives output as 'The array contains the sum of its subset...'
         *              2 + 8 = 10
         * 3) given array Arr = {5,2,8} and find sum = 9
         * Then it gives output as 'The array dose not contain the sum of its subset...'
         */
        static void Main(string[] args)
        {
            Program obj = new Program();
            int[] myArr = {5, 2};
            int sum = 8;

            obj.canGetSum(myArr, sum);
        }

        private void canGetSum(int[] arr, int sum)
        {
            int[,] mat = new int[arr.Length, sum + 1];

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < sum + 1; j++)
                {
                    if (j == 0)
                    { 
                        mat[i, j] = 1;
                        continue;
                    }
                    if (j - arr[i] < 0)
                    {
                        if (i == 0)
                            mat[i, j] = 0;                        
                        else
                            mat[i, j] = mat[i - 1, j];
                    }
                    else if (j - arr[i] == 0)
                    {
                        mat[i, j] = 1;
                    }
                    else
                    {
                        if (i == 0)
                            mat[i, j] = 0;
                        else
                            mat[i, j] = mat[i - 1, j - arr[i]];
                    }
                }
            }

            Console.Write("  ");
            for (int i = 0; i < sum + 1; i++)
            {
                Console.Write(" , "+i);
            }
                Console.WriteLine();
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                Console.Write(arr[i]+ "--> ");
                for (int j = 0; j <mat.GetLength(1); j++)
                {
                    Console.Write(mat[i,j]);
                    Console.Write(" , ");
                }
                Console.WriteLine();
                Console.WriteLine();
            }

            if (mat[arr.Length - 1, sum] == 1)
            {
                Console.WriteLine("The array contains the sum of its subset...");
            }
            else
            {
                Console.WriteLine("The array dose not contain the sum of its subset...");
            }
            Console.Read();
        }
    }
}