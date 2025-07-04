using System.ComponentModel.DataAnnotations;

namespace CalculatorAPI.DTOs
{
    public class OperandsDto
    {
        [Required(ErrorMessage = "A is required")]
        [Range(double.MinValue, double.MaxValue, ErrorMessage = "A must be a number")]
        public double A { get; set; }

        [Required(ErrorMessage = "B is required")]
        [Range(double.MinValue, double.MaxValue, ErrorMessage = "B must be a number")]
        public double B { get; set; }
    }
}
