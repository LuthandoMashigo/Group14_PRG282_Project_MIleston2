using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group14_PRG282_ProjectMilestone2.Data
{
    class User
    {
        string name;
        string password;

        public User(string name, string password)
        {
            this.Name = name;
            this.Password = password;
        }

        public string Name { get => name; set => name = value; }
        public string Password { get => password; set => password = value; }
    }
}
