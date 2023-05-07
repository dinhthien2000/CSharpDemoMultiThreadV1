using DemoMultiThread.Connection;
using DemoMultiThread.Model;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMultiThread.Dao
{
    internal class EmployeeDao
    {
        public static string SELECT = "Select * from Employee";
        public static string CREATE = "insert into Employee(id,name,age) values (@id,@name,@age)";
        public static string UPDATE = "update Employee set name = @name, age = @age where id =@id";
        public static string DELETE = "delete from Employee where id =@id";

        public static string DELETE_FRom = "delete from Employee";



        public List<Employee> retrieveAllEmployes()
        {
            MySqlConnection conn = Connect.getConnection();
            List<Employee> list = new List<Employee>();
            Employee employee = null;
            try
            {
                Console.WriteLine("Openning Connection Retrieve All ...");
                conn.Open();

                MySqlCommand command = new MySqlCommand(SELECT, conn);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    employee = new Employee(
                        reader.GetInt32("id"),
                        reader.GetString("name"),
                        reader.GetString("age")
                        );

                    list.Add(employee);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                conn.Close();
            }

            return list;
        }


        public Employee createEmployes(Employee employee)
        {
            MySqlConnection conn = Connect.getConnection();
            Employee recive = null;
            try
            {
                Console.WriteLine("Openning Connection Create ...");
                conn.Open();

                MySqlCommand command = new MySqlCommand(CREATE, conn);
                command.Parameters.AddWithValue("id", employee.Id);
                command.Parameters.AddWithValue("name", employee.Name);
                command.Parameters.AddWithValue("age", employee.Age);
                MySqlDataReader reader = command.ExecuteReader();

               if(reader != null)
               {
                  recive = employee;
               }
                
                
    

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                conn.Close();
            }

            return recive;
        }


        public Employee updateEmployes(Employee employee)
        {
            MySqlConnection conn = Connect.getConnection();
            Employee recive = null;
            try
            {
                Console.WriteLine("Openning Connection Update ...");
                conn.Open();

                MySqlCommand command = new MySqlCommand(UPDATE, conn);
                command.Parameters.AddWithValue("id", employee.Id);
                command.Parameters.AddWithValue("name", employee.Name);
                command.Parameters.AddWithValue("age", employee.Age);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader != null)
                {
                    recive = employee;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                conn.Close();
            }

            return recive;
        }

        public Object removeEmployes(int id)
        {
            MySqlConnection conn = Connect.getConnection();
            int isRemove =  -1;
            try
            {
                Console.WriteLine("Openning Connection Remove ...");
                conn.Open();

                MySqlCommand command = new MySqlCommand(DELETE, conn);
                command.Parameters.AddWithValue("id", id);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader != null)
                {
                    isRemove = id;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                conn.Close();
            }

            return isRemove;
        }


        public void removeAllEmployes()
        {
            MySqlConnection conn = Connect.getConnection();
            int isRemove =  -1;
            try
            {
                Console.WriteLine("Openning Connection Remove ...");
                conn.Open();

                MySqlCommand command = new MySqlCommand(DELETE, conn);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader != null)
                {
                    Console.WriteLine("Delete from");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                conn.Close();
            }

           
        }

    }
}
