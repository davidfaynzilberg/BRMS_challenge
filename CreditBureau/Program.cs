using System;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Linq;
using BRMSTools.API.v1.Models;
using BRMSTools.Common.RandomEngine;

namespace CreditBureau
{
    class Program
    {
        private const double TIMER_TICK = 10;
        private const string CREDIT_BUREAU_API_URI = "http://localhost:55001";

        static async Task Main(string[] args)
        {
            Console.WriteLine("Fake credit bureau started.");
            Console.WriteLine($"This will DO POST to BRMS API json request every {TIMER_TICK} seconds.");

            while (true)
            {
                string ssn = RandomSSNFromTheList.GetRandomSSN();
                int score = new Random().Next(600, 940);

                Console.Write("{0}Sending ssn <{1}>, score <{2}>", Environment.NewLine, ssn, score);

                string msg = CreateAndSendJsonUpdate(ssn, score);
                
                Console.Write("{0}Returned Status Message <{1}>", Environment.NewLine, msg);
                
                Thread.Sleep((int)(1000 * TIMER_TICK));
            }
        }

        private static string CreateAndSendJsonUpdate(string ssn, int score)
        {
            Console.WriteLine($"\nTick {DateTime.Now}.");

            RestClient client = new RestClient(CREDIT_BUREAU_API_URI);
            RestRequest request = new RestRequest("creditbureau", Method.POST);

            request.AddJsonBody(new CreditBureauRequest
            {
                SSN = ssn,
                Score = score,
            });

            // request.AddHeader("Authorization", "Bearer " + token);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");

            JObject response = new JObject();

            Task.Run(async () =>
            {
                response = await client.RetrieveRecord(request);
            }).Wait();

            string apiStatusCode = response.Value<string>(@"status") + " " + response.Value<string>(@"msg");

            if (!string.IsNullOrEmpty(apiStatusCode) && apiStatusCode.Equals("NotFound"))
            {
                return null;
            }

            return apiStatusCode;
        }
    }
}
