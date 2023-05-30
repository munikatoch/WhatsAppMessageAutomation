using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumTutorials
{
    internal class Program
    {
        private const int _threadSleepTime = 1000;
        private const string _url = "https://web.whatsapp.com/send/?phone=15067238582&type=phone_number";
        private const string _message = "https://www.youtube.com/watch?v=dQw4w9WgXcQ";

        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(_url);
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                wait.Until(x => x.FindElement(By.XPath("//*[@id=\"main\"]/footer/div[1]/div/span[2]/div/div[2]/div[1]/div/div[1]")));
                Thread.Sleep(_threadSleepTime*5);
                IWebElement textMessage = driver.FindElement(By.XPath("//*[@id=\"main\"]/footer/div[1]/div/span[2]/div/div[2]/div[1]/div/div[1]"));
                Thread.Sleep(_threadSleepTime);
                while (true)
                {
                    textMessage.Click();
                    textMessage.SendKeys(_message);
                    IWebElement sendMessageButton = driver.FindElement(By.CssSelector("button[data-testid='compose-btn-send']"));
                    sendMessageButton.Click(); 
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                driver.Quit();
            }            
        }
    }
}
