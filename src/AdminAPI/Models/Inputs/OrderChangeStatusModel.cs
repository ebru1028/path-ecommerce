using System.ComponentModel.DataAnnotations;
using Entities.Enums;

namespace AdminAPI.Models.Inputs
{
    public class OrderChangeStatusModel
    {
        [Required(ErrorMessage = "required")]
        public long OrderId { get; set; }
        
        [Required(ErrorMessage = "required")]
        public OrderStatus Status { get; set; }
    }
}