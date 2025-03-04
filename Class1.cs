﻿using Microsoft.Win32;
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

        public static void Save(int[,] array)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "Текстовые файлы (.txt) | *.txt";
            save.Title = "Сохранение таблицы";
            if (save.ShowDialog() == true && array != null)
            {
                using (StreamWriter file = new StreamWriter(save.FileName))
                {
                    for (int i = 0; i < array.GetLength(0); i++)
                    {
                        for (int j = 0; j < array.GetLength(1); j++)
                        {
                            file.Write(array[i, j].ToString());
                            if (j < array.GetLength(1) - 1)
                            {
                                file.Write(" ");
                            }
                        }
                        file.WriteLine();
                    }
                }
            }
        }

        public static int[,] Open()
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Все файлы (*.*)|*.*| Текстовые файлы (.txt) | *.txt";
            open.FilterIndex = 2;
            open.Title = "Открытие таблицы";
            int row = 0;
            int column = 0;
            List<int> values = new List<int>();
            if (open.ShowDialog() == true)
            {
                using (StreamReader file = new StreamReader(open.FileName))
                {
                    while (!file.EndOfStream)
                    {
                        string line = file.ReadLine();
                        string[] valuesStr = line.Split(' ');
                        foreach (string valueStr in valuesStr)
                        {
                            if (Int32.TryParse(valueStr, out int value))
                            {
                                values.Add(value);
                                column++;
                            }
                            else
                            {
                                return null;
                            }
                        }
                        row++;
                    }
                }
                column /= row;
                int indexList = 0;
                int[,] array = new int[row, column];
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        array[i, j] = values[indexList];
                        indexList++;
                    }
                }
                return array;
            }
            return null;
        }
    }
}
