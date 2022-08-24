using System;
using System.Collections.Generic;

namespace shop.Models.DataAccess
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
