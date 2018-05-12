using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;


namespace AutoLookBackend.Models
{
    public class Conexion
    {

        MySqlConnection connection = new MySqlConnection();
        string ConecctionString;


        public MySqlDataReader getExecuteQuery(string stringQuery)
        {
            try
            {
                openConection();

                MySqlCommand query = connection.CreateCommand();
                query.CommandText = stringQuery;

                MySqlDataReader reader = query.ExecuteReader();

                return reader;
            }
            catch (MySqlException ex)
            {
                closeConection();
                throw ex;
            }

        }

        public string deleteExecuteQuery(string stringQuery)
        {
            try
            {
                openConection();
                string ans = string.Empty;

                MySqlCommand query = connection.CreateCommand();
                query.CommandText = stringQuery;

                //MySqlDataReader reader = query.ExecuteReader();

                if (query.ExecuteNonQuery() > 0)
                {
                    ans = "1";
                }
                else
                {
                    ans = "0";
                }

                closeConection();

                return ans;
            }
            catch (MySqlException ex)
            {
                closeConection();
                return ex.Message;
            }
        }

        public string setExecuteQuery(string stringQuery, List<ParameterSchema> lstParameters)
        {
            try
            {
                openConection();
                string ans = string.Empty;

                MySqlCommand command = connection.CreateCommand();

                for (int i = 0; i < lstParameters.Count; i++)
                {
                    command.Parameters.AddWithValue("@" + lstParameters[i].ParamName, lstParameters[i].ParamValue);
                }

                command.CommandText = stringQuery;
                if (command.ExecuteNonQuery() > 0)
                {
                    ans = command.LastInsertedId.ToString() == "0" ? "" : command.LastInsertedId.ToString();
                }
                else
                {
                    ans = "0";
                }

                closeConection();

                return ans;

            }
            catch (MySqlException ex)
            {
                closeConection();
                return ex.Message;
            }

        }

        private void openConection()
        {
            connection.Close();
            ConecctionString = "Server=127.0.0.1; Port=3306; Database=mydb; Uid=root; Pwd=Tefa1992;";
            connection.ConnectionString = ConecctionString;
            connection.Open();
        }

        private void closeConection()
        {
            connection.Close();
        }

    }

    public class ParameterSchema
    {
        public string ParamName { get; set; }
        public object ParamValue { get; set; }

        public ParameterSchema() { }

        public ParameterSchema(string ParamName, object ParamValue)
        {
            this.ParamName = ParamName;
            this.ParamValue = ParamValue;
        }

    }
}