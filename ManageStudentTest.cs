using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using RethinkFirst.Models;
using RethinkFirst.PageObjects;

namespace PlaywrightTests;

[TestFixture]
public class ManageStudentTests : PageTest
{
    private static IConfiguration Config { get; set; }
    public static string UserName => Config["UserName"]!;
    public static string Password => Config["Password"]!;
    public static string BaseURL => Config["BaseUrl"]!;
    private Student MyNewStudent { get; set; }

    [SetUp]
    public async Task Setup()
    {
        Config = new ConfigurationBuilder()
        .AddUserSecrets<ManageStudentTests>()
        .Build();
        var randomNum = new Random();
        var randTestStudent = randomNum.Next(100, 500);

        var AuthUser = new User()
        {
            UserName = UserName,
            Password = Password
        };

        await Page.GotoAsync($"{BaseURL}/login");

        await new RTLoginPage(Page).Login(AuthUser);

        //Create Test Student
        MyNewStudent = new Student()
        {
            StudentId = "541" + randTestStudent,
            FirstName = "ATesty",
            LastName = "Jones",
            Email = $"tj{randTestStudent}@school.edu",
            AssignBuilding = "Sub Account 1",
            Gender = "Male",
            Ethnicity = "Black or African American",
            Birthday = "03/10/2019",
            Grade = "Grade 1",
            Education = "Special Education",
            Username = $"testyjones{randTestStudent}",
            Password = "FirstGrade1"
        };

    }
    [Test]
    public async Task TestAddStudent()
    {
        await Page.GetByRole(AriaRole.Link, new() { Name = "Setup" }).ClickAsync();
        await Page.GetByLabel("Manage Students").ClickAsync();
        await Expect(Page.GetByText("Manage All Students")).ToBeVisibleAsync();
        await Page.GetByText("Add Student").ClickAsync();


        var StudentProfilePage = new RTStudentProfilePage(Page);
        await StudentProfilePage.FillStudentID(MyNewStudent.StudentId);
        await StudentProfilePage.SelectAssignBuilding(MyNewStudent.AssignBuilding);
        await StudentProfilePage.FillFirstName(MyNewStudent.FirstName);
        await StudentProfilePage.FillLastName(MyNewStudent.LastName);
        await StudentProfilePage.SelectGender(MyNewStudent.Gender);
        await StudentProfilePage.SelectEthnicity(MyNewStudent.Ethnicity);
        await StudentProfilePage.SelectGrade(MyNewStudent.Grade);
        await StudentProfilePage.SelectEducation(MyNewStudent.Education);
        await StudentProfilePage.FillEmail(MyNewStudent.Email);
        await StudentProfilePage.FillUserName(MyNewStudent.Username);
        await StudentProfilePage.FillPassword(MyNewStudent.Password);
        await StudentProfilePage.FillConfirmPassword(MyNewStudent.Password);

        await StudentProfilePage.CheckFreeLunch();

        await Expect(StudentProfilePage.GetElement(StudentProfilePage.GenderDD)).ToHaveValueAsync("2: 1"); //Male

        await Expect(StudentProfilePage.GetElement(StudentProfilePage.FreeLunch)).ToBeCheckedAsync();

        await StudentProfilePage.ClickSaveCloseButton();

        await Task.Delay(5000);

        //Navigate to Add Student Page 
        var SearchStudentBox = Page.GetByPlaceholder("Search students");
        await SearchStudentBox.FillAsync($"{MyNewStudent.FirstName} {MyNewStudent.LastName}");
        await SearchStudentBox.PressAsync("Enter");
        await Task.Delay(5000);

        await Page.GetByTitle("activity").SelectOptionAsync("Delete");
        await Page.GetByText("Confirm").ClickAsync();

        await Expect(Page.GetByText($"Successfully deleted student: {MyNewStudent.FirstName} {MyNewStudent.LastName}")).ToBeVisibleAsync();
    }
}