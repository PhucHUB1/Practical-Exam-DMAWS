using System;
using System.Collections.Generic;

namespace Practical_Exam_DMAWS.Models;

public partial class TblItem
{
    public int ItemId { get; set; }

    public string ItemName { get; set; } = null!;

    public decimal Price { get; set; }

    public string? Note { get; set; }

    public virtual ICollection<TblOrder> TblOrders { get; set; } = new List<TblOrder>();
}
