namespace Productos.Models
{
    public class Productos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Unidad { get; set; }
        public decimal Precio { get; set; }

        //public string Proveedor { get; set; }
        public Marca MarcaProducto { get; set; }
    }
}
