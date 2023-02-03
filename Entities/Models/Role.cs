using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Role
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public sbyte Active { get; set; }

    public virtual ICollection<User> Users { get; } = new List<User>();
}
