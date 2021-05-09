using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Logic
{
    public enum Letters
    {
        A , B, C, D, E, F, G, H
    }
    public enum Sides
    {
        Black, White   //белые снизу, черные сверху 
    }
    public abstract class Figure
    {
        public abstract char Abbreviation { get; }
        public int Digit { get; protected set; } 
        public Letters Letter { get; protected set; }
        public Sides Side { get; protected set; }
        public void MoveFigure(int digit, Letters letter)
        {
            if (CheckRightMove(digit, letter))
            {
                Digit = digit;
                Letter = letter;
            }
            else
            {
                throw new Exception("фигура не может так сходить");
            }
        }
        protected abstract bool CheckRightMove(int digit, Letters letter);
    }
    public class Pawn : Figure         //пешка
    {
        public override char Abbreviation => 'P'; 
        public Pawn(Sides side)
        {
            Side = side;
        }
        protected override bool CheckRightMove(int digit, Letters letter)
        {
            if (Letter == letter)
            {
                if (Digit == 2 && Side == Sides.Black && (digit == 3 || digit == 4))   //первый ход белых
                    return true;
                else if (Digit == 7 && Side == Sides.White && (digit == 6 || digit == 5))  //первый ход черных
                    return true;
                else if (digit == Digit++) // все остальные ходы
                    return true;            
            }
            return false;
        }
    }
    public class Bishop : Figure       //слон
    {
        public override char Abbreviation => 'B';
        public Bishop(Sides side)
        {
            Side = side;
        }
        protected override bool CheckRightMove(int digit, Letters letter)
        {
            if (Math.Abs(digit - Digit) == Math.Abs(letter - Letter))
                return true;
            return false;
        }
    }
    public class Rook : Figure         //ладья
    {
        public override char Abbreviation => 'R';
        public Rook(Sides side)
        {
            Side = side;
        }
        protected override bool CheckRightMove(int digit, Letters letter)
        {
            if (digit == Digit || letter == Letter)
                return true;
            return false;
        }

    }
    class Knight : Figure      //конь 
    {
        public override char Abbreviation => 'H';
        public Knight(Sides side)
        {
            Side = side;
        }
        protected override bool CheckRightMove(int digit, Letters letter)
        {
            if ((Math.Abs(digit - Digit) == 2 && Math.Abs(letter - Letter) == 1) ||
                (Math.Abs(letter - Letter) == 2 && Math.Abs(digit - Digit) == 1))
            {
                return true;
            }
            return false;
        }
    }
    class King : Figure       //король
    {
        public override char Abbreviation => 'K';
        public King(Sides side)
        {
            Side = side;
        }
        protected override bool CheckRightMove(int digit, Letters letter)
        {
            if((Math.Abs(digit - Digit) == 0 || Math.Abs(digit - Digit) == 1) &&
               (Math.Abs(letter - Letter) == 0 || Math.Abs(letter - Letter) == 1))
            {
                return true;
            }
            return false;
        }
    }
    class Queen : Figure       //ферзь
    {
        public override char Abbreviation => 'Q';
        public Queen(Sides side)
        {
            Side = side;
        }
        protected override bool CheckRightMove(int digit, Letters letter)
        {
            if((Math.Abs(digit - Digit) == Math.Abs(letter - Letter)) ||
                (digit == Digit || letter == Letter))
            { 
                return true;
            }
            return false;
        }
    }
}
