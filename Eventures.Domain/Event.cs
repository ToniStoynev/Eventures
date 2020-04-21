using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Eventures.Domain
{
    public class Event
    {
        public string Id { get; set; }

        [Required]
        [StringLength(maximumLength: int.MaxValue, ErrorMessage = "Event name should be at least 10 symbols long", MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public string Place { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Start { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime End { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int TotalTickets { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal PricePerTicket { get; set; }
    }
}
