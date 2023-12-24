using BookFPTStore.Models.Repository.Validation;
using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Xunit.Abstractions;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace BookFPTStore.Models;

public partial class TbBook
{
    public int Id { get; set; }
    [Required]
    public string Title { get; set; } = null!;
    [Required]
    public string? Description { get; set; }
 
    public string? Detail { get; set; }
	/*[Required]*/
	public string? Image { get; set; }
	[Required]
	[NotMapped]
    [FileExtension]
    public IFormFile ImageUpload { get; set; }

    [Required(ErrorMessage = "Please enter description!")]
    [Range(0.01, double.MaxValue)]
    [Column(TypeName = "decimal(8,2)")]
    public decimal Price { get; set; }
    [Required]
    public decimal? PriceSale { get; set; }
    [Required]
    public int? Quantity { get; set; }
    [Required, Range(1, int.MaxValue, ErrorMessage = "Please choose a category!")]
    public int? CategoryId { get; set; }
    [Required, Range(1, int.MaxValue, ErrorMessage = "Please choose a author!")]
    public int? AuthorId { get; set; }

    public virtual TbAuthor? Author { get; set; }

    public virtual TbCategory? Category { get; set; }

    public virtual ICollection<TbCartDetail> TbCartDetails { get; set; } = new List<TbCartDetail>();




}
