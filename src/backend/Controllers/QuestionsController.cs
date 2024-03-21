using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class QuestionsController : ControllerBase
{
    // GET: api/Questions
    [HttpGet]
    public ActionResult<IEnumerable<QuestionViewModel>> Get()
    {
        // TODO: Implement logic to retrieve all questions
        return new QuestionViewModel[]
        {
            new QuestionViewModel
            {
                Id = 1,
                QuestionText = "What is the capital of France?",
                Type = "Multiple Choice",
                Options = new string[] { "Paris", "London", "Berlin", "Madrid" },
                CorrectOption = 0
            },
            new QuestionViewModel
            {
                Id = 2,
                QuestionText = "What is the largest planet in our solar system?",
                Type = "Multiple Choice",
                Options = new string[] { "Earth", "Mars", "Jupiter", "Saturn" },
                CorrectOption = 2
            }
        };
    }

    // GET: api/Questions/5
    [HttpGet("{id}")]
    public ActionResult<string> Get(int id)
    {
        // TODO: Implement logic to retrieve a specific question by ID
        return "Question " + id;
    }

    // POST: api/Questions
    [HttpPost]
    public ActionResult<string> Post([FromBody] string question)
    {
        // TODO: Implement logic to create a new question
        return "New question created: " + question;
    }

    // PUT: api/Questions/5
    [HttpPut("{id}")]
    public ActionResult<string> Put(int id, [FromBody] string question)
    {
        // TODO: Implement logic to update a specific question by ID
        return "Question " + id + " updated: " + question;
    }

    // DELETE: api/Questions/5
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
        // TODO: Implement logic to delete a specific question by ID
        return "Question " + id + " deleted";
    }
}