using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Lr_10.Models
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = "Name and Surname (field is required!)")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email  (field is required!)")]
        [EmailAddress(ErrorMessage = "Enter the correct Email!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Date of consultation  (field is required!)")]
        [DataType(DataType.Date)]
        [FutureDate(ErrorMessage = "The desired date should be in the future and not fall on a weekend!")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Select a product!")]
        [DaysAttribute(ErrorMessage = "Consultation on the 'Основи' product cannot be held on Mondays!")]
        public string SelectedProduct { get; set; }

    }
}