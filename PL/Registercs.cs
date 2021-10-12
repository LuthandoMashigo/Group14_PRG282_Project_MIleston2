using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Group14_PRG282_ProjectMilestone2.BL;

namespace Group14_PRG282_ProjectMilestone2.PL
{
    public partial class Registercs : Form
    {
        Business_Logic_Files blgf1 = new Business_Logic_Files();
        public Registercs()
        {
            InitializeComponent();

            usernametb.ForeColor = Color.DarkGray;
            passwordtb.ForeColor = Color.DarkGray;
            this.usernametb.Leave += new System.EventHandler(this.edtLogin_Leave_U);
            this.passwordtb.Leave += new System.EventHandler(this.edtLogin_Leave_P);
            this.usernametb.Enter += new System.EventHandler(this.edtLogin_Enter_U);
            this.passwordtb.Enter += new System.EventHandler(this.edtLogin_Enter_P);
        }
        public Registercs(string username , string password)
        {
            InitializeComponent();

            if (username != "")
            {
                usernametb.Text = username;
                usernametb.ForeColor = Color.Black;
            }
            if(password != "")
            {
                passwordtb.Text = password;
                passwordtb.ForeColor = Color.Black;
            }
        }

        private void Registercs_Load(object sender, EventArgs e)
        {
                blgf1.filecreateandint();
                blgf1.readfiledl();
              
        }

        private void regbtn_Click(object sender, EventArgs e)
        {
            SendKeys.Send("Enter");
            if (blgf1.reguser(usernametb.Text, passwordtb.Text) == false)
            {
                MessageBox.Show("User Added ","Registration");
            }
            else if (blgf1.reguser(usernametb.Text, passwordtb.Text) == true)
            {
                MessageBox.Show("User Already Exists , try enter a username that does not exist");
                usernametb.Clear();
                usernametb.Focus();
            }
           
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            Login l1 = new Login();
            l1.Show();
            this.Hide();
        }

        #region User Interface Control 

        private void edtLogin_Enter_U(object sender, EventArgs e)
        {
            if (usernametb.Text == "Username")
            {
                usernametb.Text = "";
                usernametb.ForeColor = Color.Black;
                usernametb.UseSystemPasswordChar = false;
            }
            else
            {
                usernametb.ForeColor = Color.Black;
            }
        }

        private void edtLogin_Leave_U(object sender, EventArgs e)
        {
            if (usernametb.Text == "")
            {
                usernametb.Text = "Username";
                usernametb.ForeColor = Color.DarkGray;
                usernametb.UseSystemPasswordChar = false;
            }
            else
            {
                usernametb.ForeColor = Color.Black;
            }
        }

        private void edtLogin_Enter_P(object sender, EventArgs e)
        {
            if (passwordtb.Text == "Password")
            {
                passwordtb.Text = "";
                passwordtb.ForeColor = Color.Black;
                passwordtb.UseSystemPasswordChar = true;
            }
        }

        private void edtLogin_Leave_P(object sender, EventArgs e)
        {
            if (passwordtb.Text == "")
            {
                passwordtb.Text = "Password";
                passwordtb.ForeColor = Color.DarkGray;
                passwordtb.UseSystemPasswordChar = false;
            }
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            passwordtb.UseSystemPasswordChar = false;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            passwordtb.UseSystemPasswordChar = true;
        }

        #endregion
    }
}
