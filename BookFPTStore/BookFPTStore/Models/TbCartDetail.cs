using System;
using System.Collections.Generic;

namespace BookFPTStore.Models;

public partial class TbCartDetail
{
    public int Id { get; set; }

    public decimal? Price { get; set; }

    public int? Quantity { get; set; }

    public int? CartId { get; set; }

    public int? BookId { get; set; }

    public virtual TbBook? Book { get; set; }

    public virtual TbCart? Cart { get; set; }
}
