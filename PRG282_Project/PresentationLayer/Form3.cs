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
        
        public Form3()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileHandler file = new FileHandler();
            string user = txtName.Text;
            string pass = txtPassword.Text;
            if(user == "" || pass == "" || user.Contains(",") || pass.Contains(","))
            {
                MessageBox.Show("You can not leave these fields empty or have a ',' in them.")
            }
            else
            {
                file.Register(user, pass);
                MessageBox.Show("Registered Successfully");
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
}
