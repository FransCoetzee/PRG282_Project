using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace PRG282_Project.BusinessLogicLayer
{
    class DataHandler
    {
        //To handle all business operation such as the insert, delete, update, search 
       //There are gonna be two sets of all CRUD Functions for modules and the actual students respectfully.
       
        SqlConnection connect = new SqlConnection("Server=.; Initial Catalog= BelgiumCampusStudents; Integrated Security = SSPI");

        public DataHandler() { }

        public void Open()
        {
            try
            {
                //Try open connection
                connect.Open();
                Console.WriteLine("Connection successful.");
            }
            catch (Exception er)
            {
                Console.WriteLine("Connection Not successful. \n" + er.Message);
            }
        }
        public void Close()
        {
            connect.Close();
        }

        public DataTable DisplayStudents()
        {
            using (connect)
            {
                SqlDataAdapter adapter = new SqlDataAdapter("spGetStudents", connect);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }
        public SqlDataReader getModule()
        {
            Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Module", connect);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }

        public void insertModule(string name, string description, string link)
        {
            Open();
            string query = $"INSERT INTO Module (ModuleName,ModuleDescription,OnlineLink) VALUES ('{name}','{description}','{link}')";
            SqlCommand cmd = new SqlCommand(query, connect);
            cmd.ExecuteNonQuery();
            Close();
        }

        public void updateModule(string code, string name, string description, string link)
        {
            Open();
            string query = $"UPDATE Module SET ModuleName = '{name}', ModuleDescription = '{description}', OnlineLink = '{link})' WHERE ModuleCode = {code}";
            SqlCommand cmd = new SqlCommand(query, connect);
            cmd.ExecuteNonQuery();
            Close();
        }

        public void deleteModule(string code)
        {
            Open();
            string query = $"DELETE FROM StudentModule WHERE ModuleCode = {code} " + $"DELETE FROM Module WHERE ModuleCode = {code}";
            SqlCommand cmd = new SqlCommand(query, connect);
            cmd.ExecuteNonQuery();
            Close();
        }

        //Insert Image to the database from vs
        public void InsertImage(string filename, Image img)
        {
            
            using (connect)
            {
                connect.Open();

                string query = $"INSERT INTO Picture(StudentImage,Filename) VALUES(@sImage,{filename})";
                using (SqlCommand cmd = new SqlCommand(query,connect))
                {
                    MemoryStream ms = new MemoryStream();
                    img.Save(ms, ImageFormat.Jpeg);

                    byte[] arrPhoto = new byte[ms.Length];
                    ms.Position = 0;
                    ms.Read(arrPhoto, 0, arrPhoto.Length);

                    cmd.Parameters.AddWithValue("@sImage", arrPhoto);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void insertStudent(string name, string surname, string dob, string gender, string phone, string addy, int pictureno, int modulecode)//Still needs to be tested, specifically with the picture
        {                                
                
                SqlCommand cmd = new SqlCommand("spAddStudents", connect);
                cmd.CommandType = CommandType.StoredProcedure;

                
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Surname", surname);
                cmd.Parameters.AddWithValue("@dob", dob);
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.Parameters.AddWithValue("@Address", addy);
                cmd.Parameters.AddWithValue("@PictureNo", pictureno);
                cmd.Parameters.AddWithValue("@ModuleCode", modulecode);

            Open();
            cmd.ExecuteNonQuery();
                          
        }
     
        public void updateStudent(int id,string name, string surname, string dob, string gender, string phone, string addy,int modulecode)
        {            
            using (connect)
            {
                Open();
                SqlCommand cmd = new SqlCommand("spUpdateStudents", connect);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StudentID", id);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Surname", surname);
                cmd.Parameters.AddWithValue("@dob", dob);
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.Parameters.AddWithValue("@Phone",phone);
                cmd.Parameters.AddWithValue("@Address", addy);
                cmd.Parameters.AddWithValue("@ModuleCode", modulecode);                          
               
                cmd.ExecuteNonQuery();
                Close();
            }

        }

        public bool deleteData( string id)
        {
            try
            {
                using (connect)
                {
                    SqlCommand cmd = new SqlCommand("spDeleteStudents", connect);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", id);

                    connect.Open();
                    cmd.ExecuteNonQuery();
                }
                Close();
                return true;
            }
            catch (Exception)
            {
                Close();
                return false;
            }
        }

        public DataTable SearchStudent(int id)
        {            
            using (connect)
            {
                SqlCommand cmd = new SqlCommand("spSearchStudents",connect);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);

                connect.Open();
                DataTable dt = new DataTable();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr);                    
                    return dt;
                }
            }
        }
        //Now the only thing thtat's missing is the inserting and displaying of the picture !!!

      
        public SqlConnection Connect { get => connect; set => connect = value; }
    }
}
