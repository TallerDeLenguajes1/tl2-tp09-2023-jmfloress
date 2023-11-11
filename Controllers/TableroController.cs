using Microsoft.AspNetCore.Mvc;
using tl2_tp09_2023_jmfloress.Models;
using tl2_tp09_2023_jmfloress.Repository;

namespace tl2_tp09_2023_jmfloress.Controllers;

[ApiController]
[Route("[controller]")]
public class TableroController : ControllerBase
{
    TableroRepository tableroRepository;
    private readonly ILogger<TableroController> _logger;

    public TableroController(ILogger<TableroController> logger)
    {
        tableroRepository = new TableroRepository();
        _logger = logger;
    }

    [HttpGet("GetAll")]
    public ActionResult<List<Tablero>> GetAll()
    {
        List<Tablero> tableros = tableroRepository.GetAll();
        if (tableros.Count() != 0)
            return Ok(tableros);
        return BadRequest("No se encontraron tableros :c");
    }

    [HttpGet("GetById")]
    public ActionResult<Tablero> GetById(int id)
    {
        var tablero = tableroRepository.GetById(id);
        if (tablero.Nombre != null)
            return Ok(tablero);
        return BadRequest("No se encontro al tablero :c");
    }
    [HttpGet("GetByUser")]
    public ActionResult<List<Tablero>> GetByUser(int idUsuario)
    {
        List<Tablero> tableros = tableroRepository.GetByUsuario(idUsuario);
        if(tableros.Count() != 0)
            return Ok(tableros);
        return BadRequest("El usuario no registra tableros");
    } 

    [HttpPost("Add")]
    public ActionResult Add(Tablero tablero)
    {
        tableroRepository.Add(tablero);
        return Ok("Se agrego con exito");
    }

    [HttpPut("Update")]
    public ActionResult Update(int id, Tablero tablero)
    {
        tableroRepository.Update(id, tablero);
        return Ok("Se actualizo con exito");
    }

    [HttpDelete("Delete")]
    public ActionResult Delete(int id)
    {
        tableroRepository.Delete(id);
        return Ok("Se elimino con exito");
    }

}