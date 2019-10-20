using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace HomeWork_3.Task_1
{
    public class RegistrationPage : BasePage
    {

        public RegistrationPage(IWebDriver driver)
            : base (driver)
        {
        }


        public IList<IWebElement> GenderRadioButtons => Wait.Until(d => d.FindElements(By.XPath("//div[@class='radio']//input")));
        public IWebElement FirstNameField => Driver.FindElement(By.Id("customer_firstname"));
        public IWebElement LastNameField => Driver.FindElement(By.Id("customer_lastname"));
        public IWebElement PasswordField => Driver.FindElement(By.Id("passwd"));
        public SelectElement DateDropDown
        {
            get
            {
                IWebElement dateDropDown = Driver.FindElement(By.Id("days"));
                return new SelectElement(dateDropDown);
            }
        }
        public SelectElement monthsDropDown
        {
            get
            {
                IWebElement monthsDropDown = Driver.FindElement(By.Id("months"));
                return new SelectElement(monthsDropDown);
            }
        }
        public SelectElement yearDropDown
        {
            get
            {
                IWebElement yearDropDown = Driver.FindElement(By.Id("years"));
                return new SelectElement(yearDropDown);
            }
        }
        public IWebElement address => Driver.FindElement(By.Id("address1"));
        public IWebElement city => Driver.FindElement(By.Id("city"));
        public SelectElement StateDropDown
        {
            get
            {
                IWebElement StateDropDown = Driver.FindElement(By.Id("id_state"));
                return new SelectElement(StateDropDown);
            }
        }
        public IWebElement ZipCode => Driver.FindElement(By.Id("postcode"));
        public IWebElement MobilePhone => Driver.FindElement(By.Id("phone_mobile"));
        public IWebElement AliasAddress => Driver.FindElement(By.Id("alias"));
        public IWebElement RegisterButton => Driver.FindElement(By.Id("submitAccount"));
        //public IWebElement ErrorCatch => Driver.FindElement(By.XPath("//*[@id='center_column']/div/ol/li"));


        public void FillForm(Registration user)
        {
            GenderRadioButtons[0].Click();
            FirstNameField.SendKeys(user.FirstName);
            LastNameField.SendKeys(user.LastName);
            PasswordField.SendKeys(user.Password);
            DateDropDown.SelectByValue(user.DateDropDown);
            monthsDropDown.SelectByValue(user.MonthsDropDown);
            yearDropDown.SelectByValue(user.YearDropDown);
            address.SendKeys(user.Address);
            city.SendKeys(user.City);
            StateDropDown.SelectByValue(user.StateDropDown);
            ZipCode.SendKeys(user.ZipCode);
            MobilePhone.SendKeys(user.MobilePhone);
            AliasAddress.SendKeys(user.AliasAddress);
            RegisterButton.Click();
            
        }

        public void Navigate(LoginPage loginPage)
        {
            loginPage.Navigate("http://automationpractice.com/index.php?controller=my-account");

            loginPage.Email.SendKeys("SoftUni200@gmail.com");
            loginPage.Submit.Click();
        }

        public string ErrorMesage()
        {
            var error = Driver.FindElement(By.XPath("//*[@id='center_column']/div/ol/li")).Text;
            return error;
        }

        //public void AssertErrorMessage(string expected)
        //{
        //
        //}
    }
}
