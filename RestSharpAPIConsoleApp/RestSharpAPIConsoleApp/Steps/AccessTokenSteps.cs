using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using RestSharpAPIConsoleApp.Model;
using RestSharpAPIConsoleApp.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TechTalk.SpecFlow;



namespace RestSharpAPIConsoleApp.Steps
{
    [Binding]
    public class AccessTokenSteps
    {
        [Given(@"I have jwt access token")]
        /* public void GivenIHaveJwtAccessToken()
         {
             var client = new RestClient("http://localhost:300/");
             var request = new RestRequest("auth/login", Method.POST);
             request.RequestFormat = DataFormat.Json;
             request.AddJsonBody(new { email = "bruno@email.com", password = "bruno" });
             var response = client.ExecutePostAsync(request).GetAwaiter().GetResult();
             var access_token = response.DeserializeResponse()["access_token"];
             var jwtAuth= new JwtAuthenticator(access_token);
             client.Authenticator = jwtAuth;
             var getRequest = new RestRequest("products/{id}", Method.GET);
             getRequest.AddUrlSegment("id", 4);
             var result = client.ExecuteGetAsync<Posts>(getRequest).GetAwaiter().GetResult();
             Assert.That(result.Data.name, Is.EqualTo("Product004"), "name is not correct");

         }*/
        public void GivenIHaveJwtAccessTokenWithjsonFile()
        {
           /* var htmlReporter = new ExtentV3HtmlReporter(@"C:\Users\Shanthi\source\repos\RestSharpAPIConsoleApp\RestSharpAPIConsoleApp\ExtentReport.html");
            htmlReporter.Config.Theme = Theme.Dark;
            var extent = new AventStack.ExtentReports.ExtentReports();
            extent.AttachReporter(htmlReporter);

            //Feature

            var feature = extent.CreateTest<Feature>("GetAccesstoken");
            //Scenario
            var scenario = feature.CreateNode<Scenario>("Get access token");
            //Steps
            scenario.CreateNode<Given>("I have jwt access token");


            extent.Flush();

*/
            var client = new RestClient("http://localhost:3000/");
            var request = new RestRequest("auth/login", Method.GET);
            request.RequestFormat = DataFormat.Json;

            var file = @"TestData\Data.json";
            //you need to deserilize the object in order to rest perform the operation
            var jsonData = JsonConvert.DeserializeObject<user>(File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, file)).ToString());
            request.AddJsonBody(jsonData);
            var response = client.ExecutePostAsync(request).GetAwaiter().GetResult();
            var access_token = response.DeserializeResponse()["access_token"];
            var jwtAuth = new JwtAuthenticator(access_token);
            client.Authenticator = jwtAuth;
            var getRequest = new RestRequest("products/{id}", Method.GET);
            getRequest.AddUrlSegment("id", 4);
            var result = client.ExecuteGetAsync<Posts>(getRequest).GetAwaiter().GetResult();
            Assert.That(result.Data.name, Is.EqualTo("Product004"), "name is not correct");

        }

        [When(@"I can see the status")]
        public void WhenICanSeeTheStatus()
        {
            Console.WriteLine("i can see the status");
        }

        
        [Then(@"the result will be shown")]
        public void ThenTheResultWillBeShown()
        {
            Console.WriteLine("the result will be shown");
        }


        private class user
        {
            public string email { get; set; }
            public string password { get; set; }
        }
    }
}
