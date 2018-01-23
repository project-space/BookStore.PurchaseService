using BookStore.PurchaseService.Business;
using BookStore.PurchaseService.DataAccess;
using BookStore.PurchaseService.Design.Abstractions.Business;
using BookStore.PurchaseService.Design.Abstractions.DataAccess;
using LightInject;
using LightInject.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dependencies;
using System.Web.Routing;



namespace BookStore.PurchaseService.Api
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            var container = new ServiceContainer();
            container.RegisterApiControllers();
            container.Register<IConnectionStringGetter, ConnectionStringGetter>();
            container.Register<IPurchaseDao, PurchaseDao>();
            container.Register<IPurchaseCreator, PurchaseCreator>();
            container.Register<ICartDao, CartDao>();
            container.Register<ICartCreator, CartCreator>();
            container.EnableWebApi(GlobalConfiguration.Configuration);
        }
    }
}
