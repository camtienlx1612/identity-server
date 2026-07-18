using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Identity.Models;

public partial class MasterContext : DbContext
{
    public MasterContext(DbContextOptions<MasterContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
