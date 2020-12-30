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
            //employeeRepo.getAllEmployee();
            employeeModel.id = 160;
            employeeModel.name = "Monika";
            employeeModel.basic_pay = 40500;
            employeeModel.start_date = new DateTime(2010, 05, 03);
            employeeModel.gender = 'F';
            employeeModel.phone_number = "9734567889";
            employeeModel.department = "HR";
            employeeModel.address = "Mumbai";
            employeeModel.Deduction = 4500.00;
            employeeModel.Taxable_pay = 45678;
            employeeModel.Income_tax = 6577;
            employeeModel.Net_pay = 420000;
            // employeeRepo.AddRecord(employeeModel);
            //Console.WriteLine(".....Inserted Record......");
            //Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", employeeModel.id, employeeModel.name, employeeModel.basic_pay, employeeModel.start_date, employeeModel.gender, employeeModel.phone_number, employeeModel.department, employeeModel.address, employeeModel.Deduction, employeeModel.Taxable_pay, employeeModel.Net_pay, employeeModel.Income_tax);
            //employeeRepo.GetPerticularEmployeeData();
            employeeRepo.ArithmeticOperations();
        }
    }
}
