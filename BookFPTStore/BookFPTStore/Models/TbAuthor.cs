using System;
using System.Collections.Generic;

namespace BookFPTStore.Models;

public partial class TbAuthor
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<TbBook> TbBooks { get; set; } = new List<TbBook>();
}
