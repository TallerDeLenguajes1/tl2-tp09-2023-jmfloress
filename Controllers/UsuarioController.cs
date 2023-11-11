using Microsoft.AspNetCore.Mvc;
using tl2_tp09_2023_jmfloress.Models;
using tl2_tp09_2023_jmfloress.Repository;

namespace tl2_tp09_2023_jmfloress.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    UsuarioRepository usuarioRepository;
    private readonly ILogger<UsuarioController> _logger;

    public UsuarioController(ILogger<UsuarioController> logger)
    {
        usuarioRepository = new UsuarioRepository();
        _logger = logger;
    }

    [HttpGet("GetAll")]
    public ActionResult<List<Usuario>> GetAll()
    {
        List<Usuario> usuarios = usuarioRepository.GetAll();
        if (usuarios.Count() != 0)
            return Ok(usuarios);
        return BadRequest("No se encontraron usuarios :c");
    }

    [HttpGet("GetById")]
    public ActionResult<Usuario> GetById(int id)
    {
        Usuario usuario = usuarioRepository.GetById(id);
        if (usuario.NombreDeUsuario != null)
            return Ok(usuario);
        return BadRequest("No se encontro al usuario :c");
    }

    [HttpPost("Add")]
    public ActionResult Add(Usuario usuario)
    {
        usuarioRepository.Add(usuario);
        return Ok("Se agrego con exito");
    }

    [HttpPut("Update")]
    public ActionResult Update(int id, Usuario usuario)
    {
        usuarioRepository.Update(id, usuario);
        return Ok("Se actualizo con exito");
    }

    [HttpDelete("Delete")]
    public ActionResult Delete(int id)
    {
        usuarioRepository.Delete(id);
        return Ok("Se elimino con exito");
    }
}
