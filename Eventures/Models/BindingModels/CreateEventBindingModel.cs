namespace Eventures.Models.BindingModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CreateEventBindingModel : IValidatableObject
    {

        [Required]
        [StringLength(maximumLength: int.MaxValue, ErrorMessage = "Name must be at least 10 symbols", MinimumLength = 10)]
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
        [Range(1, 500000)]
        public int TotalTickets { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal PricePerTicket { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (End < Start)
            {
                yield return new ValidationResult("End date can not be before start date !!!");
            }
        }
    }
}
