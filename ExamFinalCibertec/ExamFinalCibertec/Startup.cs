using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using ExamFinalCibertec.Models;

namespace ExamFinalCibertec
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            CreateUserAndRole();
            ConfigureAuth(app);
            ConfigInjector();
        }

        internal void CreateUserAndRole()
        {
            using (var context = new WebDeveloperDbContext())
            {

                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                var userManager = new UserManager<WebDeveloperUser>(new UserStore<WebDeveloperUser>(context));

                // In Startup iam creating first Admin Role and creating a default Admin User    
                if (!roleManager.RoleExists("Administrador"))
                {

                    // first we create Admin rool   
                    var role = new IdentityRole();
                    role.Name = "Administrador";
                    roleManager.Create(role);

                    //Here we create a Admin super user who will maintain the website                  

                    var user = new WebDeveloperUser
                    {
                        UserName = "vhzambrano87@gmail.com",
                        Email = "vhzambrano87@gmail.com"
                    };

                    string userPassword = "123456";

                    var userCreation = userManager.Create(user, userPassword);

                    //Add default User to Role Admin   
                    if (userCreation.Succeeded)
                        userManager.AddToRole(user.Id, "Administrador");


                }

                
                // creating Creating Employee role    
                if (!roleManager.RoleExists("Empleado"))
                {
                    var role = new IdentityRole
                    {
                        Name = "Empleado"
                    };
                    roleManager.Create(role);

                }
            }
        }
    }
}
