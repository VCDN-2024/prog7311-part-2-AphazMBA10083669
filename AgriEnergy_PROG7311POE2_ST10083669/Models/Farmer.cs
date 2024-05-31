using System;
using System.Collections.Generic;

namespace AgriEnergy_PROG7311POE2_ST10083669.Models;

public partial class Farmer
{
    public int FarmerId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly? DateOfBirth { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public string? FarmAddress { get; set; }

    public string? Province { get; set; }

    public virtual ICollection<FarmerProduct> FarmerProducts { get; set; } = new List<FarmerProduct>();
}
