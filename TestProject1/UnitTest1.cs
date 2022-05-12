using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using NUnit.Framework;
using BrowserControl;


namespace Elements
{
    class Program : Browser
    {
        [SetUp]
        public void Start()
        {
            url = "https://courses.letskodeit.com/practice";
            Open_Url();
        }

        [Test, Category("Radio Button")]
        public void Test1()
        {
            //*[@id='radio-btn-example']//child::label[]/input
            int i, j;
            string p = "//*[@id='radio-btn-example']//child::label[";
            By r;
            for (i = 1; i <= 3; i++)
            {
                j = i;
                r = By.XPath(p + j.ToString() + "]/input");
                Move(driver, r);
                Thread.Sleep(100);
            }
            Assert.Pass("Test case 1 passes");
        }
        [Test, Category("select-class-example")]
        public void Test2()
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

            Assert.Pass("TEST CASE 2 PASSED");
        }
        [Test, Category("Multiple Select")]
        public void Test3(){
            By m1 = By.Id("multiple-select-example");
            By m2 = By.XPath("//*[@id='multiple-select-example']/option");
            Multi_Select(m1, m2);
            Thread.Sleep(1000);
            Assert.Pass();
        }
        [Test,Category("Check box")]
        public void Test4()
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
            for (int i = 1; i<= 3; i++)
            {
                by = By.XPath(t1 + i.ToString() + t2);
                Move(driver, by);
                Thread.Sleep(1000);
            }
            Assert.AreEqual("3", box_count.ToString());
        }
        [Test,Category("New Window")]
        public void Test5()
        {
            By by = By.Id("openwindow");
            string def_handle = driver.CurrentWindowHandle;
            New_Window(driver, by);
            driver.SwitchTo().Window(def_handle);
            Thread.Sleep(1000);
            Assert.AreEqual(def_handle, driver.CurrentWindowHandle);
        }
        [Test,Category("New Tab")]
        public void Test6()
        {
            By by = By.Id("opentab");
            string def_handle = driver.CurrentWindowHandle;
            New_Tab(driver, by);
            driver.SwitchTo().Window(def_handle);
            Thread.Sleep(1000);
            Assert.AreEqual(def_handle, driver.CurrentWindowHandle);
        }
        [Test,Category("Alert")]
        public void Test7()
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
            Assert.Pass();
        }
        [Test,Category("Enable-Disable")]
        public void Test8()
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
            Assert.Pass();
        }
        [Test,Category("Hide_Show")]
        public void Test9()
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
            Assert.Pass();
        }
        [TearDown]
        public void End()
        {
            close_quit();
        }
    }
}
