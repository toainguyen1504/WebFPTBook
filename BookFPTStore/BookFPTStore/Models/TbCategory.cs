using BookFPTStore.Models;
using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace BookFPTStore.Models;

public partial class TbCategory
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Please enter title!")]
    [StringLength(30, ErrorMessage = "Title cannot exceed 30 characters.")]
    public string Title { get; set; } = null!;

    [Required(ErrorMessage = "Please enter description!")]
    [StringLength(250, ErrorMessage = "Title cannot exceed 250 characters.")]
    public string? Description { get; set; } = "Default Description";

    public virtual ICollection<TbBook> TbBooks { get; set; } = new List<TbBook>();
}
