using System.Web.Mvc;

namespace P_Mocks_Template.WebUI.ModelViews
{
    public class UserMaintViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}