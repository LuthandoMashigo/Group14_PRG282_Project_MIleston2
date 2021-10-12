using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group14_PRG282_ProjectMilestone2.BL
{
    class validation
    {
        public string validationdel(string studnum)
        {
            string msg = "";
            bool confirm1 = false;
            int pingnumcheck1 = 0;
            for (int i = 0; i < studnum.Length; i++)
            {
                char Tst = studnum[i];
                if (char.IsDigit(Tst))
                {
                    pingnumcheck1++;
                }
            }
            if (studnum.Length == pingnumcheck1 && studnum.Length > 1)
            {
                confirm1 = true;
            }
            else
            {
                msg = "Enter a studnum and the student number can only have digits";
            }
            if (confirm1 == true)
            {
                msg = "Delete sucessful";
            }
            return msg;
        }
        public string validationsrch(string studnum)
        {
            string msg = "";
            bool confirm1 = false;
            int pingnumcheck1 = 0;
            for (int i = 0; i < studnum.Length; i++)
            {
                char Tst = studnum[i];
                if (char.IsDigit(Tst))
                {
                    pingnumcheck1++;
                }
            }
            if (studnum.Length == pingnumcheck1 && studnum.Length > 1)
            {
                confirm1 = true;
            }
            else
            {
                msg = "Enter a studnum and the student number can only have digits";
            }
            if (confirm1 == true)
            {
                msg = "Search sucessful";
            }
            return msg;
        }
        public string validationUpd(string studname_surname, string dob, string phonenum, string address, string gender, string modulescodes, string studnum, string file)
        {
            string msg = "";
            int pingnumcheck1 = 0;
            int pingnumcheck2 = 0;
            int pingnumcheck3 = 0;
            int pingnumcheck4 = 0;
            int pingnumcheck5 = 0;

            bool confirm1 = false;
            bool confirm2 = false;
            bool confirm3 = false;
            bool confirm4 = false;
            bool confirm5 = false;
            bool confirm6 = false;
            bool confirm7 = false;


            for (int i = 0; i < studname_surname.Length; i++)
            {
                char Tst = studname_surname[i];
                if (char.IsLetter(Tst) || char.IsWhiteSpace(Tst))
                {
                    pingnumcheck1++;
                }

            }
            for (int i = 0; i < phonenum.Length; i++)
            {
                char Tst = phonenum[i];
                if (char.IsDigit(Tst))
                {
                    pingnumcheck2++;
                }
            }
            for (int i = 0; i < address.Length; i++)
            {
                char Tst = address[i];
                if (char.IsDigit(Tst) || char.IsWhiteSpace(Tst) || char.IsLetter(Tst))
                {
                    pingnumcheck3++;
                }
            }
            if ((pingnumcheck1 == studname_surname.Length) && studname_surname.Length > 0)
            {
                confirm1 = true;
            }
            else
            {
                msg = "Ensure that you have input a valid name and surname";
            }
            if ((pingnumcheck2 == phonenum.Length) && phonenum.Length > 0 && phonenum.Length < 11)
            {
                confirm2 = true;
            }
            else
            {
                msg = "Ensure that you have input a valid phonenumber";
            }
            if ((pingnumcheck3 == address.Length) && address.Length > 0)
            {
                confirm3 = true;
            }
            else
            {
                msg = "Ensure that you have input a valid adddress";
            }
            if (gender == "Male")
            {
                confirm4 = true;
            }
            else if (gender == "Female")
            {
                confirm4 = true;
            }
            else
            {
                msg = "Ensure that you have selected a gender";
            }

            for (int i = 0; i < dob.Length; i++)
            {
                char Tst = dob[i];
                int year = 2003;
                string yearstr = "";

                yearstr = yearstr + dob[0] + dob[1] + dob[2] + dob[3];

                if (year <= Convert.ToInt32(yearstr))
                {
                    break;
                }
                if (char.IsDigit(Tst) || Tst == '/')
                {
                    pingnumcheck4++;
                }
            }
            if ((pingnumcheck4 == dob.Length) && dob.Length > 0 && dob.Length < 11)
            {
                confirm5 = true;
            }
            else
            {

                msg = "Ensure that you have input a valid dob";
            }
            for (int i = 0; i < studnum.Length; i++)
            {
                char Tst = studnum[i];
                if (char.IsDigit(Tst))
                {
                    pingnumcheck5++;
                }
            }
            if (studnum.Length == pingnumcheck5 && studnum.Length > 1)
            {
                confirm6 = true;
            }
            else
            {
                msg = "Enter a studnum and the student number can only have digits";
            }
            if (file.Length != 0)
            {
                confirm7 = true;
            }
            else
            {
                msg = "Ensure that you select an image , use the uplaod button to do so.";
            }
            if (confirm1 == true && confirm2 == true && confirm3 == true && confirm4 == true && confirm5 == true && confirm6 == true && confirm7 == true)
            {
                msg = "Update sucessful";
            }

            return msg;
        }
        public string validationinsrt(string studname_surname, string dob, string phonenum, string address, string gender, string modules_code, string file)
        {

            string msg = "";
            int pingnumcheck1 = 0;
            int pingnumcheck2 = 0;
            int pingnumcheck3 = 0;
            int pingnumcheck4 = 0;
            int pingnumcheck5 = 0;


            bool confirm1 = false;
            bool confirm2 = false;
            bool confirm3 = false;
            bool confirm4 = false;
            bool confirm5 = false;
            bool confirm6 = false;
            bool confirm7 = false;


            for (int i = 0; i < studname_surname.Length; i++)
            {
                char Tst = studname_surname[i];
                if (char.IsLetter(Tst) || char.IsWhiteSpace(Tst))
                {
                    pingnumcheck1++;
                }

            }
            for (int i = 0; i < phonenum.Length; i++)
            {
                char Tst = phonenum[i];
                if (char.IsDigit(Tst))
                {
                    pingnumcheck2++;
                }
            }
            for (int i = 0; i < address.Length; i++)
            {
                char Tst = address[i];
                if (char.IsDigit(Tst) || char.IsWhiteSpace(Tst) || char.IsLetter(Tst))
                {
                    pingnumcheck3++;
                }
            }
            if ((pingnumcheck1 == studname_surname.Length) && studname_surname.Length > 0)
            {
                confirm1 = true;
            }
            else
            {
                msg = "Ensure that you have input a valid name and surname";
            }
            if ((pingnumcheck2 == phonenum.Length) && phonenum.Length > 0 && phonenum.Length < 11)
            {
                confirm2 = true;
            }
            else
            {
                msg = "Ensure that you have input a valid phonenumber";
            }
            if ((pingnumcheck3 == address.Length) && address.Length > 0)
            {
                confirm3 = true;
            }
            else
            {
                msg = "Ensure that you have input a valid adddress";
            }
            if (gender == "Male")
            {
                confirm4 = true;
            }
            else if (gender == "Female")
            {
                confirm4 = true;
            }
            else
            {
                msg = "Ensure that you have selected a gender";
            }

            for (int i = 0; i < dob.Length; i++)
            {
                char Tst = dob[i];
                int year = 2002;
                string yearstr = "";

                yearstr = yearstr + dob[0] + dob[1] + dob[2] + dob[3];

                if (year <= Convert.ToInt32(yearstr))
                {
                    break;
                }
                if (char.IsDigit(Tst) || Tst == '/')
                {
                    pingnumcheck4++;
                }
            }
            if ((pingnumcheck4 == dob.Length) && dob.Length > 0 && dob.Length < 11)
            {
                confirm5 = true;
            }
            else
            {

                msg = "Ensure that you have input a valid dob";
            }
            for (int i = 0; i < modules_code.Length; i++)
            {
                char Tst = modules_code[i];
                if (char.IsDigit(Tst) || Tst == ';')
                {
                    pingnumcheck5++;
                }

            }
            if ((pingnumcheck5 == modules_code.Length) && modules_code.Length > 3)
            {
                confirm6 = true;
            }
            else
            {
                msg = "Ensure that you have input all existing module codes and the field can not be blank ";
            }
            if (file.Length != 0 )
            {
                confirm7 = true;
            }
            else
            {
                msg = "Ensure that you select an image , use the uplaod button to do so.";
            }
            if (confirm1 == true && confirm2 == true && confirm3 == true && confirm4 == true && confirm5 == true && confirm6 == true && confirm7 == true)
            {

                msg = "Addition sucessful";
            }

            return msg;
        }


        public string validationdel_mods(string mod_code)
        {
            string msg = "";
            bool confirm1 = false;
            int pingnumcheck1 = 0;
            for (int i = 0; i < mod_code.Length; i++)
            {
                char Tst = mod_code[i];
                if (char.IsDigit(Tst))
                {
                    pingnumcheck1++;
                }
            }
            if (mod_code.Length == pingnumcheck1 && mod_code.Length > 1)
            {
                confirm1 = true;
            }
            else
            {
                msg = "Enter a module code of an existing module and the module code can only have digits";
            }
            if (confirm1 == true)
            {

                msg = "Delete sucessful";
            }
            return msg;
        }
        public string validationsrch_mods(string mod_code)
        {
            string msg = "";
            bool confirm1 = false;
            int pingnumcheck1 = 0;
            for (int i = 0; i < mod_code.Length; i++)
            {
                char Tst = mod_code[i];
                if (char.IsDigit(Tst))
                {
                    pingnumcheck1++;
                }
            }
            if (mod_code.Length == pingnumcheck1 && mod_code.Length > 1)
            {
                confirm1 = true;
            }
            else
            {
                msg = "Enter a module code of an existing module and the module code can only have digits";
            }
            if (confirm1 == true)
            {

                msg = "Search sucessful";
            }
            return msg;
        }
        public string validationUpd_mods(string module_code, string module_name, string module_description, string linksextraresources)
        {
            string msg = "";
            int pingnumcheck1 = 0;
            int pingnumcheck2 = 0;
            int pingnumcheck3 = 0;
            int pingnumcheck4 = 0;


            bool confirm1 = false;
            bool confirm2 = false;
            bool confirm3 = false;
            bool confirm4 = false;



            for (int i = 0; i < module_name.Length; i++)
            {
                char Tst = module_name[i];
                if (char.IsLetter(Tst) || char.IsWhiteSpace(Tst))
                {
                    pingnumcheck1++;
                }

            }
            for (int i = 0; i < module_description.Length; i++)
            {
                char Tst = module_description[i];
                if (char.IsLetter(Tst) || char.IsWhiteSpace(Tst) || char.IsDigit(Tst))
                {
                    pingnumcheck2++;
                }

            }

            for (int i = 0; i < linksextraresources.Length; i++)
            {
                char Tst = linksextraresources[i];

                if (char.IsLetter(Tst) || char.IsDigit(Tst) || Tst == '/' || Tst == '.' || Tst == ':')
                {
                    pingnumcheck3++;
                }
            }
            if ((pingnumcheck1 == module_name.Length) && module_name.Length > 0)
            {
                confirm1 = true;
            }
            else
            {
                msg = "Ensure that the module name has only letters";
            }
            if ((pingnumcheck2 == module_description.Length) && module_description.Length > 0)
            {
                confirm2 = true;
            }
            else
            {
                msg = "Ensure that have put a valid description and it cannot be left blank";
            }
            if ((pingnumcheck3 == linksextraresources.Length) && linksextraresources.Length > 0)
            {
                confirm3 = true;
            }
            else
            {
                msg = "Ensure that you input a valid link to extra resources for the module";
            }
            for (int i = 0; i < module_code.Length; i++)
            {
                char Tst = module_code[i];
                if (char.IsDigit(Tst))
                {
                    pingnumcheck4++;
                }
            }
            if (module_code.Length == pingnumcheck4 && module_code.Length > 0)
            {
                confirm4 = true;
            }
            else
            {
                msg = "Enter a module code of an existing module and the module code can only have digits";
            }
            if (confirm1 == true && confirm2 == true && confirm3 == true && confirm4 == true)
            {

                msg = "Update sucessful";
            }

            return msg;
        }
        public string validationinsrt_mods(string module_name, string module_description, string linksextraresources)
        {
            string msg = "";
            int pingnumcheck1 = 0;
            int pingnumcheck2 = 0;
            int pingnumcheck3 = 0;


            bool confirm1 = false;
            bool confirm2 = false;
            bool confirm3 = false;


            for (int i = 0; i < module_name.Length; i++)
            {
                char Tst = module_name[i];
                if (char.IsLetter(Tst) || char.IsWhiteSpace(Tst))
                {
                    pingnumcheck1++;
                }

            }
            for (int i = 0; i < module_description.Length; i++)
            {
                char Tst = module_description[i];
                if (char.IsLetter(Tst) || char.IsWhiteSpace(Tst) || char.IsDigit(Tst))
                {
                    pingnumcheck2++;
                }

            }

            for (int i = 0; i < linksextraresources.Length; i++)
            {
                char Tst = linksextraresources[i];

                if (char.IsLetter(Tst) || char.IsDigit(Tst) || Tst == '/' || Tst == '.' || Tst == ':')
                {
                    pingnumcheck3++;
                }
            }
            if ((pingnumcheck1 == module_name.Length) && module_name.Length > 0)
            {
                confirm1 = true;
            }
            else
            {
                msg = "Ensure that the module name has only letters";
            }
            if ((pingnumcheck2 == module_description.Length) && module_description.Length > 0)
            {
                confirm2 = true;
            }
            else
            {
                msg = "Ensure that have put a valid description and it cannot be left blank";
            }
            if ((pingnumcheck3 == linksextraresources.Length) && linksextraresources.Length > 0)
            {
                confirm3 = true;
            }
            else
            {
                msg = "Ensure that you input a valid link to extra resources for the module";
            }

            if (confirm1 == true && confirm2 == true && confirm3 == true)
            {

                msg = "Module addition sucessful";
            }

            return msg;
        }
    }
}
