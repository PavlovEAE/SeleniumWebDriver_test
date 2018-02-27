using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace csharp_example_task_10
{
    [TestFixture]
    public class MyTest
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void start()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

        }


        [Test]
        public void FirstTest_Task_10()
        {
            driver.Url = "http://localhost/litecart/";
            //driver.FindElement(By.Name("username")).SendKeys("admin");
            //driver.FindElement(By.Name("password")).SendKeys("admin");
            //driver.FindElement(By.Name("login")).Click();
          
   //запоминаем данные на главной странице
//запоминаем имя товара
            var name1 = driver.FindElement(By.CssSelector("div#box-campaigns li:first-child div.name")).Text;
//проверяем классы цен
            Assert.AreEqual(driver.FindElement(By.CssSelector("div#box-campaigns li:first-child s")).GetAttribute("class"), "regular-price");
            Assert.AreEqual(driver.FindElement(By.CssSelector("div#box-campaigns li:first-child strong")).GetAttribute("class"), "campaign-price");
//проверяем стили написания цен
            Assert.AreEqual(driver.FindElement(By.CssSelector("div#box-campaigns li:first-child s")).GetCssValue("text-decoration-line"), "line-through");
            Assert.AreEqual(driver.FindElement(By.CssSelector("div#box-campaigns li:first-child strong")).GetCssValue("font-weight"), "700");  
            
//проверяем размер
            var sizeRegularPrice1 = driver.FindElement(By.CssSelector("div#box-campaigns li:first-child s")).Size;
            var sizeRegular = (sizeRegularPrice1.ToString().Replace("{Width=", "").Replace(" Height=", "").Replace("}", "").Split(','));
            var sizeCampaignPrice1 = driver.FindElement(By.CssSelector("div#box-campaigns li:first-child strong")).Size;
            var sizeCampaign = (sizeCampaignPrice1.ToString().Replace("{Width=", "").Replace(" Height=", "").Replace("}", "").Split(','));
            bool compareSize = Convert.ToInt32(sizeRegular[0]) * Convert.ToInt32(sizeRegular[1]) < Convert.ToInt32(sizeCampaign[0]) * Convert.ToInt32(sizeCampaign[1]);
            Assert.AreEqual(compareSize, true);
 //запоминаем значения цен
            var regularPrice1 = driver.FindElement(By.CssSelector("div#box-campaigns li:first-child s")).Text;
            var campaignPrice1 = driver.FindElement(By.CssSelector("div#box-campaigns li:first-child strong")).Text;
//проверяем серый цвет
            var colorRegularPrice1 = driver.FindElement(By.CssSelector("div#box-campaigns li:first-child s.regular-price")).GetCssValue("color");
            var dividecolorRegular1 = colorRegularPrice1.Replace("rgba(", "").Replace(")", "").Replace(" ", "").Split(',');
            Assert.AreEqual(dividecolorRegular1[0], dividecolorRegular1[1]);
            Assert.AreEqual(dividecolorRegular1[1], dividecolorRegular1[2]);
 //проверяем красный цвет
            var colorCampaignPrice1 = driver.FindElement(By.CssSelector("div#box-campaigns li:first-child strong.campaign-price")).GetCssValue("color");
            var dividecolorCampaign1 = colorCampaignPrice1.Replace("rgba(", "").Replace(")", "").Replace(" ", "").Split(',');
            Assert.AreEqual("0", dividecolorCampaign1[1]);
            Assert.AreEqual("0", dividecolorCampaign1[2]);
//переходим по первый товар в блоке Campaigns на главной странице
//проверяем имя товара 
            driver.FindElement(By.CssSelector("div#box-campaigns li:first-child a.link")).Click();
            var name2 = driver.FindElement(By.CssSelector("h1.title")).Text;
            Assert.AreEqual(name1, name2);
//проверяем классы цен
            Assert.AreEqual(driver.FindElement(By.CssSelector("div.information div.price-wrapper s")).GetAttribute("class"), "regular-price");
            Assert.AreEqual(driver.FindElement(By.CssSelector("div.information div.price-wrapper strong")).GetAttribute("class"), "campaign-price");
//проверяем стили написания цен
            Assert.AreEqual(driver.FindElement(By.CssSelector("div.information div.price-wrapper s")).GetCssValue("text-decoration-line"), "line-through");
            Assert.AreEqual(driver.FindElement(By.CssSelector("div.information div.price-wrapper strong")).GetCssValue("font-weight"), "700");
//проверяем размер
            var sizeRegularPrice2 = driver.FindElement(By.CssSelector("div.information div.price-wrapper s")).Size;
            var sizeRegular2 = (sizeRegularPrice2.ToString().Replace("{Width=", "").Replace(" Height=", "").Replace("}", "").Split(','));
            var sizeCampaignPrice2 = driver.FindElement(By.CssSelector("div.information div.price-wrapper strong")).Size;
            var sizeCampaign2 = (sizeCampaignPrice2.ToString().Replace("{Width=", "").Replace(" Height=", "").Replace("}", "").Split(','));
            bool compareSize2 = Convert.ToInt32(sizeRegular2[0]) * Convert.ToInt32(sizeRegular2[1]) < Convert.ToInt32(sizeCampaign2[0]) * Convert.ToInt32(sizeCampaign2[1]);
            Assert.AreEqual(compareSize2, true);
//проверяем цены товара  
            var regularPrice2 = driver.FindElement(By.CssSelector("div.information div.price-wrapper s.regular-price")).Text;
            Assert.AreEqual(regularPrice1, regularPrice2);
            var campaignPrice2 = driver.FindElement(By.CssSelector("div.information div.price-wrapper strong.campaign-price")).Text;
            Assert.AreEqual(campaignPrice1, campaignPrice2);
//проверяем серый цвет
            var colorRegularPrice2 = driver.FindElement(By.CssSelector("div.information div.price-wrapper s.regular-price")).GetCssValue("color");
            var dividecolorRegular2 = colorRegularPrice2.Replace("rgba(", "").Replace(")", "").Replace(" ", "").Split(',');
            Assert.AreEqual(dividecolorRegular2[0], dividecolorRegular2[1]);
            Assert.AreEqual(dividecolorRegular2[1], dividecolorRegular2[2]);
//проверяем красный цвет
            var colorCampaignPrice2 = driver.FindElement(By.CssSelector("div.information div.price-wrapper strong.campaign-price")).GetCssValue("color");
            var dividecolorCampaign2 = colorCampaignPrice2.Replace("rgba(", "").Replace(")", "").Replace(" ", "").Split(',');
            Assert.AreEqual("0", dividecolorCampaign2[1]);
            Assert.AreEqual("0", dividecolorCampaign2[2]);
        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}