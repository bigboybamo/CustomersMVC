using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CustomersApp.Models;

public partial class Customer
{
    public int Id { get; set; }

    [DisplayName("First Name")]
    public string FirstName { get; set; } = null!;
    [DisplayName("Last Name")]
    public string LastName { get; set; } = null!;
}
