using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpAPIConsoleApp.Utilities
{
    public static class Library
    {

        public static Dictionary<string, string> DeserializeResponse(this IRestResponse restResponse)
        {
            var JSONObj = new JsonDeserializer().Deserialize<Dictionary<string, string>>(restResponse);
            return JSONObj;
        }

        public static async Task<IRestResponse<T>> ExecusteAsyncRequest<T>(this RestClient client, IRestRequest request) where T : class, new()
        {

            var taskCompletionSource = new TaskCompletionSource<IRestResponse<T>>();
            client.ExecuteAsync<T>(request, restresponse =>
            {
                if (restresponse.ErrorException != null)
                {
                    const string message = "Error retrieving response";
                    throw new ApplicationException(message, restresponse.ErrorException);
                }

                taskCompletionSource.SetResult(restresponse);
            });

            return await taskCompletionSource.Task;

        }

        public static string GetResponseObject(this IRestResponse response, string responseObject)
        {

            JObject obs = JObject.Parse(response.Content);
            return obs[responseObject].ToString();
        }
    }
}
