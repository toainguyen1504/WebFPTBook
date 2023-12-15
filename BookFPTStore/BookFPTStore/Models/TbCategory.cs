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

    [Required, MinLength(4, ErrorMessage = "Please enter title!")]
    public string Title { get; set; } = null!;

    [Required, MinLength(4, ErrorMessage = "Please enter description!")]
    public string? Description { get; set; } = "Default Description";

    public virtual ICollection<TbBook> TbBooks { get; set; } = new List<TbBook>();
}
