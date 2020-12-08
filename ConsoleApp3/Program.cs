using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        
        public static int[,] Matrix_Read()
        {
            Console.WriteLine("Введите адрес файла с матрицей:");
            string path = Console.ReadLine();
            List<string> rows_input = new List<string>();
            //string path = @"C:\программирование\1дз\задача1\matrix1.txt";
            string[] sizes = new string[2];
            int row = 0;
            int column = 0;
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    sizes = sr.ReadLine().Split();
                    row = Convert.ToInt32(sizes[0]);
                    column = Convert.ToInt32(sizes[1]);
                    for (int i = 0;i < row; i++)
                    {
                        rows_input.Add(sr.ReadLine().Trim());
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            int[,] matrix = new int[row, column];
            
            for (int i = 0;i < rows_input.Count; i++)
            {
                int j = 0;
                foreach (var u in rows_input[i].Split())
                {
                    matrix[i,j] = Convert.ToInt32(u);
                    j++;
                }
            }

            return matrix;
        }

        public static string Output_address()
        {
            Console.WriteLine("Введите адрес файла, где должен находиться результат:");
            return (Console.ReadLine());
        }

        public static int[,] Matrix_Multiplication(int[,] matrix1, int[,] matrix2)
        {
            if (matrix1.Columns_Count() != matrix2.Rows_Count()) throw new Exception("Эти матрицы не могут быть умножены");
            int[,] matrix = new int[matrix1.Rows_Count(), matrix2.Columns_Count()];
            for (int n = 0;n < matrix1.Rows_Count(); n++)
            {
                for (int m = 0;m < matrix2.Columns_Count(); m++)
                {
                    int cell = 0;
                    for (int i = 0;i < matrix1.Columns_Count(); i++)
                    {
                        cell += matrix1[n,i] * matrix2[i,m];
                    }
                    matrix[n, m] = cell;
                }
            }
            return matrix;
        }

        public static void Matrix_Print(int[,] matrix, string writePath)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    for (int row_index = 0; row_index < matrix.Rows_Count(); row_index++)
                    {
                        for (int column_index = 0; column_index < matrix.Columns_Count(); column_index++)
                        {
                            sw.Write(matrix[row_index, column_index] + " ");
                        }
                        sw.WriteLine();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    
        static void Main(string[] args)
        {
            var m1 = Matrix_Read();
            var m2 = Matrix_Read();
            var m = Matrix_Multiplication(m1, m2);
            
            //string writePath = @"C:\программирование\1дз\задача1\result.txt";
            string writePath = Output_address();
            Matrix_Print(m,writePath);
            


        }
    }
}
