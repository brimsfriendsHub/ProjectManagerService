﻿using ProjecManagement.Services.ActionFilters;
using ProjecManagement.Services.MessageHandlers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ProjecManagement.Services
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {


            //var enableCorsAttribute = new EnableCorsAttribute("*",
            //                                             "Origin, Content-Type, Accept",
            //                                             "GET, PUT, POST, DELETE, OPTIONS");
            //config.EnableCors(enableCorsAttribute);
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Filters.Add(new ExceptionHandlerAttribute());
            config.MessageHandlers.Add(new RequestResponseMessageHandler());
        }
    }
}