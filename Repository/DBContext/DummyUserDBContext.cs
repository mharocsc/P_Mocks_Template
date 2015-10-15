using System.Collections.Generic;

namespace P_Mocks_Template.Repository.DBContext
{
    using Domain.Entities;

    public class DummyUserDBContext
    {
        private List<User> UsersList;

        public DummyUserDBContext()
        {
            UsersList = new List<User>();
            UsersList.Add(new User() { UserID = 1, Username = "sysadmin", Name = "System Administrator", Password = "sysadmin", Email = "sysadmin@codservices.com.mx" });
            UsersList.Add(new User() { UserID = 2, Username = "mharo", Name = "Mirella Haro", Password = "ensenada", Email = "mharo@codeservices.com.mx" });
            UsersList.Add(new User() { UserID = 3, Username = "dmendez", Name = "Doreen Mendez", Password = "dmendez123", Email = "dmendez@codeservices.com.mx" });
        }

        public IEnumerable<User> GetUsersList()
        {
            return UsersList;
        }

        public void SaveChanges(User user)
        {
            if (user.UserID == 0)
            {
                user.UserID = GetNewUserID();
                UsersList.Add(user);
            }
            else
            {
                User dbEntry = FindUser(user.UserID);
                if (dbEntry != null)
                {
                    dbEntry.Username = user.Username;
                    dbEntry.Password = user.Password;
                    dbEntry.Name = user.Name;
                    dbEntry.Email = user.Email;
                }
            }
        }

        public void DeleteUser(int userID)
        {
            User dbEntry = FindUser(userID);
            if (dbEntry != null)
                UsersList.Remove(dbEntry);
        }

        public User FindUser(string userToFind)
        {
            return UsersList.Find(x => x.Username == userToFind);
        }
        public User FindUser(int userID)
        {
            return UsersList.Find(x => x.UserID == userID);
        }

        public User ValidateUser(string username, string password)
        {
            return UsersList.Find(x => x.Username.Equals(username) && x.Password.Equals(password));
        }

        private int GetNewUserID()
        {
            return UsersList.Count + 1;
        }
    }
}
