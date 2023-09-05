using eNompilo.v3._0._1.Constants;
using eNompilo.v3._0._1.Models.SystemUsers;
using Microsoft.AspNetCore.Identity;

namespace eNompilo.v3._0._1.Data
{
	public class DataSeed
	{
		public static async Task SeedRolesAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			await roleManager.CreateAsync(new IdentityRole(RoleConstants.Admin));
			await roleManager.CreateAsync(new IdentityRole(RoleConstants.Patient));
			await roleManager.CreateAsync(new IdentityRole(RoleConstants.Practitioner));
			await roleManager.CreateAsync(new IdentityRole(RoleConstants.Receptionist));
		}
	}
}
