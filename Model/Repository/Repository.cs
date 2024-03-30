using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS_TEMA1.Model.Repository
{
    internal class Repository
    {
        private NpgsqlConnection conection;
        public Repository()
        {
            string connString = "Server=localhost;Port=5432;Database=PS_TEMA1;User Id=postgres;Password=sql;";
            conection = new NpgsqlConnection(connString);
        }

        public NpgsqlConnection Connection
        {
            get { return conection; }
            set { conection = value; }
        }

        //Open the connection to the database
        public void OpenConnection()
        {
            if (conection.State != System.Data.ConnectionState.Open)
                conection.Open();
        }

        //Close the connection to the database
        public void CloseConnection()
        {
            if (conection.State != System.Data.ConnectionState.Closed)
                conection.Close();
        }


        //Execute nonquery to modify the database (insert, update, delete)
        //and return status of the operation
        public bool ExecuteNonQuery(string query)
        {
            bool success = false;
            try
            {
                OpenConnection();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conection);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    success = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                CloseConnection();
            }
            return success;

        }

        //Execute query to get data from database
        public DataTable ExecuteQuery(string query)
        {
            DataTable dt = new DataTable();
            try
            {
                OpenConnection();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conection);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                CloseConnection();
            }
            return dt;
        }
    }
}
