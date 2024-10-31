using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Функции;

namespace Практическая__2_Трусов
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[,] matrix;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void dt_Grid_Cell(object sender, DataGridCellEditEndingEventArgs e)
        {
            int indcol = e.Column.DisplayIndex;
            int indrow = e.Row.GetIndex();
            matrix[indrow, indcol] = Convert.ToInt32(((TextBox)e.EditingElement).Text);
        }


        private void Create_Click(object sender, RoutedEventArgs e)
        {
            int Col;
            bool f1 = Int32.TryParse(Chis.Text, out Col);
            if (f1 == true)
            {
                if (Col > 0)
                {
                    matrix = new int[1, Col];
                    dt_Grid.ItemsSource = Class2.ToDataTable(matrix).DefaultView;
                    Random random = new Random();
                    matrix = new int[1, Col];
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            int x = 0;                           
                            do 
                            {
                                x = random.Next(-99, 99);

                            } 
                            while (x == 0) ;
                            matrix[i, j] = x;
                        }
                    }
                    dt_Grid.ItemsSource = Class2.ToDataTable(matrix).DefaultView;
                }
            }
            else MessageBox.Show("Введите правильное значение");
        }

        private void Ras_Click(object sender, RoutedEventArgs e)
        {
            Rez.Text = Convert.ToString(Class1.Ras(matrix));
        }

        private void Clean_Click(object sender, RoutedEventArgs e)
        {
            dt_Grid.ItemsSource = null;
            matrix = null;
            Chis.Clear();
            Rez.Clear();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ввести n целых чисел. Найти произведение чисел.\nРезультат вывести на экран");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Class2.Save(matrix);
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            matrix = Class2.Open();
            dt_Grid.ItemsSource = Class2.ToDataTable(matrix).DefaultView;
        }
    }
}