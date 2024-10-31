using System;

namespace Функции
{
    public class Class1
    {
        public static int Ras(int[,] matrix)
        {
            int a = 1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    a = a * matrix[i, j];
                }
            }
            return a;
        }
    }

}
