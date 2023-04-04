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
using System.IO;
using Tartalyok;


namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Tartaly> tartalyok = new List<Tartaly>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnFelvesz_Click(object sender, RoutedEventArgs e)
        {
            //    lbTartalyok.Items.Add(ujtest.Info());
            Tartaly ujTest;
            try
            {

                ujTest = new Tartaly(txtNev.Text, Convert.ToInt32(txtAel.Text), Convert.ToInt32(txtBel.Text), Convert.ToInt32(txtCel.Text));
                lbTartalyok.Items.Add(ujTest.Info());
                tartalyok.Add(ujTest);
            }
            catch (Exception)
            {
                MessageBox.Show("Írd be az összes értéket");

                return;
            }

        }

        private void rdoKocka_Checked(object sender, RoutedEventArgs e)
        {
            txtAel.IsEnabled = txtBel.IsEnabled = txtCel.IsEnabled = false;
            txtAel.Text = txtBel.Text = txtCel.Text = "10";

        }

        private void btnRogzit_Click(object sender, RoutedEventArgs e)
        {
            string fileName = "szoveg.txt";
            StreamWriter sw = new StreamWriter(fileName, append: true);

            for (int i = 0; i < lbTartalyok.Items.Count; i++)
            {
                String csvsor = $"{txtNev.Text};{txtAel.Text};{txtBel.Text};{txtCel.Text};{txtMennyitTolt.Text}";

                sw.WriteLine(csvsor);

            }
            sw.Close();


        }

        private void btntolt_Click(object sender, RoutedEventArgs e)
        {

            if (lbTartalyok.SelectedIndex >= 0)
            {
                tartalyok[lbTartalyok.SelectedIndex].Tolt(Convert.ToDouble(txtMennyitTolt.Text));
                lbTartalyok.Items[lbTartalyok.SelectedIndex] = tartalyok[lbTartalyok.SelectedIndex].Info();
            }
            else if (lbTartalyok.SelectedIndex == -1)
            {
                MessageBox.Show("Nincs kiválasztva elem!");
            } 
        }

        private void btnDuplaz_Click(object sender, RoutedEventArgs e)
        {
           
            if (lbTartalyok.SelectedIndex >= 0)
            {
                 tartalyok[lbTartalyok.SelectedIndex].DuplazMeretet();
                 lbTartalyok.Items[lbTartalyok.SelectedIndex] = tartalyok[lbTartalyok.SelectedIndex].Info();
            }
            else if (true)
            {
                MessageBox.Show("Nincs kiválasztva elem");
            }
        }

        private void btnLeenged_Click(object sender, RoutedEventArgs e)
        {
            if (lbTartalyok.SelectedIndex >= 0)
            {
                tartalyok[lbTartalyok.SelectedIndex].TeljesLeengedes();
                lbTartalyok.Items[lbTartalyok.SelectedIndex] = tartalyok[lbTartalyok.SelectedIndex].Info();
            }

        }

        private void rdoTeglatest_Checked(object sender, RoutedEventArgs e)
        {
            txtAel.IsEnabled = txtBel.IsEnabled = txtCel.IsEnabled = true;
            txtAel.Text = txtBel.Text = txtCel.Text = "";
        }
    }
}