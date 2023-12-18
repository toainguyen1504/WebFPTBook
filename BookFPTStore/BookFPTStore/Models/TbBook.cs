using System;
using System.Collections.Generic;

namespace BookFPTStore.Models;

public partial class TbBook
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string? Detail { get; set; }

    public string? Image { get; set; }

    public decimal Price { get; set; }

    public decimal? PriceSale { get; set; }

    public int? Quantity { get; set; }

    public int? CategoryId { get; set; }

    public int? AuthorId { get; set; }

    public virtual TbAuthor? Author { get; set; }

    public virtual TbCategory? Category { get; set; }

    public virtual ICollection<TbCartDetail> TbCartDetails { get; set; } = new List<TbCartDetail>();
}
