using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;
using System.Security.Cryptography;
using Microsoft.Win32;


namespace Capstone.QR
{
    class utils
    {
        // Database at First Run
        private static string HOST = Environment.MachineName;
        private static string USER = Environment.UserName;
        private const string DBNAME = "eventdb";
        public string passPhrase = "lulz2018";
        public string connMasterStr = "Data Source=" + HOST + @"\MSSQLSERVER;Initial Catalog=master;Integrated Security=SSPI;User ID=" + HOST + @"\" + USER + ";Password=";
        SqlConnection conn;




        public string createMasterDB()
        {
            string err = null;
            try
            {
                conn = new SqlConnection(connMasterStr);

                SqlCommand cmd;
                if (!checkDBExist())
                {
                    conn.Open();
                    string sql = "CREATE DATABASE EVENTDB";
                    cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (SqlException ex)
            {
                err = ex.Message;
            }
            return err;
        }



        public void createDefaultAdmin(){

            //insert default username or password of admin
            conn.Open();
            SqlCommand cmd;
            string pass = "123";
            pass = EncryptString(pass,passPhrase);
            SqlParameter uname = new SqlParameter();
            SqlParameter passwd = new SqlParameter();
            string sql = "INSERT INTO AUTH(uname,passwd) VALUES(@uname,@passwd)";
            uname.ParameterName = "@uname";
            uname.Value = "admin";
            passwd.ParameterName = "@passwd";
            passwd.Value = pass;
            
            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(uname);
            cmd.Parameters.Add(passwd);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public bool checkAdminTable()
        {
            bool exist = false;
            conn = new SqlConnection(connStr);
            string query = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.tables WHERE TABLE_NAME = 'auth'";
            SqlCommand cmd;
            SqlDataReader rd;
            conn.Open();
            cmd = new SqlCommand(query,conn);
            rd = cmd.ExecuteReader();
            
            if (rd.HasRows)
            {
                exist = true;
            }

            rd.Close();
            conn.Close();
            return exist;
        }

        public bool isSQLServerInstalled()
        {
            bool installed = false;
            string uninstallKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(uninstallKey))
            {
                foreach (string skName in rk.GetSubKeyNames())
                {
                    using (RegistryKey sk = rk.OpenSubKey(skName))
                    {
                        try
                        { 
                            var displayName = sk.GetValue("DisplayName");

                            if (displayName != null)
                            {
                                if (displayName.ToString().Contains("Microsoft SQL Server")) 
                                {
                                    installed = true;
                                }
                            }
                        }
                        catch (Exception)
                        { }
                    }
                }
                
            }
            return installed;
        }

        public bool checkDBExist()
        {
            conn = new SqlConnection(connMasterStr);
            SqlCommand cmd;
            conn.Open();
            string trySQL = "SELECT name FROM master.dbo.sysdatabases";
            cmd = new SqlCommand(trySQL, conn);
            SqlDataReader rd = cmd.ExecuteReader();

            bool exist = false;
            while (rd.Read())
            {
                if (rd.GetValue(0).ToString() == "EVENTDB")
                {
                    exist = true;   
                }
            }
            rd.Close();
            cmd.Dispose();
            conn.Close();
            return exist;
        }
        string connStr = "Data Source=" + HOST + @"\MSSQLSERVER;Initial Catalog="+ DBNAME +";Integrated Security=SSPI;User ID=" + HOST + @"\"+ USER + ";Password=;";

        public SqlConnection connectSQL()
        {
            try
            {
                conn = new SqlConnection(connStr);
            }
            catch (SqlException) { }
            return conn;
        }



        public Boolean CheckLogin(string user, string pass)
        {
            bool valid = false;
            pass = EncryptString(pass,passPhrase);
            try
            {
                conn = new SqlConnection(connStr);
                SqlCommand cmd;
                SqlDataReader reader;
                SqlParameter userParam = new SqlParameter();
                SqlParameter passParam = new SqlParameter();

                string query = "SELECT uname,passwd FROM auth WHERE uname=@user and passwd=@password";
                conn.Open();
                cmd = new SqlCommand(query, conn);
                userParam.ParameterName = "@user";
                userParam.Value = user;
                passParam.ParameterName = "@password";
                passParam.Value = pass;
                cmd.Parameters.Add(userParam);
                cmd.Parameters.Add(passParam);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.GetString(0) == user &&  reader.GetString(1)  == pass)
                    {
                        valid = true;
                    }
                }

                cmd.Dispose();
                reader.Close();
                conn.Close();
            }
            catch (Exception)
            {

            }

            return valid;
        }
        // Directory Creation and Sessions 

        private static string curDir = System.IO.Directory.GetCurrentDirectory();
        private static string[] dirs = new string[] { "configs", "exports","sessions" };
        private string sessionFile = "/user.session";
        private string sessionPath = curDir + "/" + dirs[2];

        public bool RememberUser()
        {
            bool auth = false;
            string currentSession = sessionPath + sessionFile;
            if (System.IO.File.Exists(currentSession))
            {
                using (StreamReader sr = new StreamReader(currentSession))
                {
                    
                    string account = sr.ReadLine();
                    string[] x = account.Split(":".ToCharArray());
                    if (CheckLogin(x[0], DecryptString(x[1],passPhrase) ))
                    {
                        auth = true;  
                    }
                    
                }
            }
            return auth;
        }

        public void CreateSession(string username,string password)
        {
            using (StreamWriter sw = new StreamWriter(sessionPath + "/user.session"))
            {
                sw.WriteLine(username + ":" + password);
            }
        }

        public void DeleteSession()
        {
            string currentSession = sessionPath + sessionFile;
            if (System.IO.File.Exists(currentSession))
            {
                File.Delete(sessionPath + sessionFile);
            }
        }

        public void StartUp()
        {
            bool IsCreated = false;
            foreach (string dir in dirs)
            {
                if (System.IO.Directory.Exists(curDir + "/" + dir))
                {
                    IsCreated = true;
                }
            }
            if (IsCreated == false)
            {
                MakeDirs();
            }
           
        }

        private void MakeDirs()
        {
            foreach (string dir in dirs) {
                System.IO.Directory.CreateDirectory(curDir + "/" + dir);
            }
            
        }
        // Encryptor :3
        private const string initVector = "lulzsecurity2018";
        // This constant is used to determine the keysize of the encryption algorithm
        private const int keysize = 256;
        public string EncryptString(string plainText, string passPhrase)
        {
            byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] cipherTextBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            return Convert.ToBase64String(cipherTextBytes);
        }
        //Decrypt
        public string DecryptString(string cipherText, string passPhrase)
        {
            byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
        }
    }
}
