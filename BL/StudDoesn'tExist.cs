using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group14_PRG282_ProjectMilestone2.BL
{
    class StudDoesn_tExist : Exception
    {
        public StudDoesn_tExist(string message) : base(message)
        {
        }
    }
}
