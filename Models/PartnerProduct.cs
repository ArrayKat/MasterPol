using System;
using System.Collections.Generic;

namespace MasterPolDesktop.Models;

public partial class PartnerProduct
{
    public int Id { get; set; }

    public int? IdPartner { get; set; }

    public int? IdProduct { get; set; }

    public int? CountProduct { get; set; }

    public DateOnly? DateOfSale { get; set; }

    public virtual Partner? IdPartnerNavigation { get; set; }

    public virtual Product? IdProductNavigation { get; set; }
}
