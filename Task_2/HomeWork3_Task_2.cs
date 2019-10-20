using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.IO;
using System.Reflection;

namespace HomeWork_3_2_Task

{

    [TestFixture]


    class HomeWork3_Task_2
    {
        private ChromeDriver _driver;
        private NavigateTo _navigate;
        private Methods _methods;

       [OneTimeSetUp]
       public void TestInit()
       {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _navigate = new NavigateTo(_driver);
            _methods = new Methods(_driver);
       }
        

        [Test]
        public void Draggable_1()
        {
            _methods.NavigateToDraggable(_navigate);

            var itemToDrag = _driver.FindElement(By.Id("draggable"));

            int y_position = itemToDrag.Location.Y;
            int x_position = itemToDrag.Location.X;

            Actions act = new Actions(_driver);
            act.DragAndDropToOffset(itemToDrag, 100, 100).Perform();

            int newX_position = itemToDrag.Location.X;
            int newY_position = itemToDrag.Location.Y;

            Assert.AreNotEqual(y_position, newY_position);
        }

        [Test]
        public void Draggable_2()
        {
            _methods.NavigateToDraggable(_navigate); 

            var itemToDrag = _driver.FindElement(By.Id("draggable"));

            int x_position = itemToDrag.Location.X;
            int y_position = itemToDrag.Location.Y;

            Actions act = new Actions(_driver);
            act.DragAndDropToOffset(itemToDrag, 0, 100).Perform();

            int newX_position = itemToDrag.Location.X;
            int newY_position = itemToDrag.Location.Y;

            Assert.AreEqual(x_position, newX_position);
            Assert.AreNotEqual(y_position, newY_position);

        }

        [Test]
        public void Draggable_3()
        {
            _methods.NavigateToDraggable(_navigate);

            var itemToDrag = _driver.FindElement(By.Id("draggable"));

            int x_position = itemToDrag.Location.X;
            int y_position = itemToDrag.Location.Y;

            Actions act = new Actions(_driver);
            act.DragAndDropToOffset(itemToDrag, 100, 0).Perform();

            int newX_position = itemToDrag.Location.X;
            int newY_position = itemToDrag.Location.Y;

            Assert.AreNotEqual(x_position, newX_position);
            Assert.AreEqual(y_position, newY_position);
        }



        [Test]
        public void Droppable_1()
        {
            _methods.NavigateToDroppable(_navigate);

            var itemToDrop = _driver.FindElement(By.Id("draggable"));
            var positionToDrop = _driver.FindElement(By.Id("droppable"));

            Actions act = new Actions(_driver);
            act.DragAndDrop(itemToDrop, positionToDrop).Perform();

            var result = _driver.FindElement(By.XPath("//*[@id='droppable']/p")).Text;
            Assert.AreEqual("Dropped!", result);
        }

        [Test]
        public void Droppable_2()
        {
            _methods.NavigateToDroppable(_navigate);

            var itemToDrop = _driver.FindElement(By.Id("draggable"));

            Actions act = new Actions(_driver);
            act.DragAndDropToOffset(itemToDrop, 0, 100).Perform();

            var result = _driver.FindElement(By.XPath("//*[@id='droppable']/p")).Text;

            Assert.AreEqual("Drop here", result);
        }



        [Test]
        public void Sortable_1()
        {
            _methods.NavigateToSortable(_navigate);
            var firstItem = _driver.FindElement(By.XPath("//*[@id='sortable']/li[1]")).Text;

            Assert.AreEqual("Item 1", firstItem);
        }

        [Test]
        public void Sortable_2()
        {
            _methods.NavigateToSortable(_navigate);
            var lastItem = _driver.FindElement(By.XPath("//*[@id='sortable']/li[7]")).Text;

            Assert.AreEqual("Item 7", lastItem);
        }

        [Test]
        public void Sortable_3()
        {
            _methods.NavigateToSortable(_navigate);

            var firstItem = _driver.FindElement(By.XPath("//*[@id='sortable']/li[1]"));
            var firstPositionName = _driver.FindElement(By.XPath("//*[@id='sortable']/li[1]")).Text;

            Actions moveFirstItem = new Actions(_driver);
            moveFirstItem.DragAndDropToOffset(firstItem, 0, 42).Perform();

            var secondPositionName = _driver.FindElement(By.XPath("//*[@id='sortable']/li[2]")).Text;

            Assert.AreEqual(firstPositionName, secondPositionName);
        }



        [Test]
        public void Selectable_1()
        {
            _methods.NavigateToSelectable(_navigate);
            var firstItem = _driver.FindElement(By.XPath("//*[@id='selectable']/li[1]")); 
            firstItem.Click();

            var selectedItemColor = _driver.FindElement(By.XPath("//*[@id='selectable']/li[1]")).GetCssValue("background-color"); ;

            Assert.AreEqual("rgba(243, 152, 20, 1)", selectedItemColor);

        }

        [Test]
        public void Selectable_2()
        {
            _methods.NavigateToSelectable(_navigate);

            var firstItem = _driver.FindElement(By.XPath("//*[@id='selectable']/li[1]"));
            firstItem.Click();

            var selectedItem = _driver.FindElement(By.XPath("//*[@id='selectable']/li[1]")).GetAttribute("class");

            Assert.AreEqual("ui-widget-content ui-selectee ui-selected", selectedItem);
        }

         

        [Test]
        public void Resizable_1()
        {
            _methods.NavigateToResizable(_navigate);
            var resizeButton = _driver.FindElement(By.XPath("//*[@id='resizable']/div[3]"));

            int x_position = resizeButton.Location.X + 83;
            int y_position = resizeButton.Location.Y + 83;

            Actions act = new Actions(_driver);
            act.DragAndDropToOffset(resizeButton, 100, 100).Perform();

            int x_posAfterResize = resizeButton.Location.X;
            int y_posAfterResize = resizeButton.Location.Y;

            Assert.AreEqual(x_position, x_posAfterResize, 2);
            Assert.AreEqual(y_position, y_posAfterResize, 2);
        }

        [Test]
        public void Resizable_2()
        {
            
            _methods.NavigateToResizable(_navigate);
            var itemToResize = _driver.FindElement(By.Id("resizable"));

            int x_size = itemToResize.Size.Width + 83;
            int y_size = itemToResize.Size.Height + 83;

            var resizeButton = _driver.FindElement(By.XPath("//*[@id='resizable']/div[3]"));

            Actions act = new Actions(_driver);
            act.DragAndDropToOffset(resizeButton, 100, 100).Perform();

            var itemAfterResize = _driver.FindElement(By.Id("resizable"));

            int new_X_size = itemAfterResize.Size.Width;
            int new_Y_size = itemAfterResize.Size.Height;

            Assert.AreEqual(x_size, new_X_size, 2);
            Assert.AreEqual(y_size, new_Y_size, 2);
        }

        [OneTimeTearDown]
        public void TestQuitDriver()
        {
            _driver.Quit();
        }
    }   
}
