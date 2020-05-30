using System;
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
        int turn_count = 0;
        string whoTurn = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void uxNewGame_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("New Game");
        }

        private void uxExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button tile = sender as Button;
            tile.IsEnabled = false;
            turn_count++;
            setWhosTurn(tile);
            displayWhosTurn();
        }

        private void setWhosTurn(Button tile)
        {
            if (turn)
            {
                tile.Content = 'X';
                whoTurn = "O";
                turn = false;
            }
            else
            {
                tile.Content = '0';
                whoTurn = "X";
                turn = true;
            }
        }

        private void displayWhosTurn()
        {
            uxTurn.Text = $"it's {whoTurn} turn.";
        }
    }
}
