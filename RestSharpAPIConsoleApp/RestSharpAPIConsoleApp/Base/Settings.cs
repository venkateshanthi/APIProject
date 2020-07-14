using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using RestSharp;
using RestSharpAPIConsoleApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestSharpAPIConsoleApp.Base
{
    public class Settings
    {
        public Uri BaseUrl { get; set; }
        public RestClient RestClient { get; set; } = new RestClient();
        public IRestRequest request { get; set; }
        public IRestResponse Response { get; set; }

        public RemoteWebDriver Driver { get; set; }

    }
        /*public MediaEntityModelProvider CaptureScreenshotAndReturnModel(string Name)
        {
            var screenshot = ((ITakesScreenshot)Driver).GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, Name).Build();
        }*/
    }
