using System;
using System.Data;
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

namespace Calculator_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            foreach(UIElement el in MainGrid.Children)
            {
                if (el is Button)
                {
                    ((Button)el).Click += Button_Click;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str = (string)((Button)e.OriginalSource).Content;
            if (str == "AC")
                TextLabel.Text = ("");
            else if (str == "DEL")
            {
                if (TextLabel.Text != "")
                {
                    TextLabel.Text = TextLabel.Text.Remove(TextLabel.Text.Length - 1);
                }
            }
            else if (str == "=")
            {
                string value = new DataTable().Compute(TextLabel.Text, null).ToString();
                TextLabel.Text = value;
            }
            else
                TextLabel.Text += str;
        }
    }
}
