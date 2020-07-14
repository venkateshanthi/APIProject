using RestSharp;
using RestSharp.Authenticators;
using RestSharpAPIConsoleApp.Base;
using RestSharpAPIConsoleApp.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace RestSharpAPIConsoleApp
{
    [Binding]
   
    public class CommonSteps
    {
        Settings settings;
        public CommonSteps(Settings settings)
        {
            this.settings = settings;

        }

        [Given(@"I get Jwt authentication of user with following details")]
        public void GivenIGetJwtAuthenticationOfUserWithFollowingDetails(Table table)
        {
            settings.RestClient.BaseUrl = new System.Uri("http://localhost:3000/");
            dynamic data = table.CreateDynamicInstance();

            settings.request = new RestRequest("auth/login", Method.GET);
            settings.request.RequestFormat = DataFormat.Json;
            settings.request.AddJsonBody(new { email = (string)data.email, password = (string)data.password });

            //get access token
            settings.Response = settings.RestClient.ExecutePostAsync(settings.request).GetAwaiter().GetResult();
            var access_token = settings.Response.GetResponseObject("access_token");

            //Authentication
            var authenticator = new JwtAuthenticator(access_token);
            settings.RestClient.Authenticator = authenticator;

        }

    }
}
