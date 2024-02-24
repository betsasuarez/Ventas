namespace Ventas.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime FechaPedido { get; set; }
        // Otros campos

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public ICollection<DetallePedido> DetallesPedidos { get; set; }
    }
}

