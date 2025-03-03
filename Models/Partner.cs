using System;
using System.Collections.Generic;

namespace MasterPolDesktop.Models;

public partial class Partner
{
    public int IdPartner { get; set; }

    public int? IdTypeCompany { get; set; }

    public string? NameCompany { get; set; }

    public string? LegalAddress { get; set; }

    public string? TaxIdentificationNumber { get; set; }

    public string? DirectorFullName { get; set; }

    public string? ContactPhone { get; set; }

    public string? ContactEmail { get; set; }

    public int? Rating { get; set; }

    public virtual PartnerType? IdTypeCompanyNavigation { get; set; }

    public virtual ICollection<PartnerProduct> PartnerProducts { get; set; } = new List<PartnerProduct>();
}
