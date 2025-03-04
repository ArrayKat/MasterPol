using System;
using System.Collections.Generic;

namespace MasterPolDesktop.Models;

public partial class Product
{
    public int IdProduct { get; set; }

    public int? IdProductType { get; set; }

    public string? ProductName { get; set; }

    public string? ArticleNumber { get; set; }

    public decimal? MinimumPrice { get; set; }

    public virtual ProductType? IdProductTypeNavigation { get; set; }

    public virtual ICollection<PartnerProduct> PartnerProducts { get; set; } = new List<PartnerProduct>();
}
