using AutoMapper.Configuration;
using BRMSTools.API.v1.Models;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace BRMSTools.API.Tests
{
    [TestCaseOrderer("BRMSTools.API.Tests.Helpers.CustomTestCaseOrderer", "BRMSTools.API.Tests")]
    [Collection("API Collection")]
    public class Tests
    {
        private const string CREDIT_BUREAU_API_URI = "http://localhost:55001";

        [SetUp]
        public void Init()
        {
        }

        //[Test]
        //public void Test1()
        //{
        //    Assert.Pass();
        //}

        [Test]
        [Fact, Order(1)]
        public void CreditBureauFunctionTest()
        {
            v1.Models.ResponseStatus responseStatus = new v1.Models.ResponseStatus();

            int newScore = new Random().Next(400, 760);
            string customerSSN = "123456789";

            Task.Run(() =>
            {
                responseStatus = Helpers.CustomerCRUD.updateScoreRecord(customerSSN, newScore, "Database=brmsapp;Server=localhost;Uid=myUser;Pwd=myPass");

            }).Wait();


            Assert.True((responseStatus.Status == $"Borrower with SSN: {customerSSN} updated score to the new value: {newScore}"));

        }
    }
}