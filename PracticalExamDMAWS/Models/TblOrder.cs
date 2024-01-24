using System;
using System.Collections.Generic;

namespace Practical_Exam_DMAWS.Models;

public partial class TblOrder
{
    public int OrderId { get; set; }

    public int? ItemId { get; set; }

    public string ItemName { get; set; } = null!;

    public int Quantity { get; set; }

    public DateTime DeliveryTime { get; set; }

    public string OrderAddress { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Note { get; set; }

    public virtual TblItem? Item { get; set; }
}
