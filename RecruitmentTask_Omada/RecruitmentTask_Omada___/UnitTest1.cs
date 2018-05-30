using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using RecruitmentTask_Omada___.PageObjects;
using System.Linq;
using RecruitmentTask_Omada___.Helper;
using OpenQA.Selenium.Firefox;

namespace RecruitmentTask_Omada___
{
    [TestFixture(typeof(FirefoxDriver))]
    [TestFixture(typeof(ChromeDriver))]
    public class FrontEndTest<TWebDriver> where TWebDriver : IWebDriver, new()
    {
        string downloadPath = "C:\\Temp";
        private IWebDriver _driver;
        [OneTimeSetUp]
        public void CreateDriver()
        {
            //this._driver = new TWebDriver();

            if(typeof(TWebDriver) == typeof(FirefoxDriver))
            {
                FirefoxProfile firefoxProfile = new FirefoxProfile();
                firefoxProfile.SetPreference("browser.download.folderList", 2);
               
                firefoxProfile.SetPreference("browser.download.dir", downloadPath);
                firefoxProfile.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/zip");

                this._driver = new FirefoxDriver(firefoxProfile);
            }
            else
            {
                ChromeOptions chromeOptions = new ChromeOptions();
                chromeOptions.AddUserProfilePreference("download.default_directory", downloadPath);

                this._driver = new ChromeDriver(chromeOptions);
            }
            _driver.Manage().Window.Maximize();
        }
      
        string searchPhrase = "Gartner";
        string articleTitle = "There is Safety in Numbers";
        string summitArticle = "Gartner IAM Summit 2016 - London";
        //Intentionally did not copy the title 1:1 as it has a typo on "sponser" word
        string correctTitle = "Omada is a sponsor at the Gartner IAM Summit 2016 in London, UK.";
        string correctArticleURL = "https://www.omada.net/en-us/more/news-events/news/gartner-iam-summit-2016-london";
        string region = "U.S West";
        string privacyPolicyHeader = "WEBSITE PRIVACY POLICY";
       
        HomePage home;
        SearchResultsPage search;
        ArticlePage article;
        NewsPage news;
        ContactPage contact;
        PrivacyPolicyPage privacy;
        CasesPage cases;
        CasesSubpage casessub;
        

        //Check page front end availability
        [Test, Order(1)]
        public void WebpageAvailable()
        {
            //due to tests being run in order:
            home = new HomePage(_driver);
            home.GoToPage();
            Assert.Multiple(() =>
            {
                Assert.That(home.Logo.Displayed, "Homepage logo is not displayed!");
               // Assert.That(home.MoreCustomersButton.Displayed, "More customers button is not displayed!");
            });
        }
        //each test should end on one assert for code readability as well as easier troubleshooting, thus that many tests
        [Test, Order(2)]
        public void SearchForGartnerArticle()
        {
            
            search = home.SearchArticles(searchPhrase);
            var asd = search.SearchResultsAll.Select(x => x.Text);
            Assert.Multiple(() =>
            {
                Assert.That(search.SearchResultsAll.Count > 1, "There is 1 or less search results!");
                Assert.That(search.SearchResultsAll.Any(article => article.Text.Contains(articleTitle)), "Article is not present!");
            });
            

            
        }

        [Test, Order(3)]
        public void EnterSummitArticle()
        {
            article = search.GoToSummitArticle(summitArticle);

            var pageURL = _driver.Url;
            Assert.That(pageURL == correctArticleURL, "URL incorrect! Actual URL: " + pageURL);

            var pageTitle = _driver.Title;
            Assert.Multiple(() =>
            {
                Assert.That(pageTitle == correctTitle, "Title incorrect! Actual title: " + pageTitle);

                Assert.That(article.articleContent.Displayed, "Article content not displayed!");

            });
            

        }

        [Test, Order(4)]
        public void NavigateToNews()
        {
            news = article.GoToNewsPage();

            var isArticlePresent = news.IsArticlePresent(articleTitle);
            Assert.That(isArticlePresent, "News article was not found!");
            
        }
        [Test, Order(5)]
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

        [Test, Order(6)]
        public void PrivacyPolicyLoadsCorrectly()
        {
            var privacyPolicyUrl = home.Privacy.GetAttribute("href");
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.open()");
            _driver.SwitchTo().Window(_driver.WindowHandles.Last());
            _driver.Navigate().GoToUrl(privacyPolicyUrl);
            
            var isHeaderPresent_ = privacy.IsHeaderPresent(privacyPolicyHeader);
            Assert.That(isHeaderPresent_, "Privacy Policy header was not found!");
        }

        [Test, Order(7)]
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
        [Test, Order(8)]
        public void CookieTabIsNotPresentAfterReloading()
        {
            _driver.Navigate().Refresh();
            Assert.That(home.CookieTabIsPresent(), "Cookie tab is still present after refreshing!");
        }

        [Test, Order(9)]
        public void DownloadPDFFormLoadedCorrectly()
        {
            home.GoToPage();
            home.GoToCasesPage();
            cases.GoToDownloadForm();
            //TODO check if pdf form is loaded

        }

        [Test, Order(10)]
        public void CanFillOutPDFForm()
        {
            casessub.FillOutPDFForm();
            

        }

        [Test, Order(11)]
        public void DownloadPDFCorrectly()
        {
            casessub.DownloadPDF();

        }
        [OneTimeTearDown]
        public void TearDown()
        {
            _driver.Dispose();
        }
        
    }
}
