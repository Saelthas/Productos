namespace Productos.Models
{
    public class RespuestaGenerica
    {
        public bool IsOk { get; set; }
        public string Message { get; set; }
        //public List<Productos> data { get; set; }
        public object Data { get; set; }
    }
    
}
