using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;

IWebDriver driver = new EdgeDriver("C:\\edgedriver_win64");

//Navigate Amazon browser
driver.Navigate().GoToUrl("https://www.amazon.com/");

// Putting search the 'keyword' in search box , make sure u inspect the searh box id name and insert below
IWebElement searchBox = driver.FindElement(By.XPath("//div[@data-component-type='s-search-result']//h2/a"));
searchBox.SendKeys("laptop");

// itenditfy the search button and click setup 
IWebElement searchButton = driver.FindElement(By.XPath("//div[@data-component-type='s-search-result']//h2/a"));
searchButton.Click();

// Finding the first result and click 
IWebElement firstResult = driver.FindElement(By.XPath("//div[@data-component-type='s-search-result']//h2/a"));
firstResult.Click();

// Allow some wait time for the first laptop product page to load (for this one its set at 5 sec, can change to any value)
WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
wait.Until(ExpectedConditions.XPath("//div[@data-component-type='s-search-result']//h2/a"));

// Finding the price element and setting out price range
IWebElement priceElement = driver.FindElement(By.XPath("//span[@class='a-price-whole']"));
string price = priceElement.Text;
int priceValue = Int32.Parse(price.Replace(",", ""));
Assert.IsTrue(priceValue > 100);


driver.Close();
driver.Quit();

    }
}