using System;

namespace AutomationAcceptanceTests.Utils
{
    public class Locators
    {
        /* Point to the base URL of the project */
        public static string baseURL = "https://sandbox-connect-java-7224-dev-ed-1717d3dad92.cs80.force.com/s/";

        public static string ElementLocator(string link)
        {
            var element = "";
            switch (link)
            {
                case "Apply Now":
                    element = "//*[contains(@class, 'comm-navigation__top-level-item-link') and contains(@href, 'start-application')]";
                    break;
                default:
                    Console.WriteLine("Not found");
                    break;
            }
            return element;
        }

        public static string LinksUrlSearch(string page)
        {
            var elementUrl = "";
            switch (page)
            {
                case "Homepage":
                    elementUrl = "";
                    break;
                case "Grants":
                    elementUrl = "start-application";
                    break;
                default:
                    Console.WriteLine("Not found");
                    break;
            }
            return elementUrl;
        }

        public static string TextLocator(string text)
        {
            var textElement = "";
            switch (text)
            {
                case "Example":
                    textElement = "Example";
                    break;
                default:
                    Console.WriteLine("Not found");
                    break;
            }
            return textElement;
        }
    }
}