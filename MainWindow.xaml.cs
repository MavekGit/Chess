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
        int ClickCount = 0;
        private Button firstClick;
        private Button secondClick;
        private int CurrentRow=-100;
        private int CurrentColumn=-100;
        private bool BlackPawnCheck = false;
        private bool WhitePawnCheck = false;
        private bool WhitePawnCombat = false;
        private bool BlackPawnCombat = false;
        

        


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

            System.Windows.Controls.Image Bpawn = new System.Windows.Controls.Image();
            Bpawn.Source = Images.BPawn;
            buttons[1, 0].Content = Bpawn;

            System.Windows.Controls.Image Wpawn = new System.Windows.Controls.Image();
            Wpawn.Source = Images.WPawn;

            System.Windows.Controls.Image Bpawn1 = new System.Windows.Controls.Image();
            Bpawn1.Source = Images.BPawn;

            buttons[1, 0].Content = Bpawn;
            buttons[1, 1].Content = Bpawn1;
            buttons[6,0].Content = Wpawn;

            foreach (int row in pos)
            {
                foreach(int col in pos)
                {
                    pos[row,col] = 0;
                }
            }
            pos[1,0] = 1;
            pos[1,1] = 1;
            pos[6, 0] = 11;

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
                Debug.WriteLine("BBBBBBBBBBAAAAAAAAAAAAAA");
            }
            else if (pos[row,column]==1 || BlackPawnCheck == true)
            {
                BlackPawnMove(row, column, button);
                Debug.WriteLine("BBBBBBBBMMMMMMMMMMMM");
            }
            

            if (pos[row, column] < 10 && pos[row, column] > 0)
            {
                WhitePawnAttack(row, column, button);
                Debug.WriteLine("WWWWWWWWWWWWAAAAAAAAAAAAAA");
            }
            else if ((pos[row, column] == 11 || WhitePawnCheck == true))
            {
                WhitePawnMove(row, column, button);
                Debug.WriteLine("WWWWWWWWWWWWWWWWMMMMMMMMMMMMM");
            }



        }

        private void BlackPawnMove(int row, int column, Button button)
        {

            Debug.WriteLine("Black "+row);
            
            Debug.WriteLine("Black "+column);

            if (firstClick == null && pos[row, column] == 1)
            {

                Debug.WriteLine("BLACK FIRST MOVE");
                firstClick = button;
                ClickCount = 1;
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
                ClickCount = 0;
            }
            else
            {

                firstClick = null;
                secondClick = null;
                BlackPawnCheck = false;
                ClickCount = 0;
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
                ClickCount = 1;
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
                ClickCount = 0;
            }

            else
            {

                firstClick = null;
                secondClick = null;
                WhitePawnCheck = false;
                ClickCount = 0;
            }

        }

        private void WhitePawnAttack(int row, int column,Button button)
        {
            if ((firstClick != null) && (secondClick == null) && (pos[row,column] < 10 && pos[row,column] < 0 ) && ((column == CurrentColumn + 1 || column == CurrentColumn - 1) && (row == CurrentRow + 1) ))
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
                ClickCount = 0;
            }

        }

        private void BlackPawnAttack(int row, int column, Button button)
        {
            if ((firstClick != null) && (secondClick == null) && (pos[row, column] > 10 && pos[row, column] < 100) && ((column == CurrentColumn + 1 || column == CurrentColumn - 1) && (row == CurrentRow - 1)))
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
                ClickCount = 0;
            }

        }

    }
}
