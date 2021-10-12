﻿using System;
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (file.Login(textBox1.Text, textBox2.Text))
            {
                Form2 Login = new Form2();
                this.Hide();
                Login.Show();
            }
            else {
                MessageBox.Show("Username or password is incorrect");
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
