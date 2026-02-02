using System;
using System.Collections.Generic;

namespace SportGoodsProject.Models;

public partial class Tovar
{
    public string Article { get; set; } = null!;

    public string? TovarName { get; set; }

    public int? IdCategory { get; set; }

    public int? IdManufacturer { get; set; }

    public int? IdSupplier { get; set; }

    public decimal Price { get; set; }

    public string Unit { get; set; } = null!;

    public int Discount { get; set; }

    public int CountTovar { get; set; }

    public string Description { get; set; } = null!;

    public virtual Category? Category { get; set; }

    public virtual Manufacturer? Manufacturer { get; set; }

    public virtual Supplier? Supplier { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
