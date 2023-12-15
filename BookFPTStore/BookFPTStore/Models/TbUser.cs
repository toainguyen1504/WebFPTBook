using System;
using System.Collections.Generic;

namespace BookFPTStore.Models;

public partial class TbUser
{
    public int Id { get; set; }

    public string Password { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? FullName { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string Role { get; set; } = null!;

    public virtual ICollection<TbCart> TbCarts { get; set; } = new List<TbCart>();
}
