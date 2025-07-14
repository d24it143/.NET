using System;
using System.Collections.Generic;
using System.Linq;
using Practical_1.Models;  // Import the model namespace

namespace Practical_1.Services
{
    public class AttendanceManager
    {
        private List<EmployeeAttendance> attendanceRecords = new List<EmployeeAttendance>();

        public void AddRecord(EmployeeAttendance record)
        {
            attendanceRecords.Add(record);
            Console.WriteLine("✅ Attendance record added successfully.\n");
        }

        public void DisplayAllRecords()
        {
            Console.WriteLine("\n===== All Attendance Records =====");
            if (attendanceRecords.Count == 0)
            {
                Console.WriteLine("No records found.\n");
                return;
            }

            foreach (var record in attendanceRecords)
            {
                Console.WriteLine($"ID: {record.EmployeeId}, Name: {record.EmployeeName}, Date: {record.Date.ToShortDateString()}, Present: {record.IsPresent}");
            }
            Console.WriteLine();
        }

        public void GetTotalPresentDaysById(int employeeId)
        {
            var presentDays = attendanceRecords
                .Where(r => r.EmployeeId == employeeId && r.IsPresent)
                .Count();

            var employee = attendanceRecords.FirstOrDefault(r => r.EmployeeId == employeeId);
            if (employee == null)
            {
                Console.WriteLine("⚠️ No attendance records found for the given Employee ID.\n");
                return;
            }

            Console.WriteLine($"\nEmployee: {employee.EmployeeName} (ID: {employee.EmployeeId})");
            Console.WriteLine($"✅ Total Present Days: {presentDays}\n");
        }
    }
}
