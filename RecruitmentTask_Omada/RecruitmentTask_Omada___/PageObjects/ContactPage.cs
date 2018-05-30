using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using System.Linq;

namespace RecruitmentTask_Omada___.PageObjects
{
    public class ContactPage:Universal
    {
        public ContactPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        
        [FindsBy(How = How.ClassName, Using = "tabmenu__menu-item", Priority = 0)]
        public IList<IWebElement> contactPageButtons;

        public IWebElement FindRegion(string name)
        {
            IWebElement region = null;
            try
            {
                region = contactPageButtons.First(button => button.Text == name);
            }
            catch (System.Exception)
            {

               
            }
            return region;
        }

    }
}
