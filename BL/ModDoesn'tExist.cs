using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group14_PRG282_ProjectMilestone2.BL
{
    class ModDoesn_tExist : Exception
    {
        public ModDoesn_tExist(string message) : base(message)
        {
        }
    }
}
