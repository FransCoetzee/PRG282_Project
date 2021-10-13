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

        private void Form2_Load(object sender, EventArgs e)
        {
            //Display the students via the datagridview on the form load
        }
      
        private void addNewStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //There's a problem with the Stored Procedure
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
            Student temp = new Student(id, name, surname, dob, gender, phone, address, modulecode, modulename, moduleDesc, onlinelink);
            data.insertStudent(temp);            

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            using (OpenFileDialog ofg = new OpenFileDialog() {Multiselect = false, ValidateNames = true, Filter = "Images|*.jpg;*png;*jpeg;*jfif" })
            {
                if (ofg.ShowDialog() == DialogResult.OK)
                {
                    string filename = ofg.FileName;
                    pictureBox1.Image = Image.FromFile(filename);
                    string[] file = filename.Split('.');

                    data.InsertImage(file[0], pictureBox1.Image);
                }
            }

            MessageBox.Show("Student Data Inserted Successfully");
        }

        private void updateStudentToolStripMenuItem_Click(object sender, EventArgs e)
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

            Student student = new Student();
            data.updateStudent(id.ToString(), name, surname, dob, gender, phone, address, modulecode, modulename, moduleDesc, onlinelink);
            MessageBox.Show($"Student {id} has been updated successfully");
        }

        private void deleteStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            data.deleteData(id.ToString());
            MessageBox.Show("Data has been succesfully");
        }

        private void searchStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtSearch.Text);
            dataGridView1.DataSource = data.SearchStudent(id);
        }

        private void exitAppliationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //This is how you load an image from your file explorer
        }
    }
}
