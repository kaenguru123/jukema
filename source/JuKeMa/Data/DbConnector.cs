using JuKeMa.Model;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace JuKeMa.Data
{
    class DbConnector
    {
        private MySqlConnection Connection { get; set; }
        private MySqlCommand Command { get; set; }
        public DbConnector()
        {
            try
            {
                string ConnectionString = "server=localhost;database=jukema;userid=root;";
                Connection = new MySqlConnection();
                Connection.ConnectionString = ConnectionString;
            
                Command = new MySqlCommand();
                Command.Connection = Connection;

                Connection.Open();
            }
            catch (MySqlException err)
            {
                MessageBox.Show(err.Message, "ERROR! Connection to database failed!",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
                Environment.Exit(-1);
            }
        }

        ~DbConnector()
        {
            Connection.Close();
        }

        private bool tryIndex(MySqlDataReader data, string key)
        {
            try
            {
                var tryIndex = data[key];
                return true;
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
        }

        private Employee getValidEmployee(MySqlDataReader data)
        {   
            var validEmployee = new Employee();

            validEmployee.NTUser = tryIndex(data, "NTUser") ? data["NTUser"].ToString() : default(string);
            validEmployee.Name = tryIndex(data, "Name") ? data["Name"].ToString() : default(string);
            validEmployee.Address = tryIndex(data, "Address") ? data["Address"].ToString() : default(string);
            validEmployee.HireDate = tryIndex(data, "HireDate") ? DateTime.TryParse(data["HireDate"].ToString(), out DateTime hiredat) ? hiredat : default(DateTime) : default(DateTime);
            validEmployee.Birthday = tryIndex(data, "Birthday") ? DateTime.TryParse(data["Birthday"].ToString(), out DateTime birthday) ? birthday : default(DateTime) : default(DateTime);
            validEmployee.Department = tryIndex(data, "DepartmentName") ? data["DepartmentName"].ToString() : default(string);

            return validEmployee;
        }

        private List<Employee> initializeList(MySqlDataReader data)
        {
            var list = new List<Employee>();
            while (data.Read())
            {
                list.Add(getValidEmployee(data));
            }
            return list;
        }


        private T executeQuery<T>(string query)
        {
            Command.CommandText = query;
            var data = Command.ExecuteReader();
            var employees = new List<Employee>();
            employees = initializeList(data);
            data.Close();
            if (typeof(T) == typeof(string))
            {
                return (T)(object)JsonConvert.SerializeObject(employees, Formatting.Indented, new JsonSerializerSettings
                {
                    DefaultValueHandling = DefaultValueHandling.Ignore,
                    StringEscapeHandling = StringEscapeHandling.EscapeNonAscii

                });
            } else if (typeof(T) == typeof(List<Employee>))
            {
                return (T)(object)employees;
            }
            return (T)(object)null;
        }

        public string getEmployeeByList(List<string> filter)
        {
            string query = "SELECT " +
                                    "employee.NTUser, employee.Name, employee.Address, employee.HireDate, employee.Birthday, department.Name as DepartmentName " +
                                    "FROM " +
                                    "`employee` " +
                                    "JOIN " +
                                    "department " +
                                    "ON " +
                                    "employee.Department = department.ID " +
                                    "WHERE ";

            for (int i = 0; i < filter.Count-1; i++)
            {
                    query += $"employee.NTUser = '{filter[i]}' OR ";
            }
            query += $"employee.NTUser = '{filter[filter.Count-1]}';";

            return executeQuery<string>(query);
        }

        public List<Employee> getDataForCheckList()
        {
            string query = "SELECT " +
                            "employee.NTUser, employee.Name, department.Name as DepartmentName " +
                            "FROM " +
                            "employee " +
                            "JOIN " +
                            "department " +
                            "ON " +
                            "employee.Department = department.ID;";
            return executeQuery<List<Employee>>(query);
        }
    }
}
