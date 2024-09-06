using System.ComponentModel.DataAnnotations;

namespace StudentViewTemplatesDemo.Models
{
    public class Address
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Country Name")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Country must contain only alphabets and spaces")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Please Enter State Name")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "State must contain only alphabets and spaces")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please Enter City Name")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "City must contain only alphabets and spaces")]
        public string City { get; set; }
    }
}