using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Group14_PRG282_ProjectMilestone2.Data
{
    class Files
    {
        string file = @"Users.txt";
        public void createfileandintial()
        {

            string users = "Amo;12345" + "\n" + "Jax;12347" + "\n" + "Alex;12346" + "\n" + "Lee;12346" + "\n";
            if (!File.Exists(file))
            {
                using (FileStream fs1 = new FileStream(file,FileMode.OpenOrCreate,FileAccess.ReadWrite))
                {
                    StreamWriter sw1 = new StreamWriter(fs1);
                    sw1.WriteLine(users);
                    sw1.Close();
                }

            }
        }
    }
}
