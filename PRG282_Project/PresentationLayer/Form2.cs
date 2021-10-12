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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        DataHandler data = new DataHandler();
        private void button2_Click(object sender, EventArgs e)
        {
            //There's a problem with the Procedure
            int id = int.Parse(txtID.Text);
            string name = txtName.Text;
            string surname = txtSurname.Text;
            string dob = txtBirth.Text;
            string gender = cmbGender.Text;
            string phone = txtPhone.Text;
            string address = txtAddress.Text;
            string modulecode = cmbModule.Text;
            string modulename = txtModName.Text;
            string moduleDesc = txtDescription.Text;
            string onlinelink = txtLink.Text;

            data.insertStudent(id.ToString(), name, surname, dob, gender, phone, address, modulecode, modulename, moduleDesc, onlinelink);
            MessageBox.Show("Student Data Inserted Successfully");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            string name = txtName.Text;
            string surname = txtSurname.Text;
            string dob = txtBirth.Text;
            string gender = cmbGender.Text;
            string phone = txtPhone.Text;
            string address = txtAddress.Text;
            string modulecode = cmbModule.Text;
            string modulename = txtModName.Text;
            string moduleDesc = txtDescription.Text;
            string onlinelink = txtLink.Text;

            data.updateStudent(id.ToString(), name, surname, dob, gender, phone, address, modulecode, modulename, moduleDesc, onlinelink);
            MessageBox.Show($"Student {id} has been updated successfully");

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //Display the students via the datagridview on the form load
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            data.deleteData(id.ToString());
            MessageBox.Show("Data has been succesfully");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtSearch.Text);
            dataGridView1.DataSource = data.SearchStudent(id);

        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
