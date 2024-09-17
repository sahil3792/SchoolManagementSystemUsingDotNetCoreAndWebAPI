﻿using SchoolManagementWebAPI.Models;

namespace SchoolManagementWebAPI.Repo
{
    public interface UserRepo
    {

        public List<User> GetAllUser();

        public User AuthUser(User u);

        public Administrator AddAdministrator(Administrator administrator);

        public void AddUser(string userid,string password,string urole);

        public void AddSubjects(Subject sub);

        public List<Subject> GetSubjects();

        public void AddTeacher(Teacher teacher);

        public List<Teacher> GetAllTeachers();

        public void AddGuardian(Guardian g);

        public List<Guardian> GetAllGuardian();

        public List<Class> GetAllClass();

        public void AddClass(Class c);

        public void AddStudent(Student student);
        public void AddTimetable(Timetable tt);

        public void AddLibrarian(Librarian lb);

        public List<TeacherLeave> FetchAllTeacherLeaveRequest();

        public void ApproveTeacherLeave(int id);
        public void RejectTeacherLeave(int id);

        //public List<Teacher> GetAllTeachers();
        public void AddTeacherAttendance(string[] attendancelist);

    }
}
