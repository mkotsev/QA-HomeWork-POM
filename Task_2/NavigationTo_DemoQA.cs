using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.IO;
using System.Reflection;

namespace HomeWork_3_2_Task
{

    public class NavigateTo : BasePage_Task_2
    {
        public NavigateTo(IWebDriver driver)
            : base (driver)
        {
        }

        //public new string Url => "https://demoqa.com/";
        public IWebElement Sortable => Driver.FindElement(By.XPath("//*[@id='sidebar']/aside[1]/ul/li[1]/a"));
        public IWebElement Selectable => Driver.FindElement(By.XPath("//*[@id='sidebar']/aside[1]/ul/li[2]/a"));
        public IWebElement Resizable => Driver.FindElement(By.XPath("//*[@id='sidebar']/aside[1]/ul/li[3]/a"));
        public IWebElement Droppable => Driver.FindElement(By.XPath("//*[@id='sidebar']/aside[1]/ul/li[4]/a"));
        public IWebElement Draggable => Driver.FindElement(By.XPath("//*[@id='sidebar']/aside[1]/ul/li[5]/a"));

    }

    
}
