using Exercicios.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exercicios.Controllers;

[Route("[controller]")]
[ApiController]
public class SemanaController : Controller
{
    private readonly SemanaContext _semanaContext;

    // Construtor com parâmetro (injetado)
    public SemanaController(SemanaContext semanaContext)
    {
        _semanaContext = semanaContext;
    }

    [HttpGet]
    public ActionResult<List<SemanaModel>> GetTodos()
    {
        var listaSemanaModel = _semanaContext.Semana;
        List<SemanaModel> listaGetTodos = new List<SemanaModel>();

        foreach (var item in listaSemanaModel)
        {
            var semanaGetTodos = new SemanaModel();
            semanaGetTodos.Id = item.Id;
            semanaGetTodos.DataSemana = item.DataSemana;
            semanaGetTodos.Conteudo = item.Conteudo;
            semanaGetTodos.AplicandoConteudo = item.AplicandoConteudo;

            listaGetTodos.Add(semanaGetTodos);
        }

        return Ok(listaGetTodos);
    }
    
    [HttpGet]
    [Route("{id}")]
    public ActionResult GetPorId([FromRoute] int id)
    {
        SemanaModel _semanaModel = _semanaContext.Semana.Find(id);

        if (_semanaModel != null)
        {
            return Ok(_semanaModel);
        }

        return BadRequest("Esse ID não existe :(");
    }

    [HttpPost]
    public ActionResult Post([FromBody] SemanaModel semanaModel)
    {
        if (semanaModel.Id >= 0)
        {
            SemanaModel _semanaModel = new SemanaModel();
            _semanaModel.DataSemana = semanaModel.DataSemana;
            _semanaModel.Conteudo = semanaModel.Conteudo;
            _semanaModel.AplicandoConteudo = semanaModel.AplicandoConteudo;

            _semanaContext.Add(_semanaModel);
            _semanaContext.SaveChanges();
            return Ok(_semanaModel);
        }

        return BadRequest("O ID precisa ser maior que zero");
    }

    [HttpPut]
    public ActionResult Put([FromBody] SemanaModel semanaModel)
    {
        SemanaModel _semanaModel = _semanaContext.Semana.Find(semanaModel.Id);

        if (_semanaModel.Id != null)
        {
            _semanaModel.DataSemana = semanaModel.DataSemana;
            _semanaModel.Conteudo = semanaModel.Conteudo;
            _semanaModel.AplicandoConteudo = semanaModel.AplicandoConteudo;

            _semanaContext.Attach(_semanaModel);
            _semanaContext.SaveChanges();
            return Ok(semanaModel);
        }

        return BadRequest("Esse ID não existe :(");
    }

    [HttpDelete]
    [Route("{id}")]
    public ActionResult Delete([FromRoute] int id)
    {
        SemanaModel _semanaModel = _semanaContext.Semana.Find(id);

        if (_semanaModel != null)
        {
            _semanaContext.Remove(_semanaModel);
            _semanaContext.SaveChanges();
            return Ok();
        }

        return BadRequest("Esse ID não existe :(");
    }   
}