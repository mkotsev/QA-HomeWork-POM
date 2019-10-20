using HomeWork_3.Task_1;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;

namespace HomeWork_3
{

    [TestFixture]
    public class Tests
    {
        private ChromeDriver _driver;
        private LoginPage _loginPage;
        private Registration _regNewUser;
        private RegistrationPage _formPage;

        [SetUp]
        public void TestsSetUp()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _loginPage = new LoginPage(_driver);
            _formPage = new RegistrationPage(_driver);
            _regNewUser = UserData.CreateUser();
            
        }

        [Test]

        public void NavigateToLoginForm()
        {
            _formPage.Navigate(_loginPage);
            
        }

        [Test]

        public void No_FirstName_LoginForm()
        {
            _regNewUser.FirstName = "";
            _formPage.Navigate(_loginPage);
            // Това с Wait не го схванах.
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
            _formPage.FillForm(_regNewUser);

            var currentError = _formPage.ErrorMesage();
            Assert.AreEqual("firstname is required.", currentError);
        }


        [Test]

        public void No_LastName_LoginForm()
        {
            _regNewUser.LastName = "";
            _formPage.Navigate(_loginPage);

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            _formPage.FillForm(_regNewUser);

            var currentError = _formPage.ErrorMesage();
            Assert.AreEqual("lastname is required.", currentError);
        }

        [Test]

        public void No_Password_LoginForm()
        {
            _regNewUser.Password = "";
            _formPage.Navigate(_loginPage);

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            _formPage.FillForm(_regNewUser);

            var currentError = _formPage.ErrorMesage();
            Assert.AreEqual("passwd is required.", currentError);
        }

        [Test]

        public void No_Address1_LoginForm()
        {
            _regNewUser.Address = "";
            _formPage.Navigate(_loginPage);

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            _formPage.FillForm(_regNewUser);

            var currentError = _formPage.ErrorMesage();
            Assert.AreEqual("address1 is required.", currentError);
        }

        [Test]

        public void No_City_LoginForm()
        {
            _regNewUser.City = "";
            _formPage.Navigate(_loginPage);

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            _formPage.FillForm(_regNewUser);

            var currentError = _formPage.ErrorMesage();
            Assert.AreEqual("city is required.", currentError);
        }

        [Test]

        public void No_ZipCode_LoginForm()
        {
            _regNewUser.ZipCode = "";
            _formPage.Navigate(_loginPage);

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            _formPage.FillForm(_regNewUser);

            var currentError = _formPage.ErrorMesage();
            Assert.AreEqual("The Zip/Postal code you've entered is invalid. It must follow this format: 00000", currentError);
        }

        public void No_MobilePhone_LoginForm()
        {
            _regNewUser.MobilePhone = "";
            _formPage.Navigate(_loginPage);

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            _formPage.FillForm(_regNewUser);

            var currentError = _formPage.ErrorMesage();
            Assert.AreEqual("You must register at least one phone number.", currentError);
        }


        [TearDown]
        public void TestQuitDrive_1()
        {
            _driver.Quit();
        }
    }
}
