using System;

namespace Practical_1.Models
{
    public class EmployeeAttendance
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime Date { get; set; }
        public bool IsPresent { get; set; }

        public EmployeeAttendance(int employeeId, string employeeName, DateTime date, bool isPresent)
        {
            EmployeeId = employeeId;
            EmployeeName = employeeName;
            Date = date;
            IsPresent = isPresent;
        }
    }
}
