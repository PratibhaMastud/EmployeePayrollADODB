using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace EmployeeADOProject
{
    class EmployeeModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public double basic_pay { get; set; }
        public DateTime start_date { get; set; }
        public char gender { get; set; }
        public string phone_number { get; set; }
        public string department { get; set; }
        public string address { get; set; }
        public double Deduction { get; set; }
        public SqlSingle Taxable_pay { get; set; }
        public double Income_tax { get; set; }
        public SqlSingle Net_pay { get; set; }
    }
}
