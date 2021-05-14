using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BRMSTools.API.v1.Models;
using Microsoft.Extensions.Logging;

namespace BRMSTools.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NationalCrimeController : ControllerBase
    {
        private readonly ILogger<CreditBureauController> _logger;

        public NationalCrimeController(ILogger<CreditBureauController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public ResponseStatus Post([FromBody] NationalCrimeRequest nationalCrimeRequest)
        {
            ResponseStatus responseStatus = new ResponseStatus();

            int crimeId = nationalCrimeRequest.CrimeId;
            string customerSSN = nationalCrimeRequest.SSN;

            Task.Run(() =>
            {
                responseStatus = Helpers.CustomerCRUD.updateCrimeRecord(customerSSN, crimeId);

            }).Wait();

            return responseStatus;
        }
    }
}
