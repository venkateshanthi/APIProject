using NUnit.Framework;
using RestSharp;
using RestSharpAPIConsoleApp.Base;
using RestSharpAPIConsoleApp.Model;
using RestSharpAPIConsoleApp.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace RestSharpAPIConsoleApp.Steps
{
    [Binding]
    public class GetSteps
    {
        private Settings _settings;
        public GetSteps(Settings settings) => _settings = settings;

        [Given(@"I perform GET operation for ""(.*)""")]
        public void GivenIPerformGETOperationFor(string url)
        {
            _settings.RestClient.BaseUrl = new System.Uri("http://localhost:3000/");
            _settings.request = new RestRequest(url, Method.GET);

        }

        [Given(@"I perform operation for post ""(.*)""")]
        public void GivenIPerformOperationForPost(int postid)
        {
            _settings.request.AddUrlSegment("postid", postid);
            _settings.Response = _settings.RestClient.ExecusteAsyncRequest<Posts>(_settings.request).GetAwaiter().GetResult();
        }

        [Then(@"I should see the ""(.*)"" name as ""(.*)""")]
        public void ThenIShouldSeeTheNameAs(string key, string value)
        {
            Assert.That(_settings.Response.GetResponseObject(key), Is.EqualTo(value));
        }
       
    }
}
