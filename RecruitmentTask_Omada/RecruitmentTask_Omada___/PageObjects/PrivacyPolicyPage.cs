using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace RecruitmentTask_Omada___.PageObjects
{
    class PrivacyPolicyPage:Universal
    {
        public PrivacyPolicyPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsByAll]
        [FindsBy(How, How = How.ClassName, Using = "text__heading", Priority = 0)]

    }
}
