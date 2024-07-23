using System;
using System.Collections.Generic;

namespace Grp_Fund_DBEngine.Models;

public partial class MonthlyContribution
{
    public int ContributionId { get; set; }

    public decimal Amount { get; set; }

    public DateOnly UpdatedDate { get; set; }

    public DateOnly CreatedDate { get; set; }

    public int MemberId { get; set; }

    public virtual ICollection<ContributionHistory> ContributionHistories { get; set; } = new List<ContributionHistory>();

    public virtual ICollection<MemberDetail> MemberDetails { get; set; } = new List<MemberDetail>();
}
