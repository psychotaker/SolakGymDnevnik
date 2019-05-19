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
using System.Windows.Shapes;

namespace SolakGymDnevnik.Views.Glavni
{
    /// <summary>
    /// Interaction logic for Glavni.xaml
    /// </summary>
    public partial class Glavni : Window
    {
        public Glavni()
        {
            InitializeComponent();
        }

        private void BtnLista_OnClick(object sender, RoutedEventArgs e)
        {
            var lista = new Lista.Lista();
            lista.Show();
            this.Close();
        }

        private void BtnNovi_OnClick(object sender, RoutedEventArgs e)
        {
            var novi = new Novi.Novi();
            novi.Show();
            this.Close();
        }

        private void BtnPrijava_OnClick(object sender, RoutedEventArgs e)
        {
            var prijava = new Prijava.Prijava();
            prijava.Show();
            this.Close();
        }
    }
}
