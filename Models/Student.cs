using System.ComponentModel.DataAnnotations;

namespace StudentViewTemplatesDemo.Models
{
    public class Student
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Your Name")]
        [StringLength(20, ErrorMessage = "Name cannot be longer than 20 characters")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name must contain only alphabets and spaces")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Age")]
        [Range(18, 80, ErrorMessage = "Age must be between 18 and 80")]
        public int Age { get; set; }

        public Address Address { get; set; }
    }
}