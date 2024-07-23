using System;
using System.Collections.Generic;

namespace Grp_Fund_DBEngine.Models;

public partial class State
{
    public int StateId { get; set; }

    public string? State1 { get; set; }

    public string? StateCode { get; set; }

    public int? CountryId { get; set; }

    public virtual Country? Country { get; set; }
}
