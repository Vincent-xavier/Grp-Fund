using System;
using System.Collections.Generic;

namespace Grp_Fund_DBEngine.Models;

public partial class Program
{
    public int ProgramId { get; set; }

    public string ProgramName { get; set; } = null!;

    public int? QualificationId { get; set; }

    public DateOnly? CreatedOn { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<MemberDetail> MemberDetails { get; set; } = new List<MemberDetail>();

    public virtual Qualification? Qualification { get; set; }
}
