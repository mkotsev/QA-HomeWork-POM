using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_3.Task_1
{
    public class LoginPage : BasePage
    {
        
        public LoginPage(IWebDriver driver)
            : base (driver)
        {
        }

        //public new string Url => "http://automationpractice.com/index.php?controller=my-account";

        public IWebElement Email => Driver.FindElement(By.XPath(@"//*[@id=""columns""]/div[3]/div/div/div/form/div/div[2]/input"));

        public IWebElement Submit => Driver.FindElement(By.XPath(@"//*[@id=""SubmitCreate""]"));

    }
}
