using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using SanMarkVersionOne.Models;

[assembly: OwinStartupAttribute(typeof(SanMarkVersionOne.Startup))]
namespace SanMarkVersionOne
{
    public partial class Startup
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRole();
            CreateUser();
        }

        public void CreateRole()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            IdentityRole role;
            if(!roleManager.RoleExists("Admin"))
            {
                role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

            }
            if(!roleManager.RoleExists("Student"))
            {
                role = new IdentityRole();
                role.Name = "Student";
                roleManager.Create(role);
            }
            if(!roleManager.RoleExists("Teacher"))
            {
                role = new IdentityRole();
                role.Name = "Teacher";
                roleManager.Create(role);
            }
        }

        public void CreateUser()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = new ApplicationUser();
            user.Email = "reda@gmail.com";
            user.UserName = "reda";
           var check= userManager.Create(user, "sanmarkschool");
            if(check.Succeeded)
            {
                userManager.AddToRole(user.Id, "Admin");
            }

        }
    }
}
