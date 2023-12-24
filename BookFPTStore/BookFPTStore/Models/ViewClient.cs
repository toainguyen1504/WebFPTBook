using System.ComponentModel.DataAnnotations;
using Xunit.Abstractions;

namespace BookFPTStore.Models
{
	public class ViewClient
    {
		public int Id { get; set; }

		[Required(ErrorMessage = "Please enter Username!")]
		public string Username { get; set; } = null!;

		[DataType(DataType.Password), Required(ErrorMessage = "Please enter Password!")]
		public string Password { get; set; } = null!;
        /*		public string ? Role { get; set; }*/

        public string ? Email { get; set; }
        public string? ReturnUrl { get; set; }
		public List<TbCategory> Categories { get; set; }
		public List<TbAuthor> Authors { get; set; }
		public List<TbBook> Books { get; internal set; }
	}
}
