using System;
using System.Collections.Generic;

namespace DatabaseFirst_EFCore.Models;

public partial class Information
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string License { get; set; } = null!;

    public DateTime Establshed { get; set; }

    public decimal Revenue { get; set; }
}
