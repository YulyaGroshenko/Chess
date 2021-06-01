using Chess.Logic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Chess.Logic;

namespace Chess.WPF
{
    public partial class GameWindow : Window
    {
        public GameWindow(Game game)
        {
            InitializeComponent();
            Canvas.Width = this.Width;
            Canvas.Height = this.Height;
            Field = game.Board.Field;
            Game = game;
            CreateField();
        }
        public Figure[,] Field { get; private set; }
        public Figure Figure { get; private set; }
        public Letters Letter { get; private set; }
        public int Digit { get; private set; }
        public bool SelectFigure { get; private set; } = true;
        public bool SelectCell { get; private set; }
        public Game Game { get; set; }
        public void CreateField()
        {
            for (int i = 0; i < 8; i++) // y
            {
                for (int k = 0; (int)k < 8; k++) // x
                {
                    Button button = new Button()
                    {
                        BorderThickness = new Thickness(1),
                        BorderBrush = Brushes.Black
                    };
                    button.Click += Button_Click;
                    if (Field[i, (int)k] != null)
                    {
                        Field[i, (int)k].Digit = i;
                        Field[i, (int)k].Letter = (Letters)k;
                        button.Content = Field[i, (int)k].Abbreviation;
                    }
                    else
                    {
                        button.Content = " ";
                    }
                    Canvas.Children.Add(button);
                }
            }
        }
        public void PrintField()
        {
            for (int i = 0; i < Canvas.Children.Count; i++)
            {
                Button button = Canvas.Children[i] as Button;
                button.Width = Canvas.Width / 8 - 1;
                button.Height = Canvas.Height / 8 - 4;
                Canvas.SetLeft(button, button.Width * (i%8));
                Canvas.SetTop(button, button.Height * (i/8));
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = Canvas.Children.IndexOf(sender as Button);
            if (SelectFigure)
            {
                Digit = index / 8;
                Letter = (Letters)(index % 8);
                Field[Digit, (int)Letter].Digit = Digit;
                Field[Digit, (int)Letter].Letter = Letter;
                Figure = Field[Digit, (int)Letter];
                SelectFigure = false;
                SelectCell = true;
            }
            else if (SelectCell)
            {
                Digit = index / 8;
                Letter = (Letters)(index % 8);
                Game.Play(Figure, Digit, Letter);
                SelectCell = false;
                SelectFigure = true;
            }
            PrintField();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Canvas.Width = this.ActualWidth;
            Canvas.Height = this.ActualHeight;
            PrintField();
        }
    }
}
