using System;
using System.Collections.Generic;

namespace _DotNETCore_7_ADO_Sp_.Models;

public partial class Visitor
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? Mobile { get; set; }

    public DateTime? RegisterAt { get; set; }

    public DateTime? DepartAt { get; set; }
}
