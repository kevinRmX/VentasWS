using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSVentas.Models;
using WSVentas.Models.Response;
using WSVentas.Models.Request;
using Microsoft.AspNetCore.Authorization;

namespace WSVentas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
       
        {
            Respuesta oRespuesta = new Respuesta();
            oRespuesta.Exito = 0;
            try
            {
                
                using (VentasRealContext db = new VentasRealContext())
                {
                    var lst = db.Clientes.OrderByDescending(d => d.Id).ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = lst;
                    
                }
            }catch(Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);


        }

        [HttpPost]
        public IActionResult Add(ClienteRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using(VentasRealContext db = new VentasRealContext())
                {
                    Cliente oCliente = new Cliente();
                    oCliente.Nombre = oModel.Nombre;
                    db.Clientes.Add(oCliente);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
                
            }
            catch (Exception ex)
            {

            }
            return Ok(oRespuesta);
        }

        [HttpPut]
        public IActionResult Edit(ClienteRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (VentasRealContext db = new VentasRealContext())
                {
                    Cliente oCliente = db.Clientes.Find(oModel.Id);
                    oCliente.Nombre = oModel.Nombre;
                    db.Entry(oCliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }

            }
            catch (Exception ex)
            {

            }
            return Ok(oRespuesta);
        }

        [HttpDelete("{Id}")]
        public IActionResult Eliminar(int Id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (VentasRealContext db = new VentasRealContext())
                {
                    Cliente oCliente = db.Clientes.Find(Id);
                    db.Remove(oCliente);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }

            }
            catch (Exception ex)
            {

            }
            return Ok(oRespuesta);
        }
        

    }
}
