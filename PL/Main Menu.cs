using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Group14_PRG282_ProjectMilestone2.PL
{
    public partial class Main_Menu : Form
    {
        public Main_Menu()
        {
            InitializeComponent();
        }

        private void Main_Menu_Load(object sender, EventArgs e)
        {

        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Studentsfrm sfr = new Studentsfrm();
            sfr.Show();
            this.Hide();
        }

        private void modulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Modulesfrm mfr = new Modulesfrm();
            mfr.Show();
            this.Hide();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void databaseMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e) //312, 281
        {
            Point startPoint = new Point(0, 0);
            Point endPoint = new Point(300, 330);

            LinearGradientBrush lgb =
                new LinearGradientBrush(startPoint, endPoint, Color.FromArgb(255, 61, 90, 128), Color.FromArgb(255, 238, 108, 77));
            Graphics g = e.Graphics;
            g.FillRectangle(lgb, 0, 0, 300, 330);
        }
    }
}
