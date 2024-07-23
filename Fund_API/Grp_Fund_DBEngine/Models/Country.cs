using System;
using System.Collections.Generic;

namespace Grp_Fund_DBEngine.Models;

public partial class Country
{
    public int CountryId { get; set; }

    public string? Country1 { get; set; }

    public string? Iso3 { get; set; }

    public string? Iso2 { get; set; }

    public double? PhoneCode { get; set; }

    public virtual ICollection<MemberDetail> MemberDetails { get; set; } = new List<MemberDetail>();

    public virtual ICollection<State> States { get; set; } = new List<State>();
}
