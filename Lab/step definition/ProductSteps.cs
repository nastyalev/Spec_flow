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
using OpenQA.Selenium.Support.UI;

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

        [When(@"I type ""(.*)"" name, ""(.*)"" password")]
        public void WhenIType(string name, string password)
        {
            new Login(driver).Login_(new UserName_Password(name, password));
        }

        [When(@"I open All Product")]
        public void WhenIOpenAllProduct()
        {
            new HomePage(driver).AllProducts();
        }

        [When(@"I Create new Product ""(.*)"" ProductName, ""(.*)"" Category, ""(.*)"" Supplier, ""(.*)"" UnitPrice, ""(.*)"" QuantityPerUnit, ""(.*)"" UnitsInStock, ""(.*)"" UnitsOnOrder, ""(.*)"" ReorderLevel")]
        public void WhenIClickOnCreateNew(string ProductName, string Category, string Supplier, string UnitPrice, string QuantityPerUnit, string UnitsInStock, string UnitsOnOrder, string ReorderLevel)
        {
            new MainPage(driver).ClickCreateNew();
            new ProductEditing(driver).CreateProduct(new Product(ProductName, Category, Supplier, UnitPrice, QuantityPerUnit, UnitsInStock, UnitsOnOrder, ReorderLevel));
        }

        [Then(@"check the ""(.*)"" product was created")]
        public void ThenProductWasCreated(string product)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Assert.AreEqual(product, new MainPage(driver).AssertAddProduct(new Product(product, null, null, null, null, null, null, null)));
        }
    }
}


