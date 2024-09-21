using ApiStore.Models;

namespace ApiStore.DTOs
{
    public class OrderResponse
    {
        public int Id { get; set; }

        public DateOnly FechaPedido { get; set; }

        public string EstadoPedido { get; set; } = null!;

        public int ClientId { get; set; }

        public virtual User Client { get; set; } = null!;

        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
    public class OrderRequest
    {
        //public int Id { get; set; }

        public DateOnly FechaPedido { get; set; }

        public string EstadoPedido { get; set; } = null!;

        public int ClientId { get; set; }

        public virtual User Client { get; set; } = null!;

        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }








}
