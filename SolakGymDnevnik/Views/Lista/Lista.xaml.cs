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
using SolakGymDnevnik.Models;

namespace SolakGymDnevnik.Views.Lista
{
    /// <summary>
    /// Interaction logic for Lista.xaml
    /// </summary>
    public partial class Lista : Window
    {
        private SolakGymDnevnikDataClassesDataContext dataContext;
        public List<Member> Members { get; set; }

        public Lista()
        {

            InitializeComponent();

            string connectionString = ConfigurationManager
                .ConnectionStrings["SolakGymDnevnik.Properties.Settings.SolakGymDnevnikDbConnectionString"].ConnectionString;
            dataContext = new SolakGymDnevnikDataClassesDataContext(connectionString);

            ShowMembers();
        }

        public void ShowMembers()
        {
            CalculateExpirationTime();
            var members = dataContext.Members.ToList();

            var validMembers = from member in members where member.ExpirationTime >= 0 select member;
            var invalidMembers = from member in members where member.ExpirationTime < 0 select member;

            lbClanovi.ItemsSource = validMembers;
            lbIstekliClanovi.ItemsSource = invalidMembers;
        }

        public void CalculateExpirationTime()
        {
            var members = dataContext.Members.ToList();
            foreach (var member in members)
            {
                var memberValidationTime = member.MembershipDuration;
                var memberExpirationTime = (memberValidationTime - DateTime.Today).Days;
                member.ExpirationTime = memberExpirationTime;
            }
        }

        // TODO
        public void UpateMember()
        {

        }

        public void BtnProduzi_OnClick(object sender, RoutedEventArgs e)
        {
            var invalidMembers = from member in dataContext.Members where member.ExpirationTime < 0 select member;
            foreach (var invalidMember in invalidMembers)
            {
                invalidMember.MembershipDuration = DateTime.Today.AddDays(30);
                invalidMember.ExpirationTime = (invalidMember.MembershipDuration - DateTime.Today).Days;
            }

            dataContext.SubmitChanges();
            ShowMembers();

        }

        private void BtnBack_OnClick(object sender, RoutedEventArgs e)
        {
            var mainWindow = new Glavni.Glavni();
            mainWindow.Show();
            this.Close();
        }
    }
}
