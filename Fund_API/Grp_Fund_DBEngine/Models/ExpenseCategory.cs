using System;
using System.Collections.Generic;

namespace Grp_Fund_DBEngine.Models;

public partial class ExpenseCategory
{
    public int CategoryId { get; set; }

    public string? Category { get; set; }

    public bool? IsActive { get; set; }

    public DateOnly? CreatedOn { get; set; }
}
