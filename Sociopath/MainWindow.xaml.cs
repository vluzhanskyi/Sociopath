using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Sociopath
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private string _message;
        private List<string> _answers;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Logic conversation = new Logic();
            _message = InputTextBox.Text;
            _answers = conversation.RunInteraction(_message);
            MainTextBox.Text += "You said: " + _message + "\r\n";
            foreach(string answer in _answers)
                MainTextBox.Text += answer + "\r\n";

        }

        private void InputTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _message = InputTextBox.Text;
        }

        private void MainTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputTextBox.Text = null;
            
            MainTextBox.ScrollToEnd();
        }
    }
}
