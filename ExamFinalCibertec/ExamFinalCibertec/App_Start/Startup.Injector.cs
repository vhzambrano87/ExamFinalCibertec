using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using LightInject;

namespace ExamFinalCibertec
{
    public partial class Startup
    {
        public void ConfigInjector()
        {
            var container = new ServiceContainer();
            container.RegisterAssembly(Assembly.GetExecutingAssembly());
            container.RegisterAssembly("ExamFinalCibertec.AccesoDatos*.dll");
            container.RegisterAssembly("ExamFinalCibertec.Model*.dll");
            container.RegisterControllers();
            container.EnableMvc();
        }
    }
}
