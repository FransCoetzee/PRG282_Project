﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PRG282_Project.BusinessLogicLayer
{
    class DataHandler
    {
        //To handle all business operation such as the insert, delete, update, search 
        //When inserting a new student, remember to insert the student number both tables, the modules table and the studnents tables.

        //Generate the student number automatically.  E.G Starting from 10500 and increase it by 15 each time
        //Upon insert, return the student number and display it to the user, you can use a message box

        //The pictureNO is automatically generated in the database with the  IDENTITY property
        private SqlConnection connect = new SqlConnection("Server=.; Initial Catalog= BelgiumCampusStudents; Integrated Security = SSPI");

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

        public SqlDataReader getData(string table)
        {
            Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM @table", connect);
            cmd.Parameters.AddWithValue("@table", table);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
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

        public void insertStudent(string id, string name, string surname, string dob, string gender, string phone,string address)
        {
            Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Student (StudentID,sName,sSurname,DateOfBirth,Gender,Phone,sAddress) VALUES (@id,@name,@surname,@DOB,@gender,@phone,@address)", connect);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@surname", surname);
            cmd.Parameters.AddWithValue("@DOB", dob);
            cmd.Parameters.AddWithValue("@gender", gender);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.ExecuteNonQuery();
            Close();
        }

        public void insertStudentModule(string id, string module)
        {
            Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Student (StudentID,ModuleCode) VALUES (@id,@module)", connect);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@module", module);
            cmd.ExecuteNonQuery();
            Close();
        }

        public void updateValue(string table,  string category, string value, string id)
        {
            Open();
            SqlCommand cmd = new SqlCommand("UPDATE @table SET @category = @value WHERE ID = @id", connect);
            cmd.Parameters.AddWithValue("@table", table);
            cmd.Parameters.AddWithValue("@category", category);
            cmd.Parameters.AddWithValue("@value", value);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            Close();
        }

        public void deleteData(string table, string column, string id)
        {
            Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM @table WHERE @column = @id", connect); //cmd.CommandText = "DELETE FROM Logins WHERE ID = @id"; cmd.Connection Connect;
            cmd.Parameters.AddWithValue("@table", table);
            cmd.Parameters.AddWithValue("@column", column);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            Close();
        }

        public void Close()
        {
            connect.Close();
        }
        public SqlConnection Connect { get => connect; set => connect = value; }
    }
}