using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace RecruitmentTask_Omada___.PageObjects
{
    class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.ClassName, Using = "header__logo")]
        private IWebElement Logo;

        [FindsByAll]
        [FindsBy(How = How.ClassName, Using = "clientbar__button button--variant2", Priority 0)]
        [FindsBy(How = How.PartialLinkText, Using = "customers", Priority 1)]
        private IWebElement MoreCustomersButton;
        
        public void GoToPage()
        {
            driver.Navigate().GoToUrl("https://www.omada.net");
            var HomepageLoadedCorrectly;
            
            if (Logo != null && MoreCustomersButton != null)
            {
                HomepageLoadedCorrectly = true;
            }
            else
            {
                HomepageLoadedCorrectly = false;
            }

            Assert.That(HomepageLoadedCorrectly == true);

            

            
        }

       
    }
}
