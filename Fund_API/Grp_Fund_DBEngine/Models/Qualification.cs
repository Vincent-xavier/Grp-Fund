using System;
using System.Collections.Generic;

namespace Grp_Fund_DBEngine.Models;

public partial class Qualification
{
    public int QualificationId { get; set; }

    public string Qualification1 { get; set; } = null!;

    public DateOnly? CreatedOn { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Program> Programs { get; set; } = new List<Program>();
}
