using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Group14_PRG282_ProjectMilestone2.Data;

namespace Group14_PRG282_ProjectMilestone2.DL
{
    class FileHandler
    {
        List<User> u1 = new List<User>();
        Files f1 = new Files();
        string file = @"Users.txt";
        public void createfileandint()
        {
            f1.createfileandintial();
        }
        public bool regnewuser(string username, string password)
        {
            bool checkifexist = false;
            string newuser = "";
            string[] users = File.ReadAllLines(file);
            u1.Clear();
            for (int i = 0; i < users.Length; i++)
            {
                string individ = users[i];
                string[] individarr = individ.Split(';');
                u1.Add(new User(individarr[0], individarr[1]));
               
            }
            foreach (var item in u1)
            {
                if (item.Name == username)
                {
                    checkifexist = true;                    
                    break;
                }
            }
            if (checkifexist == false)
            {
                File.AppendAllText(file,"\n"+ username +";"+password);  
            }
            return checkifexist;
        }
        public bool readfileforlogin(string username, string password)
        {
            bool check = false;
            u1.Clear();
            if (u1.Count ==0)
            {
                string[] users = File.ReadAllLines(file);
                for (int i = 0; i < users.Length; i++)
                {
                    string individ = users[i];
                    string[] individarr = individ.Split(';');
                    u1.Add(new User(individarr[0], individarr[1]));
                }
            }
            foreach (var item in u1)
            {
                if (item.Name == username && item.Password == password)
                {
                    check = true;
                    break;
                }
            }
            return check;
        }
        public void readfile()
        {
            u1.Clear();
            string[] users = File.ReadAllLines(file);
            for (int i = 0; i < users.Length; i++)
            {
                string individ = users[i];
                string[] individarr = individ.Split(';');
                u1.Add(new User(individarr[0], individarr[1]));
            }
        }
    }
}
