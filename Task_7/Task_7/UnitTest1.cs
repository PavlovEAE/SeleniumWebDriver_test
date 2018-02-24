using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace csharp_example
{
    [TestFixture]
    public class MyFirstTest
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void start()
        {
            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

        }

        [Test]
        public void FirstTest_Task_7()
        {
            driver.Url = "http://localhost/litecart/admin/";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            driver.FindElement(By.XPath("//li[@id='app-']//span[contains(.,'Appearence')]")).Click();
            driver.FindElement(By.CssSelector("li.selected li#doc-template")).Click();
            IWebElement element = driver.FindElement(By.XPath("//h1[contains(.,'Template')]"));
            driver.FindElement(By.CssSelector("li.selected li#doc-logotype")).Click();
            IWebElement element2 = driver.FindElement(By.XPath("//h1[contains(.,'Logotype')]"));
            driver.FindElement(By.XPath("//li[@id='app-']//span[contains(.,'Catalog')]")).Click();
            driver.FindElement(By.CssSelector("li.selected li#doc-catalog")).Click();
            IWebElement element3 = driver.FindElement(By.XPath("//h1[contains(.,'Catalog')]"));
            driver.FindElement(By.CssSelector("li.selected li#doc-product_groups")).Click();
            IWebElement element4 = driver.FindElement(By.XPath("//h1[contains(.,'Product Groups')]"));
            driver.FindElement(By.CssSelector("li.selected li#doc-option_groups")).Click();
            IWebElement element5 = driver.FindElement(By.XPath("//h1[contains(.,'Option Groups' )]"));
            driver.FindElement(By.CssSelector("li.selected li#doc-manufacturers")).Click();
            IWebElement element6 = driver.FindElement(By.XPath("//h1[contains(.,'Manufacturers')]"));
            driver.FindElement(By.CssSelector("li.selected li#doc-suppliers")).Click();
            IWebElement elevent7 = driver.FindElement(By.XPath("//h1[contains(.,'Suppliers')]"));
            driver.FindElement(By.CssSelector("li.selected li#doc-delivery_statuses")).Click();
            IWebElement elevent8 = driver.FindElement(By.XPath("//h1[contains(.,'Delivery Statuses')]"));
            driver.FindElement(By.CssSelector("li.selected li#doc-sold_out_statuses")).Click();
            IWebElement elevent9 = driver.FindElement(By.XPath("//h1[contains(.,'Sold Out Statuses')]"));
            driver.FindElement(By.CssSelector("li.selected li#doc-quantity_units")).Click();
            IWebElement elevent10 = driver.FindElement(By.XPath("//h1[contains(.,'Quantity Units')]"));
            driver.FindElement(By.CssSelector("li.selected li#doc-csv")).Click();
            IWebElement elevent11 = driver.FindElement(By.XPath("//h1[contains(.,'CSV Import/Export')]"));

            driver.FindElement(By.XPath("//li[@id='app-']//span[contains(.,'Countries')]")).Click();
            IWebElement elevent12 = driver.FindElement(By.XPath("//h1[contains(.,'Countries')]"));

            driver.FindElement(By.XPath("//li[@id='app-']//span[contains(.,'Currencies')]")).Click();
            IWebElement elevent13 = driver.FindElement(By.XPath("//h1[contains(.,'Currencies')]"));

            driver.FindElement(By.XPath("//li[@id='app-']//span[contains(.,'Customers')]")).Click();
            driver.FindElement(By.CssSelector("li.selected li#doc-customers")).Click();
            IWebElement elevent14 = driver.FindElement(By.XPath("//h1[contains(.,'Customers')]"));
            driver.FindElement(By.CssSelector("li.selected li#doc-csv")).Click();
            IWebElement elevent15 = driver.FindElement(By.XPath("//h1[contains(.,'CSV Import/Export')]"));
            driver.FindElement(By.CssSelector("li.selected li#doc-newsletter")).Click();
            IWebElement elevent16 = driver.FindElement(By.XPath("//h1[contains(.,'Newsletter')]"));

            driver.FindElement(By.XPath("//li[@id='app-']//span[contains(.,'Geo Zones')]")).Click();
            IWebElement elevent17 = driver.FindElement(By.XPath("//h1[contains(.,'Geo Zones')]"));

            driver.FindElement(By.XPath("//li[@id='app-']//span[contains(.,'Languages')]")).Click();
            driver.FindElement(By.CssSelector("li.selected li#doc-languages")).Click();
            IWebElement elevent18 = driver.FindElement(By.XPath("//h1[contains(.,'Languages')]"));
            driver.FindElement(By.CssSelector("li.selected li#doc-storage_encoding")).Click();
            IWebElement elevent1 = driver.FindElement(By.XPath("//h1[contains(.,'Storage Encoding')]"));

            driver.FindElement(By.XPath("//li[@id='app-']//span[contains(.,'Modules')]")).Click();
            driver.FindElement(By.CssSelector("li.selected li#doc-jobs")).Click();
            IWebElement elevent19 = driver.FindElement(By.XPath("//h1[contains(.,'Job Modules')]"));
            driver.FindElement(By.CssSelector("li.selected li#doc-customer")).Click();
            IWebElement elevent20 = driver.FindElement(By.XPath("//h1[contains(.,'Customer Modules')]"));
            driver.FindElement(By.CssSelector("li.selected li#doc-shipping")).Click();
            IWebElement elevent21 = driver.FindElement(By.XPath("//h1[contains(.,'Shipping Modules')]"));
            driver.FindElement(By.CssSelector("li.selected li#doc-payment")).Click();
            IWebElement elevent22 = driver.FindElement(By.XPath("//h1[contains(.,'Payment Modules')]"));
            driver.FindElement(By.CssSelector("li.selected li#doc-order_total")).Click();
            IWebElement elevent23 = driver.FindElement(By.XPath("//h1[contains(.,'Order Total Modules')]"));
            driver.FindElement(By.CssSelector("li.selected li#doc-order_success")).Click();
            IWebElement elevent24 = driver.FindElement(By.XPath("//h1[contains(.,'Order Success Modules')]"));
            driver.FindElement(By.CssSelector("li.selected li#doc-order_action")).Click();
            IWebElement elevent25 = driver.FindElement(By.XPath("//h1[contains(.,'Order Action Modules')]"));

            driver.FindElement(By.XPath("//li[@id='app-']//span[contains(.,'Orders')]")).Click();
            driver.FindElement(By.CssSelector("li.selected li#doc-orders")).Click();
            IWebElement elevent26 = driver.FindElement(By.XPath("//h1[contains(.,'Orders')]"));
            driver.FindElement(By.CssSelector("li.selected li#doc-order_statuses")).Click();
            IWebElement elevent27 = driver.FindElement(By.XPath("//h1[contains(.,'Order Statuses')]"));

            driver.FindElement(By.XPath("//li[@id='app-']//span[contains(.,'Pages')]")).Click();
            IWebElement elevent28 = driver.FindElement(By.XPath("//h1[contains(.,'Pages')]"));

            driver.FindElement(By.XPath("//li[@id='app-']//span[contains(.,'Reports')]")).Click();
            driver.FindElement(By.CssSelector("li.selected li#doc-monthly_sales")).Click();
            IWebElement elevent29 = driver.FindElement(By.XPath("//h1[contains(.,'Monthly Sales')]"));
            driver.FindElement(By.CssSelector("li.selected li#doc-most_sold_products")).Click();
            IWebElement elevent30 = driver.FindElement(By.XPath("//h1[contains(.,'Most Sold Products')]"));
            driver.FindElement(By.CssSelector("li.selected li#doc-most_shopping_customers")).Click();
            IWebElement elevent31 = driver.FindElement(By.XPath("//h1[contains(.,'Most Shopping Customers')]"));

            driver.FindElement(By.XPath("//li[@id='app-']//span[contains(.,'Settings')]")).Click();
            driver.FindElement(By.CssSelector("li.selected li#doc-store_info")).Click();
            IWebElement elevent32 = driver.FindElement(By.XPath("//h1[contains(.,'Settings')]"));
            driver.FindElement(By.CssSelector("li.selected li#doc-defaults")).Click();
            //  IWebElement elevent33 = driver.FindElement(By.XPath("//h1[contains(.,'Settings')]"));
            driver.FindElement(By.CssSelector("li.selected li#doc-general")).Click();
            // IWebElement elevent34 = driver.FindElement(By.XPath("//h1[contains(.,'Settings')]"));
            driver.FindElement(By.CssSelector("li.selected li#doc-listings")).Click();
            // IWebElement elevent35 = driver.FindElement(By.XPath("//h1[contains(.,'Settings')]"));
            driver.FindElement(By.CssSelector("li.selected li#doc-images")).Click();
            // IWebElement elevent36 = driver.FindElement(By.XPath("//h1[contains(.,'Settings')]"));
            driver.FindElement(By.CssSelector("li.selected li#doc-checkout")).Click();
            //  IWebElement elevent37 = driver.FindElement(By.XPath("//h1[contains(.,'Settings')]"));
            driver.FindElement(By.CssSelector("li.selected li#doc-advanced")).Click();
            // IWebElement elevent38 = driver.FindElement(By.XPath("//h1[contains(.,'Settings')]"));
            driver.FindElement(By.CssSelector("li.selected li#doc-security")).Click();
            IWebElement elevent39 = driver.FindElement(By.XPath("//h1[contains(.,'Settings')]"));

            driver.FindElement(By.XPath("//li[@id='app-']//span[contains(.,'Slides')]")).Click();
            IWebElement elevent40 = driver.FindElement(By.XPath("//h1[contains(.,'Slides')]"));

            driver.FindElement(By.XPath("//li[@id='app-']//span[contains(.,'Tax')]")).Click();
            driver.FindElement(By.CssSelector("li.selected li#doc-tax_classes")).Click();
            IWebElement elevent41 = driver.FindElement(By.XPath("//h1[contains(.,'Tax Classes')]"));
            driver.FindElement(By.CssSelector("li.selected li#doc-tax_rates")).Click();
            IWebElement elevent42 = driver.FindElement(By.XPath("//h1[contains(.,'Tax Rates')]"));

            driver.FindElement(By.XPath("//li[@id='app-']//span[contains(.,'Translations')]")).Click();
            driver.FindElement(By.CssSelector("li.selected li#doc-search")).Click();
            IWebElement elevent43 = driver.FindElement(By.XPath("//h1[contains(.,'Search Translations')]"));
            driver.FindElement(By.CssSelector("li.selected li#doc-scan")).Click();
            IWebElement elevent44 = driver.FindElement(By.XPath("//h1[contains(.,'Scan Files For Translations')]"));
            driver.FindElement(By.CssSelector("li.selected li#doc-csv")).Click();
            IWebElement elevent45 = driver.FindElement(By.XPath("//h1[contains(.,'CSV Import/Export')]"));

            driver.FindElement(By.XPath("//li[@id='app-']//span[contains(.,'Users')]")).Click();
            IWebElement elevent46 = driver.FindElement(By.XPath("//h1[contains(.,'Users')]"));

            driver.FindElement(By.XPath("//li[@id='app-']//span[contains(.,'vQmods')]")).Click();
            driver.FindElement(By.CssSelector("li.selected li#doc-vqmods")).Click();
            IWebElement elevent47 = driver.FindElement(By.XPath("//h1[contains(.,'vQmods')]"));

        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}