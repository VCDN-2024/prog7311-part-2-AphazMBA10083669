using System;
using System.Collections.Generic;

namespace AgriEnergy_PROG7311POE2_ST10083669.Models;

public partial class EmployeeLogin
{
    public int LoginId { get; set; }

    public int? EmployeeId { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public virtual Employee? Employee { get; set; }
}
