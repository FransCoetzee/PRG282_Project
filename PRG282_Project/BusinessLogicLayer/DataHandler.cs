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
        //When inserting a new student, remember to insert the student number both tables, the modules table and the studnents tables.

        //Generate the student number automatically.  E.G Starting from 10500 and increase it by 15 each time
        //Upon insert, return the student number and display it to the user, you can use a message box

        //The pictureNO is automatically generated in the database with the  IDENTITY propert
       
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

     /*   public DataTable DisplayStudents()
        {
          
        }
     */

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
            string conn = "Server=.; Initial Catalog= BelgiumCampusStudents; Integrated Security = SSPI";
            using (SqlConnection connect = new SqlConnection(conn))
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


        public void insertStudent(Student myStudent)//Still needs to be tested, specifically with the picture
        {          
            string conn = "Server=.; Initial Catalog= BelgiumCampusStudents; Integrated Security = SSPI";
            using (SqlConnection connect = new SqlConnection(conn))
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
     
        public void updateStudent(string id, string name, string surname, string dob, string gender, string phone, string address, string modulecode, string modulename, string moduleDesc, string onlinelink)
        {
            /*  Open();
             SqlCommand cmd = new SqlCommand("UPDATE @table SET @category = @value WHERE ID = @id", connect);
             cmd.Parameters.AddWithValue("@table", table);
             cmd.Parameters.AddWithValue("@category", category);
             cmd.Parameters.AddWithValue("@value", value);
             cmd.Parameters.AddWithValue("@id", id);
             cmd.ExecuteNonQuery();
             Close(); */

            string conn = "Server=.; Initial Catalog= BelgiumCampusStudents; Integrated Security = SSPI";
            using (SqlConnection connect = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand("spUpdateStudents", connect);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StudentID", id);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Surname", surname);
                cmd.Parameters.AddWithValue("@dob", dob);
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@ModuleCode", modulecode);
                cmd.Parameters.AddWithValue("@ModuleName", modulename);
                cmd.Parameters.AddWithValue("@ModDescription", moduleDesc);
                cmd.Parameters.AddWithValue("@OnlineLink", onlinelink);

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

            string conn = "Server=.; Initial Catalog= BelgiumCampusStudents; Integrated Security = SSPI";
            try
            {
                using (SqlConnection connect = new SqlConnection(conn))
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
            string conn = "Server=.; Initial Catalog= BelgiumCampusStudents; Integrated Security = SSPI";
            using (SqlConnection connect = new SqlConnection(conn))
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
