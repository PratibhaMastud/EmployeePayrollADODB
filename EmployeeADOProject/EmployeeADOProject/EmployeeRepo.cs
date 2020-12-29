using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EmployeeADOProject
{
    class EmployeeRepo
    {
        public static string connectionstring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True";
        SqlConnection Connection = new SqlConnection(connectionstring);
        public void CheckDBConnection()
        {
            try
            {
                this.Connection.Open();
                Console.WriteLine("Connection Success");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
