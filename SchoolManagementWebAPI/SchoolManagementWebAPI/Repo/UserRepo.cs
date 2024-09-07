using SchoolManagementWebAPI.Models;

namespace SchoolManagementWebAPI.Repo
{
    public interface UserRepo
    {

        public List<User> GetAllUser();

        public User AuthUser(User u);
        
    }
}
