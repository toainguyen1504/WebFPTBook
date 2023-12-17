using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookFPTStore.Models;

public class TbUser
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Please enter Username!")]
    public string Username { get; set; } = null!;

    [Required(ErrorMessage = "Please enter Email!"), EmailAddress]
    public string Email { get; set; } = null!;

    [DataType(DataType.Password), Required(ErrorMessage = "Please enter Password!")]
    public string Password { get; set; } = null!;

    public string? FullName { get; set; } = null;

    public string? Address { get; set; } = null;

    public string? Phone { get; set; } = null;

    public string Role { get; set; } = "1";

    public virtual ICollection<TbCart> TbCarts { get; set; } = new List<TbCart>();
}
