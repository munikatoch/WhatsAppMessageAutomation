using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
        private const int ThreadSleepTime = 1000;
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            string url = "https://web.whatsapp.com/";
            driver.Navigate().GoToUrl(url);
            Console.ReadKey();
            string userSearch = "ying";
            try
            {
                IWebElement searchUser = driver.FindElement(By.CssSelector("div[data-testid='chat-list-search']"));
                Thread.Sleep(ThreadSleepTime);
                searchUser.Click();
                Thread.Sleep(ThreadSleepTime);
                searchUser.SendKeys(userSearch);
                Thread.Sleep(ThreadSleepTime);
                Console.ReadKey();
                //IWebElement activeElement = driver.SwitchTo().ActiveElement();
                //Console.WriteLine("activeElement=");
                //Console.WriteLine(activeElement.TagName);
                //activeElement.SendKeys("Links");

                List<IWebElement> searchedUsers = driver.FindElements(By.CssSelector("div[data-testid='cell-frame-container']")).ToList();
                Thread.Sleep(ThreadSleepTime);
                Console.WriteLine("Count=");
                Console.WriteLine(searchedUsers.Count);
                foreach (var searchedUser in searchedUsers)
                {
                    searchedUser.Click();
                    Thread.Sleep(ThreadSleepTime);
                    IWebElement searchedUserHeader = driver.FindElement(By.CssSelector("span[data-testid='conversation-info-header-chat-title']"));
                    Thread.Sleep(ThreadSleepTime);
                    Console.WriteLine("searchedUserHeader");
                    Console.WriteLine(searchedUserHeader.Text);
                    if (searchedUserHeader.Text.ToLower().Contains(userSearch.ToLower()))
                    {
                        Console.WriteLine("Inside");
                        for(int i = 0; i < 10; i++)
                        {
                            Console.WriteLine("Message sent " + (i + 1) + " times");
                            IWebElement textMessage = driver.FindElement(By.CssSelector("div[data-testid='conversation-compose-box-input']"));
                            Thread.Sleep(ThreadSleepTime);
                            textMessage.Click();
                            textMessage.SendKeys("Go To Sleep after calling dad");
                            IWebElement sendMessageButton = driver.FindElement(By.CssSelector("button[data-testid='compose-btn-send']"));
                            Thread.Sleep(ThreadSleepTime);
                            sendMessageButton.Click();
                        }
                    }
                }
                IWebElement menu = driver.FindElement(By.CssSelector("div[data-testid='menu-bar-menu'],div[title='Menu']"));
                Thread.Sleep(ThreadSleepTime);
                menu.Click();
                Console.WriteLine("menu");
                Console.WriteLine(menu);
                Thread.Sleep(ThreadSleepTime * 3);
                Console.WriteLine("Sleep Full");
                IWebElement logout = driver.FindElement(By.CssSelector("li[data-testid*='mi-logout']"));
                logout.Click();
                IWebElement logoutButton = driver.FindElement(By.CssSelector("div[data-testid*='popup-controls-ok']"));
                logoutButton.Click();
                Console.WriteLine("Logout Success");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                Console.ReadKey();
                driver.Quit();
            }            
        }
    }
}
