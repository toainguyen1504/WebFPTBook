using System;
using System.Collections.Generic;

namespace BookFPTStore.Models;

public partial class TbCart
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string? CustomerName { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public decimal? TotalAmount { get; set; }

    public int? Quantity { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<TbCartDetail> TbCartDetails { get; set; } = new List<TbCartDetail>();

    public virtual TbUser? User { get; set; }
}
