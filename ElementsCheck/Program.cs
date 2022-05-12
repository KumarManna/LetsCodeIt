using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using BrowserControl;
using SeleniumExtras.WaitHelpers;

namespace ElementsCheck
{
    class Program:Browser
    {
        public void Start()
        {

            url = "https://courses.letskodeit.com/practice";
            Open_Url();
        }
        public void Drop_Down()
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
        }
        public void MultiSelect()
        {
            By m1 = By.Id("multiple-select-example");
            By m2 = By.XPath("//*[@id='multiple-select-example']/option");
            Multi_Select(m1, m2);
            Thread.Sleep(1000);
        }
        public void Check_Box()
        {
            //*[@id='checkbox-example-div']//child::label[1]/input
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
        }
        public void NewWindow()
        {
            By by = By.Id("openwindow");
            string def_handle = driver.CurrentWindowHandle;
            New_Window(driver, by);
            driver.SwitchTo().Window(def_handle);
            Thread.Sleep(1000);
        }
        public void NewTab()
        {
            By by = By.Id("opentab");
            string def_handle = driver.CurrentWindowHandle;
            New_Tab(driver, by);
            driver.SwitchTo().Window(def_handle);
            Thread.Sleep(1000);
        }
        public void Alert()
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
        }
        public void Enable_Disable()
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
        }
        public void Hide_Show()
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
        }
        public void close()
        {
            close_quit();
            Console.ReadKey();
        }
         public static void Main()
        {
            Program p = new Program();
            p.Start();
            //  p.Drop_Down();
            // p.MultiSelect();
            //p.Check_Box();
            //p.NewWindow();
            // p.NewTab();
            // p.Alert();
            // p.Enable_Disable();
            //  p.Hide_Show();
            p.close();
        } 
    }
}
