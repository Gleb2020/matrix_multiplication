using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{ 
    
    public static class MatrixExtension
    {
        public static int Rows_Count (this int[,] matrix)
        {
            return matrix.GetUpperBound(0) + 1;
        }

        public static int Columns_Count (this int[,] matrix)
        {
            return matrix.GetUpperBound(1) + 1;
        }
    }
    
}
