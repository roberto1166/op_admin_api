using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class LogCatalog
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public sbyte Active { get; set; }

    public virtual ICollection<Log> Logs { get; } = new List<Log>();
}
