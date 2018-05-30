using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace RecruitmentTask_Omada___.PageObjects
{
    public class NewsPage:Universal
    {
        public NewsPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.ClassName, Using = "cases__item")]
        public IList<IWebElement> newsArticles;

        public IWebElement FindNewsArticle(string title)
        {

            var result = newsArticles.First(article => article.FindElement(By.ClassName("cases__heading")).Text == title);
            return result;
        }

        public bool IsArticlePresent(string title)
        {
            var result = newsArticles.Any(article => article.FindElement(By.ClassName("cases__heading")).Text == title);
            return result;
        }

    }
}
