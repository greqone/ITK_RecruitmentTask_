using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;


namespace RecruitmentTask_Omada___.Helper
{
    public class Helpers
    {
        public void Hover(IWebDriver driver, IWebElement webelement)
        {
            new Actions(driver)
                .MoveToElement(webelement)
                .Build()
                .Perform();
            
        }
    }
}
