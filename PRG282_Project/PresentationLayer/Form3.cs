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

namespace PRG282_Project.PresentationLayer
{
    public partial class Form3 : Form
    {
        FileHandler file = new FileHandler();
        public Form3()
        {
            InitializeComponent();
        }
        FileHandler file = new FileHandler();         

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(file.Register(txtName.Text, txtPassword.Text) == "True")
            {
                MessageBox.Show("Registered Successfully");
            }
            else
            {
                MessageBox.Show("Try Again");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmLogin Login = new frmLogin();
            this.Hide();
            Login.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

      
    }
}
