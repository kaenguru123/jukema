using JuKeMa.Model;
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

        private string executeQueryToGetJson(string query)
        {
            command.CommandText = query;
            var data = command.ExecuteReader();
            var employees = new List<Employee>();
            employees = initializeList(data);
            return JsonConvert.SerializeObject(employees, Formatting.Indented, new JsonSerializerSettings
            {
                DefaultValueHandling = DefaultValueHandling.Ignore
            });
        }

        public string getAllEmployee()
        {
            string query = "SELECT " +
                                "employee.NTUser, employee.Name, employee.Address, employee.HireDate, employee.Birthday, deparment.Name as DepartmentName " +
                                "FROM " +
                                "`employee` " +
                                "JOIN " +
                                "department " +
                                "WHERE " +
                                "employee.Department = department.ID;";
            return executeQueryToGetJson(query);
        }

        public string getEmployeeById(int Id)
        {
            string query = "SELECT " +
                                "employee.NTUser, employee.Name, employee.Address, employee.HireDate, employee.Birthday, department.Name as DepartmentName " +
                                "FROM " +
                                "`employee` " +
                                "JOIN " +
                                "department " +
                                "WHERE " +
                                $"employee.Department = department.ID WHERE employee.NTUser = {Id};";

            return executeQueryToGetJson(query);
        }

        public string getEmployeeByArray(string[] filter)
        {
            string query = "SELECT " +
                                    "employee.NTUser, employee.Name, employee.Address, employee.HireDate, employee.Birthday, department.Name as DepartmentName " +
                                    "FROM " +
                                    "`employee` " +
                                    "JOIN " +
                                    "department " +
                                    "WHERE " +
                                    "employee.Department = department.ID " +
                                    "WHERE ";

            for (int i = 0; i < filter.Length-1; i++)
            {
                    query += $"employee.NTUser = {filter[i]} OR ";
            }
            query += $"employee.NTUser = {filter[filter.Length-1]};";

            return executeQueryToGetJson(query);
        }

        public string getDataForCheckList()
        {
            string query = "SELECT " +
                            "employee.NTUser, employee.Name, department.Name as DepartmentName " +
                            "FROM " +
                            "employee " +
                            "JOIN " +
                            "department " +
                            "WHERE " +
                            "employee.Department = department.ID;";
            return executeQueryToGetJson(query);
        }
    }
}
