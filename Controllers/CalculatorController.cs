using CalculatorAPI.Data;
using CalculatorAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly CalculatorContext _context;

        public CalculatorController(CalculatorContext context)
        {
            _context = context;
        }

        [HttpGet("add")]
        public async Task<IActionResult> Add(double a, double b)
        {
            double result = a + b;
            await SaveCalculation("Add", a, b, result);
            return Ok(result);
        }

        [HttpGet("subtract")]
        public async Task<IActionResult> Subtract(double a, double b)
        {
            double result = a - b;
            await SaveCalculation("Subtract", a, b, result);
            return Ok(result);
        }

        [HttpGet("multiply")]
        public async Task<IActionResult> Multiply(double a, double b)
        {
            double result = a * b;
            await SaveCalculation("Multiply", a, b, result);
            return Ok(result);
        }

        [HttpGet("divide")]
        public async Task<IActionResult> Divide(double a, double b)
        {
            if (b == 0)
                return BadRequest("Cannot divide by zero.");

            double result = a / b;
            await SaveCalculation("Divide", a, b, result);
            return Ok(result);
        }

        private async Task SaveCalculation(string operation, double a, double b, double result)
        {
            var calculation = new Calculation
            {
                Operation = operation,
                Operand1 = a,
                Operand2 = b,
                Result = result
            };

            _context.Calculations.Add(calculation);
            await _context.SaveChangesAsync();
        }
    }
}
