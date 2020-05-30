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
            string whoTurn = "";
            Button btn = sender as Button;
            if (turn)
            {
                btn.Content = 'X';
                whoTurn = "O";
                turn = false;
            }
            else
            {
                btn.Content = '0';
                whoTurn = "X";
                turn = true;
            }

            btn.IsEnabled = false;
            turn_count++;
            uxTurn.Text = $"it's {whoTurn} turn.";
        }
    }
}
