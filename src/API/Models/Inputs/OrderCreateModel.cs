using System.ComponentModel.DataAnnotations;

namespace API.Models.Inputs
{
    public class OrderCreateModel
    {
        [Required(ErrorMessage = "required")]
        public long ProductId { get; set; }
    }
}