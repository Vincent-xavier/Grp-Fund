using System;
using System.Collections.Generic;

namespace Grp_Fund_DBEngine.Models;

public partial class MemberDetail
{
    public int MemberId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public byte[] Password { get; set; } = null!;

    public string MobileNo { get; set; } = null!;

    public string? AdressLine1 { get; set; }

    public string? AddressLine2 { get; set; }

    public string? City { get; set; }

    public int? StateId { get; set; }

    public int? CountryId { get; set; }

    public bool? IsMarried { get; set; }

    public int? ProgramId { get; set; }

    public int? QulificationId { get; set; }

    public bool? IsPursuing { get; set; }

    public int? OccupationId { get; set; }

    public string? ProfileImg { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDelete { get; set; }

    public DateOnly? MemberSince { get; set; }

    public int? GroupId { get; set; }

    public int? ContributionId { get; set; }

    public int RoleId { get; set; }

    public virtual MonthlyContribution? Contribution { get; set; }

    public virtual Country? Country { get; set; }

    public virtual GroupDetail? Group { get; set; }

    public virtual Occupation? Occupation { get; set; }

    public virtual Program? Program { get; set; }

    public virtual Role Role { get; set; } = null!;
}
