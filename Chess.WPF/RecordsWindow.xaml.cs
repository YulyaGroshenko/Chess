using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
<<<<<<< Updated upstream
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Chess.WPF
{
    /// <summary>
    /// Логика взаимодействия для RecordsWindow.xaml
    /// </summary>
=======
using Chess.Logic;
using System.IO;
using System.Windows.Controls;

namespace Chess.WPF
{
>>>>>>> Stashed changes
    public partial class RecordsWindow : Window
    {
        public RecordsWindow()
        {
            InitializeComponent();
<<<<<<< Updated upstream
=======
            RecordsList.Content = SetRecords();
        }
        public StringBuilder SetRecords()
        {
            string[] records = File.ReadAllLines($"{FileWorker.Records}");
            StringBuilder stringBuilder = new StringBuilder();
            foreach (string rec in records)
            {
                stringBuilder.Append($"{rec}\n");
            }
            return stringBuilder;
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Grid.Width = this.ActualWidth;
            Grid.Height = this.ActualHeight;
>>>>>>> Stashed changes
        }
    }
}
