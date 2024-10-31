using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая__2_Трусов
{
    static class Class2
    {
        public static DataTable ToDataTable<T>(this T[,] matrix)
        {
            var res = new DataTable();
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                res.Columns.Add("col" + (i + 1), typeof(T));
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var row = res.NewRow();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    row[j] = matrix[i, j];
                }
                res.Rows.Add(row);
            }

            return res;
        }

        public static void Save(int[,] matr)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "Текстовые файлы (.txt) | *.txt";
            save.Title = "Сохранение таблицы";
            if (save.ShowDialog() == true && matr != null)
            {
                StreamWriter file = new StreamWriter(save.FileName);
                file.WriteLine(matr.GetLength(0));
                file.WriteLine(matr.GetLength(1));
                for (int i = 0; i < matr.GetLength(0); i++)
                {
                    for (int j = 0; j < matr.GetLength(1); j++)
                    {
                        file.WriteLine(matr[i, j]);
                    }
                }
                file.Close();
            }
        }

        public static void Open(ref int[,] matr, out int k1, out int k2)
        {
            k1 = 0; k2 = 0;
            OpenFileDialog open = new OpenFileDialog();
            open.DefaultExt = ".txt";
            open.Filter = "Все файлы (*.*)|*.*| Текстовые файлы (.txt) | *.txt";
            open.FilterIndex = 2;
            open.Title = "Открытие таблицы";
            if (open.ShowDialog() == true)
            {
                StreamReader file = new StreamReader(open.FileName);
                int kol = Convert.ToInt32(file.ReadLine());
                int fol = Convert.ToInt32(file.ReadLine());
                k1 = kol; k2 = fol;
                matr = new int[kol, fol];
                for (int i = 0; i < matr.GetLength(0); i++)
                {
                    for (int j = 0; j < matr.GetLength(1); j++)
                    {
                        matr[i, j] = Convert.ToInt32(file.ReadLine());
                    }
                }
                file.Close();
            }
            else
            {
                matr = new int[0, 0];
            }
        }
    }
}
