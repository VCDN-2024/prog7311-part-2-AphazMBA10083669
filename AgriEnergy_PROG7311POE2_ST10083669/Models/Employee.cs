using System;
using System.Collections.Generic;

namespace AgriEnergy_PROG7311POE2_ST10083669.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Position { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public DateTime? HireDate { get; set; }

    public virtual ICollection<EmployeeLogin> EmployeeLogins { get; set; } = new List<EmployeeLogin>();
}
