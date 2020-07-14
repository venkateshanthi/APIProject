using RestSharp;
using RestSharpAPIConsoleApp.Base;
using RestSharpAPIConsoleApp.Model;
using RestSharpAPIConsoleApp.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace RestSharpAPIConsoleApp.Steps
{
    [Binding]
    public class PostProfileSteps

    {
        private Settings _settings;
        public PostProfileSteps(Settings settings) => _settings = settings;
        [Given(@"I perform post operation for ""(.*)"" with body")]
        public void GivenIPerformPostOperationForWithBody(string url, Table table)
        {
            _settings.RestClient.BaseUrl = new System.Uri("http://localhost:3000/");
             dynamic data = table.CreateDynamicInstance();
            _settings.request = new RestRequest(url, Method.POST);
            _settings.request.RequestFormat = DataFormat.Json;
            _settings.request.AddBody(new { name = data.name.ToString() });
            _settings.request.AddUrlSegment("postid", ((int)data.id).ToString());
            _settings.Response = _settings.RestClient.ExecusteAsyncRequest<Posts>(_settings.request).GetAwaiter().GetResult();

            }

    }
}
