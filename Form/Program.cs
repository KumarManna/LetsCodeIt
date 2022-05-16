using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using BrowserControl;
using OpenQA.Selenium;

namespace Form
{
    public class FormTest : Browser
    {
        public void Initialize()
        {
            url = "https://demoqa.com/text-box";
            Open_Url();
        }
        public void Name(string f, string l)
        {
            By Name = By.XPath("//input[@id='userName']");
            Move(driver, Name, f + l);
        }
        public void User_Email(string e)
        {
            By Email = By.XPath("//input[@id='userEmail']");
            Move(driver, Email, e);
        }
        public void C_Adr(string a)
        {
            By cur_adr = By.XPath("//textarea[@id='currentAddress']");
            Move(driver, cur_adr, a);
        }
        public void P_Adr(string p)
        {
            By pf = By.XPath("//textarea[@id='permanentAddress']");
            Move(driver, pf, p);
        }
        public void Submit()
        {
            By submit = By.XPath("//button[@id='submit']");
            Move(driver, submit);
        }
        public void Input()
        {
            Name("fname","lname");
            Thread.Sleep(500);
            User_Email("email@e.com");
            Thread.Sleep(500);
           
            C_Adr("cadr");
            Thread.Sleep(500);
          
            P_Adr("padr");
            Thread.Sleep(500);
            Submit();
            scroll();
            Thread.Sleep(2000);
           

        }
        public void Ouput_Test()
        {
            // [TestCase("A", "M", "a@m.com", "Hooghly", "WB")]
            IReadOnlyCollection<IWebElement> op = driver.FindElements(By.XPath("//*[@id='output']//child::p"));
            List<string> value = new List<string>();
            List<string> key = new List<string>();
            Dictionary<string, string> txt = new Dictionary<string, string>();
            Console.WriteLine(op.Count);
            int i;
            foreach(IWebElement u in op)
            {
                Console.WriteLine(u.Text.Trim());
                i = (u.Text.Trim().IndexOf(":")) + 1;
                key.Add(u.Text.Substring(0, (u.Text.Trim().IndexOf(":"))));
                value.Add(u.Text.Substring(i));
                txt.Add(u.Text.Substring(0, (u.Text.Trim().IndexOf(":"))), u.Text.Substring(i));
            }
            
            foreach(string o in value)
            {
                Console.WriteLine(o);
            }

            foreach (string o in key)
            {
                Console.WriteLine(o);
            }
            foreach(var kv in txt)
            {
                Console.WriteLine(kv.Key+":"+kv.Value);
            }
        }
        public static void Main()
        {
            FormTest ft = new FormTest();
            ft.Initialize();
            ft.Input();
            Thread.Sleep(3000);
            ft.Ouput_Test();
            ft.driver.Navigate().Refresh();

            ft.close_quit();
            Console.ReadKey();
        }
    }
}
