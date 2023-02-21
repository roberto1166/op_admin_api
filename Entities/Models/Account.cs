using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Account
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? OperationsManager { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public sbyte Active { get; set; }

    public int ClientId { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual ICollection<Log> Logs { get; } = new List<Log>();

    public virtual ICollection<UserAccountMember> UserAccountMembers { get; } = new List<UserAccountMember>();
}
