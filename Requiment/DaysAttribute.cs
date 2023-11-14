using System;
using System.ComponentModel.DataAnnotations;

namespace Lr_10.Models;
public class DaysAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
    {
        var form = (RegistrationModel)validationContext.ObjectInstance;

        if (form.SelectedProduct == "Основи" && form.Date.DayOfWeek == DayOfWeek.Monday)
        {
            return new ValidationResult("Consultation on the 'Основи' product cannot take place on Mondays");
        }

        return ValidationResult.Success;
    }
}