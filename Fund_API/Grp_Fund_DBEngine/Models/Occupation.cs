using System;
using System.Collections.Generic;

namespace Grp_Fund_DBEngine.Models;

public partial class Occupation
{
    public int OccupationId { get; set; }

    public string Occupation1 { get; set; } = null!;

    public bool? IsActive { get; set; }

    public virtual ICollection<MemberDetail> MemberDetails { get; set; } = new List<MemberDetail>();
}
