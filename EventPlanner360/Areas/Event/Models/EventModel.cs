﻿using System.ComponentModel.DataAnnotations;

namespace EventPlanner360.Areas.Event.Models
{
    public class EventModel
    {
        public int EventID { get; set; }


        //[Required(ErrorMessage = "Event name is required.")]
        public string EventName { get; set; }


        //[Required(ErrorMessage = "Event date and time is required.")]
        //[FutureDate(ErrorMessage = "Event date and time must be in the future.")]
        public DateTime EventDateTime { get; set; }


        //[Required(ErrorMessage = "Is private field is required.")]
        public bool IsPrivate { get; set; }
        //[Required]

        public int VenueID { get; set; }

        public List<string> SelectedService { get; set; }
        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

        public int CommentID { get; set; }


        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Message { get; set; }
    }

    // Custom Validation Attribute for Future Date
    //public class FutureDateAttribute : ValidationAttribute
    //{
    //    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    //    {
    //        if (value == null || !(value is DateTime))
    //        {
    //            return new ValidationResult("Invalid date.");
    //        }

    //        DateTime eventDateTime = (DateTime)value;
    //        if (eventDateTime <= DateTime.Now)
    //        {
    //            return new ValidationResult(ErrorMessage ?? "The date must be in the future.");
    //        }

    //        return ValidationResult.Success;
    //    }
    //}
}
