using Microsoft.AspNetCore.Mvc;
using Tiendaapi.Datos;
using Tiendaapi.Modelo;

namespace Tiendaapi.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class ProductosController: ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<MProductos>>> Get()
        {
            var funcion = new DProductos();
            var lista = await funcion.MostrarProductos();
            return lista;
        }

        [HttpPost]
        public async Task Post([FromBody] MProductos parametros)
        {
            var funcion = new DProductos();
            await funcion.InsertarProductos(parametros);
        }

        [HttpPut("{id}")]
        public async Task <ActionResult> Put(int id, [FromBody] MProductos parametros)
        {
            var funcion = new DProductos();
            parametros.id = id;
            await funcion.EditarProductos(parametros);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var funcion = new DProductos();
            var parametros = new MProductos();
            parametros.id = id;
            await funcion.EliminarProductos(parametros);
            return NoContent();
        }
    }
}
