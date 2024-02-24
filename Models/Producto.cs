namespace Ventas.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        // Otros campos

        public ICollection<DetallePedido> DetallesPedidos { get; set; }
    }
}
