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
    public partial class Modulesfrm : Form
    {
        BindingSource bs2 = new BindingSource();
        Business_Logic blg1 = new Business_Logic();
        validation val = new validation();
        public Modulesfrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main_Menu mm1 = new Main_Menu();
            mm1.Show();
            this.Hide();
        }

        private void clrmodfieldbtn_Click(object sender, EventArgs e)
        {
            label12.Hide();
            Modcodetb.Clear();
            Modnamtb.Clear();
            Moddesrctb.Clear();
            LinkExtraResourtb.Clear();


            Modcodetb.Hide();
            delModbtn.Hide();
            updModbtn.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1.CurrentRow.Cells[0].Value.ToString() =="")
            {
                label12.Hide();
                Modcodetb.Hide();
                Modcodetb.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            }
            else
            {
                label12.Show();
                label4.Show();
                Modcodetb.Show();
                Modcodetb.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            }
            Modnamtb.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            Moddesrctb.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            LinkExtraResourtb.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();

            delModbtn.Show();
            updModbtn.Show();
        }

        private void Modulesfrm_Load(object sender, EventArgs e)
        {
            label4.Hide();
            label12.Hide();
            Modcodetb.Hide();
            delModbtn.Hide();
            updModbtn.Hide();

            bs2.DataSource = null;
            dataGridView1.DataSource = null;
            bs2.DataSource = blg1.readtbl2();
            dataGridView1.DataSource = bs2;
        }

        private void srchmodsbtn_Click(object sender, EventArgs e)
        {
            string srchmodcode = srchmodstb.Text;
            try
            {
                if (blg1.srchbar_mods(srchmodcode).Rows.Count == 0)
                {
                    throw new ModDoesn_tExist("Module does not exist");
                }
                else
                {
                    if (val.validationsrch_mods(srchmodcode) == "Search sucessful")
                    {
                        MessageBox.Show(val.validationsrch_mods(srchmodcode));
                        bs2.DataSource = null;
                        dataGridView1.DataSource = null;
                        bs2.DataSource = blg1.srchbar_mods(srchmodcode);
                        dataGridView1.DataSource = bs2;

                        srchmodstb.Clear();
                    }
                    else
                    {
                        MessageBox.Show(val.validationsrch_mods(srchmodcode));
                    }

                }
            }
            catch (ModDoesn_tExist ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void updModbtn_Click(object sender, EventArgs e)
        {
            DialogResult result;
            string mod_code = Modcodetb.Text;
            string modnam = Modnamtb.Text;
            string moddescr = Moddesrctb.Text;
            string linkextrares = LinkExtraResourtb.Text;
            if (val.validationUpd_mods(mod_code, modnam, moddescr, linkextrares) == "Update sucessful")
            {
                result = MessageBox.Show(val.validationUpd_mods(mod_code, modnam, moddescr, linkextrares) + "would you like to confirm this update", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    bs2.DataSource = null;
                    dataGridView1.DataSource = null;
                    bs2.DataSource = blg1.update_mods(mod_code, modnam, moddescr, linkextrares);
                    dataGridView1.DataSource = bs2;

                    label12.Hide();
                    label4.Hide();
                    Modcodetb.Clear();
                    Modcodetb.Hide();
                    delModbtn.Hide();
                    updModbtn.Hide();
                    Modnamtb.Clear();
                    Moddesrctb.Clear();
                    LinkExtraResourtb.Clear();
                }
                else
                {
                    MessageBox.Show("Please confirm what you selected and input before you confirm the update");
                }

            }
            else
            {
                MessageBox.Show(val.validationUpd_mods(mod_code, modnam, moddescr, linkextrares));
            }
        }

        private void insrtModbtn_Click(object sender, EventArgs e)
        {
            string modnam = Modnamtb.Text;
            string moddescr = Moddesrctb.Text;
            string linkextrares = LinkExtraResourtb.Text;

            if (val.validationinsrt_mods(modnam, moddescr, linkextrares) == "Module addition sucessful")
            {
                MessageBox.Show(val.validationinsrt_mods(modnam, moddescr, linkextrares));
                bs2.DataSource = null;
                dataGridView1.DataSource = null;
                bs2.DataSource = blg1.insrt_mods(modnam, moddescr, linkextrares);
                dataGridView1.DataSource = bs2;

                Modnamtb.Clear();
                Moddesrctb.Clear();
                LinkExtraResourtb.Clear();
            }
            else
            {
                MessageBox.Show(val.validationinsrt_mods(modnam, moddescr, linkextrares));
            }
        }

        private void delModbtn_Click(object sender, EventArgs e)
        {
            string mod_code = Modcodetb.Text;
            DialogResult result;
            if (val.validationdel_mods(mod_code) == "Delete sucessful")
            {
                result = MessageBox.Show(val.validationdel_mods(mod_code) + "would you like to confirm this delete", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    bs2.DataSource = null;
                    dataGridView1.DataSource = null;
                    bs2.DataSource = blg1.delete_mods(mod_code);
                    dataGridView1.DataSource = bs2;

                    label12.Hide();
                    label4.Hide();
                    Modcodetb.Clear();
                    Modcodetb.Hide();
                    delModbtn.Hide();
                    updModbtn.Hide();
                    Modnamtb.Clear();
                    Moddesrctb.Clear();
                    LinkExtraResourtb.Clear();
                }
                else
                {
                    MessageBox.Show("Please confirm the module code before you confirm the delete");
                }

            }
            else
            {
                MessageBox.Show(val.validationdel_mods(mod_code));
            }
        }

        private void showfullmodstable_Click(object sender, EventArgs e)
        {
            bs2.DataSource = null;
            dataGridView1.DataSource = null;
            bs2.DataSource = blg1.readtbl2();
            dataGridView1.DataSource = bs2;
        }

        private void Modulesfrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
