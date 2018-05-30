using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;

namespace RecruitmentTask_Omada___.PageObjects
{
    public class Universal
    {
        public IWebDriver driver;

        public Universal(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        [FindsByAll]
        [FindsBy(How = How.ClassName, Using = "header__menulink--submenu", Priority = 0)]
        [FindsBy(How = How.PartialLinkText, Using = "news", Priority = 1)]
        public IWebElement News;


        [FindsBy(How = How.ClassName, Using = "header__search", Priority = 0)]
        public IWebElement SearchBox;

        [FindsByAll]
        [FindsBy(How = How.ClassName, Using = "header__menulink--function-nav", Priority = 0)]
        [FindsBy(How = How.PartialLinkText, Using = "contact", Priority = 1)]
        public IWebElement Contact;

        [FindsByAll]
        [FindsBy(How = How.ClassName, Using = "cookiebar__read-more", Priority = 0)]
        [FindsBy(How = How.PartialLinkText, Using = "privacy", Priority = 1)]
        public IWebElement Privacy;

        [FindsByAll]
        [FindsBy(How = How.ClassName, Using = "footer__menulink--submenu", Priority = 0)]
        [FindsBy(How = How.PartialLinkText, Using = "cases", Priority = 1)]
        public IWebElement Cases;

        
        [FindsBy(How = How.CssSelector, Using = ".header__menulink--megamenu.js-menulink")]
        public IWebElement MenuBar;

        [FindsByAll]
        [FindsBy(How = How.ClassName, Using = "cookiebar__button button--variant1", Priority = 0)]
        [FindsBy(How = How.PartialLinkText, Using = "Close", Priority = 1)]
        public IWebElement CookieBarCloseButton;


        [FindsBy(How = How.ClassName, Using = "cookiebar__container", Priority = 0)]
        public IList<IWebElement> CookieBarContainer;


        public NewsPage GoToNewsPage()
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(MenuBar)
                .Build()
                .Perform();
            News.Click();
            return new NewsPage(driver);
        }

        public SearchResultsPage SearchArticles(string searchPhrase)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(SearchBox);
            actions.Click();
            actions.SendKeys(searchPhrase);
            actions.SendKeys(Keys.Return);
            actions.Build();
            actions.Perform();
            //SearchBox.SendKeys(searchPhrase);
            //SearchBox.SendKeys(Keys.Return);
            return new SearchResultsPage(driver);
        }

        public ContactPage GoToContactPage()
        {
            Contact.Click();
            return new ContactPage(driver);
        }

        public void CloseCookieTab()
        {
            CookieBarCloseButton.Click();
            
        }

        public bool CookieTabIsPresent()
        {
            var result = !CookieBarContainer.Any();
            return result;

        }

        public CasesPage GoToCasesPage()
        {
            Cases.Click();
            return new CasesPage(driver);
        }
    }
}
