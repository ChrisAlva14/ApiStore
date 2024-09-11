using System;
using System.Collections.Generic;

namespace ApiStore.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public decimal Precio { get; set; }

    public int CategoriaId { get; set; }

    public int Stock { get; set; }

    public string? Imagen { get; set; }

    public virtual Category Categoria { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
