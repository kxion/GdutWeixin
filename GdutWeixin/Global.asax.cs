﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using log4net;
using GdutWeixin.Utils;

namespace GdutWeixin
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            log4net.Config.XmlConfigurator.Configure();
			this.Error += MvcApplication_Error;
        }

        //protected void Application_BeginRequest()
        //{
        //}

		//在使用cookie作为session的依据的时候，为了在一个session中session保持不变，需要在backend对Session进行写入
        //protected void Session_Start(Object sender, EventArgs e)
        //{
        //    Session["init"] = 0;
        //}

        private void MvcApplication_Error(object sender, EventArgs e)
        {
            var error = Server.GetLastError();
			ApplicationLogger.GetLogger().Error(String.Format("{0}", error.StackTrace));
        }
    }
}