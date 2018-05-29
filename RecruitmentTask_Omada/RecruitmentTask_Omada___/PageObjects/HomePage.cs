using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace RecruitmentTask_Omada___.PageObjects
{
    public class HomePage:Universal
    {
        
        public HomePage(IWebDriver driver):base(driver)
        {
            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.ClassName, Using = "header__logo")]
        public IWebElement Logo;

        [FindsByAll]
        [FindsBy(How = How.ClassName, Using = "clientbar__button button--variant2", Priority = 0)]
        [FindsBy(How = How.PartialLinkText, Using = "customers", Priority = 1)]
        public IWebElement MoreCustomersButton;

        [FindsBy(How = How.TagName, Using = "body")]
        public IWebElement SearchBar;

        public void GoToPage()
        {
            driver.Navigate().GoToUrl("https://www.omada.net");
           /* var HomepageLoadedCorrectly;
            
            if (Logo != null && MoreCustomersButton != null)
            {
                HomepageLoadedCorrectly = true;
            }
            else
            {
                HomepageLoadedCorrectly = false;
            }

            //Assert.That(HomepageLoadedCorrectly == true);
            */
            

            
        }

        


    }
}
