using System;
using System.Collections.ObjectModel;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace RamblerTest
{
    static class Selen
    {
        static public IWebElement FindWebElement(IWebDriver driver, sBy identify, string locator)
        {
            switch (identify)
            {
                case sBy.CssSelector:
                    {
                        return driver.FindElement(By.CssSelector(locator));
                    }
                case sBy.XPath:
                    {
                        return driver.FindElement(By.XPath(locator));
                    }
                case sBy.ID:
                    {
                        return driver.FindElement(By.Id(locator));
                    }
                case sBy.TagName:
                    {
                        return driver.FindElement(By.TagName(locator));
                    }
                default: return null;
            }
        }

        static public ReadOnlyCollection<IWebElement> FindWebElements(WebDriverWait wait, sBy identify, string locator)
        {
            switch (identify)
            {
                case sBy.CssSelector:
                    {
                        return wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.CssSelector(locator)));
                    }
                case sBy.XPath:
                    {
                        return wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(locator)));
                    }
                case sBy.ID:
                    {
                        return wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.Id(locator)));
                    }
                case sBy.TagName:
                    {
                        return wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.TagName(locator)));
                    }
                default: return null;
            }
        }
        static public ReadOnlyCollection<IWebElement> FindWebElements(IWebDriver driver, sBy identify, string locator)
        {
            switch (identify)
            {
                case sBy.CssSelector:
                    {
                        return driver.FindElements(By.CssSelector(locator));
                    }
                case sBy.XPath:
                    {
                        return driver.FindElements(By.XPath(locator));
                    }
                case sBy.ID:
                    {
                        return driver.FindElements(By.Id(locator));
                    }
                case sBy.TagName:
                    {
                        return driver.FindElements(By.TagName(locator));
                    }
                default: return null;
            }
        }
        static public void ClickOnWebElement(IWebDriver driver, sBy identify, string locator)
        {
            switch (identify)
            {
                case sBy.CssSelector:
                    {
                        driver.FindElement(By.CssSelector(locator)).Click();
                        break;
                    }
                case sBy.XPath:
                    {
                        driver.FindElement(By.XPath(locator)).Click();
                        break;
                    }
                case sBy.ID:
                    {
                        driver.FindElement(By.Id(locator)).Click();
                        break;
                    }
                case sBy.TagName:
                    {
                        driver.FindElement(By.TagName(locator)).Click();
                        break;
                    }
            }
        }
        static public void ClickOnWebElement(WebDriverWait wait, sBy identify, string locator)
        {
            switch (identify)
            {
                case sBy.CssSelector:
                    {
                        wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(locator))).Click();
                        break;
                    }
                case sBy.XPath:
                    {
                        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(locator))).Click();
                        break;
                    }
                case sBy.ID:
                    {
                        wait.Until(ExpectedConditions.ElementIsVisible(By.Id(locator))).Click();
                        break;
                    }
                case sBy.TagName:
                    {
                        wait.Until(ExpectedConditions.ElementIsVisible(By.TagName(locator))).Click();
                        break;
                    }
            }
        }
        static public IWebElement FindWebElement(WebDriverWait wait, sBy identify, string locator)
        {
            switch (identify)
            {
                case sBy.CssSelector:
                    {
                        return wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(locator)));
                    }
                case sBy.XPath:
                    {
                        return wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(locator)));
                    }
                case sBy.ID:
                    {
                        return wait.Until(ExpectedConditions.ElementIsVisible(By.Id(locator)));
                    }
                case sBy.TagName:
                    {
                        return wait.Until(ExpectedConditions.ElementIsVisible(By.TagName(locator)));
                    }
                default: return null;
            }
        }
        public enum sBy
        {
            CssSelector,
            XPath,
            ID,
            TagName
        }
        public enum Attr
        {
            Value,
            Text,
            Index
        }
        static public void SelectChangeByAttr(IWebElement select, Attr attribute, string value)
        {
            SelectElement selectElement = new SelectElement(select);
            switch (attribute)
            {
                case Attr.Value:
                    {
                        selectElement.SelectByValue(value);
                        break;
                    }
                case Attr.Text:
                    {
                        selectElement.SelectByText(value);
                        break;
                    }
                case Attr.Index:
                    {
                        selectElement.SelectByIndex(Convert.ToInt32(value));
                        break;
                    }
            }
        }
        static public void SwitchToFrame(IWebDriver driver, IWebElement frame)
        {
            driver.SwitchTo().Frame(frame);
        }
        static public void GoToURL(IWebDriver driver, string url)
        {
            driver.Navigate().GoToUrl("https://mail.yandex.ru/?noretpath=1");
        }
        static public void SendTextElement(IWebDriver driver, sBy identify, string locator, string text)
        {
            switch (identify)
            {
                case sBy.CssSelector:
                    {
                        driver.FindElement(By.CssSelector(locator)).SendKeys(text);
                        break;
                    }
                case sBy.XPath:
                    {
                        driver.FindElement(By.XPath(locator)).SendKeys(text);
                        break;
                    }
                case sBy.ID:
                    {
                        driver.FindElement(By.Id(locator)).SendKeys(text);
                        break;
                    }
                case sBy.TagName:
                    {
                        driver.FindElement(By.TagName(locator)).SendKeys(text);
                        break;
                    }
            }
        }
        static public void SendTextElement(WebDriverWait wait, sBy identify, string locator, string text)
        {
            switch (identify)
            {
                case sBy.CssSelector:
                    {
                        wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(locator))).SendKeys(text);
                        break;
                    }
                case sBy.XPath:
                    {
                        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(locator))).SendKeys(text);
                        break;
                    }
                case sBy.ID:
                    {
                        wait.Until(ExpectedConditions.ElementIsVisible(By.Id(locator))).SendKeys(text);
                        break;
                    }
                case sBy.TagName:
                    {
                        wait.Until(ExpectedConditions.ElementIsVisible(By.TagName(locator))).SendKeys(text);
                        break;
                    }
            }
        }
        static public void WaitAlert(IWebDriver driver)
        {
            for (; ; )
            {
                try
                {
                    driver.SwitchTo().Alert().Accept();
                    break;
                }
                catch { }
                Thread.Sleep(500);
            }
        }
        static public void Sleep(int delay)
        {
            Thread.Sleep(delay);
        }
        static public bool CheckDisableElement(IWebDriver driver, sBy method, string locator)
        {
            try
            {
                FindWebElement(driver, method, locator);
                return false;
            }
            catch
            {
                return true;
            }
        }
        static public void WaitStalenessOf(IWebDriver driver, sBy method, string locator)
        {
            for (; ; )
            {
                try
                {
                    FindWebElement(driver, method, locator);
                }
                catch
                {
                    break;
                }
                Sleep(1000);
            }
        }
        static public void ClickOn(this IWebElement button)
        {
            while (true)
            {
                if (button.Displayed == true)
                {
                    button.Click();
                }
            }
        }
    }
}
