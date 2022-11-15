using System;
using System.Collections.Generic;

namespace CustomersApp.Models;

public partial class Login
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Password { get; set; } = null!;
}
