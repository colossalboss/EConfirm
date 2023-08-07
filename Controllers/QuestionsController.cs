using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EConfirm.Services.Interfaces;
using EConfirm.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EConfirm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService _questionsService;

        public QuestionsController(IQuestionService questionService)
        {
            _questionsService = questionService;
        }

        // GET: api/<QuestionsController>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_questionsService.GetAll());
        }

        // GET api/<QuestionsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<QuestionsController>
        [Authorize(Roles = "Api.ReadWrite, readaccessss")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] QuestionDTO model)
        {
            var result = await _questionsService.Create(model);
            if (result)
                return NoContent();
            return BadRequest("Oops, something went wrong");
        }

        // PUT api/<QuestionsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<QuestionsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
