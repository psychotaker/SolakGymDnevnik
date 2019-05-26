using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SolakGymDnevnik.Views.Novi
{
    /// <summary>
    /// Interaction logic for Novi.xaml
    /// </summary>
    public partial class Novi
    {
        private SolakGymDnevnikDataClassesDataContext dataContext;
        public Novi()
        {
            InitializeComponent();

            string connectionString = ConfigurationManager
                .ConnectionStrings["SolakGymDnevnik.Properties.Settings.SolakGymDnevnikDbConnectionString"].ConnectionString;
            dataContext = new SolakGymDnevnikDataClassesDataContext(connectionString);

        }

        public void AddMember()
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(tbName.Text) && !String.IsNullOrWhiteSpace(tbPhoneNumber.Text))
                {
                    if (CheckInput(tbName.Text, tbPhoneNumber.Text))
                    {
                        var newMemeber = new Member(tbName.Text, tbPhoneNumber.Text, 1);
                        dataContext.Members.InsertOnSubmit(newMemeber);
                        dataContext.SubmitChanges();
                        tbName.Text = null;
                        tbPhoneNumber.Text = null;
                    }
                }
                else
                {
                    MessageBox.Show("Unesite zadana polja", "Pogreška", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ime i prezime te broj telefona su obavezni", "Obavezna polja", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

        }

        public bool CheckInput(string Name, string PhoneNumber)
        {
            var inputCorrect = false;
            Match matchPhoneNumber = Regex.Match(PhoneNumber, @"\d");
            Match matchName = Regex.Match(Name, @"[A-Z]");
            if (!matchName.Success && !matchPhoneNumber.Success)
            {
                tbNameIncorrect.Visibility = Visibility.Visible;
                tbPhoneNumberIncorrect.Visibility = Visibility.Visible;
            }
            else if (!matchName.Success)
            {
                tbNameIncorrect.Visibility = Visibility.Visible;
            }
            else if (!matchPhoneNumber.Success || PhoneNumber.Length < 9)
            {
                tbPhoneNumberIncorrect.Visibility = Visibility.Visible;
            }
            else
            {
                inputCorrect = true;
            }

            return inputCorrect;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddMember();
        }

        private void BtnBack_OnClick(object sender, RoutedEventArgs e)
        {
            var mainWindow = new Glavni.Glavni();
            mainWindow.Show();
            this.Close();
        }

        private void TbPhoneNumber_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            tbPhoneNumberIncorrect.Visibility = Visibility.Collapsed;
        }

        private void TbName_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            tbNameIncorrect.Visibility = Visibility.Collapsed;
        }
    }
}
