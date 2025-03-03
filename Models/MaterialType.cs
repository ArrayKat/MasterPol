using System;
using System.Collections.Generic;

namespace MasterPolDesktop.Models;

public partial class MaterialType
{
    public int IdType { get; set; }

    public decimal? PercentDefectMaterials { get; set; }

    public string? NameTypeMaterial { get; set; }
}
