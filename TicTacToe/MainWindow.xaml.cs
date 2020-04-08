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
using System.Windows.Threading;


namespace TicTacToe
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _istErsterSpielerAmZug = true;

        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void SpielfeldLeeren()
        {
            kasten_0_0.Content = null;
            kasten_1_0.Content = null;
            kasten_2_0.Content = null;

            kasten_0_1.Content = null;
            kasten_1_1.Content = null;
            kasten_2_1.Content = null;

            kasten_0_2.Content = null;
            kasten_1_2.Content = null;
            kasten_2_2.Content = null;
        }

        private bool IstSpielfeldVoll()
        {
            foreach (var item in Spielfeld.Children)
            {
                Button b = item as Button;

                if (b.Content == null || b.Content.ToString() == string.Empty)
                {
                    return false;
                }
            }
            return true;
        }

        private void Kasten_Click(object sender, RoutedEventArgs e)
        {
            Button buttonKasten = (Button)sender;
            

            if (IstSpielfeldVoll())
            {
                SpielfeldLeeren();
                _istErsterSpielerAmZug = true;
            }


            // Prüfen ob Kästchen leer ist
            if (buttonKasten.Content == null || buttonKasten.Content.ToString() == "")
            {
                if (_istErsterSpielerAmZug)   // Spieler X
                {
                    buttonKasten.Content = "X";
                    _istErsterSpielerAmZug = false;
                }
                else   // Spieler Y
                {
                    buttonKasten.Content = "O";
                    _istErsterSpielerAmZug = true;
                }
            }
            else
            {
                MessageBox.Show("Das Feld ist bereits belegt. Bitte ein freies Kästchen wählen.", "Unzulässiger Zug", MessageBoxButton.OK, MessageBoxImage.Stop);
            }

            //var bisherigerVordergrund = kasten_0_0.Foreground;
            //kasten_0_0.Foreground = kasten_0_0.Background;
            //kasten_0_0.Background = bisherigerVordergrund;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _istErsterSpielerAmZug = true;
        }
    }
}
