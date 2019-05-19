using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace SolakGymDnevnik.Views.Novi
{
    /// <summary>
    /// Interaction logic for Novi.xaml
    /// </summary>
    public partial class Novi : Window
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

                    var newMemeber = new Member(tbName.Text, Convert.ToInt32(tbPhoneNumber.Text), 30);
                    dataContext.Members.InsertOnSubmit(newMemeber);
                    dataContext.SubmitChanges();
                }
                else
                {
                    MessageBox.Show("Unesite zadana polja","Pogreška");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ime i prezime te broj telefona su obavezni");
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddMember();
            tbName.Text = null;
            tbPhoneNumber.Text = null;
        }

        private void BtnBack_OnClick(object sender, RoutedEventArgs e)
        {
            var mainWindow = new Glavni.Glavni();
            mainWindow.Show();
            this.Close();
        }
    }
}
