using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetManagementSystem_WebApi.Models
{
    public class Hardware
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Model_No { get; set; }

        [Display(Name = "Hardware Type")]
        public string? Hardware_Type { get; set; }

        [Display(Name = "Publishing Date")]
        [DataType(DataType.Date)]
        public System.DateTime Date_of_Publish { get; set; }
       
        [Display(Name = "Hardware Price")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public string? AssignedTo { get; set; }

    }
}
