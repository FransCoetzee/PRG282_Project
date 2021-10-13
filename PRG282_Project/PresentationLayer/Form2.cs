using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.IO;


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
        string filename;

        private void Form2_Load(object sender, EventArgs e)
        {
            //Display the students via the datagridview on the form load
            dataGridView1.DataSource = data.DisplayStudents();
            data.Close();
        }
      
        private void addNewStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {                        
            string name = txtName.Text;
            string surname = txtSurname.Text;
            string dob = txtBirth.Text;
            string gender = cmbGender.Text;
            string phone = txtPhone.Text;
            string address = txtAddress.Text;

            int pictureno = 10160;
            int modulecode = int.Parse(txtMC.Text);
            //ADD THE INSERT METHOD HERE
            data.insertStudent(name, surname, dob, gender, phone, address, pictureno, modulecode);
            pictureno = pictureno + 15;

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
          
                    
            pictureBox1.Image = Image.FromFile(filename);
            string[] file = filename.Split('.');
            data.InsertImage(file[0], pictureBox1.Image);//I think this is where it takes the picture that's in the piture box into the database                          

            MessageBox.Show("Student Data Inserted Successfully");
            Form4 Module = new Form4();
            Module.Show();
            this.Hide();
        }

        private void updateStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtID.Enabled = true;
            int id = int.Parse(txtID.Text);
            string name = txtName.Text;
            string surname = txtSurname.Text;
            string dob = txtBirth.Text;
            string gender = cmbGender.Text;
            string phone = txtPhone.Text;
            string address = txtAddress.Text;

            int modulecode = int.Parse(txtMC.Text);

            data.updateStudent(id, name, surname, dob, gender, phone, address, modulecode);

            DialogResult dialogResult =  MessageBox.Show("Would you like to update the student image as well?", "Student Image", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
              pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
              using (OpenFileDialog ofg = new OpenFileDialog() { Multiselect = false, ValidateNames = true, Filter = "Images|*.jpg;*png;*jpeg;*jfif" })
              {
                if (ofg.ShowDialog() == DialogResult.Yes)
                {
                    string filename = ofg.FileName;
                    pictureBox1.Image = Image.FromFile(filename);
                    string[] file = filename.Split('.');

                    data.InsertImage(file[0], pictureBox1.Image);
                }
              }
                MessageBox.Show($"Student {id} has been updated successfully");
            }
            else
            {
                MessageBox.Show($"Student {id} has been updated successfully");
            }                        
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
            data.Close();
        }

        private void exitAppliationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //This is how you load an image from your file explorer
            //Image image = null;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            using (OpenFileDialog ofg = new OpenFileDialog() { Multiselect = false, ValidateNames = true, Filter = "Images|*.jpg;*png;*jpeg;*jfif" })
            {
                if (ofg.ShowDialog() == DialogResult.OK)
                {
                    filename = ofg.FileName;
                    pictureBox1.Image = Image.FromFile(filename);
                    textBox1.Text = filename;
                }
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {                                  
            if (e.RowIndex >= 0)
            {              
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                txtID.Text = row.Cells["StudentID"].Value.ToString();
                txtName.Text = row.Cells["sName"].Value.ToString();
                txtSurname.Text = row.Cells["sSurname"].Value.ToString();
                txtAddress.Text = row.Cells["sAddress"].Value.ToString();
                txtPhone.Text = row.Cells["Phone"].Value.ToString();
                txtMC.Text = row.Cells["ModuleCode"].Value.ToString();
                txtBirth.Text = row.Cells["DateOfBirth"].Value.ToString();
                textBox1.Text = row.Cells["Filename"].Value.ToString();
                cmbGender.SelectedItem = row.Cells["Gender"].Value.ToString();

                string conn = "Server=.; Initial Catalog= BelgiumCampusStudents; Integrated Security = SSPI";
                SqlConnection connect = new SqlConnection(conn);
                connect.Open();

                string query = $"SELECT StudentImage FROM Picture P INNER JOIN Student S ON P.PictureNo = S.PictureNo WHERE StudentID = {row.Cells["StudentID"].Value.ToString()}";
                SqlCommand cmd = new SqlCommand(query,connect);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    byte[] b = new byte[0];
                    b = (Byte[])dr["StudentImage"];
                    MemoryStream ms = new MemoryStream(b);
                    pictureBox1.Image = Image.FromStream(ms);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 Module = new Form4();
            Module.Show();
            this.Hide();
        }
        private void btnMod_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 frm = new Form4();
            frm.Show();

        }
    }
}
