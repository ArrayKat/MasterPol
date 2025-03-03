using System;
using System.Collections.Generic;

namespace MasterPolDesktop.Models;

public partial class PartnerType
{
    public int IdType { get; set; }

    public string? TypeName { get; set; }

    public virtual ICollection<Partner> Partners { get; set; } = new List<Partner>();
}
