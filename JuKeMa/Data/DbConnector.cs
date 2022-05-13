using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuKeMa.Data
{
    class DbConnector
    {
        private MySqlConnection Connection { get; set; }
        private MySqlCommand command { get; set; }
        public DbConnector()
        {
            string ConnectionString = "server=localhost;database=jukema;userid=root;";
            Connection = new MySqlConnection();
            Connection.ConnectionString = ConnectionString;

            command = new MySqlCommand();
            command.Connection = Connection;

            Connection.Open();
        }

        ~DbConnector()
        {
            Connection.Close();
        }
        private string executeQueryToGetJson(string query)
        {
            command.CommandText = query;
            var data = command.ExecuteReader();
            var dataTable = new DataTable();
            dataTable.Load(data);
            return JsonConvert.SerializeObject(dataTable);
        }

        private string[] executeQueryToGetList(string query)
        {
            command.CommandText = query;
            var data = command.ExecuteReader();
            var dataTable = new DataTable();
            dataTable.Load(data);
            var str = JsonConvert.SerializeObject(dataTable);
            return JsonConvert.DeserializeObject<string[]>(str);
        }

        public string getAllEmployee()
        {
            string query = "SELECT " +
                                "mitarbeiter.NTUser, mitarbeiter.Name, mitarbeiter.Anschrift, mitarbeiter.Einstellungsdatum, mitarbeiter.Geburtstag, abteilung.Name " +
                                "FROM " +
                                "`mitarbeiter` " +
                                "JOIN " +
                                "abteilung " +
                                "WHERE " +
                                "mitarbeiter.Abteilung = abteilung.ID;";
            return executeQueryToGetJson(query);
        }

        public string getEmployeeById(int Id)
        {
            string query = "SELECT " +
                                "mitarbeiter.NTUser, mitarbeiter.Name, mitarbeiter.Anschrift, mitarbeiter.Einstellungsdatum, mitarbeiter.Geburtstag, abteilung.Name " +
                                "FROM " +
                                "`mitarbeiter` " +
                                "JOIN " +
                                "abteilung " +
                                "WHERE " +
                                $"mitarbeiter.Abteilung = abteilung.ID WHERE mitarbeiter.NTUser = {Id};";

            return executeQueryToGetJson(query);
        }

        public string getEmployeeByArray(string[] filter)
        {
            string query = "SELECT " +
                                    "mitarbeiter.NTUser, mitarbeiter.Name, mitarbeiter.Anschrift, mitarbeiter.Einstellungsdatum, mitarbeiter.Geburtstag, abteilung.Name " +
                                    "FROM " +
                                    "`mitarbeiter` " +
                                    "JOIN " +
                                    "abteilung " +
                                    "WHERE " +
                                    "mitarbeiter.Abteilung = abteilung.ID " +
                                    "WHERE ";

            for (int i = 0; i < filter.Length-1; i++)
            {
                    query += $"mitarbeiter.NTUser = {filter[i]} OR ";
            }
            query += $"mitarbeiter.NTUser = {filter[filter.Length-1]};";

            return executeQueryToGetJson(query);
        }

        public string[] getDataForCheckList()
        {
            string query = "SELECT " +
                            "mitarbeiter.NTUser, mitarbeiter.Name " +
                            "FROM " +
                            "mitarbeiter;";
            return executeQueryToGetList(query);
        }
    }
}
