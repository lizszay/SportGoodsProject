using System;
using System.Collections.Generic;

namespace SportGoodsProject.Models;

public partial class User
{
    public int Id { get; set; }

    public int? IdRole { get; set; }

    public string FullName { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public virtual Role? Role { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
