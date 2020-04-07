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
        private bool _istErsterSpielerAmZug = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        private bool IstSpielfeldVoll()
        {
            foreach (var item in Spielfeld.Children)
            {
                Button kasten = item as Button;

                if (kasten == null || kasten.Content.ToString() == "")
                {
                    return false;
                }
            }
            return true;
        }
        private void Kasten_Click(object sender, RoutedEventArgs e)
        { 
            Button buttonKasten = (Button)sender;

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
                MessageBox.Show("Das Feld ist bereits besetzt. Bitte ein freies Kästchen wählen.", "Unzulässiger Zug", MessageBoxButton.OK, MessageBoxImage.Stop);
            }

            
            





            //var bisherigerVordergrund = kasten_0_0.Foreground;
            //kasten_0_0.Foreground = kasten_0_0.Background;
            //kasten_0_0.Background = bisherigerVordergrund;

        }
    }
}
