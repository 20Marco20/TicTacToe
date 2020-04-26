using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


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


            kasten_0_0.Background = (Brush)new BrushConverter().ConvertFrom("#FF73ABFF");
            kasten_1_0.Background = (Brush)new BrushConverter().ConvertFrom("#FF73ABFF");
            kasten_2_0.Background = (Brush)new BrushConverter().ConvertFrom("#FF73ABFF");

            kasten_0_1.Background = (Brush)new BrushConverter().ConvertFrom("#FF73ABFF");
            kasten_1_1.Background = (Brush)new BrushConverter().ConvertFrom("#FF73ABFF");
            kasten_2_1.Background = (Brush)new BrushConverter().ConvertFrom("#FF73ABFF");

            kasten_0_2.Background = (Brush)new BrushConverter().ConvertFrom("#FF73ABFF");
            kasten_1_2.Background = (Brush)new BrushConverter().ConvertFrom("#FF73ABFF");
            kasten_2_2.Background = (Brush)new BrushConverter().ConvertFrom("#FF73ABFF");


            kasten_0_0.Foreground = (Brush)new BrushConverter().ConvertFrom("AliceBlue");
            kasten_1_0.Foreground = (Brush)new BrushConverter().ConvertFrom("AliceBlue");
            kasten_2_0.Foreground = (Brush)new BrushConverter().ConvertFrom("AliceBlue");

            kasten_0_1.Foreground = (Brush)new BrushConverter().ConvertFrom("AliceBlue");
            kasten_1_1.Foreground = (Brush)new BrushConverter().ConvertFrom("AliceBlue");
            kasten_2_1.Foreground = (Brush)new BrushConverter().ConvertFrom("AliceBlue");

            kasten_0_2.Foreground = (Brush)new BrushConverter().ConvertFrom("AliceBlue");
            kasten_1_2.Foreground = (Brush)new BrushConverter().ConvertFrom("AliceBlue");
            kasten_2_2.Foreground = (Brush)new BrushConverter().ConvertFrom("AliceBlue");
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

        private bool Gewinnreihe(Button erstesKaestchen, Button zweitesKaestchen, Button drittesKaestchen)
        {
            if (erstesKaestchen.Content.ToString() != "" && erstesKaestchen.ToString() == zweitesKaestchen.ToString() && zweitesKaestchen.ToString() == drittesKaestchen.ToString())
            {
                return true;
            }

            return false;
        }

        private void GewinnreiheHervorheben(Button erstesKaestchen, Button zweitesKaestchen, Button drittesKaestchen)
        {
            erstesKaestchen.Background = Brushes.Orange;
            zweitesKaestchen.Background = Brushes.Orange;
            drittesKaestchen.Background = Brushes.Orange;
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
                lblHinweis.Content = "";
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
                lblHinweis.Content = "Kästchen belegt!";
                //MessageBox.Show("Das Feld ist bereits belegt. Bitte ein freies Kästchen wählen.", "Unzulässiger Zug", MessageBoxButton.OK, MessageBoxImage.Stop);
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
