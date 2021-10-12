using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using Group14_PRG282_ProjectMilestone2.BL;

namespace Group14_PRG282_ProjectMilestone2.PL
{
    public partial class Studentsfrm : Form
    {
        BindingSource picsbs = new BindingSource();
        Business_Logic blg1 = new Business_Logic();
        validation val = new validation();

        public Studentsfrm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label2.Hide();
            label13.Hide();
            DElBtn.Hide();
            UPbtn.Hide();
            StudNumtb.Hide();
            //StudentsDGV.Columns[7].Visible = false;
            StudentsDGV.DataSource = null;
            StudentsDGV.DataSource = blg1.readtbl();
        }

        private void INSTBtn_Click(object sender, EventArgs e)
        {
            string studname_surname = StudNam_Surtb.Text;
            string dob = dateTimePicker1.Value.ToString();
            string phone =studphonnumtb.Text;
            string address = studaddress.Text;
            string modulescodes = studmodstb.Text;
            string gender = "";
            if (radioButton1.Checked == true)
            {
                gender = radioButton1.Text;
            }
            else if (radioButton2.Checked == true)
            {
                gender = radioButton2.Text;
            }

            string justdate = "";
            for (int i = 0; i < 10; i++)
            {
                justdate = justdate + dob[i];
            }
            if (val.validationinsrt(studname_surname, justdate, phone, address, gender, modulescodes,filenametxt.Text) == "Addition sucessful")
            {
                MessageBox.Show(val.validationinsrt(studname_surname, justdate, phone, address, gender, modulescodes, filenametxt.Text));
                StudentsDGV.DataSource = null;
                StudentsDGV.DataSource = blg1.insrt(studname_surname, justdate, phone, address, gender, modulescodes, filenametxt.Text, blg1.ConvertImageToBytes(pictureBox1.Image));

                StudNumtb.Clear();
                StudNam_Surtb.Clear();
                dateTimePicker1.ResetText();
                studphonnumtb.Clear();
                studaddress.Clear();
                studmodstb.Clear();
                filenametxt.Clear();
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                pictureBox1.Image = null;
            }
            else
            {
                MessageBox.Show(val.validationinsrt(studname_surname, justdate, phone, address, gender, modulescodes, filenametxt.Text));
            }
        }

        private void DElBtn_Click(object sender, EventArgs e)
        {
            string studnum = StudNumtb.Text;
            DialogResult result;
            if (val.validationdel(studnum) == "Delete sucessful")
            {
                result = MessageBox.Show(val.validationdel(studnum) + " would you like to confirm this delete", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    StudentsDGV.DataSource = null;
                    StudentsDGV.DataSource = blg1.delete(studnum);

                    //add a delete pics ,ethdo to delete command to delete the pic after the user is deleted.
                    label2.Hide();
                    label13.Hide();
                    StudNumtb.Hide();
                    DElBtn.Hide();
                    UPbtn.Hide();

                    StudNumtb.Clear();
                    StudNam_Surtb.Clear();
                    dateTimePicker1.ResetText();
                    studphonnumtb.Clear();
                    studaddress.Clear();
                    studmodstb.Clear();
                    filenametxt.Clear();
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    pictureBox1.Image = null;
                }
                else
                {
                    MessageBox.Show("Please confirm your student number before you confirm the delete");
                }

            }
            else
            {
                MessageBox.Show(val.validationdel(studnum));
            }

        }

        private void UPbtn_Click(object sender, EventArgs e)
        {
            string studnum = StudNumtb.Text;
            string studname_surname = StudNam_Surtb.Text;
            string dob = dateTimePicker1.Value.ToString();
            string phone = studphonnumtb.Text;
            string address = studaddress.Text;
            string modulescodes = studmodstb.Text;
            string gender = "";
            if (radioButton1.Checked == true)
            {
                gender = radioButton1.Text;
            }
            else if (radioButton2.Checked == true)
            {
                gender = radioButton2.Text;
            }

            string justdate = "";
            for (int i = 0; i < 10; i++)
            {
                justdate = justdate + dob[i];
            }
            DialogResult result;
            if (val.validationUpd(studname_surname, justdate, phone, address, gender, modulescodes, studnum, filenametxt.Text) == "Update sucessful")
            {
                result = MessageBox.Show(val.validationUpd(studname_surname, justdate, phone, address, gender, modulescodes, studnum, filenametxt.Text) +"would you like to confirm this update", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    StudentsDGV.DataSource = null;
             
                    //add an update delete for the picture table to delete and insert a new pic.
                    StudentsDGV.DataSource = blg1.update(studname_surname, justdate, phone, address, gender, modulescodes, studnum, filenametxt.Text, blg1.ConvertImageToBytes(pictureBox1.Image));

                    label2.Hide();
                    label13.Hide();
                    StudNumtb.Hide();
                    DElBtn.Hide();
                    UPbtn.Hide();

                    StudNumtb.Clear();
                    StudNam_Surtb.Clear();
                    dateTimePicker1.ResetText();
                    studphonnumtb.Clear();
                    studaddress.Clear();
                    studmodstb.Clear();
                    filenametxt.Clear();
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    pictureBox1.Image = null;

                }
                else
                {
                    MessageBox.Show("Please confirm the what you have selected and input before you confirm the update");
                }
            }
            else
            {
               MessageBox.Show(val.validationUpd(studname_surname, justdate, phone, address, gender, modulescodes, studnum, filenametxt.Text));
            }


        }

        private void SrchBtn_Click(object sender, EventArgs e)
        {
            string srchcode = srchtb.Text;

            try
            {
                if (blg1.srchbar(srchcode).Rows.Count == 0)
                {
                    throw new StudDoesn_tExist("Student does not exist");
                }
                else
                {
                    if (val.validationsrch(srchcode) == "Search sucessful")
                    {
                        MessageBox.Show(val.validationsrch(srchcode));
                        StudentsDGV.DataSource = null;
                        StudentsDGV.DataSource = blg1.srchbar(srchcode);

                        srchtb.Clear();
                    }
                }
            }
            catch (StudDoesn_tExist ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main_Menu mm1 = new Main_Menu();
            mm1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StudentsDGV.DataSource = null;
            StudentsDGV.DataSource = blg1.readtbl();
        }

        private void updstudimgbtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Images(.jpg,.png)|*.png;*.jpg", Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(ofd.FileName);
                    filenametxt.Text = ofd.FileName;
                    picsbs.DataSource = null;
                    picsbs.DataSource = blg1.LoadData();
                }
            }
        }

        private void clrstudfieldbtn_Click(object sender, EventArgs e)
        {
            label2.Hide();
            label13.Hide();
            StudNumtb.Hide();
            DElBtn.Hide();
            UPbtn.Hide();

            StudNumtb.Clear();
            StudNam_Surtb.Clear();
            dateTimePicker1.ResetText();
            studphonnumtb.Clear();
            studaddress.Clear();
            studmodstb.Clear();
            filenametxt.Clear();

            radioButton1.Checked = false;
            radioButton2.Checked = false;

            pictureBox1.Image = null;
        }


        private void StudentsDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (StudentsDGV.CurrentRow.Cells[0].Value.ToString() == "")
            {
                label2.Hide();
                label13.Hide();
                StudNumtb.Hide();
                StudNumtb.Text = StudentsDGV.CurrentRow.Cells[0].Value.ToString();
            }
            else
            {
                label2.Show();
                label13.Show();
                StudNumtb.Show();
                StudNumtb.Text = StudentsDGV.CurrentRow.Cells[0].Value.ToString();
            }
            StudNam_Surtb.Text = StudentsDGV.CurrentRow.Cells[1].Value.ToString();
            if (StudentsDGV.CurrentRow.Cells[2].Value.ToString() =="")
            {
                dateTimePicker1.ResetText();
            }
            else
            {
                dateTimePicker1.Value = Convert.ToDateTime(StudentsDGV.CurrentRow.Cells[2].Value.ToString());
            }
            studphonnumtb.Text = StudentsDGV.CurrentRow.Cells[3].Value.ToString();
            studaddress.Text = StudentsDGV.CurrentRow.Cells[4].Value.ToString();
            studmodstb.Text = StudentsDGV.CurrentRow.Cells[6].Value.ToString();
            if (StudentsDGV.CurrentRow.Cells[5].Value.ToString() == "Male")
            {
                radioButton1.Checked = true;
            }
            else if(StudentsDGV.CurrentRow.Cells[5].Value.ToString() == "Female")
            {
                radioButton2.Checked = true;
            }
            else if (StudentsDGV.CurrentRow.Cells[5].Value.ToString() == "")
            {
                radioButton1.Checked = false;
                radioButton2.Checked = false;
            }
            if (StudentsDGV.CurrentRow.Cells[7].Value.ToString() =="")
            {
                pictureBox1.Image = null;
            }
            else
            {
                pictureBox1.Image = blg1.ConvertByteArrayToImage((byte[])StudentsDGV.CurrentRow.Cells[7].Value);
            }
            DElBtn.Show();
            UPbtn.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void StudNumtb_TextChanged(object sender, EventArgs e)
        {

        }

        private void StudNam_Surtb_TextChanged(object sender, EventArgs e)
        {

        }

        private void filenametxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void studphonnumtb_TextChanged(object sender, EventArgs e)
        {

        }

        private void studaddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void studmodstb_TextChanged(object sender, EventArgs e)
        {

        }

        private void Studentsfrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
