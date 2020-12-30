using System;
using System.Collections.Generic;
using System.Data;
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
                this.connection.Close();
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
                    this.connection.Close();
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
            }
        }
    
        public bool AddRecord(EmployeeModel Model)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand CMD = new SqlCommand("SpInsertEmployeePayroll", this.connection);
                    CMD.CommandType = CommandType.StoredProcedure;
                    CMD.Parameters.AddWithValue("@Id", Model.id);
                    CMD.Parameters.AddWithValue("@name", Model.name);
                    CMD.Parameters.AddWithValue("@basic_pay", Model.basic_pay);
                    CMD.Parameters.AddWithValue("@start_Date", Model.start_date);
                    CMD.Parameters.AddWithValue("@gender", Model.gender);
                    CMD.Parameters.AddWithValue("@phoneNumber", Model.phone_number);
                    CMD.Parameters.AddWithValue("@department", Model.department);
                    CMD.Parameters.AddWithValue("@address", Model.address);
                    CMD.Parameters.AddWithValue("@deduction", Model.Deduction);
                    CMD.Parameters.AddWithValue("@taxable", Model.Taxable_pay);
                    CMD.Parameters.AddWithValue("@income_tax", Model.Income_tax);
                    CMD.Parameters.AddWithValue("@netpay", Model.Net_pay);
                    this.connection.Open();
                    var result = CMD.ExecuteNonQuery();
                    this.connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
            }
        }

        public void GetPerticularEmployeeData()
        {
            try
            {
                EmployeeModel employeemodel = new EmployeeModel();
                using (this.connection)
                {
                    string query = @"SELECT basic_pay  from employee_payroll WHERE name = 'Pratibha'; ";
                    SqlCommand cmd3 = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader readerRow = cmd3.ExecuteReader();
                    if (readerRow.HasRows)
                    {
                        if (readerRow.HasRows)
                        {
                            while (readerRow.Read())
                            {
                                employeemodel.basic_pay = (double)readerRow.GetDecimal(0);
                            }
                            Console.WriteLine("Basic Pay for Pratibha is : {0}", employeemodel.basic_pay);
                        }
                        else
                        {
                            Console.WriteLine("No Data Found");
                        }
                    }
                    readerRow.Close();
                }
                this.connection.Close();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
            }
        }
    }
}
