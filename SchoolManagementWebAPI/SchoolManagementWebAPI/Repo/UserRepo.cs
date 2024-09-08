using SchoolManagementWebAPI.Models;

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

    }
}
