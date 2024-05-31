using System;
using System.Collections.Generic;

namespace AgriEnergy_PROG7311POE2_ST10083669.Models;

public partial class FarmerProduct
{
    public int ProductId { get; set; }

    public int? FarmerId { get; set; }

    public string ProductName { get; set; } = null!;

    public string? Category { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public int? QuantityAvailable { get; set; }

    public DateTime? DateAdded { get; set; }

    public virtual Farmer? Farmer { get; set; }
}
