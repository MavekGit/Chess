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
        private bool WhiteBishiopCheck = false;
        private bool BlackBishopCheck = false;
        

        


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
            pos[6, 7] = 11;
            pos[0, 2] = 2;
            pos[0, 5] = 2;

            //WhitePawn Wpawn1 = new WhitePawn();
            //Wpawn1.type = 1; Wpawn1.posX = 1; Wpawn1.posY = 0;
            //pos[Wpawn1.posX,Wpawn1.posY] = 1;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Button button = (Button)sender;
            int column = Grid.GetColumn(button);
            int row = Grid.GetRow(button);

            if(pos[row,column] > 10 && BlackPawnCheck == true )
            {

                BlackPawnAttack(row, column, button);
            
            }
            else if ((pos[row,column]==1 || BlackPawnCheck == true) && WhitePawnCheck == false)
            {

                BlackPawnMove(row, column, button);
                
            }
            

            if (pos[row, column] < 10 && pos[row, column] > 0 && WhitePawnCheck == true)
            {

                WhitePawnAttack(row, column, button);
            }
            else if ((pos[row, column] == 11 || WhitePawnCheck == true) && BlackPawnCheck == false && BlackBishopCheck == false)
            {

                WhitePawnMove(row, column, button);
            
            }

            if ((pos[row, column] == 2 || BlackBishopCheck == true) && WhitePawnCheck == false)
            {

               BlackBishopMove(row, column, button);

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
                WhitePawnCheck = false;
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
            else if ((firstClick != null) && (secondClick == null) && ((pos[row, column] == 0) && (Math.Abs(row - CurrentRow) == Math.Abs(column - CurrentColumn))))
            {
                int StartRow = 0; int EndRow = 0;
                int StartColumn = 0; int EndColumn = 0;
                int path = 0; int i, j; 

                if (row > CurrentRow)
                {
                    StartRow = CurrentRow;
                    EndRow = row;
                }
                else
                {
                    StartRow = row;
                    EndRow = CurrentRow;
                }

                if (column > CurrentColumn)
                {
                    StartColumn = CurrentColumn;
                    EndColumn = column;
                }
                else
                {
                    StartColumn = column;
                    EndColumn = CurrentColumn;
                }


                if (true)
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
                }
            }
            else
            {
                firstClick = null;
                secondClick = null;
                BlackBishopCheck = false;
            }
 
        }

    }
}
