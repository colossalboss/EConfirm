using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EConfirm.Services.Interfaces;
using EConfirm.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EConfirm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluationController : ControllerBase
    {
        private readonly IEmployeeEvaluation _evaluationService;

        public EvaluationController(IEmployeeEvaluation employeeEvaluationService)
        {
            _evaluationService = employeeEvaluationService;
        }

        // GET: api/<EvaluationController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_evaluationService.GetAll());
        }

        // GET api/<EvaluationController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            if (id == Guid.Empty || id == null)
                return BadRequest("Id is required");
            return Ok(await _evaluationService.Get(id));
        }

        // POST api/<EvaluationController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmployeeEvaluationDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please enter all required fields");
            }
            var result = await _evaluationService.CreateEvaluation(model);
            if (result?.Id != Guid.Empty && result.Id != null) return NoContent();
            return BadRequest("Oops, something went wrong");
        }

        // PUT api/<EvaluationController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] QuestionAnswersDTO model)
        {
            if (id == Guid.Empty && model.EvaluationId == Guid.Empty)
                return BadRequest("Id is required");

            model.EvaluationId = model.EvaluationId == Guid.Empty ? id : model.EvaluationId;

            var result = await _evaluationService.UpdateEvaluationAnswers(model);
            if (result)
                return NoContent();

            return BadRequest("Oops, something went wrong");
        }

        [HttpPut("{id}/updatestatus")]
        public async Task<IActionResult> UpdateStatus(Guid id, [FromBody] AcceptOrRejectEvaluationDTO model)
        {
            if (id == Guid.Empty && model.EvaluationId == Guid.Empty)
                return BadRequest("Id is required");

            model.EvaluationId = model.EvaluationId == Guid.Empty ? id : model.EvaluationId;

            var result = await _evaluationService.UpdateEvaluationStatus(model);
            if (result)
                return NoContent();

            return BadRequest("Oops, something went wrong");
        }

            // DELETE api/<EvaluationController>/5
            [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
