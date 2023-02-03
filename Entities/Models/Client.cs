using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Client
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public sbyte Active { get; set; }

    public virtual ICollection<Account> Accounts { get; } = new List<Account>();
}
