﻿using System;
using System.Collections.Generic;

namespace shop.DataAccess
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
