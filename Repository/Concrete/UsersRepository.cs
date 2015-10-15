using System.Collections.Generic;

namespace P_Mocks_Template.Repository.Concrete
{
    using Domain.Abstract;
    using Domain.Entities;
    using DBContext;

    public class UsersRepository : IUsersRepository
    {
        //Get data from DB/Document/Whatever. For this we are using a DummyDB
        private DummyUserDBContext userData = new DummyUserDBContext();

        public IEnumerable<User> UsersList
        {
            get { return userData.GetUsersList(); }
        }

        public User FindUserByName(string userToFind)
        {
            return userData.FindUser(userToFind);
        }

        public User FindUserByID(int userID)
        {
            return userData.FindUser(userID);
        }

        public void SaveUser(User user)
        {
            userData.SaveChanges(user);
        }

        public void DeleteUser(int userID)
        {
            userData.DeleteUser(userID);
        }

        public User ValidateUser(string username, string password)
        {
            return userData.ValidateUser(username, password);
        }
    }
}
