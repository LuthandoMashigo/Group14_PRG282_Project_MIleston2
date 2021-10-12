using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Group14_PRG282_ProjectMilestone2.DL;

namespace Group14_PRG282_ProjectMilestone2.BL
{
    class Business_Logic_Files
    {
        FileHandler fh1 = new FileHandler();
        public void filecreateandint()
        {
         fh1.createfileandint();
        }
        public void readfiledl()
        {
            fh1.readfile();
        }
        public bool reguser(string username, string password)
        {
            bool check = fh1.regnewuser(username, password);

            return check;
        }

        public bool readfileforlogin(string username, string password)
        {
            bool check = fh1.readfileforlogin(username, password);

            return check;
        }
        public string validationfieldsreg(string username, string password)
        {
            string msg = "";
            if (string.IsNullOrEmpty(username)== true || string.IsNullOrEmpty(password) == true)
            {
                msg = "Ensure none of the fields are blank";
            }
            else
            {
                reguser(username,password);
            }
            return msg;
        }
        public string validationfieldslogin(string username, string password)
        {
            string msg = "";
            if (string.IsNullOrEmpty(username) == true || string.IsNullOrEmpty(password) == true)
            {
                msg = "Ensure none of the fields are blank";
            }
            else
            {
                readfileforlogin(username, password);
            }
            return msg;
        }
    }
}
