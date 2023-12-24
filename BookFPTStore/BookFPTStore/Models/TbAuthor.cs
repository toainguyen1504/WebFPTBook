using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit.Abstractions;

namespace BookFPTStore.Models;
public partial class TbAuthor
{
    public int Id { get; set; }

	[Required(ErrorMessage = "Please enter Name!")]
	[StringLength(30, ErrorMessage = "Name cannot exceed 30 characters.")]
	public string Name { get; set; } = null!;

	[Required(ErrorMessage = "Please enter Address!")]

	public string? Address { get; set; }

	[Required(ErrorMessage = "Please enter Email!"), EmailAddress]

	public string? Email { get; set; }

    public virtual ICollection<TbBook> TbBooks { get; set; } = new List<TbBook>();
}
