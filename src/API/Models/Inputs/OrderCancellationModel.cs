using System.ComponentModel.DataAnnotations;

namespace API.Models.Inputs
{
    public class OrderCancellationModel
    {
        [Required(ErrorMessage = "required")]
        public long OrderId { get; set; }
    }
}