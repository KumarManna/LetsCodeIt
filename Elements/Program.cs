using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;
using BrowserControl;


namespace Elements
{
    class Program:Browser
    {
        [SetUp]
        public void Start()
        {
            url = "https://courses.letskodeit.com/practice";
            Open_Url();
        }

        [Test,Category("Radio Button")]
        public void Test1()
        {
            //*[@id='radio-btn-example']//child::label[]/input
            int i,j;
            string p = "//*[@id='radio-btn-example']//child::label[";
            By r;
            for (i = 1; i <= 3; i++)
            {
                j = i;
                r = By.XPath(p + j.ToString() + "]/input");
                Move(driver, r);
            }
           // By r=By.XPath("//*[@id='radio-btn-example']//child::label[")
        }

        [TearDown]
        public void End()
        {
            close_quit();
        }
    }
}
