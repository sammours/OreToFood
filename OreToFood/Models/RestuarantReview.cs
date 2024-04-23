using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OreToFood.Models
{

    public class MaxWordsAttribute : ValidationAttribute
    {
        private readonly int _maxWords;
        public MaxWordsAttribute(int maxWords) : base("{0} has to many words!")
        {
            _maxWords = maxWords;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value != null)
            {
                var valueAsString = value.ToString();
                if(valueAsString.Trim().Split(' ').Length > _maxWords)
                {
                    var error = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(error);
                }
            }
            return ValidationResult.Success;
        }
    }
    public class RestuarantReview : IValidatableObject
    {
        public int ID { get; set; }
        [Range(1,10)]
        [Required]
        public int Rating { get; set; }
        [Required]
        [StringLength(1024)]
        public String Body { get; set; }

        [Display(Name = "User")]
        [DisplayFormat(NullDisplayText = "Anonymous")]
        [MaxWords(1)]
        public String ReviewerName { get; set; }
        public int RestuaratId { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Rating < 2 && ReviewerName.ToLower().StartsWith("scott"))
            {
                yield return new ValidationResult("Please leave");
            }
        }
    }
}