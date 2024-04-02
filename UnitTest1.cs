using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using System.Threading.Tasks;


using System.IO;
using System.Reflection;
using System.Diagnostics;
using static RamblerTest.Selen;
using SeleniumExtras.WaitHelpers;

namespace RamblerTest
{
    [TestFixture, Order(1)]

    class Add
    {
        private App app = new App();
        private IWebDriver driver = null;
        private WebDriverWait wait = null;
        private ChromeOptions options = new ChromeOptions();
        private string descTest = null;

        [SetUp]
        public void TestInit()
        {
            try
            {
                //initialize
                options.AddArguments("start-maximized");
                options.AddArguments("start-fullscreen");
                driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), options);
                wait = new WebDriverWait(driver, app.GetExpectationTime());
                descTest = TestContext.CurrentContext.Test.MethodName;
            }
            catch (Exception eMessage)
            {
                Debug.WriteLine("Exception while starting GoogleChrome" + eMessage);
            }
        }

        [TearDown]
        public void TestCleanUp()
        {
            try
            {
                //exit
                driver.Close();
                driver.Quit();
            }
            catch (Exception eMessage)
            {
                Debug.WriteLine("Exception while stopping GoogleChrome" + eMessage);
            }
        }

        [Test, Order(1)]
        [TestCase("Вставляем логин в поле на почте")]
        public void Logging(string title)
        {
            //стартуем
            driver.Navigate().GoToUrl("https://mail.yandex.ru/?noretpath=1");
            app.Sleep();
            // new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.XPath("//*[@id='index-page-container']/div/div[2]/div/div/div[4]/a[2]/span")));
            // driver.FindElement(By.XPath("//*[@id='index-page-container']/div/div[2]/div/div/div[4]/a[2]/span"));
            // app.Sleep();
            // driver.FindElement(By.XPath("//*[@id='index-page-container']/div/div[2]/div/div/div[4]/a[2]/span")).SendKeys("vpochta1@ro.ru");
            // app.Sleep();
            //FindWebElement(wait, sBy.CssSelector, "#index-page-container > div > div.HeadBanner.with-her > div > div > div.HeadBanner-ButtonsWrapper > a.control.button2.button2_view_classic.button2_size_mail-big.button2_theme_mail-white.button2_type_link.HeadBanner-Button.HeadBanner-Button-Enter.with-shadow").Click();
            //app.Sleep();
            //Заходим на страницу авторизации
            driver.FindElement(By.LinkText("Войти")).Click();
            app.Sleep();
            //FindWebElement(wait, sBy.CssSelector, "#passp-field-login").Click();
            //app.Sleep();
            //Вносим данные логина
            FindWebElement(wait, sBy.CssSelector, "#passp-field-login").SendKeys(Convert.ToString("testpo4tav"));
            app.Sleep();
            FindWebElement(wait, sBy.CssSelector, "#passp-field-login").SendKeys(Keys.Enter);
            app.Sleep();
            //Вводим пароль
            FindWebElement(wait, sBy.CssSelector, "#passp-field-passwd").SendKeys(Convert.ToString("post!vbn"));
            app.Sleep();
            FindWebElement(wait, sBy.CssSelector, "#passp-field-passwd").SendKeys(Keys.Enter);
            app.Sleep();
            //FindWebElement(wait, sBy.CssSelector, "#root > div > div.passp-page > div.passp-flex-wrapper > div > div > div.passp-auth-content > div.passp-route-forward > div > div > form > div:nth-child(3) > button").Click();
            //app.Sleep();
            //Написать - работает
            //FindWebElement(wait, sBy.XPath, "//*[@id='js-apps-container']/div[2]/div[7]/div/div[3]/div[2]/div[1]/div/div/div/a/svg").Click();
            //app.Sleep();
            //FindWebElement(wait, sBy.CssSelector, "#js-apps-container > div.ns-view-app.ns-view-id-66.mail-App.js-mail-App > div.mail-App-Content.js-mail-app-content > div > div.mail-Layout-Inner > div.mail-Layout-Aside.js-layout-left.ui-resizable.mail-Layout-Aside_maximum > div.ns-view-compose-buttons-box.ns-view-id-79 > div > div > div > a").Click();
            //app.Sleep();
            //написать письмо кнопка - рабочее
            driver.FindElement(By.LinkText("Написать")).Click();
            app.Sleep();
            //FindWebElement(wait, sBy.CssSelector, "#js-apps-container > div.ns-view-app.ns-view-id-38.mail-App.js-mail-App > div.ns-view-compose-manager-container-box.ns-view-id-58.mail-ComposeManagerContainer_box > div > div > div.popup2.popup2_view_classic.popup2_theme_normal.popup2_direction_top-center.popup2_nonvisual_yes.popup2_visible_yes.popup2_target_position.popup2_motionless.ComposePopup.ComposePopup_size_large > div > div.ComposePopup-Body > div > div.composeReact.ComposeManager-PopupCompose > div.composeReact__inner > div.composeReact__scrollable-container > div > div.composeReact__scrollable-top-content > div.ComposeRecipients > div.ComposeRecipients-TopRow > div > div > div > div > div").SendKeys(Convert.ToString("vpochta1@list.ru"));
            //xpath - рабочий - адресата вставляет
            FindWebElement(wait, sBy.XPath, "//*[@id='js-apps-container']/div[2]/div[10]/div/div/div[2]/div/div[2]/div/div[1]/div[1]/div[1]/div/div[1]/div[1]/div[1]/div/div/div/div/div").SendKeys(Convert.ToString("vpochta1@list.ru"));
            app.Sleep();
            //Вставляем тему
            FindWebElement(wait, sBy.XPath, "//*[@id='js-apps-container']/div[2]/div[10]/div/div/div[2]/div/div[2]/div/div[1]/div[1]/div[1]/div/div[1]/div[1]/div[3]/div/div/input").SendKeys(Convert.ToString("seleniumTest"));
            app.Sleep();
            //Текст - пишет
            FindWebElement(wait, sBy.CssSelector, "#cke_1_contents > div").SendKeys(Convert.ToString("blablabla"));
            app.Sleep();
            //FindWebElement(wait, sBy.CssSelector, "#js-apps-container > div.ns-view-app.ns-view-id-38.mail-App.js-mail-App > div.ns-view-compose-manager-container-box.ns-view-id-58.mail-ComposeManagerContainer_box > div > div > div.popup2.popup2_view_classic.popup2_theme_normal.popup2_direction_top-center.popup2_nonvisual_yes.popup2_visible_yes.popup2_target_position.popup2_motionless.ComposePopup.ComposePopup_size_large > div > div.ComposePopup-Body > div > div.composeReact.ComposeManager-PopupCompose > div.composeReact__inner > div.composeReact__footer > div > div:nth-child(1) > div.new__root--3qgLa.qa-Compose-ControlPanelButton.ComposeControlPanel-Button.ComposeControlPanel-Button_new.ComposeControlPanel-SendButton.qa-Compose-SendButton.ComposeSendButton.ComposeSendButton_desktop > button").Click();
            //app.Sleep();
            //driver.FindElement(By.LinkText("Отправить")).Click();
            //app.Sleep();
            //Отправить - работает
            FindWebElement(wait, sBy.XPath, "//*[@id='js-apps-container']/div[2]/div[10]/div/div/div[2]/div/div[2]/div/div[1]/div[1]/div[2]/div/div[1]/div[1]/button").Click();
            app.Sleep();
            //Выход из почты
            driver.FindElement(By.LinkText("testpo4tav")).Click();
            app.Sleep();
            driver.FindElement(By.LinkText("Выйти из сервисов Яндекса")).Click();
            app.Sleep();


            //*[@id="js-apps-container"]/div[2]/div[7]/div/div[3]/div[2]/div[1]/div/div/div/a/svg
            //FindWebElement(wait, sBy.ID, "//passp:sign-in").Click();
            //app.Sleep();

            //private readonly By _SignInPassButton = By.XPath("//div[@id='mailbox']/form/button[2]"); //button[contains(.,'Ввести пароль')]
            /* driver.FindElement(By.CssSelector("#index-page-container > div > div.HeadBanner.with-her > div > div > div.HeadBanner-ButtonsWrapper > a.control.button2.button2_view_classic.button2_size_mail-big.button2_theme_mail-white.button2_type_link.HeadBanner-Button.HeadBanner-Button-Enter.with-shadow")).Click();
             app.Sleep();
             new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.CssSelector("# passp-field-login")));
             app.Sleep();
             driver.FindElement(By.CssSelector("# passp-field-login")).Click();
             app.Sleep();
             new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.CssSelector("#passp-field-login")));
             app.Sleep();
             driver.FindElement(By.CssSelector("#passp-field-login")).SendKeys("pochta1vitaliy@yandex.ru");
             app.Sleep(); 
            */
        }

        //Проба для рамблера
        /*
        public class RamblertestTest
        {
            private IWebDriver driver;
            public IDictionary<string, object> vars { get; private set; }
            private IJavaScriptExecutor js;
            [SetUp]
            public void SetUp()
            {
                driver = new ChromeDriver();
                //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                js = (IJavaScriptExecutor)driver;
                vars = new Dictionary<string, object>();
            }
            [TearDown]
            protected void TearDown()
            {
                driver.Quit();
            }
            [Test]
            public void Ramblertest()
            {
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                // Test name: rambler test
                // Step # | name | target | value
                // 1 | open | https://mail.rambler.ru/ | 
                driver.Navigate().GoToUrl("https://mail.rambler.ru/");
                // 2 | setWindowSize | 1478x838 | 
                // 3 | selectFrame | index=1 | 
                //driver.SwitchTo().Frame(1);
                //Task.Delay(5000).Wait();    
                // 3 | waitForElementVisible | id=login | 30000
                {
                    //WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(10));
                    //wait.Until(driver => driver.FindElement(By.XPath("//div[@id='__next']/div/div/div[2]/div/div/div/div/form/section/div/div/div/input")).Enabled);
                    //var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
                    //var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("login")));

                    double waitTime = 10000;
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(waitTime));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("login"))).Click();
                    //SendKeys("John Doe");
                }
            }
            // 4 | waitForElementVisible | id=login | 30000
            //{
            //WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(10));
            //wait.Until(driver => driver.FindElement(By.XPath("//div[@id='__next']/div/div/div[2]/div/div/div/div/form/section/div/div/div/input")).Enabled);
            //}
            // 5 | click | id=login | 
            //driver.FindElement(By.Id("login")).Click();
            //driver.FindElement(By.XPath("//div[@id='__next']/div/div/div[2]/div/div/div/div/form/section/div/div/div/input")).Click();
            // 6 | type | id=login | vpochta1@ro.ru
            //driver.FindElement(By.Id("login")).SendKeys("vpochta1@ro.ru");
            //driver.FindElement(By.XPath("//div[@id='__next']/div/div/div[2]/div/div/div/div/form/section/div/div/div/input")).SendKeys("vpochta1@ro.ru");
            /*
            // 6 | click | id=password | 
            driver.FindElement(By.Id("password")).Click();
            // 7 | type | id=password | Test1pochta@
            driver.FindElement(By.Id("password")).SendKeys("Test1pochta@");
            // 8 | click | css=.rui-Button-content | 
            driver.FindElement(By.CssSelector(".rui-Button-content")).Click();
            // 9 | selectFrame | relative=parent | 
            driver.SwitchTo().DefaultContent();
            // 10 | runScript | window.scrollTo(0,57) | 
            js.ExecuteScript("window.scrollTo(0,57)");
            // 11 | click | css=.rui-Button-content | 
            driver.FindElement(By.CssSelector(".rui-Button-content")).Click();
            // 12 | runScript | window.scrollTo(0,0) | 
            js.ExecuteScript("window.scrollTo(0,0)");
            // 13 | click | id=receivers | 
            driver.FindElement(By.Id("receivers")).Click();
            // 14 | mouseOver | id=mceu_0-button | 
            {
                var element = driver.FindElement(By.Id("mceu_0-button"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element).Perform();
            }
            // 15 | mouseOut | id=mceu_0-button | 
            {
                var element = driver.FindElement(By.TagName("body"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element, 0, 0).Perform();
            }
            // 16 | type | id=receivers | vpochta1@list.ru
            driver.FindElement(By.Id("receivers")).SendKeys("vpochta1@list.ru");
            // 17 | click | id=subject | 
            driver.FindElement(By.Id("subject")).Click();
            // 18 | type | id=subject | theme1
            driver.FindElement(By.Id("subject")).SendKeys("theme1");
            // 19 | selectFrame | index=1 | 
            driver.SwitchTo().Frame(1);
            // 20 | click | css=div | 
            driver.FindElement(By.CssSelector("div")).Click();
            // 21 | editContent | id=tinymce | <div>selen test theme1</div>
            {
                var element = driver.FindElement(By.Id("tinymce"));
                js.ExecuteScript("if(arguments[0].contentEditable === 'true') {arguments[0].innerText = '<div>selen test theme1</div>'}", element);
            }
            // 22 | selectFrame | relative=parent | 
            driver.SwitchTo().DefaultContent();
            // 23 | click | css=.rui-Button-type-primary:nth-child(1) > .rui-Button-content | 
            driver.FindElement(By.CssSelector(".rui-Button-type-primary:nth-child(1) > .rui-Button-content")).Click();
            // 24 | runScript | window.scrollTo(0,0) | 
            js.ExecuteScript("window.scrollTo(0,0)");
        } 
            */
    }
}

