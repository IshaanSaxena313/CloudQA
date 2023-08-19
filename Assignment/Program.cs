using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

class Program
{
    static void Main(string[] args)
    {
        // Set up WebDriver
        IWebDriver driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://app.cloudqa.io/home/AutomationPracticeForm");

        try
        {
            // Test the first field (First Name)
            TestTextField(driver, "fname", "John");

            // Test the second field (Last Name)
            TestTextField(driver, "lname", "Doe");

            // Test the third field (Gender - Male radio button)
            TestRadioButton(driver, "male");

            Console.WriteLine("All tests passed!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        finally
        {
            // Close the browser
            driver.Quit();
        }
    }

    //Method for testing fields
    static void TestTextField(IWebDriver driver, string fieldId, string value)
    {
        IWebElement textField = driver.FindElement(By.Id(fieldId));
        textField.Clear();
        textField.SendKeys(value);
    }

    //Meathod for testing radio-button
    static void TestRadioButton(IWebDriver driver, string fieldId)
    {
        IWebElement radioButton = driver.FindElement(By.Id(fieldId));
        radioButton.Click();
    }
}
