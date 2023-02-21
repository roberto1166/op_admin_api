using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Log
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public int LogCatalogId { get; set; }

    public int? UserId { get; set; }

    public int? AccountId { get; set; }

    public virtual Account? Account { get; set; }

    public virtual LogCatalog LogCatalog { get; set; } = null!;

    public virtual User? User { get; set; }
}
