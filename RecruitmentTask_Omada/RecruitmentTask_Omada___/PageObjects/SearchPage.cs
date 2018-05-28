﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using System.Linq;

namespace RecruitmentTask_Omada___.PageObjects
{
    public class SearchPage
    {
        private IWebDriver driver;

        public SearchPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        
        [FindsBy(How = How.ClassName, Using = "search-results__item")]
        public IReadOnlyCollection<IWebElement> SearchResultsAll;

        
        [FindsBy(How = How.TagName, Using = "a")]
        public IReadOnlyCollection<IWebElement> articles;

        

        public ArticlePage GoToSummitArticle(string title)
        {
            var correctTitle = articles.First(art => art.Text == title);
            correctTitle.Click();
            return new ArticlePage(driver);
        }
        
        
    }
}
