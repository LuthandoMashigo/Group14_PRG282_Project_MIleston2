using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.IO;

namespace Group14_PRG282_ProjectMilestone2.Data
{
    class DataBase
    {
      

        public void createDB()//delete this , in github
        {
            string usedb = "USE UniversityDB\n\n";
            string dropdispstudprocifexist = "DROP PROCEDURE IF EXISTS displayprocStudents";
            string dropdispmodsprocifexist = "DROP PROCEDURE IF EXISTS displayprocModules";
            string createdisplaystudproc = "CREATE PROCEDURE displayprocStudents\nAS\nBEGIN\nSELECT " +
                "tblStudents.Student_Number AS 'Student Number', tblStudents.Name_Surname  AS 'Student Number',tblStudents.DOB  AS 'Student DOB',tblStudents.Phone  AS 'Student Phone Number',tblStudents.Address  AS 'Student Address',tblStudents.Gender  AS 'Student Gender',tblStudents.Module_Codes  AS 'Student Modules', tblPictures.IMG  AS 'Student Image'" +
                "FROM tblStudents INNER JOIN tblPictures ON tblPictures.pic_id = tblStudents.StudPicID\nEND";
            string createdisplaymodsproc = "CREATE PROCEDURE displayprocModules\nAS\nBEGIN\nSELECT * FROM tblModules\nEND";

            string tableint = "INSERT INTO tblStudents(Name_Surname,DOB,Phone,Address,Gender,Module_Codes,StudPicID)VALUES('Amo Mashigo','2001/04/19','0813187828','38 Corporal Avenue','Male','500;\n505;\n510',1000)";
            string tableint2 = "INSERT INTO tblModules(Module_Name,Module_Description,LinksToExtraSoucres)VALUES('Math','281 version','https://wwww.math.com')" +"\n"+ "INSERT INTO tblModules(Module_Name,Module_Description,LinksToExtraSoucres)VALUES('Linear Programming','281 version','https://wwww.LPR.com')" + "\n" + "INSERT INTO tblModules(Module_Name,Module_Description,LinksToExtraSoucres)VALUES('Programming','282 version','https://wwww.programming.com')" + "\n";

            string tableint3 = "INSERT INTO tblStudModules(Mod_Code,Studnum)VALUES(500,1000)"+"\n"+ "INSERT INTO tblStudModules(Mod_Code,Studnum)VALUES(505,1000)" + "\n" + "INSERT INTO tblStudModules(Mod_Code,Studnum)VALUES(510,1000)" + "\n";
            string createifdoesntexists = "USE master\n\nIF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = 'UniversityDB')\nBEGIN\nCREATE DATABASE UniversityDB\nEND";

            string filename = @"D:\Belgium Campus\Second year\PRG282\Testing for Proj\handsome-athletic-young-male-studnet-dormitory-cant-focus-loud-crowded-place_176420-33416.jpg";
            byte[] imageData = File.ReadAllBytes(@"D:\Belgium Campus\Second year\PRG282\Testing for Proj\handsome-athletic-young-male-studnet-dormitory-cant-focus-loud-crowded-place_176420-33416.jpg");

            SqlConnection myConn = new SqlConnection("Data Source=(local);Initial Catalog=master;Integrated Security=SSPI");
            SqlCommand createcommand = new SqlCommand(createifdoesntexists, myConn);
           

            myConn.Open();
            createcommand.ExecuteNonQuery();
            myConn.Close();

            string createtablestudandinitifdoesntexist = "IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblStudents')\nBEGIN\nCREATE TABLE tblStudents" +
             "(" +
            "Student_Number INT" + " IDENTITY(1000,5) PRIMARY KEY," +
            "Name_Surname VARCHAR(100)," +
            "DOB VARCHAR(20)," +
            "Phone  VARCHAR(20)," +
            "Address  VARCHAR(500)," +
            "Gender VARCHAR(10)," +
            "Module_Codes VARCHAR(100),"+
            "StudPicID INT REFERENCES tblPictures(pic_id)" +
            ")" + "\n" + tableint + "\nEND";

            //img table
            string createtablepicsandinitifdoesntexist = "IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblPictures')\nBEGIN\nCREATE TABLE tblPictures" +
             "(" +
            "pic_id INT" + " IDENTITY(1000,5) PRIMARY KEY," +
            "Filename VARCHAR(1000)," +
            "IMG IMAGE," +

            ")" + "\nEND";


            string createtablemodulesandinitifdoesntexist = "IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblModules')\nBEGIN\nCREATE TABLE tblModules" +
             "(" +
            "Module_Code INT" + " IDENTITY(500,5) PRIMARY KEY," +
            "Module_Name VARCHAR(100)," +
            "Module_Description VARCHAR(50)," +
            "LinksToExtraSoucres  VARCHAR(200)," +
            ")" + "\n" + tableint2+ "\nEND"; ;

            //Bridge table....
            
            string createtablestudmodulesandinitifdoesntexist = "IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblStudModules')\nBEGIN\nCREATE TABLE tblStudModules" +
             "(" +
            "Mod_Code INT" + " REFERENCES tblModules(Module_Code)," +
            "Studnum INT" + " REFERENCES tblStudents(Student_Number)," +
            "PRIMARY KEY(Mod_Code,Studnum)" +
            ")"+"\n"+ tableint3+ "\nEND"; ;

            SqlConnection myConn2 = new SqlConnection("Data Source=(local);Initial Catalog=UniversityDB;Integrated Security=SSPI");

            myConn2.Open();
            SqlCommand useunidb = new SqlCommand(usedb, myConn2);
            useunidb.ExecuteNonQuery();
            SqlCommand crctblpicscom = new SqlCommand(createtablepicsandinitifdoesntexist, myConn2);
            crctblpicscom.ExecuteNonQuery();
            //Get this to onlu fire once

            SqlCommand picint = new SqlCommand("INSERT INTO tblPictures(Filename,IMG)VALUES(@Filename,@Img)", myConn2);
            picint.Parameters.AddWithValue("@FIlename",filename);
            picint.Parameters.AddWithValue("@Img",imageData);
            picint.ExecuteNonQuery();
            SqlCommand crctblstudcom = new SqlCommand(createtablestudandinitifdoesntexist, myConn2);
            crctblstudcom.ExecuteNonQuery();
            SqlCommand crctblmodscom = new SqlCommand(createtablemodulesandinitifdoesntexist, myConn2);
            crctblmodscom.ExecuteNonQuery();     
            SqlCommand crctblstudmodscom = new SqlCommand(createtablestudmodulesandinitifdoesntexist, myConn2);
            crctblstudmodscom.ExecuteNonQuery();
            SqlCommand dropproc1 = new SqlCommand(dropdispstudprocifexist, myConn2);
            dropproc1.ExecuteNonQuery();
            SqlCommand dropproc2 = new SqlCommand(dropdispmodsprocifexist, myConn2);
            dropproc2.ExecuteNonQuery();
            SqlCommand crcproc1 = new SqlCommand(createdisplaystudproc, myConn2);
            crcproc1.ExecuteNonQuery();
            SqlCommand crcproc2 = new SqlCommand(createdisplaymodsproc, myConn2);
            crcproc2.ExecuteNonQuery();

            myConn2.Close();
        }
    }
}
