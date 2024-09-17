using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagementWebAPI.Data;
using SchoolManagementWebAPI.Models;

namespace SchoolManagementWebAPI.Repo
{
    public class StudentService : StudentRepo
    {
        private readonly ApplicationDbContext db;
        public StudentService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public List<Timetable> FetchTimetableByStudentid(string studentid)
        {
            var data = db.Timetables.FromSqlRaw($"exec FetchTimetableByStudentid '{studentid}' ").ToList();
            return data;
        }

        public StudentAttendancePercentage GetStudentData(String username)
        {
            //[HttpGet("student-data/{id}")]
            //public IActionResult GetStudentData(int id)
            //{
                //var username = db.Students.Find(id).StudentId;

                //if (string.IsNullOrEmpty(username))
                //{
                //    return Unauthorized("User is not logged in.");
                //}

                var currentMonth = DateTime.Now.Month;
                var currentYear = DateTime.Now.Year;
                var totalDaysInMonth = DateTime.DaysInMonth(currentYear, currentMonth);

                // Fetch student data based on username
                var student = db.Students.FirstOrDefault(s => s.StudentId == username);
                //if (student == null)
                //{
                //    return NotFound("Student not found.");
                //}

                // Fetch attendance records for the student
                var attendanceRecords = db.StudentAttendances
                    .Where(a => a.StudentId == username && a.AttendanceDate.Month == currentMonth && a.AttendanceDate.Year == currentYear)
                    .ToList();

                // Calculate attendance percentage
                var presentDays = attendanceRecords.Count(a => a.Attendance);
                var attendancePercentage = (double)presentDays / totalDaysInMonth * 100;
            attendancePercentage=Math.Round(attendancePercentage,2);
            StudentAttendancePercentage response = new StudentAttendancePercentage
                {
                    student = student,
                    PresentDays = presentDays,
                    TotalDaysInMonth = totalDaysInMonth,
                    AttendancePercentage = attendancePercentage
                };

                return response;
            }
        }
    }
