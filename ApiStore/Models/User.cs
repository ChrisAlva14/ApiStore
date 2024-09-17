using System;
using System.Collections.Generic;
namespace ApiStore.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Userpassword { get; set; } = null!;

    public string UserRole { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
