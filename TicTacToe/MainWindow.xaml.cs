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

            if (buttonKasten.Content == null || buttonKasten.Content.ToString() == "")
            {
                buttonKasten.Content = "X";
            }
            else
            {
                MessageBox.Show("Spieler 1 hat das Feld bereits besetzt.", "Unzulässiger Zug", MessageBoxButton.OK, MessageBoxImage.Stop);
            }



                //if (buttonKasten.Content.ToString() == "X")
                //{
                //    buttonKasten.Content = "O";
                //}
                //else
                //{
                //    buttonKasten.Content = "X";
                //}


            //if (buttonKasten == null || buttonKasten.Content.ToString() == "")
            //{
            //    buttonKasten.Content = "X";



            //}






            //buttonKasten_0_0.Content = "X";

            //if (IstSpielfeldVoll(true))
            //{

            //}
            




            //var bisherigerVordergrund = kasten_0_0.Foreground;
            //kasten_0_0.Foreground = kasten_0_0.Background;
            //kasten_0_0.Background = bisherigerVordergrund;


            //;

            //foreach (UIElement item in Spielfeld.Children)
            //{
            //    if (item is Button Kasten_0_0)
            //    {
            //        
            //    }
            //    else
            //    {
            //        MessageBox.Show("Feld bereits von Sieler 1 belegt.");
            //    }

            //}


            //if (buttonKasten_0_0 == null)
            //{
            //    kasten_0_0.Content = "X";
            //}

            //kasten_0_0.Content = "X";

            //switch ((Button)sender)
            //{
            //    case (kasten_0_0.Content = "x")
            //    {


            //    }


      //              {
      //default:
      //              break;
      //              }
          
            //}
        }
    }
}
