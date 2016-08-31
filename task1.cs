using System;
using System.Linq;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            //enter path to file
            Calculation compute = new Calculation("Redirecting2.txt");

            for (int i = compute.triangle.GetUpperBound(1) - 1; i >= 0; i--)
            {
                compute.triangle = compute.FindMaxPath(compute.triangle, i);

            }
            Console.WriteLine(compute.triangle[0, 0]);
            Console.ReadKey();
        }
    }

    internal class Calculation
    {
        public int[,] triangle = new int[100, 100];
        public Calculation(string FilePath)
        {
            string[] lines = System.IO.File.ReadAllLines(FilePath);
            //Spliting of the File
            for (int i = 0; i < lines.Count(); i++)
            {
                string[] cells = lines[i].Split(' ');
                for (int j = 0; j <= i; j++)
                    triangle[i, j] = Int32.Parse(cells[j]);
            }
        }

        public int[,] FindMaxPath(int[,] T, int i)
        {
            //Search maximal elements and feeding them to the top of the small triangle
            for (int j = 0; j <= i; j++)
            {
                T[i, j] = T[i, j] + Math.Max(T[i + 1, j], T[i + 1, j + 1]);
            }
            return T;
        }
    }
}
