using Microsoft.AspNetCore.Identity;

namespace BookFPTStore.Models
{
    public class AppUserModel : IdentityUser
    {
		public int Role { get; set; } = 1;
		public int GetRole()
		{
			return Role;
		}

	}
}
