using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetManagementSystem_WebApi.Models
{
    public class Software
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Software_Id { get; set; }

        
        [Display(Name = "Software Name")]
        public string? Software_Name { get; set; }
       
        [Display(Name = "Author Name")]
        public string? Software_Author { get; set; }

        [Display(Name = "Date Of Publish")]
        [DataType(DataType.Date)]
        public System.DateTime Date_Of_Publish { get; set; }

        public String? AssignedTo { get; set; }
    }
    
    
}
