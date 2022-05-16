using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using NUnit.Framework;
using BrowserControl;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;


namespace Elements
{
    class Program : Browser
    {
        public static ExtentTest Test;
        public static ExtentReports Extent;

        [OneTimeSetUp]
        public void Start()
        {
            url = "https://courses.letskodeit.com/practice";
            Open_Url();
        }

        [OneTimeSetUp]
        public void ExtentStart()
        {
            Extent = new ExtentReports();

            var HTMLReporter = new ExtentHtmlReporter(@"D:\Bassetti Training\TestingReports\" + DateTime.Now.ToString("__MMddyyyy_hhmmtt") + ".html");
            Extent.AttachReporter(HTMLReporter);
        }

        [Test, Category("Radio Button")]
        public void Test1()
        {
            //*[@id='radio-btn-example']//child::label[]/input
            int i, j;
            Test = null;
            Test = Extent.CreateTest("T001").Info("Radio Button Test");
            try
            {
                string p = "//*[@id='radio-btn-example']//child::label[";
                By r;
                for (i = 1; i <= 3; i++)
                {
                    j = i;
                    r = By.XPath(p + j.ToString() + "]/input");
                    Move(driver, r);
                    Thread.Sleep(100);

                }
                Test.Log(Status.Pass, "Test Passed");
            }
            catch (Exception)
            {
                Test.Log(Status.Fail, "Test Failed");
                throw;
            }
            Assert.Pass("Test case 1 passes");
        }
        [Test, Category("select-class-example")]
        public void Test2()
        {
            Test = null;
            Test = Extent.CreateTest("T002").Info("Drop Down Test");
            try
            {
                
                By d = By.XPath("//*[@id='carselect']/option");
                Move(driver, By.XPath("//*[@id='carselect']"));
                Thread.Sleep(1000);

                drop_down_list(d, "BMW");
                Thread.Sleep(1000);

                drop_down_list(d, "Benz");
                Thread.Sleep(1000);

                drop_down_list(d, "Honda");
                Thread.Sleep(1000);

                Test.Log(Status.Pass, "Test Passed");

            }
            catch (Exception)
            {
                Test.Log(Status.Fail, "Test Failed");
                throw;
            }
        }
        [Test, Category("Multiple Select")]
        public void Test3(){
            Test = null;
            Test = Extent.CreateTest("T003").Info("Drop Down Test");
            try
            {
                
                By m1 = By.Id("multiple-select-example");
                By m2 = By.XPath("//*[@id='multiple-select-example']/option");
                Multi_Select(m1, m2);
                Thread.Sleep(1000);
           
                Test.Log(Status.Pass, "Test Passed");
            }
            catch (Exception)
            {
                Test.Log(Status.Fail, "Test Failed");
                throw;
            }
        }
        [Test,Category("Check box")]
        public void Test4()
        {
            Test = null;
            Test = Extent.CreateTest("T004").Info("Check Box");
            try
            {
               
                string t1 = "//*[@id='checkbox-example-div']//child::label[";
                string t2 = "]/input";
                By by;
                IReadOnlyCollection<IWebElement> l = driver.FindElements(By.XPath("//*[@id='checkbox-example-div']//child::label"));
                int box_count = l.Count;
                Console.WriteLine(box_count);
                for (int i = 1; i <= 3; i++)
                {
                    by = By.XPath(t1 + i.ToString() + t2);
                    Move(driver, by);
                    Thread.Sleep(1000);
                }
                for (int i = 1; i <= 3; i++)
                {
                    by = By.XPath(t1 + i.ToString() + t2);
                    Move(driver, by);
                    Thread.Sleep(1000);
                }
                //Assert.AreEqual("3", box_count.ToString());
                Test.Log(Status.Pass, "Test Passed");
            }
            catch (Exception)
            {
                Test.Log(Status.Fail, "Test Failed");
                throw;
            }
        }
        [Test,Category("New Window")]
        public void Test5()
        {
            Test = null;
            Test = Extent.CreateTest("T006").Info("New Window Test");
            try
            {
              
                By by = By.Id("openwindow");
                string def_handle = driver.CurrentWindowHandle;
                New_Window(driver, by);
                driver.SwitchTo().Window(def_handle);
                Thread.Sleep(1000);
               // Assert.AreEqual(def_handle, driver.CurrentWindowHandle);
                Test.Log(Status.Pass, "Test Passed");
            }
            catch (Exception)
            {
                Test.Log(Status.Fail, "Test Failed");
                throw;
            }
        }
        [Test, Category("New Tab")]
        public void Test6()
        {
            Test = null;
            Test = Extent.CreateTest("T007").Info("New Tab Test");
            try {
                By by = By.Id("opentab");
                string def_handle = driver.CurrentWindowHandle;
                New_Tab(driver, by);
                driver.SwitchTo().Window(def_handle);
                Thread.Sleep(1000);
              //  Assert.AreEqual(def_handle, driver.CurrentWindowHandle);
                Test.Log(Status.Pass, "Test Passed");
            }
            catch (Exception)
            {
                Test.Log(Status.Fail, "Test Failed");
                throw;
            }
         }
        [Test,Category("Alert")]
        public void Test7()
        {
            Test = null;
            Test = Extent.CreateTest("T008").Info("Alert Test");
            try
            {
                By by = By.Id("name");
                Move(driver, by, "Abhijit");
                Thread.Sleep(500);
                By alrt_btn = By.Id("alertbtn");
                Alert_Ok(alrt_btn);

                Move(driver, by, "Manna");
                Thread.Sleep(500);
                By confrm_btn = By.Id("confirmbtn");
                Alert_Ok(confrm_btn);
              //  Assert.Pass();
                Test.Log(Status.Pass, "Test Passed");
            }
            catch (Exception)
            {
                Test.Log(Status.Fail, "Test Failed");
                throw;
            }
        }
        [Test,Category("Enable-Disable")]
        public void Test8()
        {
            Test = null;
            Test = Extent.CreateTest("T010").Info("Enable Disable Test");
            try
            {
                By disable = By.XPath("//*[@id='enabled-example-div']//child::input[1]");
                Move(driver, disable);
                Thread.Sleep(500);
                By enable = By.XPath("//*[@id='enabled-example-div']//child::input[2]");
                Move(driver, enable);
                Thread.Sleep(1000);
                By send_txt = By.XPath("//*[@id='enabled-example-div']//child::input[3]");
                Move(driver, send_txt, "Hi");
                Thread.Sleep(5000);
               // Assert.Pass();
                Test.Log(Status.Pass, "Test Passed");
            }
            catch (Exception)
            {
                Test.Log(Status.Fail, "Test Failed");
                throw;
            }

        }
        [Test,Category("Hide_Show")]
        public void Test9()
        {
            Test = null;
            Test = Extent.CreateTest("T011").Info("Hide Show Test");
            try
            {
                scroll();
                By hide = By.XPath("//*[@id='hide-show-example-div']//child::input[1]");
                Move(driver, hide);
                Thread.Sleep(2000);
                By show = By.XPath("//*[@id='hide-show-example-div']//child::input[2]");
                Move(driver, show);
                Thread.Sleep(500);
                By send_txt = By.XPath("//*[@id='hide-show-example-div']//child::input[3]");
                Move(driver, send_txt, "Hi,Hello");
                Thread.Sleep(1000);
               /// Assert.Pass();
                Test.Log(Status.Pass, "Test Passed");
            }
            catch (Exception)
            {
                Test.Log(Status.Fail, "Test Failed");
                throw;
            }
        }
        [OneTimeTearDown]
        public void End()
        {
            Extent.Flush();
            close_quit();
        }
    }
}
