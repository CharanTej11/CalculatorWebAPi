namespace CalculatorAPI.Models
{
    public class Calculation
    {
        public int Id { get; set; }
        public string Operation { get; set; }
        public double Operand1 { get; set; }
        public double Operand2 { get; set; }
        public double Result { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
