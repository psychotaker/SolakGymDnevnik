using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SolakGymDnevnik.Views.Uredi
{
    /// <summary>
    /// Interaction logic for Uredi.xaml
    /// </summary>
    public partial class Uredi : Window
    {
        private Member selectedMember { get; set; }
        private SolakGymDnevnikDataClassesDataContext dataContext;
        public Uredi()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager
                .ConnectionStrings["SolakGymDnevnik.Properties.Settings.SolakGymDnevnikDbConnectionString"].ConnectionString;
            dataContext = new SolakGymDnevnikDataClassesDataContext(connectionString);
        }

        public void EditMember(string userName,string phoneNumber,int id)
        {
            selectedMember = dataContext.Members.FirstOrDefault(m => m.Id.Equals(id));
            tbName.Text = userName;
            tbPhoneNumber.Text = phoneNumber;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            selectedMember.Name = tbName.Text;
            selectedMember.PhoneNumber = Convert.ToInt32(tbPhoneNumber.Text);

            dataContext.SubmitChanges();

            var listaWindow = new Lista.Lista();
            listaWindow.Show();
            this.Close();
        }

        private void BtnBack_OnClick(object sender, RoutedEventArgs e)
        {
            var listaWindow = new Lista.Lista();
            listaWindow.Show();
            this.Close();
        }
    }
}
