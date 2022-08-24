using System;
using System.Collections.Generic;

namespace shop.Models.DataAccess
{
    public partial class CustomerHasProduct
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
    }
}
