using System;
using System.Collections.Generic;

namespace Grp_Fund_DBEngine.Models;

public partial class ContributionHistory
{
    public int HistoryId { get; set; }

    public decimal Amount { get; set; }

    public int MemberId { get; set; }

    public DateOnly? RevisedDate { get; set; }

    public int ContributionId { get; set; }

    public virtual MonthlyContribution Contribution { get; set; } = null!;
}
