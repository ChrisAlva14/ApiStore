using System;
using System.Collections.Generic;

namespace ApiStore.Models;

public partial class Category
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
