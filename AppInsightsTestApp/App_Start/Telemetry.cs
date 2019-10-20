using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.Extensibility;

namespace AppInsightsTestApp.App_Start
{
    public class Telemetry : ITelemetryInitializer
    {

        public void Initialize(ITelemetry telemetry)
        {
            var ctx = HttpContext.Current;

            // If telemetry initializer is called as part of request execution and not from some async thread
            if (ctx != null)
            {
                var requestTelemetry = ctx.GetRequestTelemetry();

                // Set the user and session ids from requestTelemetry.Context.User.Id, which is populated in Application_PostAcquireRequestState in Global.asax.cs.
                if (requestTelemetry != null && !string.IsNullOrEmpty(requestTelemetry.Context.User.Id) &&
                    (string.IsNullOrEmpty(telemetry.Context.User.Id) || string.IsNullOrEmpty(telemetry.Context.Session.Id)))
                {
                    // Set the user id on the Application Insights telemetry item.
                    telemetry.Context.User.Id = requestTelemetry.Context.User.Id;

                    // Set the session id on the Application Insights telemetry item.
                    telemetry.Context.Session.Id = requestTelemetry.Context.User.Id;
                }
            }
        }
    }

}
