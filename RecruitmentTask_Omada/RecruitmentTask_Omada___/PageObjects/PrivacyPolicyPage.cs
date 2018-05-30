using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using System.Linq;

namespace RecruitmentTask_Omada___.PageObjects
{
    class PrivacyPolicyPage:Universal
    {
        public PrivacyPolicyPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        
        [FindsBy(How = How.ClassName, Using = "text__heading", Priority = 0)]
        public IList<IWebElement> PrivacyPolicyHeader;

        public bool IsHeaderPresent(string header)
        {
            var result = PrivacyPolicyHeader.Any(header_ => header_.FindElement(By.TagName("h1")).Text == header);
            return result;
        }
    }
}
