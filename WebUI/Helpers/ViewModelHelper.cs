using System.Collections.Generic;

namespace P_Mocks_Template.WebUI.Infrastructure
{
    using Domain.Entities;
    using ModelViews;

    public static class ViewModelHelper
    {
        public static IEnumerable<UserMaintViewModel> ConvertToUserMaintViewModel(this IEnumerable<User> users)
        {
            foreach (var user in users)
            {
                yield return new UserMaintViewModel { UserID = user.UserID, Username = user.Username, Name = user.Name, Email = user.Email };
            }
        }

        public static EditUserViewModel ConvertToEditUserViewModel(this User users)
        {
            EditUserViewModel vmodel = new EditUserViewModel { UserID = users.UserID, Username = users.Username, Password = users.Password, ConfirmPassword = users.Password, Name = users.Name, Email = users.Email, Phone = users.Phone };
            return vmodel;
        }

        public static User ConverEditUserViewModelToUser(this EditUserViewModel vmodel)
        {
            User user = new User { UserID = vmodel.UserID, Username = vmodel.Username, Password = vmodel.Password, Name = vmodel.Name, Email = vmodel.Email };
            return user;
        }


    }
}