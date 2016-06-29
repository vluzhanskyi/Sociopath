using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sociopath
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string message;
        private List<string> answers;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            logic Conversation = new logic();
            message = InputTextBox.Text;
            answers = Conversation.RunInteraction(message);
            MainTextBox.Text += "You said: " + message + "\r\n";
            foreach(string answer in answers)
                MainTextBox.Text += answer + "\r\n";

        }

        private void InputTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            message = InputTextBox.Text;
        }

        private void MainTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputTextBox.Text = null;
        }
    }
}
