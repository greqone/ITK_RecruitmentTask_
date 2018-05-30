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

        [FindsBy(How = How.PartialLinkText, Using = "Customers")]
        public IWebElement MoreCustomersButton;

        [FindsBy(How = How.TagName, Using = "body")]
        public IWebElement SearchBar;

        public void GoToPage()
        {
            driver.Navigate().GoToUrl("https://www.omada.net");
        
            

            
        }

        


    }
}
