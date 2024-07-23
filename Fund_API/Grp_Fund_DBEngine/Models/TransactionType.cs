using System;
using System.Collections.Generic;

namespace Grp_Fund_DBEngine.Models;

public partial class TransactionType
{
    public int TypeId { get; set; }

    public string Type { get; set; } = null!;

    public DateOnly? CreatedOn { get; set; }

    public bool? IsActive { get; set; }
}
