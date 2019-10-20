using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_3_2_Task
{
    public abstract class BasePage_Task_2
    {

        private IWebDriver _driver;
        private WebDriverWait _wait;

        public BasePage_Task_2(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(2));
        }

        public IWebDriver Driver => _driver;

        public WebDriverWait Wait => _wait;

        public virtual void NavigateTo(string url)
        {
            Driver.Url = url;
        }

    }
}
