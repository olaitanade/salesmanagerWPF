using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManager.Model
{
    class dbms
    {

        //This database path and name
        string dbnm = "";
        //The connection object
        SQLiteConnection dbConnection;

        //The Constructor
        public dbms(string db)
        {
            dbnm = db;
        }

        //A method to create the database file
        public void createdb()
        {
            SQLiteConnection.CreateFile(dbnm);

        }

        //A method to connect the and open the database I/O stream
        public void connect()
        {
            dbConnection = new SQLiteConnection("Data Source=" + dbnm);
            dbConnection.Open();
        }

        //A test method to create table in the database
        public void createTable()
        {
            string sql = "create table highscores (name varchar(20), score int)";

            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);

            command.ExecuteNonQuery();
        }

        //A test method to insert data into the table
        public void insertDt()
        {
            string sql = "insert into highscores (name, score) values ('Titilops', 3000)";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
            sql = "insert into highscores (name, score) values ('Mim', 6000)";
            command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
            sql = "insert into highscores (name, score) values ('tee', 9001)";
            command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }

        //A test method to reader data from the database 
        public SQLiteDataReader getDt()
        {
            string sql = "select * from highscores order by score desc";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            return reader;
        }
    }
}
