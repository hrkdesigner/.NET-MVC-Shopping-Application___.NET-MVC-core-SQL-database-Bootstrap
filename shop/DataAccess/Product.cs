using System;
using System.Collections.Generic;

namespace shop.DataAccess
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Describtion { get; set; } = null!;
        public double Price { get; set; }
        public int? BrandId { get; set; }

        public virtual Brand? Brand { get; set; }
    }
}
