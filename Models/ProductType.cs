using System;
using System.Collections.Generic;

namespace MasterPolDesktop.Models;

public partial class ProductType
{
    public int IdType { get; set; }

    public string? TypeName { get; set; }

    public decimal? Ratio { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
