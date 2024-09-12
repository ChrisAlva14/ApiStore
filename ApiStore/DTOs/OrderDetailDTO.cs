using ApiStore.Models;

namespace ApiStore.DTOs
{
    public class OrderDetailResponse
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Cantidad { get; set; }

        public decimal Precio { get; set; }

        public virtual Order Order { get; set; } = null!;

        public virtual Product Product { get; set; } = null!;
    }
    public class OrderDetailRequest
    {
        //public int Id { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Cantidad { get; set; }

        public decimal Precio { get; set; }

        public virtual Order Order { get; set; } = null!;

        public virtual Product Product { get; set; } = null!;
    }
}
