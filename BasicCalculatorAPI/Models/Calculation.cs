using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Calculator.Models;

public partial class Calculation
{
    [Key]
    public int Id { get; set; }

    public string? Type { get; set; }

    public string? Expression { get; set; }

    public string? CreateDate { get; set; }

    public long? Result { get; set; }
}
