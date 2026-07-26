using System;
using System.Collections.Generic;

namespace Identity.Models;

public partial class EmailConfirmToken
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string TokenHash { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime ExpiresAt { get; set; }

    public bool Used { get; set; }

    public virtual User User { get; set; } = null!;
}
