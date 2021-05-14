using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BRMSTools.API.v1.Models
{
    public class CreditBureauRequest
    {

        [Required]
        public int Score { get; set; }

        [Key]
        public string SSN { get; set; }
    }
}
