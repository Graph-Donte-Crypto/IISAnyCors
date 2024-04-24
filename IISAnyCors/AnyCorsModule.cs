using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AnyCors {
    public class AnyCorsModule : IHttpModule {
        public void Dispose() {

        }

        public void Init(HttpApplication context) {
            context.BeginRequest += Context_BeginRequest;
        }

        private void Context_BeginRequest(object sender, EventArgs e) {

            var context = (HttpApplication)sender;

            if (!string.IsNullOrEmpty(context.Request.Headers["Origin"]))
                context.Response.Headers.Set("Access-Control-Allow-Origin", context.Request.Headers["Origin"]);

            if (!string.IsNullOrEmpty(context.Request.Headers["Access-Control-Request-Headers"]))
                context.Response.Headers.Set("Access-Control-Allow-Headers", context.Request.Headers["Access-Control-Request-Headers"]);
            else
                context.Response.Headers.Set("Access-Control-Allow-Headers", "*");

            if (!string.IsNullOrEmpty(context.Request.Headers["Access-Control-Request-Method"]))
                context.Response.Headers.Set("Access-Control-Allow-Methods", context.Request.Headers["Access-Control-Request-Method"]);
            else
                context.Response.Headers.Set("Access-Control-Allow-Methods", "*");

            context.Response.Headers.Set("Access-Control-Allow-Credentials", "true");
        }
    }
}
