using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System.ComponentModel;
using System.ComponentModel.Design;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;
namespace WebDriverTask2
{
    public class Tests
    {
        private ChromeDriver driver;
        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://pastebin.com/");

            var code = driver.FindElement(By.Id("postform-text"));
            code.SendKeys(@"git config --global user.name  ""New Sheriff in Town""" + '\n' +@"git reset $(git commit-tree HEAD^{tree} -m ""Legacy code"")" + '\n' +@"git push origin master --force");

            driver.FindElement(By.ClassName("field-postform-format")).FindElement(By.ClassName("selection")).Click();
            driver.FindElement(By.ClassName("select2-results__options")).FindElements(By.TagName("li"))[1].FindElement(By.ClassName("select2-results__options")).FindElements(By.TagName("li"))[0].Click();

            driver.FindElement(By.ClassName("field-postform-expiration")).FindElement(By.ClassName("selection")).Click();
            driver.FindElement(By.ClassName("select2-results__options")).FindElements(By.TagName("li"))[2].Click();

            var title = driver.FindElement(By.Id("postform-name"));
            title.SendKeys("how to gain dominance among developers");
            var button = driver.FindElement(By.ClassName("btn"));
            button.Click();
            Thread.Sleep(3000);
        }

        [Test]
        public void TitleTest()
        {
            Assert.That(driver.Title, Is.EqualTo("how to gain dominance among developers"));
        }
        [Test]
        public void SyntaxTest()
        {
            var syntax = driver.FindElement(By.ClassName("left")).FindElements(By.TagName("a"))[0];
            Assert.That(syntax.Text, Is.EqualTo("Bash"));
        }
        [Test]
        public void CodeTest()
        {
            var code = driver.FindElement(By.ClassName("de1"));
            Assert.That(code.Text, Is.EqualTo(@"git config --global user.name  ""New Sheriff in Town""" + '\n' + @"git reset $(git commit-tree HEAD^{tree} -m ""Legacy code"")" + '\n' + @"git push origin master --force"));
        }
        [OneTimeTearDown]
        public void TearDown()
        {
            // Dispose of your resource in the TearDown method
            if (driver != null)
            {
                driver.Dispose();
            }
        }
    }
}