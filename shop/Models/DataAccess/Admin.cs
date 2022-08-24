using System;
using System.Collections.Generic;

namespace shop.Models.DataAccess
{
    public partial class Admin
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
    }
}
