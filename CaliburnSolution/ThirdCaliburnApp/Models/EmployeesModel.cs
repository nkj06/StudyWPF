using System;

namespace ThirdCaliburnApp.Models
{
    public class EmployeesModel
    {
        public int Id { get; set; }
        public string EmpName { get; set; }
        public Decimal Salary { get; set; }
        public string DeptName { get; set; }
        public string Destination { get; set; }
    }
}