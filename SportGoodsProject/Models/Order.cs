using System;
using System.Collections.Generic;

namespace SportGoodsProject.Models;

public partial class Order
{
    public int Id { get; set; }

    public DateOnly OrderDate { get; set; }

    public DateOnly DeliveryDate { get; set; }

    public int IdPickupPoint { get; set; }

    public int IdUser { get; set; }

    public int Code { get; set; }

    public int IdStatus { get; set; }

    public virtual PickupPoint IdPickupPointNavigation { get; set; } = null!;

    public virtual Status IdStatusNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
