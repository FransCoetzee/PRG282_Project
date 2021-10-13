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


namespace PRG282_Project.PresentationLayer
{
    public partial class frmLogin : Form
    {
        FileHandler file = new FileHandler();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            try
            {
                if (textBox1.Text == string.Empty || textBox2.Text == string.Empty || textBox1.Text.Contains(",") || textBox2.Text.Contains(","))
                {
                    throw new EmptyTextException("\t\t\t\t!! Error !!\nUsername and Password cannot be left empty or contain a comma (',')");
                }
                string username = textBox1.Text;
                string password = textBox2.Text;
                if (file.Login(username, password))
                {
                 Form2 Login = new Form2();
                 this.Hide();
                 Login.Show();
                }
                else
                {
                  MessageBox.Show("Username or password is incorrect");
                }                                
            }
            catch (EmptyTextException et)
            {
                MessageBox.Show(et.Message);
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 Register = new Form3();
            this.Hide();
            Register.Show();
        }
    }
}
