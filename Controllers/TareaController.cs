using Microsoft.AspNetCore.Mvc;
using tl2_tp09_2023_jmfloress.Models;
using tl2_tp09_2023_jmfloress.Repository;

namespace tl2_tp09_2023_jmfloress.Controllers;

[ApiController]
[Route("[controller]")]
public class TareaController : ControllerBase
{
    TareaRepository tareaRepository;
    private readonly ILogger<TareaController> _logger;

    public TareaController(ILogger<TareaController> logger)
    {
        tareaRepository = new TareaRepository();
        _logger = logger;
    }

    [HttpGet("GetById")]
    public ActionResult<Tarea> GetById(int id)
    {
        var tarea = tareaRepository.GetById(id);
        if (tarea.Nombre != null)
            return Ok(tarea);
        return BadRequest("No se encontro la tarea :c");
    }

    [HttpGet("GetByUser")]
    public ActionResult<List<Tarea>> GetByUser(int idUsuario)
    {
        List<Tarea> tarea = tareaRepository.GetByUsuario(idUsuario);
        if(tarea.Count() != 0)
            return Ok(tarea);
        return BadRequest("El usuario no registra tareas");
    }

    [HttpGet("GetByBoard")]
    public ActionResult<List<Tarea>> GetByBoard(int idTablero)
    {
        List<Tarea> tarea = tareaRepository.GetByTablero(idTablero);
        if(tarea.Count() != 0)
            return Ok(tarea);
        return BadRequest("El tablero no registra tareas");
    }  

    [HttpPost("Add")]
    public ActionResult Add(int idTablero, Tarea tarea)
    {
        tareaRepository.Add(idTablero, tarea);
        return Ok("Se agrego con exito");
    }

    [HttpPut("AssignTask")]
    public ActionResult AssignTask(int idUsuario, int idTarea)
    {
        tareaRepository.AsignarTarea(idUsuario, idTarea);
        return Ok("Asignacion exitosa");
    }

    [HttpPut("Update")]
    public ActionResult Update(int id, Tarea tarea)
    {
        tareaRepository.Update(id, tarea);
        return Ok("Se actualizo con exito");
    }

    [HttpDelete("Delete")]
    public ActionResult Delete(int id)
    {
        tareaRepository.Delete(id);
        return Ok("Se elimino con exito");
    }

}