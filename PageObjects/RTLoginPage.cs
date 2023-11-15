using Microsoft.Playwright;

namespace RethinkFirst.Models
{
    public class RTLoginPage
    {
        private string UserNameID = "#UserName";
        private string PasswordID = "#Password";
        private string SubmitButton = "#loginBtn";
        IPage LoginPage { get; set; }

        public RTLoginPage(IPage Page)
        {
            LoginPage = Page;
        }

        public async Task Login(User user)
        {
            await LoginPage.Locator(UserNameID).FillAsync(user.UserName);
            await LoginPage.Locator(PasswordID).FillAsync(user.Password);
            await LoginPage.Locator(SubmitButton).ClickAsync();
        }
    }
}
