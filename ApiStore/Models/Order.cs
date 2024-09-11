using System;
using System.Collections.Generic;

namespace ApiStore.Models;

public partial class Order
{
    public int Id { get; set; }

    public DateOnly FechaPedido { get; set; }

    public string EstadoPedido { get; set; } = null!;

    public int ClientId { get; set; }

    public virtual User Client { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
