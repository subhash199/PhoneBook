using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    public static class DatabaseServices
    {
        private static string fileName = "database.db";
        private static string connectionString = "Data Source=" + fileName + ";Version=3;";
        private static SQLiteConnection sqlite_conn;
        private static SQLiteCommand command;

        public static void connection()
        {
            if (!File.Exists(fileName))
            {
                File.Create(fileName);
            }
            sqlite_conn = new SQLiteConnection(connectionString);
            try
            {
                sqlite_conn.Open();
                Console.WriteLine("Connection has been opened!");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
        public static void CreateTable()
        {
            connection();
            string commandString = "Create table if not exists Contacts (FirstName VARCHAR (20), LastName VARCHAR (20), Phone VARCHAR(20));";

            command = sqlite_conn.CreateCommand();
            command.CommandText = commandString;
            command.ExecuteNonQuery();
            Console.WriteLine("Table Created!");
            sqlite_conn.Close();
        }
        public static bool Insert(string fName, string lName, string pPhone)
        {
            connection();
            bool result = true;
            string commandString = "Insert into Contacts (FirstName, LastName, Phone) Values('" + fName + "','" + lName + "'," + pPhone + ");";
            try
            {
                command = sqlite_conn.CreateCommand();
                command.CommandText = commandString;
                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                result = false;
            }
            sqlite_conn.Close();
            return result;
        }

        public static List<Contact> FetchContacts(string whereParam)
        {
            connection();
            List<Contact> contactList = new List<Contact>();

            command = sqlite_conn.CreateCommand();
            if(string.IsNullOrEmpty(whereParam))
            {
                command.CommandText = "Select *,rowid from Contacts";
            }
            else
            {
                command.CommandText = "Select * from Contacts where (FirstName Like " +
                    "'" + whereParam + "%'" + " OR LastName Like " +
                    "'" + whereParam + "%'" + " OR Phone Like " +
                    "'" + whereParam + "%');";
            }
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                contactList.Add(new Contact() { firstName = reader.GetString(0), lastName = reader.GetString(1), number = reader.GetString(2) });
            }
            sqlite_conn.Close();
            return contactList;
        }

        public static bool Update(string id, string firstName, string lastName, string phone)
        {
            bool result = true;
            connection();
            command = sqlite_conn.CreateCommand();
            try
            {
                command.CommandText = "update Contacts set FirstName='" + firstName + "', LastName='" + lastName + "', Phone='" + phone + "' where rowid=" + id + ";";
                command.ExecuteNonQuery();
            }
            catch
            {
                result = false;
            }
            sqlite_conn.Close();
            return result;          

        }

        public static bool Delete(string id)
        {
            bool result = true;
            connection();
            command = sqlite_conn.CreateCommand();
            try
            {
                command.CommandText = "DELETE FROM Contacts WHERE rowid="+id+";";
                command.ExecuteNonQuery();
            }
            catch
            {
                result = false;
            }
            sqlite_conn.Close();
            return result;

        }
        public static string fetchRowId(string firstName, string lastName, string phone)
        {
            string id="";
            connection();
            command = sqlite_conn.CreateCommand();
            command.CommandText="select rowid from Contacts where FirstName='"+firstName+"' AND LastName='"+lastName+"' AND Phone='"+phone+"';";
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                id = reader.GetInt64(0).ToString();
            }
            sqlite_conn.Close();
            return id;
        }
    }


}
