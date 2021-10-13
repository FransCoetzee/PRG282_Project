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
     

        public string getValue(string id, string category, string table)
        {
            Open();
            SqlCommand cmd = new SqlCommand("SELECT @category FROM @table WHERE ID = @id", connect);
            cmd.Parameters.AddWithValue("@table", table);
            cmd.Parameters.AddWithValue("@category", category);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            cmd.ExecuteNonQuery();
            Close();
            return reader.ToString();
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
            using (connect)
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
               

                connect.Open();
                cmd.ExecuteNonQuery();
            }
            
        }
     
        public void updateStudent(int id,string name, string surname, string dob, string gender, string phone, string addy,int modulecode)
        {
            /*  Open();
             SqlCommand cmd = new SqlCommand("UPDATE @table SET @category = @value WHERE ID = @id", connect);
             cmd.Parameters.AddWithValue("@table", table);
             cmd.Parameters.AddWithValue("@category", category);
             cmd.Parameters.AddWithValue("@value", value);
             cmd.Parameters.AddWithValue("@id", id);
             cmd.ExecuteNonQuery();
             Close(); */

            
            using (connect)
            {
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

                connect.Open();
                cmd.ExecuteNonQuery();
            }

        }

        public bool deleteData(/*string table, string column,*/ string id)
        {
            /* Open();
             SqlCommand cmd = new SqlCommand("DELETE FROM @table WHERE @column = @id", connect); //cmd.CommandText = "DELETE FROM Logins WHERE ID = @id"; cmd.Connection Connect;
             cmd.Parameters.AddWithValue("@table", table);
             cmd.Parameters.AddWithValue("@column", column);
             cmd.Parameters.AddWithValue("@id", id);
             cmd.ExecuteNonQuery();
             Close();*/
          
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
                return true;
            }
            catch (Exception)
            {

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

        public void Close()
        {
            connect.Close();
        }
        public SqlConnection Connect { get => connect; set => connect = value; }
    }
}
