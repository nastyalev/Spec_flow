using Lab.business_object;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Lab.service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace Lab.step_definition
{
    [Binding]
    class ProductSteps
    {
        private IWebDriver driver;

        [Given(@"I open ""(.*)"" url")]
        public void GivenIOpenUrl(string url)
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = url;
        }

        [When(@"I type user")]
        public void WhenIType()
        {
            new Login(driver).Login_(new UserName_Password("user", "user"));
        }

        [When(@"I open All Product")]
        public void WhenIOpenAllProduct()
        {
            new HomePage(driver).AllProducts();
        }

        
        [When(@"I Create new Product")]
        public void WhenIClickOnCreateNew()
        {
            new MainPage(driver).ClickCreateNew();
            new ProductEditing(driver).CreateProduct(new Product("Fortune cookie", "Confections", "Specialty Biscuits, Ltd.", "3,000", "10 boxes x 15 pieces", "1", "3", "0"));
        }

        [Then(@"check the product was created")]
        public void ThenProductWasCreated()
        {
            Thread.Sleep(2000);
            Assert.AreEqual("Fortune cookie", new MainPage(driver).AssertAddProduct(new Product("Fortune cookie", null, null, null, null, null, null, null)));
        }
    }
}


