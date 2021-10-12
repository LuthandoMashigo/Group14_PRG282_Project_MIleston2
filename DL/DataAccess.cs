using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Group14_PRG282_ProjectMilestone2.Data;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Group14_PRG282_ProjectMilestone2.DL
{
    
    class DataAccess
    {


        public DataTable readdb ()
        {
            SqlConnection myConn = new SqlConnection("Data Source=(local);Initial Catalog=UniversityDB;Integrated Security=SSPI");
            myConn.Open();
            SqlCommand selecom = new SqlCommand("EXEC displayprocStudents", myConn);
            selecom.ExecuteNonQuery();
            myConn.Close();

            SqlDataAdapter SDA = new SqlDataAdapter(selecom);
            DataTable dt1 = new DataTable();
            SDA.Fill(dt1);

            myConn.Close();
            return dt1;
        }
        public DataTable readdb2()
        {
            SqlConnection myConn = new SqlConnection("Data Source=(local);Initial Catalog=UniversityDB;Integrated Security=SSPI");
            myConn.Open();
            SqlCommand selecom = new SqlCommand("EXEC displayprocModules", myConn);
            selecom.ExecuteNonQuery();
            myConn.Close();

            SqlDataAdapter SDA = new SqlDataAdapter(selecom);
            DataTable dt1 = new DataTable();
            SDA.Fill(dt1);

            myConn.Close();
            return dt1;
        }
        public DataTable readdb3()
        {
            SqlConnection myConn = new SqlConnection("Data Source=(local);Initial Catalog=UniversityDB;Integrated Security=SSPI");
            myConn.Open();
            SqlCommand selecom = new SqlCommand("SELECT * FROM tblStudModules ORDER BY [Studnum] asc ", myConn);
            selecom.ExecuteNonQuery();
            myConn.Close();

            SqlDataAdapter SDA = new SqlDataAdapter(selecom);
            DataTable dt1 = new DataTable();
            SDA.Fill(dt1);

            myConn.Close();
            return dt1;
        }
        public DataTable inserttbl(string studname_surname,string dob,string phone , string addess,string gender,string module_codes, string fileName, byte[] image)
        {

            string inscmd = "INSERT INTO tblStudents(Name_Surname,DOB,Phone,Address,Gender,Module_Codes,StudPicID)" + "VALUES("+Convert.ToString("'"+studname_surname+"'" +","+ "'" + dob + "'" + ","+ "'" + phone + "'" + ","+ "'" + addess + "'"+ ","+"'" + gender + "'"+ "," + "'" + module_codes+"'"+ ", (SELECT TOP 1 pic_id FROM tblPictures ORDER BY [pic_id] desc)") +")";
            SqlConnection myConn = new SqlConnection("Data Source=(local);Initial Catalog=UniversityDB;Integrated Security=SSPI");

            myConn.Open();
            using (SqlCommand cmd = new SqlCommand("Insert into tblPictures(Filename, IMG) values(@filename, @image)", myConn))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@filename", fileName);
                cmd.Parameters.AddWithValue("@image", image);
                cmd.ExecuteNonQuery();
            }

            string[] studmodcodes = module_codes.Split(';');

            SqlCommand incomm = new SqlCommand(inscmd, myConn);
            incomm.ExecuteNonQuery();

            for (int i = 0; i < studmodcodes.Length; i++)
            {
                SqlCommand checkifmodexistthheninsrt = new SqlCommand(
                 "DECLARE @CurrentModnum INT " +
                 "SET @CurrentModnum =" + Convert.ToString(studmodcodes[i]) +
                 "IF(@CurrentModnum IN((SELECT Module_Code FROM tblModules)))" +
                 "\nBEGIN\n" +
                 "INSERT INTO tblStudModules(Mod_Code,Studnum)" +
                "VALUES(@CurrentModnum,(SELECT TOP 1 Student_Number FROM tblStudents ORDER BY [Student_Number] desc))" +
                "\nEND", myConn);
                checkifmodexistthheninsrt.ExecuteNonQuery();
            }

            SqlCommand selecomm = new SqlCommand("EXEC displayprocStudents", myConn);
            selecomm.ExecuteNonQuery();

               

            SqlDataAdapter SDA = new SqlDataAdapter(selecomm);
            DataTable dt1 = new DataTable();
            SDA.Fill(dt1);

            myConn.Close();
      
            return dt1;
        }
        public DataTable uptbl(string studname_surname, string dob, string phone, string addess,string gender, string module_codes, string studnum ,string fileName, byte[] image)
        {
            //Have it update the student table as well with the revelant infor to show that the module has changed and update the studmodtable as well. And then redisplay student
            string upbystudnum1 = "UPDATE tblStudents SET Name_Surname=" + Convert.ToString("'"+studname_surname+"'")+ "WHERE Student_Number =" + Convert.ToString(studnum);
            string upbystudnum2 = "UPDATE tblStudents SET DOB=" + Convert.ToString("'" + dob + "'") + "WHERE Student_Number =" + Convert.ToString(studnum);
            string upbystudnum3 = "UPDATE tblStudents SET Phone=" + Convert.ToString("'" + phone + "'") + "WHERE Student_Number =" + Convert.ToString(studnum);
            string upbystudnum4 = "UPDATE tblStudents SET Address=" + Convert.ToString("'" + addess + "'") + "WHERE Student_Number =" + Convert.ToString(studnum);
            string upbystudnum5 = "UPDATE tblStudents SET Gender=" + Convert.ToString("'" + gender + "'") + "WHERE Student_Number =" + Convert.ToString(studnum);
            string upbystudnum6 = "UPDATE tblStudents SET Module_Codes=" + Convert.ToString("'" + module_codes + "'") + "WHERE Student_Number =" + Convert.ToString(studnum);

            SqlConnection myConn = new SqlConnection("Data Source=(local);Initial Catalog=UniversityDB;Integrated Security=SSPI");


            myConn.Open();

            using (SqlCommand cmd = new SqlCommand("UPDATE tblPictures SET Filename = @filename  WHERE pic_id =" + studnum, myConn))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@filename", fileName);
                cmd.ExecuteNonQuery();
            }
            using (SqlCommand cmd = new SqlCommand("UPDATE tblPictures SET IMG = @image  WHERE pic_id =" + studnum, myConn))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@image", image);
                cmd.ExecuteNonQuery();
            }

            SqlCommand upcomm1 = new SqlCommand(upbystudnum1, myConn);
            SqlCommand upcomm2 = new SqlCommand(upbystudnum2, myConn);
            SqlCommand upcomm3 = new SqlCommand(upbystudnum3, myConn);
            SqlCommand upcomm4 = new SqlCommand(upbystudnum4, myConn);
            SqlCommand upcomm5 = new SqlCommand(upbystudnum5, myConn);
            SqlCommand upcomm6 = new SqlCommand(upbystudnum6, myConn);
            upcomm1.ExecuteNonQuery();
            upcomm2.ExecuteNonQuery();
            upcomm3.ExecuteNonQuery();
            upcomm4.ExecuteNonQuery();
            upcomm5.ExecuteNonQuery();
            upcomm6.ExecuteNonQuery();

            string[] studmodcodes = module_codes.Split(';');

            SqlCommand delststudmods = new SqlCommand("DELETE FROM  tblStudModules" + " WHERE Studnum =" + Convert.ToString(studnum), myConn);
            delststudmods.ExecuteNonQuery();
            for (int i = 0; i < studmodcodes.Length; i++)
            {

                SqlCommand checkifmodexistthheninsrt = new SqlCommand(
                 "DECLARE @CurrentModnum INT " +
                 "SET @CurrentModnum =" + Convert.ToString(studmodcodes[i]) +
                 "IF(@CurrentModnum IN((SELECT Module_Code FROM tblModules)))" +
                 "\nBEGIN\n" +
                 "INSERT INTO tblStudModules(Mod_Code,Studnum)" +
                "VALUES(@CurrentModnum,(SELECT TOP 1 Student_Number FROM tblStudents WHERE Student_Number = " + studnum + " ORDER BY [Student_Number] desc))" +
                "\nEND", myConn);
                checkifmodexistthheninsrt.ExecuteNonQuery();
            }
            //Add correct modcodes to student modcode field once update is complete
            //.....code goes here
            
            SqlCommand selecomm = new SqlCommand("EXEC displayprocStudents", myConn);
            selecomm.ExecuteNonQuery();

            SqlDataAdapter SDA = new SqlDataAdapter(selecomm);
            DataTable dt1 = new DataTable();
            SDA.Fill(dt1);

            myConn.Close();
            return dt1;
        }
        public DataTable deltbl(string studnum)
        {
            string delbystudnum = "DELETE FROM tblStudents " + "WHERE Student_Number =" + Convert.ToString(studnum);
            string delpic = "DELETE FROM tblPictures WHERE pic_id =" + studnum;
            SqlConnection myConn = new SqlConnection("Data Source=(local);Initial Catalog=UniversityDB;Integrated Security=SSPI");

            myConn.Open();
            SqlCommand delpiccom = new SqlCommand(delpic,myConn);
            SqlCommand delcomm = new SqlCommand(delbystudnum, myConn);
            SqlCommand delststudmods = new SqlCommand("DELETE FROM  tblStudModules" + " WHERE Studnum =" + Convert.ToString(studnum), myConn);
            delststudmods.ExecuteNonQuery();
            delcomm.ExecuteNonQuery();
            delpiccom.ExecuteNonQuery();

            SqlCommand selecomm = new SqlCommand("EXEC displayprocStudents", myConn);
            selecomm.ExecuteNonQuery();

            SqlDataAdapter SDA = new SqlDataAdapter(selecomm);
            DataTable dt1 = new DataTable();
            SDA.Fill(dt1);

            myConn.Close();
            return dt1;

        }
        public DataTable srvhtbl(string studnum)
        {
           
            string srchbystudnum = "SELECT tblStudents.Student_Number AS 'Student Number', tblStudents.Name_Surname  AS 'Student Name and Surname',tblStudents.DOB  AS 'Student DOB',tblStudents.Phone  AS 'Student Phone Number',tblStudents.Address  AS 'Student Address',tblStudents.Gender  AS 'Student Gender',tblStudents.Module_Codes  AS 'Student Modules', tblPictures.IMG  AS 'Student Image'" +
                "FROM tblStudents INNER JOIN tblPictures ON tblPictures.pic_id = tblStudents.StudPicID " +
                "WHERE tblStudents.Student_Number =" + Convert.ToString(studnum);

            SqlConnection myConn = new SqlConnection("Data Source=(local);Initial Catalog=UniversityDB;Integrated Security=SSPI");
         
            myConn.Open();
            SqlCommand selcomm = new SqlCommand(srchbystudnum, myConn);

            selcomm.ExecuteNonQuery();

            SqlDataAdapter SDA = new SqlDataAdapter(selcomm);
            DataTable dt1 = new DataTable();
            SDA.Fill(dt1);
            myConn.Close();

            return dt1;
            
        }

        public DataTable inserttbl_mods(string module_name, string module_description, string linksextraresources)
        {
            string inscmd = "INSERT INTO tblModules(Module_Name,Module_Description,LinksToExtraSources)" + "VALUES(" + Convert.ToString("'" + module_name + "'" + "," + "'" + module_description + "'" + "," + "'" + linksextraresources + "'") + ")";
            SqlConnection myConn = new SqlConnection("Data Source=(local);Initial Catalog=UniversityDB;Integrated Security=SSPI");


            myConn.Open();
            SqlCommand incomm = new SqlCommand(inscmd, myConn);
            incomm.ExecuteNonQuery();


            SqlCommand selecomm = new SqlCommand("EXEC displayprocModules", myConn);
            selecomm.ExecuteNonQuery();



            SqlDataAdapter SDA = new SqlDataAdapter(selecomm);
            DataTable dt1 = new DataTable();
            SDA.Fill(dt1);

            myConn.Close();

            return dt1;
        }
        public DataTable uptbl_mods(string module_code, string module_name, string module_description, string linksextraresources)
        {
            string upbystudnum1 = "UPDATE tblModules SET Module_Name=" + Convert.ToString("'" + module_name + "'") + "WHERE Module_Code =" + Convert.ToString(module_code);
            string upbystudnum2 = "UPDATE tblModules SET Module_Description=" + Convert.ToString("'" + module_description + "'") + "WHERE Module_Code =" + Convert.ToString(module_code);
            string upbystudnum3 = "UPDATE tblModules SET LinksToExtraSources=" + Convert.ToString("'" + linksextraresources + "'") + "WHERE Module_Code =" + Convert.ToString(module_code);


            SqlConnection myConn = new SqlConnection("Data Source=(local);Initial Catalog=UniversityDB;Integrated Security=SSPI");



            myConn.Open();
            SqlCommand upcomm1 = new SqlCommand(upbystudnum1, myConn);
            SqlCommand upcomm2 = new SqlCommand(upbystudnum2, myConn);
            SqlCommand upcomm3 = new SqlCommand(upbystudnum3, myConn);

            upcomm1.ExecuteNonQuery();
            upcomm2.ExecuteNonQuery();
            upcomm3.ExecuteNonQuery();


            SqlCommand selecomm = new SqlCommand("EXEC displayprocModules", myConn);
            selecomm.ExecuteNonQuery();

            SqlDataAdapter SDA = new SqlDataAdapter(selecomm);
            DataTable dt1 = new DataTable();
            SDA.Fill(dt1);

            myConn.Close();
            return dt1;
        }
        public DataTable deltbl_mods(string module_code)
        {
           
            string delbymodcode = "DELETE FROM tblModules " + "WHERE Module_Code =" + Convert.ToString(module_code);

            SqlConnection myConn = new SqlConnection("Data Source=(local);Initial Catalog=UniversityDB;Integrated Security=SSPI");

            string delbystudmodcode = "DELETE FROM tblStudModules " + "WHERE Mod_Code =" + Convert.ToString(module_code);


            myConn.Open();
            SqlCommand delstudmodcomm = new SqlCommand(delbystudmodcode, myConn);

            delstudmodcomm.ExecuteNonQuery();
            SqlCommand delcomm = new SqlCommand(delbymodcode, myConn);
            
            delcomm.ExecuteNonQuery();

            SqlCommand selecomm = new SqlCommand("EXEC displayprocModules", myConn);
            selecomm.ExecuteNonQuery();

            SqlDataAdapter SDA = new SqlDataAdapter(selecomm);
            DataTable dt1 = new DataTable();
            SDA.Fill(dt1);

            myConn.Close();
            return dt1;

        }
        public DataTable srvhtbl_mods(string modulecode)
        {
            string srchbymodcode = "SELECT * FROM tblModules " + "WHERE Module_Code =" + Convert.ToString(modulecode);

            SqlConnection myConn = new SqlConnection("Data Source=(local);Initial Catalog=UniversityDB;Integrated Security=SSPI");

            myConn.Open();
            SqlCommand selcomm = new SqlCommand(srchbymodcode, myConn);

            selcomm.ExecuteNonQuery();

            SqlDataAdapter SDA = new SqlDataAdapter(selcomm);
            DataTable dt1 = new DataTable();
            SDA.Fill(dt1);

            myConn.Close();



            return dt1;
        }

        public void Insert(string fileName, byte[] image)
        {
            using (SqlConnection cn = new SqlConnection("Data Source=(local);Initial Catalog=UniversityDB;Integrated Security=SSPI"))
            {
                if (cn.State == ConnectionState.Closed)
                    cn.Open();
                using (SqlCommand cmd = new SqlCommand("Insert into tblPictures(Filename, IMG) values(@filename, @image)", cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@filename", fileName);
                    cmd.Parameters.AddWithValue("@image", image);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable LoadData()
        {
            using (SqlConnection cn = new SqlConnection("Data Source=(local);Initial Catalog=UniversityDB;Integrated Security=SSPI"))
            {
                if (cn.State == ConnectionState.Closed)
                    cn.Open();
                using (DataTable dt = new DataTable("Pictures"))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("select * from tblPictures", cn);
                    adapter.Fill(dt);
                     return dt;
                }
            }
        }

        public byte[] ConvertImageToBytes(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        public Image ConvertByteArrayToImage(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }
    }
}
