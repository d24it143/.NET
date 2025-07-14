using System;
using Practical_1.Models;
using Practical_1.Services;

namespace Practical_1
{
    class Program
    {
        static void Main(string[] args)
        {
            AttendanceManager manager = new AttendanceManager();
            int choice;

            do
            {
                Console.WriteLine("===== Employee Attendance Tracker =====");
                Console.WriteLine("1. Add Attendance Record");
                Console.WriteLine("2. View All Attendance Records");
                Console.WriteLine("3. Get Total Present Days by Employee ID");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("❌ Invalid input. Please enter a number between 1 and 4.\n");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddAttendance(manager);
                        break;
                    case 2:
                        manager.DisplayAllRecords();
                        break;
                    case 3:
                        GetPresentDays(manager);
                        break;
                    case 4:
                        Console.WriteLine("👋 Exiting... Goodbye!");
                        break;
                    default:
                        Console.WriteLine("❌ Invalid choice. Please try again.\n");
                        break;
                }
            } while (choice != 4);
        }

        static void AddAttendance(AttendanceManager manager)
        {
            try
            {
                Console.Write("Enter Employee ID: ");
                if (!int.TryParse(Console.ReadLine(), out int empId))
                {
                    Console.WriteLine("❌ Invalid ID. Must be a number.\n");
                    return;
                }

                Console.Write("Enter Employee Name: ");
                string name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("❌ Name cannot be empty.\n");
                    return;
                }

                Console.Write("Enter Date (yyyy-mm-dd): ");
                if (!DateTime.TryParse(Console.ReadLine(), out DateTime date))
                {
                    Console.WriteLine("❌ Invalid date format.\n");
                    return;
                }

                Console.Write("Was the employee present? (Y/N): ");
                string presentInput = Console.ReadLine().Trim().ToUpper();
                bool isPresent = presentInput == "Y";

                var record = new EmployeeAttendance(empId, name, date, isPresent);
                manager.AddRecord(record);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ Error: {ex.Message}\n");
            }
        }

        static void GetPresentDays(AttendanceManager manager)
        {
            Console.Write("Enter Employee ID to view attendance: ");
            if (!int.TryParse(Console.ReadLine(), out int empId))
            {
                Console.WriteLine("❌ Invalid ID. Must be a number.\n");
                return;
            }

            manager.GetTotalPresentDaysById(empId);
        }
    }
}
