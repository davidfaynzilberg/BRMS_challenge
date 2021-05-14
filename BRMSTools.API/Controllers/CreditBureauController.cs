using BRMSTools.API.v1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BRMSTools.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreditBureauController : ControllerBase
    {
        private readonly ILogger<CreditBureauController> _logger;

        public CreditBureauController(ILogger<CreditBureauController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public ResponseStatus Post([FromBody] CreditBureauRequest creditBureauRequest)
        {
            ResponseStatus responseStatus = new ResponseStatus();
            
            string connectionString = Startup.StaticConfig.GetConnectionString("DbConnection");

            int newScore = creditBureauRequest.Score;
            string customerSSN = creditBureauRequest.SSN;

            Task.Run(() =>
            {
                responseStatus = Helpers.CustomerCRUD.updateScoreRecord(customerSSN, newScore, connectionString);

            }).Wait();

            return responseStatus;
        }
    }
}
