using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Chess.Logic; 

namespace Chess.WPF
{
    public partial class OptionsWindow : Window
    {
        public OptionsWindow()
        {
            InitializeComponent();
            Colors = new SolidColorBrush[] {Brushes.Chocolate, Brushes.DarkGray, Brushes.LightGreen, Brushes.LightBlue, Brushes.LightSalmon, Brushes.LightCoral };
        }
        public SolidColorBrush[] Colors { get; private set; }
        private void FirstColor_Click(object sender, RoutedEventArgs e)
        {
            OptionData.FirstCellColor = Array.IndexOf(Colors, (sender as Button).Background);
        }
        private void SecondColor_Click(object sender, RoutedEventArgs e)
        {
            OptionData.SecondCellColor = Array.IndexOf(Colors, (sender as Button).Background);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
