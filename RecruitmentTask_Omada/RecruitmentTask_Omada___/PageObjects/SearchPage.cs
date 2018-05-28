using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace RecruitmentTask_Omada___.PageObjects
{
    class SearchPage
    {
        private IWebDriver driver;

        public SearchPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        
        [FindsBy(How = How.ClassName, Using = "search-results__item")]
        private IWebElement SearchResultsAll;

        
        [FindsBy(How = How.PartialLinkText, Using = "gartner-iam-summit-2016-london")]
        private IWebElement SummitArticle;

        public SearchPage SearchForText(string searchPhrase)
        {
            [FindsBy(How = How.TagName, Using = "body")]
            private IWebElement Body;
            var Result = Assert.IsTrue(Body.Text.Contains(searchPhrase));
            
            return Result;
        }

        public SearchPage GoToSummitArticle()
        {
            SummitArticle.Click();
            return new SummitArticlePage(driver);
        }
        
        
    }
}
