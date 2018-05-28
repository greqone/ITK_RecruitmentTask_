using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace RecruitmentTask_Omada___.PageObjects
{
    public class CasesPage:Universal
    {
        public CasesPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }


    }
}
