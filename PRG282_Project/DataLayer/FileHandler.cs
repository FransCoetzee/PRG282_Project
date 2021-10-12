﻿using System;
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

        //Connection to the data base. we can use a single method to connect to the database like we once did in class

        //1 - read from file when validating the login credentials

        //2 -  method to write to the textfile when registering a new user
        private string path = AppDomain.CurrentDomain.BaseDirectory + "Login.txt";

        public FileHandler() { }

        public void CheckCreateFile()
        {
            if (!File.Exists(path))
            {
                StreamWriter file = File.CreateText(path);
                file.Close();
            }
        }

        public List<string> FileList()
        {
            using (TextReader file = File.OpenText(path))
            {
                return file.ReadToEnd().Split('\n').ToList();
            }
        }

        public bool Login(string user, string pass)
        {
            CheckCreateFile();
            List<string> logins = FileList();
            string details = user + "," + pass + "\r";
            using (FileStream file = File.Open(path, FileMode.Open))
            {
                if (logins.Contains(details))
                {
                    return true;
                }
                return false;
            }
        }

        public void Register(string user, string pass)
        {
            CheckCreateFile();
            using (StreamWriter file = File.AppendText(path))
            {
                file.WriteLine(user + "," + pass);
            }
        }

    }
}
