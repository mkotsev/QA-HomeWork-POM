using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_3_2_Task
{
    public class Methods : BasePage_Task_2
    {
        public Methods(IWebDriver driver)
            : base(driver)
        {
        }

        public void NavigateToSortable(NavigateTo navigateTo)
        {
            navigateTo.NavigateTo("https://demoqa.com/");
            navigateTo.Sortable.Click();
        }

        public void NavigateToSelectable(NavigateTo navigateTo)
        {
            navigateTo.NavigateTo("https://demoqa.com/");
            navigateTo.Selectable.Click();
        }

        public void NavigateToResizable(NavigateTo navigateTo)
        {
            navigateTo.NavigateTo("https://demoqa.com/");
            navigateTo.Resizable.Click();
        }

        public void NavigateToDroppable(NavigateTo navigateTo)
        {
            navigateTo.NavigateTo("https://demoqa.com/");
            navigateTo.Droppable.Click();
        }

        public void NavigateToDraggable(NavigateTo navigateTo)
        {
            navigateTo.NavigateTo("https://demoqa.com/");
            navigateTo.Draggable.Click();
        }
    }
}
