﻿using System.Web.Http;
using Owin;
using Swashbuckle.Application;
using GIB.ProductsAPI.Swagger;

namespace GIB.ProductsAPI
{
    public static class Startup
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public static void ConfigureApp(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();

            // Attribute routing.
            config.MapHttpAttributeRoutes();
            config.EnsureInitialized();

            config.EnableSwagger(c =>
            {
                c.SingleApiVersion("v1", "GIB.ProductsAPI.");
                c.IncludeXmlComments("GIB.ProductsAPI.XML");
                c.OperationFilter<MultipleOperationsWithSameVerbFilter>();
                //c.IgnoreObsoleteActions();
                //c.DescribeAllEnumsAsStrings();
                //c.IgnoreObsoleteProperties();


            })
            .EnableSwaggerUi();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

          

            appBuilder.UseWebApi(config);
        }
    }
}
