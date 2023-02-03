using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class UserAccountMember
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public sbyte Active { get; set; }

    public int UserId { get; set; }

    public int AccountId { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
