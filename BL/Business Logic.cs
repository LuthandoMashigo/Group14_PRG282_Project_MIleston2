using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;

using Group14_PRG282_ProjectMilestone2.DL;

namespace Group14_PRG282_ProjectMilestone2.BL
{
    class Business_Logic
    {
        DataAccess dac1 = new DataAccess();
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
        DataTable dt4 = new DataTable();

        public void insertpic(string fileName, byte[] image)
        {
            dac1.Insert(fileName,image);
        }
        public DataTable LoadData()
        {
            dt4 = dac1.LoadData();

            return dt4;
        }

        public byte[] ConvertImageToBytes(Image img)
        {
            return dac1.ConvertImageToBytes(img);
        }

        public Image ConvertByteArrayToImage(byte[] data)
        {
            return dac1.ConvertByteArrayToImage(data);
        }

        public void db_tbl_create()
        {
            dac1.createdb();
        }
        public string dropdb()
        {
            string msg = "";
            msg = dac1.dropdb();
            return msg;
        }
        public DataTable insrt(string studname_surname, string dob, string phone, string address, string gender, string mod_codes, string fileName, byte[] image)
        {

            dt.Clear();

            dt = dac1.inserttbl(studname_surname, dob, phone, address,gender, mod_codes, fileName, image);

            return dt;
        }

        public DataTable update(string studname_surname, string dob, string phone, string addess,string gender,string modules_codes, string studnum, string fileName, byte[] image)
        {

            dt.Clear();
            dt = dac1.uptbl(studname_surname, dob, phone, addess,gender,modules_codes, studnum, fileName, image);

            return dt;
        }

        public DataTable delete(string studnum)
        {
            dt.Clear();
            dt = dac1.deltbl(studnum);

            return dt;
        }
        public DataTable srchbar(string studnum)
        {
            dt.Clear();
            dt = dac1.srvhtbl(studnum);

            return dt;
        }
        public DataTable insrt_mods(string module_name, string module_description, string linksextraresources)
        {

            dt2.Clear();

            dt2 = dac1.inserttbl_mods( module_name,  module_description,  linksextraresources);
            return dt2;
        }

        public DataTable update_mods(string module_code, string module_name, string module_description, string linksextraresources)
        {

            dt2.Clear();
            dt2 = dac1.uptbl_mods( module_code,  module_name,  module_description,  linksextraresources);

            return dt2;
        }

        public DataTable delete_mods(string module_code)
        {
            dt2.Clear();
            dt2 = dac1.deltbl_mods(module_code);

            return dt2;
        }
        public DataTable srchbar_mods(string module_code)
        {
            dt2.Clear();
            dt2 = dac1.srvhtbl_mods(module_code);

            return dt2;
        }


        public DataTable readtbl()
        {
            dt.Clear();
            dt = dac1.readdb();

            return dt;
        }

        public DataTable readtbl2()
        {
            dt2.Clear();
            dt2 = dac1.readdb2();

            return dt2;
        }

        public DataTable readtbl3()
        {
            dt3.Clear();
            dt3 = dac1.readdb3();

            return dt3;
        }

    }
}
