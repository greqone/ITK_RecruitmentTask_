using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using System.Linq;

namespace RecruitmentTask_Omada___.PageObjects
{
    public class SearchResultsPage
    {
        private IWebDriver driver;

        public SearchResultsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        
        [FindsBy(How = How.ClassName, Using = "search-results__item")]
        public IList<IWebElement> SearchResultsAll;

        
        [FindsBy(How = How.TagName, Using = "a")]
        public IList<IWebElement> articles;

        

        public ArticlePage GoToSummitArticle(string title)
        {
            var correctTitle = articles.First(art => art.Text == title);
            correctTitle.Click();
            return new ArticlePage(driver);
        }
        
        
    }
}
