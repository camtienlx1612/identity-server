using System;
using System.Collections.Generic;

namespace Identity.Models;

public partial class User
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public bool Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdateAt { get; set; }

    public virtual ICollection<EmailConfirmToken> EmailConfirmTokens { get; set; } = new List<EmailConfirmToken>();
}
