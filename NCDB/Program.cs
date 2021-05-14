using System;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Linq;
using BRMSTools.API.v1.Models;
using BRMSTools.Common.RandomEngine;

namespace NCDB
{
    class Program
    {
        private const double TIMER_TICK = 10;
        private const string CREDIT_BUREAU_API_URI = "http://localhost:55001";

        static async Task Main(string[] args)
        {
            Console.WriteLine("Fake National Crime Database started.");
            Console.WriteLine($"This will DO POST to BRMS API json request every {TIMER_TICK} seconds.");

            while (true)
            {
                string ssn = RandomSSNFromTheList.GetRandomSSN();
                int crimeId = new Random().Next(1000, 2000);

                Console.Write("{0}Sending ssn <{1}>, crime id <{2}>", Environment.NewLine, ssn, crimeId);

                string msg = CreateAndSendJsonUpdate(ssn, crimeId);

                Console.Write("{0}Returned Status Message <{1}>", Environment.NewLine, msg);

                Thread.Sleep((int)(1000 * TIMER_TICK));
            }
        }

        private static string CreateAndSendJsonUpdate(string ssn, int crimeId)
        {
            Console.WriteLine($"\nTick {DateTime.Now}.");

            RestClient client = new RestClient(CREDIT_BUREAU_API_URI);
            RestRequest request = new RestRequest("nationalcrime", Method.POST);

            request.AddJsonBody(new NationalCrimeRequest
            {
                SSN = ssn,
                CrimeId = crimeId,
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
