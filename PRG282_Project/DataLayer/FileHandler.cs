using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PRG282_Project.DataLayer
{
    class FileHandler
    {
        //Define all methods to read and write to the textfile and database.        

    
        private string path = AppDomain.CurrentDomain.BaseDirectory + "Login.txt";

        public FileHandler() { }

        public void CheckCreateFile()
        {
            if (!File.Exists(path))
            {
                File.CreateText(path);
            }
        }
        
        //1 - read from file when validating the login credentials
        public List<string> FileList()
        {
            return File.ReadAllLines(path).ToList();
        }

        //2 -  method to write to the textfile when registering a new user
        public void Register(string user, string pass)
        {
            File.AppendText(path).WriteLine(user + "," + pass);
        }



    }
}
