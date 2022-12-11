using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Calculator.Data;
using Calculator.Models;
using BasicCalculatorAPI.Services;

namespace BasicCalculatorAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculationsController : Controller
    {
        private readonly CalculatorContext _context;
        private readonly ICalculationRepository _calculationRepository;
        private readonly ICalculator _calculator;

        public CalculationsController(CalculatorContext context, ICalculationRepository calculationRepository, ICalculator calculator)
        {
            _context = context;
            _calculator = calculator;
            _calculationRepository = calculationRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Calculation>> GetById(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }

            var calculation = await _calculationRepository.FindByIdAsync(id.Value);
            if (calculation is null)
            {
                return NotFound();
            }

            return calculation;
        }

        [HttpGet("history")]
        public ActionResult<IEnumerable<Calculation>> History()
        {
            if (_calculationRepository.GetAll().Result == null)
            {
                return NotFound();
            }

            return _calculationRepository.GetAll().Result.ToList();
        }

        [HttpPost("Add")]
        public async Task<ActionResult<Calculation>> Add([FromBody] Calculation calculationModel, string value1, string value2)
        {
            calculationModel.CreateDate = DateTime.Now.ToLongDateString();
            calculationModel.Type = "Addition";
            calculationModel.Expression = value1 + "+" + value2;
            calculationModel.Result = (long?)_calculator.Calculate(calculationModel.Expression);

            // Validation check model
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity();
            }

            await _calculationRepository.CreateAsync(calculationModel);
            return CreatedAtAction(nameof(GetById), new { id = calculationModel.Id }, calculationModel);
        }

        [HttpPost("Add2")]
        public async Task<ActionResult<Calculation>> Add([FromBody] Calculation calculationModel, string value1, string value2, string value3)
        {
            calculationModel.CreateDate = DateTime.Now.ToLongDateString();
            calculationModel.Type = "Addition";
            calculationModel.Expression = value1 + "+" + value2 + "+" + value3;
            calculationModel.Result = (long?)_calculator.Calculate(calculationModel.Expression);

            // Validation check model
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity();
            }

            await _calculationRepository.CreateAsync(calculationModel);
            return CreatedAtAction(nameof(GetById), new { id = calculationModel.Id }, calculationModel);
        }

        [HttpPost("Add3")]
        public async Task<ActionResult<Calculation>> Add([FromBody] Calculation calculationModel, string value1, string value2, string value3, string value4)
        {
            calculationModel.CreateDate = DateTime.Now.ToLongDateString();
            calculationModel.Type = "Addition";
            calculationModel.Expression = value1 + "+" + value2 + "+" + value3 + "+" + value4;
            calculationModel.Result = (long?)_calculator.Calculate(calculationModel.Expression);

            // Validation check model
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity();
            }

            await _calculationRepository.CreateAsync(calculationModel);
            return CreatedAtAction(nameof(GetById), new { id = calculationModel.Id }, calculationModel);
        }

        [HttpPost("Subtract")]
        public async Task<ActionResult<Calculation>> Subtract([FromBody] Calculation calculationModel, string value1, string value2)
        {
            calculationModel.CreateDate = DateTime.Now.ToLongDateString();
            calculationModel.Type = "Subtract";
            calculationModel.Expression = value1 + "-" + value2;
            calculationModel.Result = (long?)_calculator.Calculate(calculationModel.Expression);

            // Validation check model
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity();
            }

            await _calculationRepository.CreateAsync(calculationModel);
            return CreatedAtAction(nameof(GetById), new { id = calculationModel.Id }, calculationModel);
        }

        [HttpPost("Subtract2")]
        public async Task<ActionResult<Calculation>> Subtract([FromBody] Calculation calculationModel, string value1, string value2, string value3)
        {
            calculationModel.CreateDate = DateTime.Now.ToLongDateString();
            calculationModel.Type = "Subtract";
            calculationModel.Expression = value1 + "-" + value2 + "-" + value3;
            calculationModel.Result = (long?)_calculator.Calculate(calculationModel.Expression);

            // Validation check model
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity();
            }

            await _calculationRepository.CreateAsync(calculationModel);
            return CreatedAtAction(nameof(GetById), new { id = calculationModel.Id }, calculationModel);
        }

        [HttpPost("Subtract3")]
        public async Task<ActionResult<Calculation>> Subtract([FromBody] Calculation calculationModel, string value1, string value2, string value3, string value4)
        {
            calculationModel.CreateDate = DateTime.Now.ToLongDateString();
            calculationModel.Type = "Subtract";
            calculationModel.Expression = value1 + "-" + value2 + "-" + value3 + "-" + value4;
            calculationModel.Result = (long?)_calculator.Calculate(calculationModel.Expression);

            // Validation check model
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity();
            }

            await _calculationRepository.CreateAsync(calculationModel);
            return CreatedAtAction(nameof(GetById), new { id = calculationModel.Id }, calculationModel);
        }

        [HttpPost("Multiply")]
        public async Task<ActionResult<Calculation>> Multiply([FromBody] Calculation calculationModel, string value1, string value2)
        {
            calculationModel.CreateDate = DateTime.Now.ToLongDateString();
            calculationModel.Type = "Multiply";
            calculationModel.Expression = value1 + "*" + value2;
            calculationModel.Result = (long?)_calculator.Calculate(calculationModel.Expression);

            // Validation check model
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity();
            }

            await _calculationRepository.CreateAsync(calculationModel);
            return CreatedAtAction(nameof(GetById), new { id = calculationModel.Id }, calculationModel);
        }

        [HttpPost("Multiply2")]
        public async Task<ActionResult<Calculation>> Multiply([FromBody] Calculation calculationModel, string value1, string value2, string value3)
        {
            calculationModel.CreateDate = DateTime.Now.ToLongDateString();
            calculationModel.Type = "Multiply";
            calculationModel.Expression = value1 + "*" + value2 + "*" + value3;
            calculationModel.Result = (long?)_calculator.Calculate(calculationModel.Expression);

            // Validation check model
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity();
            }

            await _calculationRepository.CreateAsync(calculationModel);
            return CreatedAtAction(nameof(GetById), new { id = calculationModel.Id }, calculationModel);
        }

        [HttpPost("Multiply3")]
        public async Task<ActionResult<Calculation>> Multiply([FromBody] Calculation calculationModel, string value1, string value2, string value3, string value4)
        {
            calculationModel.CreateDate = DateTime.Now.ToLongDateString();
            calculationModel.Type = "Multiply";
            calculationModel.Expression = value1 + "*" + value2 + "*" + value3 + "*" + value4;
            calculationModel.Result = (long?)_calculator.Calculate(calculationModel.Expression);

            // Validation check model
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity();
            }

            await _calculationRepository.CreateAsync(calculationModel);
            return CreatedAtAction(nameof(GetById), new { id = calculationModel.Id }, calculationModel);
        }

        [HttpPost("Divide")]
        public async Task<ActionResult<Calculation>> Divide([FromBody] Calculation calculationModel, string value1, string value2)
        {
            calculationModel.CreateDate = DateTime.Now.ToLongDateString();
            calculationModel.Type = "Divide";
            calculationModel.Expression = value1 + "/" + value2;
            calculationModel.Result = (long?)_calculator.Calculate(calculationModel.Expression);

            // Validation check model
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity();
            }

            await _calculationRepository.CreateAsync(calculationModel);
            return CreatedAtAction(nameof(GetById), new { id = calculationModel.Id }, calculationModel);
        }

        [HttpPost("Divide2")]
        public async Task<ActionResult<Calculation>> Divide([FromBody] Calculation calculationModel, string value1, string value2, string value3)
        {
            calculationModel.CreateDate = DateTime.Now.ToLongDateString();
            calculationModel.Type = "Divide";
            calculationModel.Expression = value1 + "/" + value2 + "/" + value3;
            calculationModel.Result = (long?)_calculator.Calculate(calculationModel.Expression);

            // Validation check model
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity();
            }

            await _calculationRepository.CreateAsync(calculationModel);
            return CreatedAtAction(nameof(GetById), new { id = calculationModel.Id }, calculationModel);
        }

        [HttpPost("Divide3")]
        public async Task<ActionResult<Calculation>> Divide([FromBody] Calculation calculationModel, string value1, string value2, string value3, string value4)
        {
            calculationModel.CreateDate = DateTime.Now.ToLongDateString();
            calculationModel.Type = "Divide";
            calculationModel.Expression = value1 + "/" + value2 + "/" + value3 + "/" + value4;
            calculationModel.Result = (long?)_calculator.Calculate(calculationModel.Expression);

            // Validation check model
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity();
            }

            await _calculationRepository.CreateAsync(calculationModel);
            return CreatedAtAction(nameof(GetById), new { id = calculationModel.Id }, calculationModel);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Calculation calculationModel, string expression)
        {
            calculationModel.CreateDate = DateTime.Now.ToLongDateString();
            calculationModel.Type = _calculator.OperationType(expression);
            calculationModel.Expression = expression;
            calculationModel.Result = (long?)_calculator.Calculate(expression);

            // Validation check model
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity();
            }

            await _calculationRepository.CreateAsync(calculationModel);
            return CreatedAtAction(nameof(GetById), new { id = calculationModel.Id }, calculationModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Calculation calculationModel)
        {
            if (id != calculationModel.Id)
            {
                return NotFound();
            }

            // Validation check model
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity();
            }

            await _calculationRepository.UpdateAsync(calculationModel);

            return Ok(calculationModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {

            if (!id.HasValue)
            {
                return BadRequest();
            }

            var calculation = await _calculationRepository.FindByIdAsync(id.Value);
            if (calculation is null)
            {
                return NotFound();
            }
            await _calculationRepository.DeleteAsync((int?)calculation.Id);

            return NoContent();
        }
    }
}
