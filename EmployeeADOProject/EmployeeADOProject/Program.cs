using System;

namespace EmployeeADOProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome in Employee Payroll DAO");
            EmployeeModel employeeModel = new EmployeeModel();
            EmployeeRepo employeeRepo = new EmployeeRepo();
            //employeeRepo.CheckDBConnection();
            employeeRepo.getAllEmployee();
        }
    }
}
