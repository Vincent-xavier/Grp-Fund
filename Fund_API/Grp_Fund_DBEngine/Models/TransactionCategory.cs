using System;
using System.Collections.Generic;

namespace Grp_Fund_DBEngine.Models;

public partial class TransactionCategory
{
    public int CategoryId { get; set; }

    public string Category { get; set; } = null!;

    public DateOnly? CreatedOn { get; set; }

    public bool? IsActive { get; set; }
}
