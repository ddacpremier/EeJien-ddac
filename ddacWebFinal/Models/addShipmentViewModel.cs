using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ddacWebFinal.Models
{
    public class addShipmentViewModel
    {
        [Required]
        [Display(Name = "Destination")]
        public string destination { get; set; }
        [Required]
        [Display(Name = "Departure")]
        public string departure { get; set; }
        [Required]
        [Display(Name = "Date")]
        public string date { get; set; }
        [Required]
        [Display(Name = "Weight")]
        public string weight { get; set; }
        [Required]
        [Display(Name = "Status")]
        public string status { get; set; }
    }
}