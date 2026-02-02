using System;
using System.Collections.Generic;

namespace SportGoodsProject.Models;

public partial class OrderItem
{
    public int Id { get; set; }

    public int IdOrder { get; set; }

    public string Article { get; set; } = null!;

    public int CountOrder { get; set; }

    public virtual Tovar ArticleNavigation { get; set; } = null!;

    public virtual Order IdOrderNavigation { get; set; } = null!;
}
