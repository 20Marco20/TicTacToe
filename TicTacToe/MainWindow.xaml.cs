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
            SpielfeldLeeren();
        }
        
        private void SpielfeldLeeren()
        {
            kasten_0_0.Content = string.Empty;
            kasten_1_0.Content = string.Empty;
            kasten_2_0.Content = string.Empty;

            kasten_0_1.Content = string.Empty;
            kasten_1_1.Content = string.Empty;
            kasten_2_1.Content = string.Empty;

            kasten_0_2.Content = string.Empty;
            kasten_1_2.Content = string.Empty;
            kasten_2_2.Content = string.Empty;
        }

        private bool IstSpielfeldVoll()
        {
            foreach (var item in Spielfeld.Children)
            {
                Button b = item as Button;

                if (b.Content == null || b.Content.ToString() == "")
                {
                    return false;
                }
            }

            return true;
        }

        private List<Button> Gewinnermittlung()
        {
            var result = new List<Button>();

            if (Gewinnreihe(kasten_0_0, kasten_0_1, kasten_0_2))
            {
                result.Add(kasten_0_0);
                result.Add(kasten_0_1);
                result.Add(kasten_0_2);
            }
            else if (Gewinnreihe(kasten_1_0, kasten_1_1, kasten_1_2))
            {
                result.Add(kasten_1_0);
                result.Add(kasten_1_1);
                result.Add(kasten_1_2);
            }
            else if (Gewinnreihe(kasten_2_0, kasten_2_1, kasten_2_2))
            {
                result.Add(kasten_2_0);
                result.Add(kasten_2_1);
                result.Add(kasten_2_2);
            }
            else if (Gewinnreihe(kasten_0_0, kasten_1_0, kasten_2_0))
            {
                result.Add(kasten_0_0);
                result.Add(kasten_1_0);
                result.Add(kasten_2_0);
            }
            else if (Gewinnreihe(kasten_0_1, kasten_1_1, kasten_2_1))
            {
                result.Add(kasten_0_1);
                result.Add(kasten_1_1);
                result.Add(kasten_2_1);
            }
            else if (Gewinnreihe(kasten_0_2, kasten_1_2, kasten_2_2))
            {
                result.Add(kasten_0_2);
                result.Add(kasten_1_2);
                result.Add(kasten_2_2);
            }
            else if (Gewinnreihe(kasten_0_0, kasten_1_1, kasten_2_2))
            {
                result.Add(kasten_0_0);
                result.Add(kasten_1_1);
                result.Add(kasten_2_2);
            }
            else if (Gewinnreihe(kasten_2_0, kasten_1_1, kasten_0_2))
            {
                result.Add(kasten_2_0);
                result.Add(kasten_1_1);
                result.Add(kasten_0_2);
            }

            return result;
        }

        private bool Gewinnreihe(Button kasten1, Button kasten2, Button kasten3)
        {
            //if (kasten1.Content != null || kasten2.Content != null || kasten3.Content != null)
            //{
                if (kasten1.Content.ToString() != "" && kasten1.ToString() == kasten2.ToString() && kasten2.ToString() == kasten3.ToString())
                {
                    return true;
                }

            //}
            return false;

        }

        private void GewinnreiheHervorheben(Button kasten1, Button kasten2, Button kasten3)
        {
            kasten1.Background = Brushes.Orange;
            kasten2.Background = Brushes.Orange;
            kasten3.Background = Brushes.Orange;
        }
        private void Kasten_Click(object sender, RoutedEventArgs e)
        {
            Button buttonKasten = (Button)sender;

            if (IstSpielfeldVoll())
            {
                SpielfeldLeeren();
                _istErsterSpielerAmZug = true;
                return;
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
                    //var bisherigerVordergrund = kasten_0_0.Foreground;
                    //kasten_0_0.Foreground = kasten_0_0.Background;
                    //kasten_0_0.Background = bisherigerVordergrund;
                    _istErsterSpielerAmZug = true;
                }
            }
            else
            {
                MessageBox.Show("Das Feld ist bereits belegt. Bitte ein freies Kästchen wählen.", "Unzulässiger Zug", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }


            var gewinnReihe = Gewinnermittlung();

            if (gewinnReihe.Count == 3)
            {
                GewinnreiheHervorheben(gewinnReihe[0], gewinnReihe[1], gewinnReihe[2]);

                if (_istErsterSpielerAmZug)
                {
                    MessageBox.Show("Spieler 2 (O) hat gewonnen!");
                }
                else
                {
                    MessageBox.Show("Spieler 1 (X) hat gewonnen!");
                }
                SpielfeldLeeren();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _istErsterSpielerAmZug = true;
        }
    }
}
