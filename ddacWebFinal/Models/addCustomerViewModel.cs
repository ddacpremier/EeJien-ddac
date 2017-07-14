using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ddacWebFinal.Models
{
    public class addCustomerViewModel
    {
        [Required]
        [Display(Name = "Company Name")]
        public string companyname { get; set; }
        [Required]
        [Display(Name = "Business Type")]
        public string businesstype { get; set; }
        [Required]
        [Display(Name = "Country")]
        public string country { get; set; }
    }
}