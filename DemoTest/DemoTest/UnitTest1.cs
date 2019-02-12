using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
namespace DemoTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ChromeMethod()
        {
            IWebDriver Driver = new ChromeDriver();
            Driver.Navigate().GoToUrl("https://rajv11.github.io");
            Driver.Manage().Window.Maximize();

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            
            //clicling on App tab in webiste using XPath
            Driver.FindElement(By.XPath("//*[@id='navbarNavAltMarkup']/div/a[3]")).Click();
            // Selecting dropdwon list by name
            var Sem = Driver.FindElement(By.Name("semester"));
            // creating select element object
            var SelectElement = new SelectElement(Sem);

            //Setting the value of selector to 2
            SelectElement.SelectByValue("2");

            //Setting test values for two input boxes
            Driver.FindElement(By.Name("semester_1")).SendKeys("3.5");
            Driver.FindElement(By.Name("semester_2")).SendKeys("3.6");

            //Clicking Claculate GPA buuton using XPath
            Driver.FindElement(By.XPath("//*[@id='generatedHtml']/button")).Click();

            //Getting calculated gpa value using xPath
            var Result = Driver.FindElement(By.XPath("//*[@id='scholor']/div/div/div[3]/span[2]")).Text;

            var ExpectedValue = "3.55";

            //Testing result value with expectd value
            Assert.AreEqual(ExpectedValue,Result);

            //use following lines to quit the browser
            //driver.Close();
            //driver.Quit();
        }
    }
}
