using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharpAPIConsoleApp.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestSharpAPIConsoleApp
{
    [TestClass]
    public class SampleTest
    {
        [TestMethod]
        public void testmethodtest()
        {
            var client = new RestClient("http://localhost:3000/");
            var request = new RestRequest("posts/{postid}", Method.GET);
            request.AddUrlSegment("postid", 1);
            //var content = client.Execute(request).Content;
            var response = client.Execute(request);
            //JsonDeserializer
            /*var deserialize = new JsonDeserializer();
              var output = deserialize.Deserialize<Dictionary<string, string>>(response);
              var result = output["author"];*/
            //other way
            //var result = response.GetResponseObject("author");
            JObject obs = JObject.Parse(response.Content);
            NUnit.Framework.Assert.That(obs.ToString(), Is.EqualTo("typicode"), "Author is not correct");

        }

        [TestMethod]
        public void AuthenticationMechanism()
        {
            var client = new RestClient("http://localhost:3000/");
            var request = new RestRequest("auth/login", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new{ email = "bruno@email.com",password = "bruno"});
            var response = client.ExecutePostAsync(request).GetAwaiter().GetResult();
            var access_token = response.DeserializeResponse()["access_token"];
        }
    }
}
