using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace RecruitmentTask_Omada___.PageObjects
{
    class Universal
    {
        private IWebDriver driver;

        public Universal(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        [FindsByAll]
        [FindsBy(How = How.ClassName, Using = "header__menulink--submenu", Priority = 0)]
        [FindsBy(How = How.PartialLinkText, Using = "news", Priority = 1)]
        private IWebElement News;

        [FindsByAll]
        [FindsBy(How = How.ClassName, Using = "header__search-input", Priority 0)]
        [FindsBy(How = How.Name, Using = "q"), Priority 1]
        private IWebElement SearchBox;

        [FindsByAll]
        [FindsBy(How = How.ClassName, Using = "header__menulink--function-nav", Priority 0)]
        [FindsBy(How = How.PartialLinkText, Using = "contact"), Priority 1]
        private IWebElement Contact;

        [FindsByAll]
        [FindsBy(How = How.ClassName, Using = "cookiebar__read-more", Priority 0)]
        [FindsBy(How = How.PartialLinkText, Using = "privacy", Priority 1)]
        private IWebElement Privacy;

        [FindsByAll]
        [FindsBy(How = How.ClassName, Using = "footer__menulink--submenu", Priority 0)]
        [FindsBy(How = How.PartialLinkText, Using = "cases", Priority 1)]
        private IWebElement Cases;

        public NewsPage GoToNewsPage()
        {
            News.Click();
            return new NewsPage(driver);
        }

        public SearchPage GoToSearchPage(string searchPhrase)
        {
            SearchBox.SendKeys(searchPhrase);
            SearchBox.SendKeys(Keys.Return);
            return new SearchPage(driver);
        }

        public ContactPage GoToContactPage()
        {
            Contact.Click();
            return new ContactPage(driver);
        }
    }
}
