﻿using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace RecruitmentTask_Omada___.PageObjects
{
    public class CasesSubpage
    {
        public CasesSubpage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        
        [FindsBy(How = How.Id, Using = "f_84ef53b4f80ee71180eac4346bac2ebc")]
        public IWebElement JobTitleField;

        
        [FindsBy(How = How.Id, Using = "f_7bb79f2f2aa5e61180e4c4346bac7e3c")]
        public IWebElement FirstNameField;

      
        [FindsBy(How = How.Id, Using = "f_501281762aa5e61180e4c4346bac7e3c")]
        public IWebElement LastNameField;

       
        [FindsBy(How = How.Id, Using = "f_511a8b932aa5e61180e4c4346bac7e3c")]
        public IWebElement EmailField;

       
        [FindsBy(How = How.Id, Using = "f_5d3af1ac19a8e61180dfc4346bad20a4")]
        public IWebElement BusinessPhoneField;

       
        [FindsBy(How = How.Id, Using = "f_42b109e9c1a5e61180e4c4346bac7e3c")]
        public IWebElement CompanyNameField;

       
        [FindsBy(How = How.Id, Using = "f_61d4da016ca6e61180dfc4346bad20a4")]
        public IWebElement CountryField;

       
        [FindsBy(How = How.Id, Using = "f_3557f512c2a5e61180e4c4346bac7e3c")]
        public IWebElement AcceptCheckBox;

        [FindsBy(How = How.Id, Using = "btnSubmit")]
        public IWebElement FinalDownloadPDFButton;
    }
}
