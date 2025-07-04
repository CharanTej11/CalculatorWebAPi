using CalculatorWebAPi.Exceptions;
using CalculatorAPI.Models;
using Microsoft.AspNetCore.Mvc;
using CalculatorAPI.Data;
using CalculatorAPI.DTOs;

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

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] OperandsDto dto)
        {
            double result = dto.A + dto.B;
            await SaveCalculation("Add", dto.A, dto.B, result);
            return Ok(new { result });
        }

        [HttpPost("subtract")]
        public async Task<IActionResult> Subtract([FromBody] OperandsDto dto)
        {
            double result = dto.A - dto.B;
            await SaveCalculation("Subtract", dto.A, dto.B, result);
            return Ok(new { result });
        }

        [HttpPost("multiply")]
        public async Task<IActionResult> Multiply([FromBody] OperandsDto dto)
        {
            double result = dto.A * dto.B;
            await SaveCalculation("Multiply", dto.A, dto.B, result);
            return Ok(new { result });
        }

        [HttpPost("divide")]
        public async Task<IActionResult> Divide([FromBody] OperandsDto dto)
        {
            if (dto.B == 0)
            {
                throw new BadRequestException("Cannot divide by zero.");
            }

            double result = dto.A / dto.B;
            await SaveCalculation("Divide", dto.A, dto.B, result);
            return Ok(new { result });
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
