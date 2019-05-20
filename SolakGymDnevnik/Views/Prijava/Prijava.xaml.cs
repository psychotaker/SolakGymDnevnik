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

namespace SolakGymDnevnik.Views.Prijava
{
    /// <summary>
    /// Interaction logic for Prijava.xaml
    /// </summary>
    public partial class Prijava : Window
    {
        

        public Prijava()
        {
            InitializeComponent();
        }

        private void BtnBack_OnClick(object sender, RoutedEventArgs e)
        {
            var mainWindow = new Glavni.Glavni();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(tbUserName.Text) && !String.IsNullOrWhiteSpace(pbPassword.Password))
            {
                var isAdmin = Admin.IsAdmin(tbUserName.Text, pbPassword.Password);
                if (isAdmin)
                {
                    MessageBox.Show("Prijavljeni ste kao administarator", "Prijava uspješna", MessageBoxButton.OK,
                        MessageBoxImage.Information);
                    var glavni = new Glavni.Glavni();
                    glavni.BtnPrijava.Visibility = Visibility.Collapsed;
                    glavni.BtnOdjava.Visibility = Visibility.Visible;
                    glavni.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Podaci unešeni u zadana polja nisu ispravni", "Prijava neuspješna",
                        MessageBoxButton.OK,MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Molimo vas da unesete podatke u odgovarajuća polja", "Unesi podatke",
                    MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        
    }

}
