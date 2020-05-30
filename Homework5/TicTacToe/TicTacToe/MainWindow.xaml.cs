using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        bool turn = true; //when true = X turn false = y turn
        int turnCount = 0;
        string whoTurn = "";
        bool?[,] gridData = new bool?[3, 3];

        public MainWindow()
        {
            InitializeComponent();
            initializeArray();
            whoTurn = "X";
            displayWhosTurn();
        }

        private void initializeArray()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    gridData[i, j] = null;
                }
            }
        }

        private void uxNewGame_Click(object sender, RoutedEventArgs e)
        {
            startNewGame();
        }

        private void uxExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button gridButton = sender as Button;
            gridButton.IsEnabled = false;
            string[] s  =  gridButton.Tag.ToString().Split(',');
            gridData[Int32.Parse(s[0]), Int32.Parse(s[1])] = turn;

            if (determineWinner())
            {
                MessageBox.Show("Tic Tab Toe!");
            } else
            {
                turnCount++;
                setGridButton(gridButton);
                setWhosTurn();
                displayWhosTurn();
            }

        }

        private bool determineWinner()
        {
            //foreach (Button c in uxGrid.Children) 
            //{
            //    MessageBox.Show($"{c.Tag} = {c.IsEnabled}");   
            //}
            //MessageBox.Show("Row = " + uxGrid.Selected);

            return false;

        }

        private void setWhosTurn()
        {
            if (turn)
            {
                whoTurn = "O";
                turn = false;
            }
            else
            {
                whoTurn = "X";
                turn = true;
            }
        }


        private void setGridButton(Button gridButton)
        {
            if (turnCount < 9)
            {
                if (turn)
                {
                    gridButton.Content = 'X';
                    whoTurn = "O";
                    turn = false;
                }
                else
                {
                    gridButton.Content = '0';
                    whoTurn = "X";
                    turn = true;
                }
            }
            else 
            {
                MessageBox.Show("Game is Tied! No Winner");
                startNewGame();
            }

            setWhosTurn();
        }

        private void startNewGame()
        {
            foreach (Button gridButton in uxGrid.Children)
            {
                gridButton.Content = "";
                gridButton.IsEnabled = true;
            }

            turn = true;
            turnCount = 0;
            whoTurn = "X";
            displayWhosTurn();
        }

        private void displayWhosTurn()
        {
            uxTurn.Text = $"it's {whoTurn} turn.";
        }
    }
}
