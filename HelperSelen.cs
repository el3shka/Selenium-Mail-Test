using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.Extensions;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;


using static RamblerTest.Selen;
    
    namespace RamblerTest
{
    static class HelperSelen
    {
        static public IWebElement ElementExistsWait(WebDriverWait wait, sBy identify, string locator)
        {
            try
            {
                switch (identify)
                {
                    case sBy.CssSelector:
                        {
                            return wait.Until(ExpectedConditions.ElementExists(By.CssSelector(locator)));
                        }
                    case sBy.XPath:
                        {
                            return wait.Until(ExpectedConditions.ElementExists(By.XPath(locator)));
                        }
                    case sBy.ID:
                        {
                            return wait.Until(ExpectedConditions.ElementExists(By.Id(locator)));
                        }
                    case sBy.TagName:
                        {
                            return wait.Until(ExpectedConditions.ElementExists(By.TagName(locator)));
                        }
                    default: return null;
                }
            }
            catch (WebDriverTimeoutException)
            {
                return null;
            }
            }
        }
    }