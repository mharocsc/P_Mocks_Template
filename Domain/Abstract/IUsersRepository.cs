using System.Collections.Generic;

namespace P_Mocks_Template.Domain.Abstract
{
    using Entities;

    public interface IUsersRepository
    {
        IEnumerable<User> UsersList { get; }
        User FindUserByName(string userToFind);
        User FindUserByID(int userID);
        void SaveUser(User user);
        void DeleteUser(int UserID);
        User ValidateUser(string username, string password);
    }
}
