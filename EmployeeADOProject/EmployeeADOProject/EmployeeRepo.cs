using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EmployeeADOProject
{
    class EmployeeRepo
    {
        public static string connectionstring = "Data Source=(localdb)\\MSSQLLocaldb;Initial Catalog=Payroll_Service;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionstring);
        public void CheckDBConnection()
        {
            try
            {
                this.connection.Open();
                Console.WriteLine("Connection Success");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public void getAllEmployee()
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.connection)
                {
                    string query = @"select * from employee_payroll;";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader sqlData = cmd.ExecuteReader();
                    if (sqlData.HasRows)
                    {
                        while (sqlData.Read())
                        {
                            employeeModel.id = sqlData.GetInt32(0);
                            employeeModel.name = sqlData.GetString(1);
                            employeeModel.basic_pay = (double)sqlData.GetDecimal(2);
                            employeeModel.start_date = sqlData.GetDateTime(3);
                            employeeModel.gender = Convert.ToChar(sqlData.GetString(4));
                            employeeModel.phone_number = sqlData.GetString(5);
                            employeeModel.department = sqlData.GetString(6);
                            employeeModel.address = sqlData.GetString(7);
                            employeeModel.Deduction = sqlData.GetDouble(8);
                            employeeModel.Taxable_pay = Convert.ToDouble(sqlData.GetFloat(9));
                            employeeModel.Income_tax = sqlData.GetDouble(10);
                            employeeModel.Net_pay = Convert.ToDouble(sqlData.GetFloat(11));
                            Console.WriteLine("{0},{1},{2},{3},{4},{5}", employeeModel.id, employeeModel.name, employeeModel.basic_pay, employeeModel.start_date, employeeModel.gender, employeeModel.phone_number);
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                    }
                    sqlData.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
    }
}
