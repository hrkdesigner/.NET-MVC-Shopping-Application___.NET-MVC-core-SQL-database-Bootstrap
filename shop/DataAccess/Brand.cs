using System;
using System.Collections.Generic;

namespace shop.DataAccess
{
    public partial class Brand
    {
        public Brand()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Country { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
