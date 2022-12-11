using System;
using System.Collections.Generic;
using Calculator.Models;
using Microsoft.EntityFrameworkCore;

namespace Calculator.Data;

public partial class CalculatorContext : DbContext
{
    public CalculatorContext(DbContextOptions<CalculatorContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Calculation>? Calculations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Calculation>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.ToTable("Calculation");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
