using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? SecondLastName { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public sbyte Active { get; set; }

    public int RoleId { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<UserAccountMember> UserAccountMembers { get; } = new List<UserAccountMember>();
}
