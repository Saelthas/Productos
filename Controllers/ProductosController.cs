using Microsoft.AspNetCore.Mvc;
using Productos.Models;

namespace Productos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductosController : ControllerBase
    {
        private static int c = 3;
        private static List<Models.Productos> productsBD = new List<Models.Productos> {
           new Models.Productos(){ Id=1, Nombre="arroz", Precio=12.5m, Unidad="kilo", MarcaProducto = new Marca(){Nombre="San Aurelio", Direccion="NN",FechaCreacion="NN",PaisOrigen="Bolivia" } },
           new Models.Productos() { Id = 2, Nombre = "harina", Precio = 5.5m, Unidad = "kilo", MarcaProducto = new Marca() { Nombre = "Harinosa", Direccion = "NN", FechaCreacion = "NN", PaisOrigen = "Venezuela" } }
        };

        public ProductosController()
        {

        }

        [HttpGet]
        public RespuestaGenerica GetProductos()
        {
            DataAccess.DataAccess  data = new DataAccess.DataAccess();

            data.ejecutarConsulta("SELECT [id],[Code],[Name],[Description],[Stock],[Price],[CreatedDate],[UpdateDate]FROM [Store].[dbo].[Products]");

            if (productsBD.Count==0) 
            {
                RespuestaGenerica respuesta = new RespuestaGenerica();
                respuesta.IsOk = false;
                respuesta.Message = "No se encontraron registros";
                //respuesta.data = productsBD;

                return respuesta;
            }
            else
            {
                RespuestaGenerica respuesta = new RespuestaGenerica();
                respuesta.IsOk = true;
                respuesta.Message = "Se encontraron registros";
                respuesta.Data = productsBD;

                return respuesta;
            }
            
            //return productsBD;
        }
        [HttpGet("{id}")]
        public RespuestaGenerica GetProductoxId(int id) 
        {
            foreach (var producto in productsBD)
            {
                if (producto.Id == id)
                {
                    RespuestaGenerica respuestaexitosa = new RespuestaGenerica();
                    respuestaexitosa.IsOk = true;
                    respuestaexitosa.Message = "Se encontro el producto";
                    respuestaexitosa.Data = producto;
                    return respuestaexitosa;
                }
            }
            RespuestaGenerica respuesta = new RespuestaGenerica();
            respuesta.IsOk = false;
            respuesta.Message = "No se encontró el registro con id: "+ id;

            return respuesta;
        }

        [HttpPost]
        public RespuestaGenerica CrearProducto(Models.Productos solicitudCreacion)
        {
            solicitudCreacion.Id= c;
            productsBD.Add(solicitudCreacion);
            c++;
            RespuestaGenerica respuesta = new RespuestaGenerica();
            respuesta.IsOk= true;
            respuesta.Message = "Producto registrado";
            return respuesta;
        }
        [HttpPut("{id}")]
        public RespuestaGenerica ModificarProducts(int id, Models.Productos SolicitudModificacion)
        {
            foreach (var producto in productsBD)
            {
                if (producto.Id == id)
                {
                    producto.Nombre = SolicitudModificacion.Nombre;
                    producto.Unidad = SolicitudModificacion.Unidad;
                    producto.Precio = SolicitudModificacion.Precio;
                    //return "Se modifico el producto";
                    return new RespuestaGenerica() { IsOk = true, Message = "Se modifico el producto" };
                }
            }
            RespuestaGenerica respuesta = new RespuestaGenerica();
            respuesta.IsOk = false;
            respuesta.Message = "El producto con Id " + id + "no existe!";
            return respuesta;
            //return "El producto con Id "+id + "no existe!";
        }
        [HttpDelete("{id}")]
        public RespuestaGenerica BorrarProducts(int id)
        {
            foreach (var producto in productsBD)
            {
                if (producto.Id == id)
                {
                    productsBD.Remove(producto);
                    //return "Se borro el producto";
                    return new RespuestaGenerica() { IsOk = true, Message = "Se borro el producto" };
                }
            }

            //return "El producto con Id " + id + "no existe!";
            RespuestaGenerica respuesta = new RespuestaGenerica();
            respuesta.IsOk = false;
            respuesta.Message = "El producto con Id " + id + "no existe!";
            return respuesta;
        }



    }
    /*
     * Create
     * Read
     * Update
     * Delete
     */
    //Productos de tienda Abarrotes
}
