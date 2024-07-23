using System;
using System.Collections.Generic;

namespace Grp_Fund_DBEngine.Models;

public partial class GroupDetail
{
    public int GroupId { get; set; }

    public string? GroupName { get; set; }

    public string? Slogan { get; set; }

    public int? LeaderId { get; set; }

    public int? AssLeaderId { get; set; }

    public int? AccountentId { get; set; }

    public DateOnly? EstablishedDate { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public virtual ICollection<MemberDetail> MemberDetails { get; set; } = new List<MemberDetail>();
}
