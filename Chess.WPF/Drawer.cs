using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using Chess.Logic;

namespace Chess.WPF
{
    static class Drawer
    {
        public static void CreateField(Board board, Canvas canvas)
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Label label = new Label()
                    {
                        Content = board.Field[i, j].Abbreviation
                    };
                    Canvas.SetTop(label, i);
                    Canvas.SetLeft(label, j);
                    canvas.Children.Add(label);
                }
            }
        }
    }
}
