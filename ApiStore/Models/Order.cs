namespace ApiStore.Models;

public partial class Order
{
    public int Id { get; set; }

    public DateOnly FechaPedido { get; set; }

    public string EstadoPedido { get; set; } = null!;

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;//

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();//
}
