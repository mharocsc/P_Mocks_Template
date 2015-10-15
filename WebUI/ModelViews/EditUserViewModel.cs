using System.Web.Mvc;

namespace P_Mocks_Template.WebUI.ModelViews
{
    public class EditUserViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}