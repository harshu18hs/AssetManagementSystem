using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetManagementSystem_WebApi.Models
{
    public class Book
    {
       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

            [Display(Name = "Book Name")]
            public string? Name { get; set; }

            [Display(Name = "Author Name")]
            public string? Author { get; set; }

            [DataType(DataType.Date)]
            public DateTime? Date { get; set; }

            
            public String? AssignedTo { get; set; }

        }
}
