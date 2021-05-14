using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleWebAppMVC.Models
{
    /**
     * Task Model 
     */
    public class Borrower
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [StringLength(50, MinimumLength = 3), Required]
        public string Name { get; set; }

        [StringLength(9)]
        public string SSN { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Today;

        [Required]
        public string Status { get; set; }

        [NotMapped]
        public SelectList StatusCodes { get; } = new SelectList(new List<string> {
            "N/A", "Active", "Not Active"
        });

        [Required]
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }

        [StringLength(50, MinimumLength = 3), Required]
        public string Address { get; set; }

        public string Crimeid { get; set; } = "N/A";

        [Required] 
        public string Score { get; set; }

        public void Update(Borrower task)
        {
            this.Name = task.Name;
            this.SSN = task.SSN;
            this.Date = task.Date;
            this.Status = task.Status;
            this.Crimeid = task.Crimeid;
            this.Score = task.Score;
            this.Dob = task.Dob;
            this.Address = task.Address;
        }
    }
}
