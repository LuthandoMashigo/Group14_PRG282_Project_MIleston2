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

    public partial class Login : Form
    {
        Business_Logic_Files blgf1 = new Business_Logic_Files();

        int LoginState = 0;
        bool ShowError = false;
        public bool Sign_In = false;

        private int count = 0;
        private bool register = true;

        private string sUsername = "";

        public Login()
        {
            InitializeComponent();
            edtLogin.Text = "Username";
            edtLogin.ForeColor = Color.DarkGray;
            this.edtLogin.Leave += new System.EventHandler(this.edtLogin_Leave_U);
            this.edtLogin.Leave += new System.EventHandler(this.edtLogin_Leave_P);
            this.edtLogin.Enter += new System.EventHandler(this.edtLogin_Enter_U);
            this.edtLogin.Enter += new System.EventHandler(this.edtLogin_Enter_P);
        }
        public Login(string username, string password)
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //
        }

        private void Login_Load(object sender, EventArgs e)
        {
            blgf1.filecreateandint();
            blgf1.readfiledl();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username = sUsername;
            string password = edtLogin.Text;

            if (username == "")
            {
                password = "";
            } else
            {
                if (password == "Password")
                {
                    password = "";
                }
            }
            Registercs refg = new Registercs(username, password);
            refg.Show();
            this.Hide();

        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #region User Interface Control 

        private void edtLogin_Enter_U(object sender, EventArgs e)
        {
            if (edtLogin.Text == "Username" && LoginState == 0)
            {
                edtLogin.Text = "";
                edtLogin.ForeColor = Color.Black;
                edtLogin.UseSystemPasswordChar = false;
            }
        }

        private void edtLogin_Leave_U(object sender, EventArgs e)
        {
            if (edtLogin.Text == "" && LoginState == 0)
            {
                edtLogin.Text = "Username";
                edtLogin.ForeColor = Color.DarkGray;
                edtLogin.UseSystemPasswordChar = false;
            }
        }

        private void edtLogin_Enter_P(object sender, EventArgs e)
        {
            if (edtLogin.Text == "Password" && LoginState == 1)
            {
                edtLogin.Text = "";
                edtLogin.ForeColor = Color.Black;
                edtLogin.UseSystemPasswordChar = true;
            }
        }

        private void edtLogin_Leave_P(object sender, EventArgs e)
        {
            if (edtLogin.Text == "" && LoginState == 1)
            {
                edtLogin.Text = "Password";
                edtLogin.ForeColor = Color.Black;
                edtLogin.UseSystemPasswordChar = false;
            }
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            edtLogin.UseSystemPasswordChar = false;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            edtLogin.UseSystemPasswordChar = true;
        }

        #endregion

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SendKeys.Send("Enter");
            switch (LoginState)
            {
                case 0:
                    {
                        sUsername = edtLogin.Text;
                        Pass();
                    }
                    break;
                case 1:
                    if (blgf1.readfileforlogin(sUsername, edtLogin.Text) == true)
                    {
                        Sign_In = true;

                        Main_Menu mm1 = new Main_Menu();
                        mm1.Show();
                        this.Hide();

                    }
                    else
                    {
                        lblError.Visible = true;
                        lblError.Text = "Login credentials are incorrect.";
                        ShowError = true;

                        count += 1;
                        if (count > 1 && register == true)
                        {
                            DialogResult result;
                            result = MessageBox.Show("Ensure you credentials are correct, if these are not your credentials would you like to register", "Credentials", MessageBoxButtons.YesNo);

                            if (result == DialogResult.Yes)
                            {
                                string username = sUsername;
                                string password = edtLogin.Text;

                                if (username == "")
                                {
                                    password = "";
                                }
                                else
                                {
                                    if (password == "Password")
                                    {
                                        password = "";
                                    }
                                }
                                Registercs refg = new Registercs(username, password);
                                refg.Show();
                                this.Hide();

                            }
                            else if (result == DialogResult.No)
                            {
                                MessageBox.Show("Please try again");
                                register = false;
                            }
                        }
                    }
                    break;
                default:
                    break;

            }
        }

        private void Pass()
        {
            lblLogin.Text = "Enter Password";
            LoginState = 1;
            edtLogin.Text = "Password";
            edtLogin.ForeColor = Color.DarkGray;
            lblBack.Visible = true;
            btnLogin.Text = "Enter";
            picShowPass.Visible = true;
            edtLogin.UseSystemPasswordChar = false;
            if (ShowError)
            {
                lblError.Visible = false;
                ShowError = false;
            }
            this.Focus();
        }

        private void User()
        {
            lblLogin.Text = "Sign In";
            LoginState = 0;
            edtLogin.Text = "Username";
            edtLogin.ForeColor = Color.DarkGray;
            lblBack.Visible = false;
            btnLogin.Text = "Next";
            picShowPass.Visible = false;
            edtLogin.UseSystemPasswordChar = false;
            if (ShowError)
            {
                lblError.Visible = false;
                ShowError = false;
            }
            this.Focus();
        }

        private void picShowPass_MouseEnter(object sender, EventArgs e)
        {
            edtLogin.UseSystemPasswordChar = false;
        }

        private void picShowPass_MouseLeave(object sender, EventArgs e)
        {
            edtLogin.UseSystemPasswordChar = true;
        }

        private void lblBack_Click(object sender, EventArgs e)
        {
            User();
        }
    }
}
