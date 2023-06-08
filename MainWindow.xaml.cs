using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Schema;
using System.Diagnostics;
using ProbaNumer2;

using static System.Net.Mime.MediaTypeNames;
using System.Reflection.Metadata;

namespace ProbaNumer2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Button[,] buttons = new Button[8, 8];
        int[,] pos = new int[8, 8];
        private Button firstClick;
        private Button secondClick;
        private int CurrentRow=-100;
        private int CurrentColumn=-100;
        private bool BlackPawnCheck = false;
        private bool WhitePawnCheck = false;
        private bool BlackBishopCheck = false;
        private bool WhiteBishopCheck = false;
        private bool WhiteRookCheck = false;
        private bool BlackRookCheck = false;
        private bool BlackKnightCheck = false;
        private bool WhiteKnightCheck = false;
        private bool BlackQueenCheck = false;
        private bool WhiteQueenCheck = false;
        private bool WhiteKingCheck = false;
        private bool BlackKingCheck = false;
        int turn = 1;
        private bool GlobalTurn = true;


        public MainWindow()
        {
            InitializeComponent();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Button button = new Button();
                    
                    //button.Content = image;

                    Grid.SetRow(button, i);
                    Grid.SetColumn(button, j);

                    button.Click += Button_Click;

                    UGrid.Children.Add(button);

                    buttons[i, j] = button;

                    if ((i + j) % 2 == 0)
                    {
                        button.Background = Brushes.Gray;
                    }
                    else
                    {
                        button.Background = Brushes.White;
                    }
                }
            }

            System.Windows.Controls.Image Bpawn0 = new System.Windows.Controls.Image();
            Bpawn0.Source = Images.BPawn;

            System.Windows.Controls.Image Bpawn1 = new System.Windows.Controls.Image();
            Bpawn1.Source = Images.BPawn;

            System.Windows.Controls.Image Bpawn2 = new System.Windows.Controls.Image();
            Bpawn2.Source = Images.BPawn;

            System.Windows.Controls.Image Bpawn3 = new System.Windows.Controls.Image();
            Bpawn3.Source = Images.BPawn;

            System.Windows.Controls.Image Bpawn4 = new System.Windows.Controls.Image();
            Bpawn4.Source = Images.BPawn;

            System.Windows.Controls.Image Bpawn5 = new System.Windows.Controls.Image();
            Bpawn5.Source = Images.BPawn;

            System.Windows.Controls.Image Bpawn6 = new System.Windows.Controls.Image();
            Bpawn6.Source = Images.BPawn;

            System.Windows.Controls.Image Bpawn7 = new System.Windows.Controls.Image();
            Bpawn7.Source = Images.BPawn;

            buttons[1, 0].Content = Bpawn0;
            buttons[1, 1].Content = Bpawn1;
            buttons[1, 2].Content = Bpawn2;
            buttons[1, 3].Content = Bpawn3;
            buttons[1, 4].Content = Bpawn4;
            buttons[1, 5].Content = Bpawn5;
            buttons[1, 6].Content = Bpawn6;
            buttons[1, 7].Content = Bpawn7;

            System.Windows.Controls.Image Bbishop0 = new System.Windows.Controls.Image();
            Bbishop0.Source = Images.BBishop;

            System.Windows.Controls.Image Bbishop1 = new System.Windows.Controls.Image();
            Bbishop1.Source = Images.BBishop;

            buttons[0, 2].Content = Bbishop0;
            buttons[0, 5].Content = Bbishop1;


            System.Windows.Controls.Image BKnight0 = new System.Windows.Controls.Image();
            BKnight0.Source = Images.BKnight;

            System.Windows.Controls.Image BKnight1 = new System.Windows.Controls.Image();
            BKnight1.Source = Images.BKnight;

            buttons[0, 1].Content = BKnight0;
            buttons[0, 6].Content = BKnight1;

            System.Windows.Controls.Image BRook0 = new System.Windows.Controls.Image();
            BRook0.Source = Images.BRook;

            System.Windows.Controls.Image BRook1 = new System.Windows.Controls.Image();
            BRook1.Source = Images.BRook;

            buttons[0, 0].Content = BRook0;
            buttons[0, 7].Content = BRook1;

            System.Windows.Controls.Image BQueen0 = new System.Windows.Controls.Image();
            BQueen0.Source = Images.BQueen;

            buttons[0, 4].Content = BQueen0;

            System.Windows.Controls.Image BKing0 = new System.Windows.Controls.Image();
            BKing0.Source = Images.BKing;

            buttons[0, 3].Content = BKing0;

            System.Windows.Controls.Image Wpawn0 = new System.Windows.Controls.Image();
            Wpawn0.Source = Images.WPawn;

            System.Windows.Controls.Image Wpawn1 = new System.Windows.Controls.Image();
            Wpawn1.Source = Images.WPawn;

            System.Windows.Controls.Image Wpawn2 = new System.Windows.Controls.Image();
            Wpawn2.Source = Images.WPawn;

            System.Windows.Controls.Image Wpawn3 = new System.Windows.Controls.Image();
            Wpawn3.Source = Images.WPawn;

            System.Windows.Controls.Image Wpawn4 = new System.Windows.Controls.Image();
            Wpawn4.Source = Images.WPawn;

            System.Windows.Controls.Image Wpawn5 = new System.Windows.Controls.Image();
            Wpawn5.Source = Images.WPawn;

            System.Windows.Controls.Image Wpawn6 = new System.Windows.Controls.Image();
            Wpawn6.Source = Images.WPawn;

            System.Windows.Controls.Image Wpawn7 = new System.Windows.Controls.Image();
            Wpawn7.Source = Images.WPawn;

            buttons[6, 0].Content = Wpawn0;
            buttons[6, 1].Content = Wpawn1;
            buttons[6, 2].Content = Wpawn2;
            buttons[6, 3].Content = Wpawn3;
            buttons[6, 4].Content = Wpawn4;
            buttons[6, 5].Content = Wpawn5;
            buttons[6, 6].Content = Wpawn6;
            buttons[6, 7].Content = Wpawn7;

            System.Windows.Controls.Image Wbishop0 = new System.Windows.Controls.Image();
            Wbishop0.Source = Images.WBishop;

            System.Windows.Controls.Image Wbishop1 = new System.Windows.Controls.Image();
            Wbishop1.Source = Images.WBishop;

            buttons[7, 2].Content = Wbishop0;
            buttons[7, 5].Content = Wbishop1;

            System.Windows.Controls.Image WKnight0 = new System.Windows.Controls.Image();
            WKnight0.Source = Images.WKnight;

            System.Windows.Controls.Image WKnight1 = new System.Windows.Controls.Image();
            WKnight1.Source = Images.WKnight;

            buttons[7, 1].Content = WKnight0;
            buttons[7, 6].Content = WKnight1;

            System.Windows.Controls.Image WRook0 = new System.Windows.Controls.Image();
            WRook0.Source = Images.WRook;

            System.Windows.Controls.Image WRook1 = new System.Windows.Controls.Image();
            WRook1.Source = Images.WRook;

            buttons[7, 0].Content = WRook0;
            buttons[7, 7].Content = WRook1;


            System.Windows.Controls.Image WQueen0 = new System.Windows.Controls.Image();
            WQueen0.Source = Images.WQueen;

            buttons[7, 4].Content = WQueen0;

            System.Windows.Controls.Image WKing0 = new System.Windows.Controls.Image();
            WKing0.Source = Images.WKing;

            buttons[7, 3].Content = WKing0;


            foreach (int row in pos)
            {
                foreach(int col in pos)
                {
                    pos[row,col] = 0;
                }
            }
            pos[1,0] = 1;
            pos[1,1] = 1;
            pos[1,2] = 1;
            pos[1,3] = 1;
            pos[1,4] = 1;
            pos[1,5] = 1;
            pos[1,6] = 1;
            pos[1,7] = 1;
            pos[6,0] = 11;
            pos[6,1] = 11;
            pos[6,2] = 11;
            pos[6,3] = 11;
            pos[6,4] = 11;
            pos[6,5] = 11;
            pos[6,6] = 11;
            pos[6,7] = 11;
            pos[0,2] = 2;
            pos[0,5] = 2;
            pos[7,2] = 12;
            pos[7,5] = 12;
            pos[7,0] = 14;
            pos[7,7] = 14;
            pos[0,0] = 4;
            pos[0,7] = 4;
            pos[0,1] = 3;
            pos[0,6] = 3;
            pos[7,1] = 13;
            pos[7,6] = 13;
            pos[0,4] = 5;
            pos[7,4] = 15;
            pos[7,3] = 2000;
            pos[0,3] = 1000;
            //WhitePawn Wpawn1 = new WhitePawn();
            //Wpawn1.type = 1; Wpawn1.posX = 1; Wpawn1.posY = 0;
            //pos[Wpawn1.posX,Wpawn1.posY] = 1;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Button button = (Button)sender;
            int column = Grid.GetColumn(button);
            int row = Grid.GetRow(button);


            //    switch(turn)
            //        {
            //        case 0:

            if (GlobalTurn == false)
            {
                Debug.WriteLine("RUCH CZARNYCH " + GlobalTurn);
                // CZARNY PIONEK BICIE
                if (pos[row, column] > 10 && BlackPawnCheck == true)
                {
                    Debug.WriteLine("CZARNY PIONEK ATTACK");
                    BlackPawnAttack(row, column, button);

                }
                // CZARNY PIONEK RUCH
                else if ((pos[row, column] == 1 || BlackPawnCheck == true) && WhitePawnCheck == false && WhiteBishopCheck == false && WhiteKnightCheck == false && WhiteRookCheck == false && WhiteQueenCheck == false && WhiteKingCheck == false)
                {
                    Debug.WriteLine("CZARNY PIONEK");
                    BlackPawnMove(row, column, button);

                }
                // CZARNY GONIEC
                if ((pos[row, column] == 2 || BlackBishopCheck == true) && WhitePawnCheck == false && WhiteBishopCheck == false && WhiteKnightCheck == false && WhiteRookCheck == false && WhiteQueenCheck == false && WhiteKingCheck == false)
                {
                    Debug.WriteLine("CZARNY GONIEC");
                    BlackBishopMove(row, column, button);

                }
                // CZARNY SKOCZEK
                if ((pos[row, column] == 3 || BlackKnightCheck == true) && WhitePawnCheck == false && WhiteBishopCheck == false && WhiteKnightCheck == false && WhiteRookCheck == false && WhiteQueenCheck == false && WhiteKingCheck == false)
                {
                    Debug.WriteLine("CZARNY SKOCZEK");
                    BlackKnightMove(row, column, button);

                }
                // CZARNY WIEŻA
                if ((pos[row, column] == 4 || BlackRookCheck == true) && WhitePawnCheck == false && WhiteBishopCheck == false && WhiteKnightCheck == false && WhiteRookCheck == false && WhiteQueenCheck == false && WhiteKingCheck == false)
                {
                    Debug.WriteLine("CZARNY WIEŻA");
                    BlackRookMove(row, column, button);

                }
                // CZARNY HETMAN
                if ((pos[row, column] == 5 || BlackQueenCheck == true) && WhitePawnCheck == false && WhiteBishopCheck == false && WhiteKnightCheck == false && WhiteRookCheck == false && WhiteQueenCheck == false && WhiteKingCheck == false)
                {
                    Debug.WriteLine("CZARNY HETMAN");
                    BlackQueenMove(row, column, button);

                }
                // CZARNY KRÓL
                if ((pos[row, column] == 1000 || BlackKingCheck == true) && WhitePawnCheck == false && WhiteBishopCheck == false && WhiteKnightCheck == false && WhiteRookCheck == false && WhiteQueenCheck == false && WhiteKingCheck == false)
                {
                    Debug.WriteLine("CZARNY KRÓL");
                    BlackKingMove(row, column, button);

                }
            }
            else if (GlobalTurn == true)
            {
                Debug.WriteLine("RUCH BIAŁYCH " + GlobalTurn);
                //            break;

                //        case 1:    
                // BIAŁY PIONEK BICIE
                if (pos[row, column] < 10 && pos[row, column] > 0 && WhitePawnCheck == true)
                {
                    Debug.WriteLine("BIAŁY PIONEK ATTACK");
                    WhitePawnAttack(row, column, button);
                }
                // BIAŁY PIONEK RUCH
                else if ((pos[row, column] == 11 || WhitePawnCheck == true) && BlackPawnCheck == false && BlackBishopCheck == false && BlackKnightCheck == false && BlackRookCheck == false && BlackQueenCheck == false && BlackKingCheck == false)
                {
                    Debug.WriteLine("BIAŁY PIONEK");
                    WhitePawnMove(row, column, button);

                }
                // BIAŁY GONIEC
                if ((pos[row, column] == 12 || WhiteBishopCheck == true) && BlackPawnCheck == false && BlackBishopCheck == false && BlackKnightCheck == false && BlackRookCheck == false && BlackQueenCheck == false && BlackKingCheck == false)
                {
                    Debug.WriteLine("BIAŁY GONIEC");
                    WhiteBishopMove(row, column, button);

                }
                // BIAŁY SKOCZEK
                if ((pos[row, column] == 13 || WhiteKnightCheck == true) && BlackPawnCheck == false && BlackBishopCheck == false && BlackKnightCheck == false && BlackRookCheck == false && BlackQueenCheck == false && BlackKingCheck == false)
                {
                    Debug.WriteLine("BIAŁY SKOCZEK");
                    WhiteKnightMove(row, column, button);

                }
                // BIAŁY WIEŻA
                if ((pos[row, column] == 14 || WhiteRookCheck == true) && BlackPawnCheck == false && BlackBishopCheck == false && BlackKnightCheck == false && BlackRookCheck == false && BlackQueenCheck == false && BlackKingCheck == false)
                {
                    Debug.WriteLine("BIAŁY WIEŻA");
                    WhiteRookMove(row, column, button);

                }
                // BIAŁY HETMAN
                if ((pos[row, column] == 15 || WhiteQueenCheck == true) && BlackPawnCheck == false && BlackBishopCheck == false && BlackKnightCheck == false && BlackRookCheck == false && BlackQueenCheck == false && BlackKingCheck == false)
                {
                    Debug.WriteLine("BIAŁY HETMAN");
                    WhiteQueenMove(row, column, button);

                }
                // BIAŁY KRÓL
                if ((pos[row, column] == 2000 || WhiteKingCheck == true) && BlackPawnCheck == false && BlackBishopCheck == false && BlackKnightCheck == false && BlackRookCheck == false && BlackQueenCheck == false && BlackKingCheck == false)
                {
                    Debug.WriteLine("BIAŁY Król");
                    WhiteKingMove(row, column, button);

                }
                //            break;
                //          }
            }
        }

        private void BlackPawnMove(int row, int column, Button button)
        {

            if (firstClick == null && pos[row, column] == 1)
            {

                Debug.WriteLine("BLACK FIRST MOVE");
                firstClick = button;
                CurrentRow = row;
                CurrentColumn = column;
                Debug.WriteLine("Current Row "+CurrentRow);
                Debug.WriteLine("Current Column "+CurrentColumn);
                BlackPawnCheck = true;

            }
            else if ((firstClick != null) && (secondClick == null) && ((pos[row,column] == 0) && ((column == CurrentColumn && row - 1 == CurrentRow) || (CurrentRow == 1 && row-2 == CurrentRow && column == CurrentColumn))))
            {
                Debug.WriteLine("BLACK SECOND MOVE");
                secondClick = button;

                System.Windows.Controls.Image BPawn = new System.Windows.Controls.Image();
                BPawn.Source = Images.BPawn;

                buttons[CurrentRow, CurrentColumn].Content = "";
                buttons[row, column].Content = BPawn;
                pos[row, column] = 1;
                pos[CurrentRow, CurrentColumn] = 0;

                firstClick = null;
                secondClick = null;
                BlackPawnCheck = false;
                GlobalTurn = true;
            }
            else
            {

                firstClick = null;
                secondClick = null;
                BlackPawnCheck = false;
            }

        }

        private void WhitePawnMove(int row, int column, Button button)
        {

            //Debug.WriteLine(row);
            //Debug.WriteLine("WhitePawn");
            //Debug.WriteLine(column);

            if (firstClick == null && pos[row, column] == 11)
            {
                Debug.WriteLine("WHITE FIRST MOVE");
                firstClick = button;
                CurrentRow = row;
                CurrentColumn = column;
                WhitePawnCheck = true;
            }
            else if ((firstClick != null) && (secondClick == null) && ((pos[row, column] == 0) && (column == CurrentColumn && row + 1 == CurrentRow || (CurrentRow == 6 && row + 2 == CurrentRow && column == CurrentColumn))))
            {
                Debug.WriteLine("WHITE SECOND MOVE");
                secondClick = button;

                System.Windows.Controls.Image image = new System.Windows.Controls.Image();
                image.Source = Images.WPawn;

                buttons[CurrentRow, CurrentColumn].Content = "";
                buttons[row, column].Content = image;
                pos[row, column] = 11;
                pos[CurrentRow, CurrentColumn] = 0;

                firstClick = null;
                secondClick = null;
                WhitePawnCheck = false;
                GlobalTurn = false;
            }

            else
            {

                firstClick = null;
                secondClick = null;
                WhitePawnCheck = false;
            }

        }

        private void WhitePawnAttack(int row, int column,Button button)
        {
            if ((firstClick != null) && (secondClick == null) && (pos[row,column] < 10 && pos[row,column] > 0 ) && ((column == CurrentColumn + 1 || column == CurrentColumn - 1) && (row == CurrentRow - 1) ))
            {
                Debug.WriteLine("WHITE ATTACK");
                secondClick = button;

                System.Windows.Controls.Image image = new System.Windows.Controls.Image();
                image.Source = Images.WPawn;

                buttons[CurrentRow, CurrentColumn].Content = "";
                buttons[row, column].Content = image;
                pos[row, column] = 11;
                pos[CurrentRow, CurrentColumn] = 0;

                firstClick = null;
                secondClick = null;
                WhitePawnCheck = false;
                GlobalTurn = false;
            }

        }

        private void BlackPawnAttack(int row, int column, Button button)
        {
            if ((firstClick != null) && (secondClick == null) && (pos[row, column] > 10 && pos[row, column] < 100) && ((column == CurrentColumn + 1 || column == CurrentColumn - 1) && (row == CurrentRow + 1)))
            {
                Debug.WriteLine("BLACK ATTACK");
                secondClick = button;

                System.Windows.Controls.Image image = new System.Windows.Controls.Image();
                image.Source = Images.BPawn;

                buttons[CurrentRow, CurrentColumn].Content = "";
                buttons[row, column].Content = image;
                pos[row, column] = 1;
                pos[CurrentRow, CurrentColumn] = 0;

                firstClick = null;
                secondClick = null;
                BlackPawnCheck = false;
                GlobalTurn = true;
            }

        }

        private void BlackBishopMove(int row, int column, Button button)
        {
            if (firstClick == null && pos[row, column] == 2)
            {

                firstClick = button;
                CurrentRow = row;
                CurrentColumn = column;
                BlackBishopCheck = true;

            }
            else if ((firstClick != null) && (secondClick == null) && ((pos[row, column] == 0 || (pos[row, column] > 10) && pos[row,column] < 100 ) && (Math.Abs(row - CurrentRow) == Math.Abs(column - CurrentColumn))))
            {
                int FigureCount = 0;
                int path = 0; int i, j; 
                i = row; j = column;

                if (row > CurrentRow && column > CurrentColumn)
                {
                    while(i != CurrentRow && j != CurrentColumn )
                    {
                        path += pos[i, j];
                        Debug.WriteLine("path " + path);
                        i--;j--;

                        if (pos[i,j] > 0)
                        {
                            FigureCount++;
                        }
                    }
                }
                else if(row < CurrentRow && column > CurrentColumn)
                {
                    while (i != CurrentRow && j != CurrentColumn)
                    {
                        path += pos[i, j];
                        Debug.WriteLine("path " + path);
                        i++; j--;

                        if (pos[i, j] > 0)
                        {
                            FigureCount++;
                        }
                    }
                }
                else if (row > CurrentRow && column < CurrentColumn)
                {
                    while (i != CurrentRow && j != CurrentColumn)
                    {
                        path += pos[i, j];
                        Debug.WriteLine("path " + path);
                        i--; j++;

                        if (pos[i, j] > 0)
                        {
                            FigureCount++;
                        }
                    }
                }
                else if (row < CurrentRow && column < CurrentColumn)
                {
                    while (i != CurrentRow && j != CurrentColumn)
                    {
                        path += pos[i, j];
                        Debug.WriteLine("path " + path);
                        i++; j++;

                        if (pos[i, j] > 0)
                        {
                            FigureCount++;
                        }
                    }
                }

                if (path == 0 || FigureCount == 1)
                {

                    secondClick = button;

                    System.Windows.Controls.Image Bbishop = new System.Windows.Controls.Image();
                    Bbishop.Source = Images.BBishop;

                    buttons[CurrentRow, CurrentColumn].Content = "";
                    buttons[row, column].Content = Bbishop;
                    pos[row, column] = 2;
                    pos[CurrentRow, CurrentColumn] = 0;

                    firstClick = null;
                    secondClick = null;
                    BlackBishopCheck = false;
                    GlobalTurn = true;
                }
            }
            else
            {
                firstClick = null;
                secondClick = null;
                BlackBishopCheck = false;
            }
 
        }

        private void WhiteBishopMove(int row, int column, Button button)
        {
            if (firstClick == null && pos[row, column] == 12)
            {
                Debug.WriteLine("BIAŁY GONIEC POCZATEK");
                firstClick = button;
                CurrentRow = row;
                CurrentColumn = column;
                WhiteBishopCheck = true;

            }
            else if ((firstClick != null) && (secondClick == null) && ((pos[row, column] == 0 || pos[row, column] < 10) && (Math.Abs(row - CurrentRow) == Math.Abs(column - CurrentColumn))))
            {
                Debug.WriteLine("BIAŁY GONIEC KONIEC");
                int FigureCount = 0;
                int path = 0; int i, j;
                i = row; j = column;

                if (row > CurrentRow && column > CurrentColumn)
                {
                    while (i != CurrentRow && j != CurrentColumn)
                    {
                        path += pos[i, j];
                        Debug.WriteLine("path " + path);
                        i--; j--;

                        if (pos[i, j] > 0)
                        {
                            FigureCount++;
                        }
                    }
                }
                else if (row < CurrentRow && column > CurrentColumn)
                {
                    while (i != CurrentRow && j != CurrentColumn)
                    {
                        path += pos[i, j];
                        Debug.WriteLine("path " + path);
                        i++; j--;

                        if (pos[i, j] > 0)
                        {
                            FigureCount++;
                        }
                    }
                }
                else if (row > CurrentRow && column < CurrentColumn)
                {
                    while (i != CurrentRow && j != CurrentColumn)
                    {
                        path += pos[i, j];
                        Debug.WriteLine("path " + path);
                        i--; j++;

                        if (pos[i, j] > 0)
                        {
                            FigureCount++;
                        }
                    }
                }
                else if (row < CurrentRow && column < CurrentColumn)
                {
                    while (i != CurrentRow && j != CurrentColumn)
                    {
                        path += pos[i, j];
                        Debug.WriteLine("path " + path);
                        i++; j++;

                        if (pos[i, j] > 0)
                        {
                            FigureCount++;
                        }
                    }
                }

                if (path == 0 || FigureCount == 1)
                {

                    secondClick = button;

                    System.Windows.Controls.Image Wbishop = new System.Windows.Controls.Image();
                    Wbishop.Source = Images.WBishop;

                    buttons[CurrentRow, CurrentColumn].Content = "";
                    buttons[row, column].Content = Wbishop;
                    pos[row, column] = 12;
                    pos[CurrentRow, CurrentColumn] = 0;

                    firstClick = null;
                    secondClick = null;
                    WhiteBishopCheck = false;
                    GlobalTurn = false;
                }
            }
            else
            {
                firstClick = null;
                secondClick = null;
                WhiteBishopCheck = false;
            }

        }

        private void WhiteRookMove(int row, int column, Button button)
        {
            if (firstClick == null && pos[row, column] == 14)
            {
                firstClick = button;
                CurrentRow = row;
                CurrentColumn = column;
                WhiteRookCheck = true;

            }
            else if ((firstClick != null) && (secondClick == null) && ((pos[row, column] == 0 || pos[row, column] < 10) && ((row == CurrentRow && column != CurrentColumn) || (row != CurrentRow && column == CurrentColumn)) ))
            {
                int FigureCount = 0;
                int path = 0; int i, j;
                i = row; j = column;

                if (row > CurrentRow)
                {
                    while (i != CurrentRow)
                    {
                        path += pos[i, j];
                        Debug.WriteLine("path " + path);
                        i--;

                        if (pos[i, j] > 0)
                        {
                            FigureCount++;
                        }
                    }
                }
                else if (column > CurrentColumn)
                {
                    while (j != CurrentColumn)
                    {
                        path += pos[i, j];
                        Debug.WriteLine("path " + path);
                        j--;

                        if (pos[i, j] > 0)
                        {
                            FigureCount++;
                        }
                    }
                }
                else if (column < CurrentColumn)
                {
                    while (j != CurrentColumn)
                    {
                        path += pos[i, j];
                        Debug.WriteLine("path " + path);
                        j++;

                        if (pos[i, j] > 0)
                        {
                            FigureCount++;
                        }
                    }
                }
                else if (row < CurrentRow)
                {
                    while (i != CurrentRow)
                    {
                        path += pos[i, j];
                        Debug.WriteLine("path " + path);
                        i++;

                        if (pos[i, j] > 0)
                        {
                            FigureCount++;
                        }
                    }
                }

                if (path == 0 || FigureCount == 1)
                {

                    secondClick = button;

                    System.Windows.Controls.Image WRook = new System.Windows.Controls.Image();
                    WRook.Source = Images.WRook;

                    buttons[CurrentRow, CurrentColumn].Content = "";
                    buttons[row, column].Content = WRook;
                    pos[row, column] = 14;
                    pos[CurrentRow, CurrentColumn] = 0;

                    firstClick = null;
                    secondClick = null;
                    WhiteRookCheck = false;
                    GlobalTurn = false;
                }
            }
            else
            {
                firstClick = null;
                secondClick = null;
                WhiteRookCheck = false;
            }

        }


        private void BlackRookMove(int row, int column, Button button)
        {
            if (firstClick == null && pos[row, column] == 4)
            {
                firstClick = button;
                CurrentRow = row;
                CurrentColumn = column;
                BlackRookCheck = true;

            }
            else if ((firstClick != null) && (secondClick == null) && ((pos[row, column] == 0 || (pos[row, column] > 10) && pos[row,column] < 100) && ((row == CurrentRow && column != CurrentColumn) || (row != CurrentRow && column == CurrentColumn))))
            {
                int FigureCount = 0;
                int path = 0; int i, j;
                i = row; j = column;

                if (row > CurrentRow)
                {
                    while (i != CurrentRow)
                    {
                        path += pos[i, j];
                        Debug.WriteLine("path " + path);
                        i--;

                        if (pos[i, j] > 0)
                        {
                            FigureCount++;
                        }
                    }
                }
                else if (column > CurrentColumn)
                {
                    while (j != CurrentColumn)
                    {
                        path += pos[i, j];
                        Debug.WriteLine("path " + path);
                        j--;

                        if (pos[i, j] > 0)
                        {
                            FigureCount++;
                        }
                    }
                }
                else if (column < CurrentColumn)
                {
                    while (j != CurrentColumn)
                    {
                        path += pos[i, j];
                        Debug.WriteLine("path " + path);
                        j++;

                        if (pos[i, j] > 0)
                        {
                            FigureCount++;
                        }
                    }
                }
                else if (row < CurrentRow)
                {
                    while (i != CurrentRow)
                    {
                        path += pos[i, j];
                        Debug.WriteLine("path " + path);
                        i++;

                        if (pos[i, j] > 0)
                        {
                            FigureCount++;
                        }
                    }
                }

                if (path == 0 || FigureCount == 1)
                {

                    secondClick = button;

                    System.Windows.Controls.Image BRook = new System.Windows.Controls.Image();
                    BRook.Source = Images.BRook;

                    buttons[CurrentRow, CurrentColumn].Content = "";
                    buttons[row, column].Content = BRook;
                    pos[row, column] = 4;
                    pos[CurrentRow, CurrentColumn] = 0;

                    firstClick = null;
                    secondClick = null;
                    BlackRookCheck = false;
                    GlobalTurn = true;
                }
            }
            else
            {
                firstClick = null;
                secondClick = null;
                BlackRookCheck = false;
            }

        }


        private void BlackKnightMove(int row, int column, Button button)
        {
            if (firstClick == null && pos[row, column] == 3)
            {
                firstClick = button;
                CurrentRow = row;
                CurrentColumn = column;
                BlackKnightCheck = true;

            }
            else if ((firstClick != null) && (secondClick == null) && ((pos[row, column] == 0 || (pos[row, column] > 10) && pos[row, column] < 100) && ((Math.Abs(row - CurrentRow) == 1 && (Math.Abs(column - CurrentColumn) == 2)) || ((Math.Abs(row - CurrentRow) == 2 && (Math.Abs(column - CurrentColumn) == 1))))))
            {
                            
     

                    secondClick = button;

                    System.Windows.Controls.Image BKnight = new System.Windows.Controls.Image();
                    BKnight.Source = Images.BKnight;

                    buttons[CurrentRow, CurrentColumn].Content = "";
                    buttons[row, column].Content = BKnight;
                    pos[row, column] = 3;
                    pos[CurrentRow, CurrentColumn] = 0;

                    firstClick = null;
                    secondClick = null;
                    BlackKnightCheck = false;
                    GlobalTurn = true;

            }
            else
            {
                firstClick = null;
                secondClick = null;
                BlackKnightCheck = false;
            }

        }


        private void WhiteKnightMove(int row, int column, Button button)
        {
            if (firstClick == null && pos[row, column] == 13)
            {
                firstClick = button;
                CurrentRow = row;
                CurrentColumn = column;
                WhiteKnightCheck = true;

            }
            else if ((firstClick != null) && (secondClick == null) && ((pos[row, column] == 0 || (pos[row, column] < 10)) && ((Math.Abs(row - CurrentRow) == 1 && (Math.Abs(column - CurrentColumn) == 2)) || ((Math.Abs(row - CurrentRow) == 2 && (Math.Abs(column - CurrentColumn) == 1))))))
            {



                secondClick = button;

                System.Windows.Controls.Image WKnight = new System.Windows.Controls.Image();
                WKnight.Source = Images.WKnight;

                buttons[CurrentRow, CurrentColumn].Content = "";
                buttons[row, column].Content = WKnight;
                pos[row, column] = 13;
                pos[CurrentRow, CurrentColumn] = 0;

                firstClick = null;
                secondClick = null;
                WhiteKnightCheck = false;
                GlobalTurn = false;

            }
            else
            {
                firstClick = null;
                secondClick = null;
                WhiteKnightCheck = false;
            }

        }

        private void BlackQueenMove(int row, int column, Button button)
        {
            if (firstClick == null && pos[row, column] == 5)
            {

                firstClick = button;
                CurrentRow = row;
                CurrentColumn = column;
                BlackQueenCheck = true;

            }
            else if ((firstClick != null) && (secondClick == null) && ((pos[row, column] == 0 || (pos[row, column] > 10) && pos[row, column] < 100) && (Math.Abs(row - CurrentRow) == Math.Abs(column - CurrentColumn) || row == CurrentRow || column == CurrentColumn)))
            {
                int FigureCount = 0;
                int path = 0; int i, j;
                i = row; j = column;

                if (row > CurrentRow && column > CurrentColumn)
                {
                    while (i != CurrentRow && j != CurrentColumn)
                    {
                        path += pos[i, j];
                        Debug.WriteLine("path " + path);
                        i--; j--;

                        if (pos[i, j] > 0)
                        {
                            FigureCount++;
                        }
                    }
                }
                else if (row < CurrentRow && column > CurrentColumn)
                {
                    while (i != CurrentRow && j != CurrentColumn)
                    {
                        path += pos[i, j];
                        Debug.WriteLine("path " + path);
                        i++; j--;

                        if (pos[i, j] > 0)
                        {
                            FigureCount++;
                        }
                    }
                }
                else if (row > CurrentRow && column < CurrentColumn)
                {
                    while (i != CurrentRow && j != CurrentColumn)
                    {
                        path += pos[i, j];
                        Debug.WriteLine("path " + path);
                        i--; j++;

                        if (pos[i, j] > 0)
                        {
                            FigureCount++;
                        }
                    }
                }
                else if (row < CurrentRow && column < CurrentColumn)
                {
                    while (i != CurrentRow && j != CurrentColumn)
                    {
                        path += pos[i, j];
                        Debug.WriteLine("path " + path);
                        i++; j++;

                        if (pos[i, j] > 0)
                        {
                            FigureCount++;
                        }
                    }
                }
                else if (row > CurrentRow && column == CurrentColumn)
                {
                    while (i != CurrentRow)
                    {
                        path += pos[i, j];
                        Debug.WriteLine("path " + path);
                        i--;

                        if (pos[i, j] > 0)
                        {
                            FigureCount++;
                        }
                    }
                }
                else if (column > CurrentColumn && column == CurrentColumn)
                {
                    while (j != CurrentColumn)
                    {
                        path += pos[i, j];
                        Debug.WriteLine("path " + path);
                        j--;

                        if (pos[i, j] > 0)
                        {
                            FigureCount++;
                        }
                    }
                }
                else if (column < CurrentColumn && column == CurrentColumn)
                {
                    while (j != CurrentColumn)
                    {
                        path += pos[i, j];
                        Debug.WriteLine("path " + path);
                        j++;

                        if (pos[i, j] > 0)
                        {
                            FigureCount++;
                        }
                    }
                }
                else if (row < CurrentRow && column == CurrentColumn)
                {
                    while (i != CurrentRow)
                    {
                        path += pos[i, j];
                        Debug.WriteLine("path " + path);
                        i++;

                        if (pos[i, j] > 0)
                        {
                            FigureCount++;
                        }
                    }
                }


                if (path == 0 || FigureCount == 1)
                {

                    secondClick = button;

                    System.Windows.Controls.Image BQueen = new System.Windows.Controls.Image();
                    BQueen.Source = Images.BQueen;

                    buttons[CurrentRow, CurrentColumn].Content = "";
                    buttons[row, column].Content = BQueen;
                    pos[row, column] = 5;
                    pos[CurrentRow, CurrentColumn] = 0;

                    firstClick = null;
                    secondClick = null;
                    BlackQueenCheck = false;
                    GlobalTurn = true;
                }
            }
            else
            {
                firstClick = null;
                secondClick = null;
                BlackQueenCheck = false;
            }

        }


        private void WhiteQueenMove(int row, int column, Button button)
        {
            if (firstClick == null && pos[row, column] == 15)
            {

                firstClick = button;
                CurrentRow = row;
                CurrentColumn = column;
                WhiteQueenCheck = true;

            }
            else if ((firstClick != null) && (secondClick == null) && ((pos[row, column] == 0 || (pos[row, column] < 10)) && (Math.Abs(row - CurrentRow) == Math.Abs(column - CurrentColumn) || row == CurrentRow || column == CurrentColumn)))
            {
                int FigureCount = 0;
                int path = 0; int i, j;
                i = row; j = column;

                if (row > CurrentRow && column > CurrentColumn)
                {
                    while (i != CurrentRow && j != CurrentColumn)
                    {
                        path += pos[i, j];
                        Debug.WriteLine("path " + path);
                        i--; j--;

                        if (pos[i, j] > 0)
                        {
                            FigureCount++;
                        }
                    }
                }
                else if (row < CurrentRow && column > CurrentColumn)
                {
                    while (i != CurrentRow && j != CurrentColumn)
                    {
                        path += pos[i, j];
                        Debug.WriteLine("path " + path);
                        i++; j--;

                        if (pos[i, j] > 0)
                        {
                            FigureCount++;
                        }
                    }
                }
                else if (row > CurrentRow && column < CurrentColumn)
                {
                    while (i != CurrentRow && j != CurrentColumn)
                    {
                        path += pos[i, j];
                        Debug.WriteLine("path " + path);
                        i--; j++;

                        if (pos[i, j] > 0)
                        {
                            FigureCount++;
                        }
                    }
                }
                else if (row < CurrentRow && column < CurrentColumn)
                {
                    while (i != CurrentRow && j != CurrentColumn)
                    {
                        path += pos[i, j];
                        Debug.WriteLine("path " + path);
                        i++; j++;

                        if (pos[i, j] > 0)
                        {
                            FigureCount++;
                        }
                    }
                }
                else if (row > CurrentRow && column == CurrentColumn)
                {
                    while (i != CurrentRow)
                    {
                        path += pos[i, j];
                        Debug.WriteLine("path " + path);
                        i--;

                        if (pos[i, j] > 0)
                        {
                            FigureCount++;
                        }
                    }
                }
                else if (column > CurrentColumn && column == CurrentColumn)
                {
                    while (j != CurrentColumn)
                    {
                        path += pos[i, j];
                        Debug.WriteLine("path " + path);
                        j--;

                        if (pos[i, j] > 0)
                        {
                            FigureCount++;
                        }
                    }
                }
                else if (column < CurrentColumn && column == CurrentColumn)
                {
                    while (j != CurrentColumn)
                    {
                        path += pos[i, j];
                        Debug.WriteLine("path " + path);
                        j++;

                        if (pos[i, j] > 0)
                        {
                            FigureCount++;
                        }
                    }
                }
                else if (row < CurrentRow && column == CurrentColumn)
                {
                    while (i != CurrentRow)
                    {
                        path += pos[i, j];
                        Debug.WriteLine("path " + path);
                        i++;

                        if (pos[i, j] > 0)
                        {
                            FigureCount++;
                        }
                    }
                }


                if (path == 0 || FigureCount == 1)
                {

                    secondClick = button;

                    System.Windows.Controls.Image WQueen = new System.Windows.Controls.Image();
                    WQueen.Source = Images.WQueen;

                    buttons[CurrentRow, CurrentColumn].Content = "";
                    buttons[row, column].Content = WQueen;
                    pos[row, column] = 15;
                    pos[CurrentRow, CurrentColumn] = 0;

                    firstClick = null;
                    secondClick = null;
                    WhiteQueenCheck = false;
                    GlobalTurn = false;
                }
            }
            else
            {
                firstClick = null;
                secondClick = null;
                WhiteQueenCheck = false;
            }

        }



        private void BlackKingMove(int row, int column, Button button)
        {
            if (firstClick == null && pos[row, column] == 1000)
            {
                firstClick = button;
                CurrentRow = row;
                CurrentColumn = column;
                BlackKingCheck = true;

            }
            else if ((firstClick != null) && (secondClick == null) && ((pos[row, column] == 0 || (pos[row, column] > 10) && pos[row, column] < 100) && ( Math.Abs(row - CurrentRow) <= 1 && Math.Abs(column - CurrentColumn) <= 1 )))
            {



                secondClick = button;

                System.Windows.Controls.Image BKing = new System.Windows.Controls.Image();
                BKing.Source = Images.BKing;

                buttons[CurrentRow, CurrentColumn].Content = "";
                buttons[row, column].Content = BKing;
                pos[row, column] = 1000;
                pos[CurrentRow, CurrentColumn] = 0;

                firstClick = null;
                secondClick = null;
                BlackKingCheck = false;
                GlobalTurn = true;

            }
            else
            {
                firstClick = null;
                secondClick = null;
                BlackKingCheck = false;
            }

        }

        private void WhiteKingMove(int row, int column, Button button)
        {
            if (firstClick == null && pos[row, column] == 2000)
            {
                firstClick = button;
                CurrentRow = row;
                CurrentColumn = column;
                WhiteKingCheck = true;

            }
            else if ((firstClick != null) && (secondClick == null) && ((pos[row, column] == 0 || (pos[row, column] < 10)) && (Math.Abs(row - CurrentRow) <= 1 && Math.Abs(column - CurrentColumn) <= 1)))
            {



                secondClick = button;

                System.Windows.Controls.Image WKing = new System.Windows.Controls.Image();
                WKing.Source = Images.WKing;

                buttons[CurrentRow, CurrentColumn].Content = "";
                buttons[row, column].Content = WKing;
                pos[row, column] = 2000;
                pos[CurrentRow, CurrentColumn] = 0;

                firstClick = null;
                secondClick = null;
                WhiteKingCheck = false;
                GlobalTurn = false;

            }
            else
            {
                firstClick = null;
                secondClick = null;
                WhiteKingCheck = false;
            }

        }



    }
}
