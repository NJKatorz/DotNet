using System;
using System.Collections.Generic;

namespace Nortwind_API.Entities;

public partial class OrderSubtotal
{
    public int OrderId { get; set; }

    public decimal? Subtotal { get; set; }
}
