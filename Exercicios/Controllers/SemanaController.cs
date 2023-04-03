using Exercicios.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exercicios.Controllers;

[Route("[controller]")]
[ApiController]
public class SemanaController : Controller
{
    private readonly SemanaContext _semanaContext;

    public SemanaController(SemanaContext semanaContext)
    {
        _semanaContext = semanaContext;
    }

    [HttpGet]
    public ActionResult Get()
    {
        return Ok();
    }
    
    [HttpGet]
    [Route("{id}")]
    public ActionResult Get([FromRoute] int id)
    {
        return Ok();
    }

    [HttpPost]
    public ActionResult Post([FromBody] SemanaModel semanaModel)
    {
        if (semanaModel.Id > 0)
        {
            return Ok();
        }

        return BadRequest("O ID precisa ser maior que zero");
    }

    [HttpPut]
    [Route("{id}")]
    public ActionResult Put([FromBody] SemanaModel semanaModel, [FromRoute] int id)
    {
        if (semanaModel.Id == id)
        {
            return Ok();
        }

        return BadRequest("Esse ID não existe :(");
    }

    [HttpDelete]
    [Route("{id}")]
    public ActionResult Delete([FromRoute] int id)
    {
        return BadRequest("Esse ID não existe :(");
    }
     
}