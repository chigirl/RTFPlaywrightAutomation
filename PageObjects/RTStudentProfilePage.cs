using Microsoft.Playwright;

namespace RethinkFirst.PageObjects
{
    public class RTStudentProfilePage
    {
        public IPage StudentPage { get; set; }

        public string FirstNameInput = "#firstName";
        public string LastNameInput = "#lastName";
        public string StudentIDInput = "#stateTestNumber";
        public string SchoolBuildingDD = "#schoolDD";
        public string GenderDD = "#genderDD";
        public string EthnicityDD = "#ethnicityDD";
        public string BirthdaySpinner = "spinbutton"; //AriaRole
        public string GradeDD = "#gradeDD";
        public string EducationDD = "#educationTypeId";
        public string EmailInput = "#email";
        public string FreeLunch = "#freeLunch";
        public string UsernameInput = "#userName";
        public string PasswordInput = "#password";
        public string ConfirmPasswordInput = "#password2";

        private string SaveCloseButton = "Save and Close"; //AriaRole

        public RTStudentProfilePage(IPage Page)
        {
            StudentPage = Page;
        }
        public ILocator GetElement(string identifier)
        {
            return StudentPage.Locator(identifier);
        }
        public async Task FillStudentID(string studentID)
        {
            await StudentPage.Locator(StudentIDInput).FillAsync(studentID);
        }
        public async Task FillFirstName(string studentFirstName)
        {
            await StudentPage.Locator(FirstNameInput).FillAsync(studentFirstName);
        }
        public async Task FillLastName(string studentLastName)
        {
            await StudentPage.Locator(LastNameInput).FillAsync(studentLastName);
        }
        public async Task FillEmail(string studentEmail)
        {
            await StudentPage.Locator(EmailInput).FillAsync(studentEmail);
        }
        public async Task FillUserName(string username)
        {
            await StudentPage.Locator(UsernameInput).FillAsync(username);
        }
        public async Task FillPassword(string password)
        {
            await StudentPage.Locator(PasswordInput).FillAsync(password);
        }
        public async Task FillConfirmPassword(string password)
        {
            await StudentPage.Locator(ConfirmPasswordInput).FillAsync(password);
        }

        public async Task Check504()
        {
            await StudentPage.GetByText("504").ClickAsync();
        }
        public async Task CheckIEP()
        {
            await StudentPage.GetByLabel("IEP", new() { Exact = true }).ClickAsync();
        }
        public async Task CheckGIEP()
        {
            await StudentPage.GetByLabel("GIEP", new() { Exact = true }).ClickAsync();
        }
        public async Task CheckELL()
        {
            await StudentPage.GetByText("ELL").ClickAsync();
        }

        public async Task CheckFreeLunch()
        {
            await StudentPage.GetByText("Free/Reduced Lunch (FRL)").ClickAsync();
        }

        public async Task CheckHomeless()
        {
            await StudentPage.GetByText("Homeless").ClickAsync();
        }

        public async Task SelectAssignBuilding(string building)
        {
            await StudentPage.Locator(SchoolBuildingDD).SelectOptionAsync(new[] { building });
        }

        public async Task SelectGender(string gender)
        {
            await StudentPage.Locator(GenderDD).SelectOptionAsync(new[] { gender });
        }

        public async Task SelectEthnicity(string ethnicity)
        {
            await StudentPage.Locator(EthnicityDD).SelectOptionAsync(new[] { ethnicity });
        }

        public async Task SelectGrade(string grade)
        {
            await StudentPage.Locator(GradeDD).SelectOptionAsync(new[] { grade });
        }

        public async Task SelectEducation(string education)
        {
            await StudentPage.Locator(EducationDD).SelectOptionAsync(new[] { education });
        }

        public async Task ClickSaveCloseButton()
        {
            await StudentPage.GetByRole(AriaRole.Button, new() { Name = SaveCloseButton }).ClickAsync();
        }
    }
}
