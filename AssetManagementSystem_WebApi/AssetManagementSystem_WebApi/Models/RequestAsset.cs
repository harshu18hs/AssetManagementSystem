using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetManagementSystem_WebApi.Models
{
    public class RequestAsset
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Assign Type is required")]
        [Display(Name = "Assign Type")]
        public string AssetType { get; set; }

        [Required(ErrorMessage = "Assign Item Name is required")]
        [Display(Name = "Assign Item Name")]
        public string AssetItemName { get; set; }

    }
}
