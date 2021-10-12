using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PRG282_Project.DataLayer;
using PRG282_Project.BusinessLogicLayer;


namespace PRG282_Project
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileHandler file = new FileHandler();
            if (file.Login(textBox1.Text, textBox2.Text))
            {
                Form2 login = new Form2();
                this.Hide();
                login.Show();
            }
            else {
                MessageBox.Show("Username or password is incorrect");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
