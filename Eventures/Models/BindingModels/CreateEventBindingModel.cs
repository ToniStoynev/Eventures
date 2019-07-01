using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eventures.Models.BindingModels
{
    public class CreateEventBindingModel
    {

        [Required]
        [StringLength(maximumLength: int.MaxValue, ErrorMessage = "Name must be at least 10 symbols", MinimumLength = 10)]
        public string Name { get; set; }

        [Required]
        public string Place { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Start { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime End { get; set; }

        [Required]
        [Range(0, 500000)]
        public int TotalTickets { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal PricePerTicket { get; set; }
    }
}
