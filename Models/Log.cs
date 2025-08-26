using System;
using System.Collections.Generic;

namespace MultiOutputLogger.Models;

public partial class Log
{
    public int Id { get; set; }

    public string Level { get; set; } = null!;

    public string Message { get; set; } = null!;

    public DateTime CreatedAt { get; set; }
}
