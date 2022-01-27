using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;
using System.IO;


//Try catch for any possible error
try
{
    // Create or open a .txt file named "languages_enumeration.txt". Its in "using" statement for closing it automatically
    using (StreamWriter sw = new StreamWriter("languages_enumeration.txt"))
    {
        // Using for close and quit driver successfully
        using (IWebDriver driver = new ChromeDriver())
        {
            // Minimize the window just for personal confort
            driver.Manage().Window.Minimize();

            // Go to url
            driver.Navigate().GoToUrl("https://translate.google.com");

            // Do click on "select lenguages" button for load all available language on the page
            driver.FindElement(By.XPath("/html/body/c-wiz/div/div[2]/c-wiz/div[2]/c-wiz/div[1]/div[1]/c-wiz/div[1]/c-wiz/div[2]/button")).Click();

            // Get all labels on which are contained lenguage code and language name
            IWebElement element = driver.FindElement(By.XPath("/html/body/c-wiz/div/div[2]/c-wiz/div[2]/c-wiz/div[1]/div[1]/c-wiz/div[2]/c-wiz/div[1]/div/div[3]/div/div[3]"));
            ReadOnlyCollection<IWebElement> lenguagesElements = element.FindElements(By.ClassName("qSb8Pe"));


            foreach (IWebElement e in lenguagesElements)
            {
                // Get the real name and the code of language
                string realLenguage = e.FindElement(By.ClassName("Llmcnf")).Text;
                string lenguageCode = e.GetAttribute("data-language-code");

                // Write the language on the txt file
                sw.WriteLine("/// <summary>");
                sw.WriteLine("/// " + realLenguage);
                sw.WriteLine("/// </summary>");
                sw.WriteLine(lenguageCode + ",");
            }
        }
    }
}
catch (Exception e)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("An error occurred: ");
    Console.WriteLine(e.Message);
}
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Press any key to close this window");
Console.ReadKey();