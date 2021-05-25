using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerOfPasswords {
    public class Account {
        public string NameSite { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ChangeDate { get; set; }

        public Account(string name_site, string login, string password, DateTime create_date, DateTime change_date) {
            NameSite = name_site;
            Login = login;
            Password = password;
            CreateDate = create_date;
            ChangeDate = change_date;
        }
    }
}
