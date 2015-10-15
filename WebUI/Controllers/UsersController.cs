using System.Web.Mvc;

namespace P_Mocks_Template.WebUI.Controllers
{
    using Domain.Abstract;
    using Domain.Entities;
    using Infrastructure;
    using ModelViews;

    //[Authorize]
    public class UsersController : Controller
    {
        private IUsersRepository usersRepository;

        public UsersController(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public ActionResult UsersMaint()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult UsersMaintPartial()
        {
            var model = usersRepository.UsersList.ConvertToUserMaintViewModel();
            return PartialView("UsersMaintPartial", model);
        }

        [HttpGet]
        public ActionResult EditUsersForm(int userID)
        {
            var vmodel = new EditUserViewModel();
            User editUser = usersRepository.FindUserByID(userID);
            if (editUser != null)
            {
                vmodel = editUser.ConvertToEditUserViewModel();
            }

            ViewBag.Title = vmodel.UserID == 0 ? "New User" : "User Edit";
            return PartialView("EditUsersForm", vmodel);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult EditUsersForm(EditUserViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("EditUsersForm", user);
            }
            else
            {
                usersRepository.SaveUser(user.ConverEditUserViewModelToUser());
                return RedirectToAction("UsersMaint");
            }
        }

        public ActionResult DeleteUserForm(int userID)
        {
            usersRepository.DeleteUser(userID);
            return RedirectToAction("UsersMaint");
        }

        [HttpPost]
        public JsonResult isUsernameAvailable(string username)
        {
            var user = usersRepository.FindUserByName(username);
            if (user != null)
            {
                return new JsonResult { Data = false };
            }
            else
            {
                return new JsonResult { Data = true };
            }
        }
    }
}