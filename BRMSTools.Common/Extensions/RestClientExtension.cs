using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Net;
using System.Threading.Tasks;

public static class RestClientExtension
{
    public static Task<JObject> RetrieveRecord(this RestClient client, RestRequest request)
    {
        var tcs = new TaskCompletionSource<JObject>();
            
        Console.Write("{0}Trying To Connect To <{1}> URI", Environment.NewLine, client.BaseUrl + request.Resource);    
        
        client.ExecuteAsync(request, response =>
        {
            var jsonObject = new JObject();

            if (response.ErrorException != null)
            {
                // throw new ApplicationException(message, response.ErrorException);/api/errorlog/log
                jsonObject.Add("Status", "Error retrieving response.");
                jsonObject.Add("StatusCode", response.StatusCode.ToString());
                jsonObject.Add("Error", response.ErrorMessage);

                Console.Write("{0}Error Message <{1}> URI", Environment.NewLine, response.ErrorMessage.ToString());
                Console.Write("{0}Error Exception <{1}> URI", Environment.NewLine, response.ErrorException.ToString());

                tcs.SetResult(jsonObject);
            }

            if (response.IsSuccessful())
            {
                Console.Write("{0}Successfully Connected To <{1}> URI", Environment.NewLine, client.BaseUrl + request.Resource);
                
                tcs.SetResult(JObject.Parse(response.Content));
                if (string.IsNullOrWhiteSpace(response.Content))
                {
                    jsonObject.Add("StatusCode", response.StatusCode.ToString());
                    tcs.SetResult(jsonObject);
                }                    
            }
            else
            {
                jsonObject.Add("StatusCode", response.StatusCode.ToString());
                jsonObject.Add("Error", response.ErrorMessage);

                Console.Write("{0}Error Status Code <{1}> URI", Environment.NewLine, response.StatusCode.ToString());
                
                if(response.ErrorMessage != null)
                    Console.Write("{0}Error Message <{1}> URI", Environment.NewLine, response.ErrorMessage.ToString());
                    
                tcs.SetResult(jsonObject);
            }
        });

        return tcs.Task;
    }

    public static Task<string> RetrieveString(this RestClient client, RestRequest request)
    {
        var tcs = new TaskCompletionSource<string>();
        client.ExecuteAsync(request, response =>
        {
            if (response.IsSuccessful())
                tcs.SetResult(response.Content.ToString());
            else
                tcs.SetResult(response.StatusCode.ToString());
        });

        return tcs.Task;
    }

    public static Task<JObject> RetrieveRecordwithContent(this RestClient client, RestRequest request)
    {
        var tcs = new TaskCompletionSource<JObject>();
        client.ExecuteAsync(request, response =>
        {

            if (response.IsSuccessful())
            {
                tcs.SetResult(JObject.Parse(response.Content));
            }
            else
            {
                var jsonObject = new JObject();
                jsonObject.Add("StatusCode", response.StatusCode.ToString());
                jsonObject.Add("ErrorMessage", response.Content.ToString());
                tcs.SetResult(jsonObject);
            }
        });

        return tcs.Task;
    }

    public static Task<JArray> RetrieveRecords(this RestClient client, RestRequest request)
    {
        var tcs = new TaskCompletionSource<JArray>();
        client.ExecuteAsync(request, response =>
        {
            if (response.IsSuccessful())
            {
                tcs.SetResult(JArray.Parse(response.Content));
            }
            else
            {
                JArray array = new JArray();
                var jsonObject = new JObject();
                jsonObject.Add("StatusCode", response.StatusCode.ToString());
                jsonObject.Add("Error", response.ErrorMessage);
                array.Add(jsonObject);
                tcs.SetResult(array);
            }
        });

        return tcs.Task;
    }

    public static bool IsSuccessful(this IRestResponse response)
    {
        return response.StatusCode.IsSuccessStatusCode() && response.ResponseStatus == ResponseStatus.Completed;
    }

    public static bool IsSuccessStatusCode(this HttpStatusCode responseCode)
    {
        return (int)responseCode >= 200 && (int)responseCode <= 399;
    }
}
