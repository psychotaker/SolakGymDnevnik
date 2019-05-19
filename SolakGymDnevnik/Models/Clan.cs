using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SolakGymDnevnik.Models
{
    public class Clan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime MembershipTermTime { get; set; }
        public int ExpirationTime { get; set; }

        public Clan(int id,string name, int phoneNumber, double membershipTermTime)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            MembershipTermTime = DateTime.Today.AddDays(membershipTermTime);
            ExpirationTime = (MembershipTermTime - DateTime.Today).Days;
        }

        public Clan()
        {

        }


        public void SetMembershipTermTime(int days)
        {
            var dateTime = DateTime.Now.Date;
            MembershipTermTime = dateTime.Date.AddDays(days);
        }

    }
}
