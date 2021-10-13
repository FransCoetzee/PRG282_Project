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

        public SqlDataReader getStudents()
        {
            Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Student", connect);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }

        public SqlDataReader getModule()
        {
            Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Module", connect);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }

        public void insertModule(string code, string name, string description, string link)
        {
            Open();
            string query = $"INSERT INTO Module VALUES ({code},{name},{description},{link})";
            SqlCommand cmd = new SqlCommand(query, connect);
            SqlDataReader reader = cmd.ExecuteReader();
            cmd.ExecuteNonQuery();
            Close();
        }

        public void updateModule(string code, string name, string description, string link)
        {
            Open();
            string query = $"UPDATE Module SET (ModuleCode,ModuleName,ModuleDescription,OnlineLink) = ({code},{name},{description},{link})";
            SqlCommand cmd = new SqlCommand(query, connect);
            SqlDataReader reader = cmd.ExecuteReader();
            cmd.ExecuteNonQuery();
            Close();
        }

        public void deleteModule(string code)
        {
            Open();
            string query = $"DELETE FROM Module WHERE ModuleCode = {code}";
            SqlCommand cmd = new SqlCommand(query, connect);
            SqlDataReader reader = cmd.ExecuteReader();
            cmd.ExecuteNonQuery();
            Close();
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

        //Read a picture from the database
        /*
        public string getImage()
        {
            Image img = null;
            int i = 0;            
            using (connect)
            {
                connect.Open();
                string query = "SELECT * FROM Picture";

                SqlCommand cmd = new SqlCommand(query, connect);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    byte[] imgData = (byte[])reader["StudentImage"];

                    using (MemoryStream ms = new MemoryStream(imgData))
                    {
                        img = Image.FromStream(ms);
                        img.Save(@"C:\Users\moren\OneDrive - belgiumcampus.ac.za\Pictures\Project Pictures\NewPicture"+i+".jpg");
                    }
                    i++;
                }
                return "Success";
            }
        }
        */

        public void insertStudent(Student myStudent)//Still needs to be tested, specifically with the picture
        {                     
            using (connect)
            {
                SqlCommand cmd = new SqlCommand("spAddStudents", connect);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StudentID", myStudent.Id);
                cmd.Parameters.AddWithValue("@Name", myStudent.Name);
                cmd.Parameters.AddWithValue("@Surname", myStudent.Surname);
                cmd.Parameters.AddWithValue("@dob", myStudent.Dob);
                cmd.Parameters.AddWithValue("@Gender", myStudent.Gender);
                cmd.Parameters.AddWithValue("@Phone", myStudent.Phone);
                cmd.Parameters.AddWithValue("@Address", myStudent.Address);
                cmd.Parameters.AddWithValue("@ModuleCode", myStudent.Modulecode);
                cmd.Parameters.AddWithValue("@ModuleName", myStudent.ModuleName);
                cmd.Parameters.AddWithValue("@ModDescription", myStudent.ModDescription);
                cmd.Parameters.AddWithValue("@OnlineLink", myStudent.Onlinelink);

                connect.Open();
                cmd.ExecuteNonQuery();
            }
            //When the user picks the module, whatever module code is selected, the rest of the information should apprear in the text boxes
        }
     
        public void updateStudent(Student myStudent)
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

                cmd.Parameters.AddWithValue("@StudentID", myStudent.Id);
                cmd.Parameters.AddWithValue("@Name", myStudent.Name);
                cmd.Parameters.AddWithValue("@Surname", myStudent.Surname);
                cmd.Parameters.AddWithValue("@dob", myStudent.Dob);
                cmd.Parameters.AddWithValue("@Gender", myStudent.Gender);
                cmd.Parameters.AddWithValue("@Phone", myStudent.Phone);
                cmd.Parameters.AddWithValue("@Address", myStudent.Address);
                cmd.Parameters.AddWithValue("@ModuleCode", myStudent.Modulecode);
                cmd.Parameters.AddWithValue("@ModuleName", myStudent.ModuleName);
                cmd.Parameters.AddWithValue("@ModDescription", myStudent.ModDescription);
                cmd.Parameters.AddWithValue("@OnlineLink", myStudent.Onlinelink);

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
