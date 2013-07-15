using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace FamilyPortal
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // i.e. resource/12
            config.Routes.MapHttpRoute(
                name: "DefaultRestApiWithId",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { action = "DefaultWebApiAction"},
                constraints: new { id = @"^\d+$" }
            );

            // i.e. resource and v1/resource/subresource1
            config.Routes.MapHttpRoute(
                name: "DefaultAction",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { action = "DefaultWebApiAction" }
            );

            // i.e. resource/12/subresource2
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}/{action}",
                defaults: new { id = RouteParameter.Optional, action = "DefaultWebApiAction"},
                constraints: new { id = @"^\d+$" }
            );

            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            json.UseDataContractJsonSerializer = false;

            json.SerializerSettings = new JsonSerializerSettings()
            {
                DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate
            };	

            var xml = GlobalConfiguration.Configuration.Formatters.XmlFormatter;
            GlobalConfiguration.Configuration.Formatters.Remove(xml);


            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();
        }
    }
}