using System;

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using RecruitmentTask_Omada___.PageObjects;
using System.Linq;
using RecruitmentTask_Omada___.Helper;

namespace RecruitmentTask_Omada___
{
    [TestFixture]
    public class FrontEndTest
    {
        [OneTimeSetUp]
        public void Setup()
        {
            home = new HomePage(_driver);
        }
        IWebDriver _driver = new ChromeDriver();
        string searchPhrase = "Gartner";
        string articleTitle = "There is Safety in Numbers";
        string summitArticle = "Gartner IAM Summit 2016 - London";
        string correctTitle = "Omada is a sponsor at the Gartner IAM Summit 2016 in London, UK.";
        string correctArticleURL = "https://www.omada.net/en-us/more/news-events/news/gartner-iam-summit-2016-london";
        string region = "U.S West";
       
        HomePage home;
        SearchPage search;
        ArticlePage article;
        NewsPage news;
        ContactPage contact;
        PrivacyPolicyPage privacy;

        //Check page front end availability, could be reused, thus a seperate test
        [Test]
        public void WebpageAvailable()
        {
            home.GoToPage();
            Assert.That(home.Logo.Displayed, "Homepage logo is not displayed!");
            Assert.That(home.MoreCustomersButton.Displayed);
        }

        [Test]
        public void SearchForGartnerArticle()
        {
            
            search = home.SearchArticles(searchPhrase);
            Assert.That(search.SearchResultsAll.Count > 1);
            Assert.That(search.SearchResultsAll.Any(article => article.Text.Contains(articleTitle)));

            
        }

        [Test]
        public void EnterSummitArticle()
        {
            article = search.GoToSummitArticle(summitArticle);

            var pageURL = _driver.Url;
            Assert.That(pageURL == correctArticleURL, "URL incorrect! Actual URL: " + pageURL);

            var pageTitle = _driver.Title;
            Assert.That(pageTitle == correctTitle, "Title incorrect! Actual title: " + pageTitle);

            Assert.That(article.articleContent.Displayed, "Article content not displayed!");

        }

        [Test]
        public void NavigateToNews()
        {
            news = article.GoToNewsPage();

            var isArticlePresent = news.IsArticlePresent(articleTitle);
            Assert.That(isArticlePresent, "News article was not found!");
            
        }
        [Test]
        public void NavigateToContact()
        {
            home.GoToPage();
            contact = home.GoToContactPage();
            IWebElement regionButton = contact.FindRegion(region);
            string classBeforeClick = regionButton.GetAttribute("class");
            regionButton.Click();
            Screenshot ss = ((ITakesScreenshot)_driver).GetScreenshot();
            ss.SaveAsFile(AppDomain.CurrentDomain + "\\" + DateTime.Now.ToString("MM_dd_yyyy_HH_mm_ss_fff") + "Omada.png", ScreenshotImageFormat.Png);
            string classAfterClick = regionButton.GetAttribute("class");
            Assert.That(classAfterClick != classBeforeClick, "Region button class did not change after clicking!");
            IWebElement newRegionButton = contact.FindRegion("UK");
            Helpers helper = new Helpers();
            ss.SaveAsFile(AppDomain.CurrentDomain + "\\" + DateTime.Now.ToString("MM_dd_yyyy_HH_mm_ss_fff") + "BeforeHoverOmada.png", ScreenshotImageFormat.Png);
            helper.Hover(_driver, newRegionButton);
            ss.SaveAsFile(AppDomain.CurrentDomain + "\\" + DateTime.Now.ToString("MM_dd_yyyy_HH_mm_ss_fff") + "AfterHoverOmada.png", ScreenshotImageFormat.Png);

        }

        [Test]
        public void PrivacyPolicyLoadsCorrectly()
        {
            var privacyPolicyUrl = home.Privacy.GetAttribute("href");
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.open()");
            _driver.SwitchTo().Window(_driver.WindowHandles.Last());
            _driver.Navigate().GoToUrl(privacyPolicyUrl);
            //check loaded properly TODO
        }

        [Test]
        public void CookieTabClosesCorrectly()
        {

            _driver.SwitchTo().Window(_driver.WindowHandles.First());
            home.CloseCookieTab();
            _driver.SwitchTo().Window(_driver.WindowHandles.Last());
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.close()");
            _driver.SwitchTo().Window(_driver.WindowHandles.First());
            //CHECK IF WAIT IS NEEDED
            Assert.That(home.CookieTabIsPresent(), "Cookie tab is still present after closing!");


        }
        [Test]
        public void CookieTabIsNotPresentAfterReloading()
        {
            _driver.Navigate().Refresh();
            Assert.That(home.CookieTabIsPresent(), "Cookie tab is still present after refreshing!");
        }

        [Test]
        public void CasesPageLoadsCorrectly()
        {

        }
        
    }
}
