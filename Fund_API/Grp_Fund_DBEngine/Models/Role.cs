namespace Grp_Fund_DBEngine.Models;

public partial class Role
{
    public int RoleId { get; set; }

    public string Role1 { get; set; } = null!;

    public bool? IsActive { get; set; }

    public DateOnly? CreatedOn { get; set; }

    public virtual ICollection<MemberDetail> MemberDetails { get; set; } = new List<MemberDetail>();
}
