using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.Owin;
using Owin;
using Swashbuckle.Application;

[assembly: OwinStartup(typeof(ApplicantApi.Startup))]

namespace ApplicantApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            HttpConfiguration config = new HttpConfiguration();

            config
                .EnableSwagger(c => c.SingleApiVersion("v1", "Applicant Api"))
                .EnableSwaggerUi();

            WebApiConfig.Register(config);

            app.UseWebApi(config);
        }
    }
}
