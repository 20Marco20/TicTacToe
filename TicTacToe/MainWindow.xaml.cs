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

namespace TicTacToe
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Kasten_0_0_Click(object sender, RoutedEventArgs e)
        {
            Kasten_0_0.Background = new SolidColorBrush(Colors.DarkOrange);
            Kasten_0_0.Foreground = new SolidColorBrush(Colors.SlateBlue);
        }
    }
}
