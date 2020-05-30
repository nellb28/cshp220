using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace TicTacToe
{
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
            turnCount++;
            setGridButton(gridButton);


            if (determineWinner())
            {
                MessageBox.Show("Tic Tac Toe!");
                startNewGame();
            } else
            {
                setWhosTurn();
                displayWhosTurn();
            }

        }

        private bool determineWinner()
        {
            //check for tic-tac-toe in rows
            if ((gridData[0, 0] != null) && (gridData[0, 0] == gridData[0, 1]) && (gridData[0, 1] == gridData[0, 2]))
            {
                return true;
            }
            else if ((gridData[1, 0] != null) && (gridData[1, 0] == gridData[1, 1]) && (gridData[1, 1] == gridData[1, 2]))
            {
                return true;
            }
            else if ((gridData[2, 0] != null) && (gridData[2, 0] == gridData[2, 1]) && (gridData[2, 1] == gridData[2, 2]))
            {
                return true;
            }
            //check for tic-tac-toe in columns
            else if ((gridData[0, 0] != null) && (gridData[0, 0] == gridData[1, 0]) && (gridData[1, 0] == gridData[2, 0]))
            {
                return true;
            }
            else if ((gridData[0, 1] != null) && (gridData[0, 1] == gridData[1, 1]) && (gridData[1, 1] == gridData[2, 1]))
            {
                return true;
            }
            else if ((gridData[0, 2] != null) && (gridData[0, 2] == gridData[1, 2]) && (gridData[1, 2] == gridData[2, 2]))
            {
                return true;
            }
            //check for tic-tac-toe in diagonals
            else if ((gridData[0, 0] != null) && (gridData[0, 0] == gridData[1, 1]) && (gridData[1, 1] == gridData[2, 2]))
            {
                return true;
            }
            else if ((gridData[2, 0] != null) && (gridData[2, 0] == gridData[1, 1]) && (gridData[1, 1] == gridData[0, 2]))
            {
                return true;
            }
            else
            {
                return false;
            }

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
            if (turnCount >= 9)
            {
                MessageBox.Show("Game is Tied! No Winner");
                startNewGame();
                return;
            }
            setWhosTurn();
        }

        private void startNewGame()
        {
            initializeArray();
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
