using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using EjercicioMVC8.Models;

[assembly: OwinStartupAttribute(typeof(EjercicioMVC8.Startup))]
namespace EjercicioMVC8
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CrearRolesUsuario();
        }
        //Generamos metodos de administración de roles
        private void CrearRolesUsuario()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var ManejadorRol = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var ManejadorUsuario = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!ManejadorRol.RoleExists("Admin"))
            {
                //sino existe, se crea el rol y se asigna un nuevo usuario con ese rol
                var rol = new IdentityRole();
                rol.Name = "Admin";
                ManejadorRol.Create(rol);
                //creamos un primer usuario para ese rol
                var user = new ApplicationUser();
                user.UserName = "Admin@hos.gob.ni";
                user.Email = "Admin@hos.gob.ni";
                string PWD = "12345678";
                var chkUser = ManejadorUsuario.Create(user, PWD);
                //si se creo con exito
                if (chkUser.Succeeded)
                {
                    ManejadorUsuario.AddToRole(user.Id, "Admin");
                }
            }
            if (!ManejadorRol.RoleExists("Empleado"))
            {
                //sino existe, se crea el rol y se asigna un nuevo usuario con ese rol
                var rol = new IdentityRole();
                rol.Name = "Empleado";
                ManejadorRol.Create(rol);
                //creamos un primer usuario para ese rol
                var user = new ApplicationUser();
                user.UserName = "Meydell Lezama";
                user.Email = "mlezama@hos.ni";
                string PWD = "12345678";
                var chkUser = ManejadorUsuario.Create(user, PWD);
            }
            if (!ManejadorRol.RoleExists("Paciente"))
            {
                //sino existe, se crea el rol y se asigna un nuevo usuario con ese rol
                var rol = new IdentityRole();
                rol.Name = "Paciente";
                ManejadorRol.Create(rol);
                //creamos un primer usuario para ese rol
                var user = new ApplicationUser();
                user.UserName = "Cynthia Contreras";
                user.Email = "ccontreras@hos.ni";
                string PWD = "12345678";
                var chkUser = ManejadorUsuario.Create(user, PWD);
            }
        }

    }
}

