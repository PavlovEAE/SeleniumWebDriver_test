using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace csharp_example_task_9
{
    [TestFixture]
    public class MyFirstTest
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
        public void FirstTest_Task_9_1()
        {
            driver.Url = "http://localhost/litecart/admin/?app=countries&doc=countries";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();

            //проверка сортировки стран          
            var name_countries = driver.FindElements(By.CssSelector("tr.row td a:not([title=Edit])"));
            var SortCountriesNames = new List<String>();
            foreach (var item in name_countries)
            {
                var item_name = item.GetAttribute("textContent");
                SortCountriesNames.Add(item_name);
            }
            var sortedCountries = SortCountriesNames.OrderBy(x => x);
            bool isSorteredList = SortCountriesNames.Equals(sortedCountries);
            
            //Нахождение списка стран где количество зон не равно 0
            var rows = driver.FindElements(By.CssSelector("tbody tr.row"));
            var SortZonesNames = new List<String>();
            foreach (var Zones in rows)
            {
                var ZonesNumber = Zones.FindElement(By.XPath(".//td[6]")).Text;
                if (ZonesNumber != "0")
                {
                    var ZonesNotNull = Zones.FindElement(By.XPath("./td[5]//a")).GetAttribute("href");
                    SortZonesNames.Add(ZonesNotNull);
                }
            }

            //проверка найденых стран где зон больше 0
            foreach (var Countries in SortZonesNames)
            {
                driver.Url = Countries;
                Assert.DoesNotThrow(() => driver.FindElement(By.XPath("//h1[contains(.,'Edit Country')]")));
                var ZonesCountriesNames = driver.FindElements(By.CssSelector("table#table-zones td:nth-child(3)"));
                var SortZonesCountriesNames = new List<String>();
                foreach (var item2 in ZonesCountriesNames)
                {
                    var item2_name  = item2.Text;
                    SortZonesCountriesNames.Add(item2_name);
                }
                var SortedZones = SortZonesCountriesNames.OrderBy(x => x);
                bool isSorteredList2 = SortZonesCountriesNames.Equals(SortedZones);
               // driver.FindElement(By.CssSelector("p button[name=cancel]"));
            }
        }

        [Test]

        public void FirstTest_Task_9_2()
        {
            driver.Url = "http://localhost/litecart/admin/?app=geo_zones&doc=geo_zones";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            //Создание списка ссылок на страны
            var rows2 = driver.FindElements(By.CssSelector("form[name=geo_zones_form] tr.row"));
            var countresLinks = new List<String>();
            foreach (var links in rows2)
            {
                var Linkcountry = links.FindElement(By.XPath(".//td[3]//a")).GetAttribute("href");
                countresLinks.Add(Linkcountry);
            }

            //проверка сортировки геозон внутри списка стран
            foreach (var CountriesName2 in countresLinks)
            {
                driver.Url = CountriesName2;
                Assert.DoesNotThrow(() => driver.FindElement(By.XPath("//h1[contains(.,'Edit Geo Zone')]")));
                var ZonesCountriesNames2 = driver.FindElements(By.CssSelector("table#table-zones tr:not(.header) select:not(.select2-hidden-accessible)"));
                var SortZonesCountriesNames2 = new List<String>();
                foreach (var item3 in ZonesCountriesNames2)
                {
                    var item3_name = item3.Text;
                    SortZonesCountriesNames2.Add(item3_name);
                }
                var SortedZones2 = SortZonesCountriesNames2.OrderBy(x => x);
                bool isSorteredList3 = SortZonesCountriesNames2.Equals(SortedZones2);
            }
        }


        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}