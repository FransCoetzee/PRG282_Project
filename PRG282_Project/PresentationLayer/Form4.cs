using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PRG282_Project.BusinessLogicLayer;

namespace PRG282_Project.PresentationLayer
{
    public partial class Form4 : Form
    {
        DataHandler db = new DataHandler();
        BindingSource source = new BindingSource();
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Validate first all of the
            //Do not take the module code as a parameter when inserting
            //Only take it  for update, search and delete
            db.insertModule(txtModName.Text, txtDescription.Text, txtLink.Text);
            loaddata();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            loaddata();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            db.updateModule(txtCode.Text,txtModName.Text, txtDescription.Text, txtLink.Text);
            loaddata();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            db.deleteModule(txtCode.Text);
            loaddata();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = dataGridView1.CurrentCell.RowIndex;

            txtCode.Text = dataGridView1.Rows[rowindex].Cells[0].Value.ToString();
            txtModName.Text = dataGridView1.Rows[rowindex].Cells[1].Value.ToString();
            txtDescription.Text = dataGridView1.Rows[rowindex].Cells[2].Value.ToString();
            txtLink.Text = dataGridView1.Rows[rowindex].Cells[3].Value.ToString();
        }

        public void loaddata()
        {
            source.DataSource = db.getModule();
            dataGridView1.DataSource = source;
            db.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
