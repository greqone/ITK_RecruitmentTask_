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

        [FindsByAll]
        [FindsBy(How = How.ClassName, Using = "cases__button button--variant2", Priority = 0)]
        [FindsBy(How = How.PartialLinkText, Using = "Download PDF", Priority = 1)]
        public IList<IWebElement> downloadButton;

        public void GoToDownloadForm()
        {
            downloadButton.First().Click();

        }


    }
}
