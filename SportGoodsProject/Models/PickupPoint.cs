using System;
using System.Collections.Generic;

namespace SportGoodsProject.Models;

public partial class PickupPoint
{
    public int Id { get; set; }

    public string? FullAdress { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
