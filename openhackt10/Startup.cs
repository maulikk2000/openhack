using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace openhackt10
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            var bearerToken = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJrdWJlcm5ldGVzL3NlcnZpY2VhY2NvdW50Iiwia3ViZXJuZXRlcy5pby9zZXJ2aWNlYWNjb3VudC9uYW1lc3BhY2UiOiJkZWZhdWx0Iiwia3ViZXJuZXRlcy5pby9zZXJ2aWNlYWNjb3VudC9zZWNyZXQubmFtZSI6ImRlZmF1bHQtdG9rZW4tbHY5bnYiLCJrdWJlcm5ldGVzLmlvL3NlcnZpY2VhY2NvdW50L3NlcnZpY2UtYWNjb3VudC5uYW1lIjoiZGVmYXVsdCIsImt1YmVybmV0ZXMuaW8vc2VydmljZWFjY291bnQvc2VydmljZS1hY2NvdW50LnVpZCI6IjUwM2FhNDBhLTcyOWYtMTFlOC1iNDQ5LWJlNzcxNGI5YTI5MSIsInN1YiI6InN5c3RlbTpzZXJ2aWNlYWNjb3VudDpkZWZhdWx0OmRlZmF1bHQifQ.HfM0SSs3TAZK38VlOBR4Jwu1T2bCWOKktOjtSQRZLpJXThBaeaYFt9MAYQRblhGjt0k98R-0kUfmjxvDOuLwW6JIiRToytvtMYY2Tn2JnRiroDttrr40geUPE_iX474VHcuWHh32B8yjLbF_4CE95cbdyw8-cSgkWk4jObQpnOpKSyzrYrFISm7PXmxNI8gaNpcwieve3pyLOqnxtR8Sfe29h3pRq2MBSg3piZuUJ0Tu_BvAyc-OCgW6FmqB8yIXmv5fQo3RphitWz9h6XO2uVhwdaHDLG3e8GiKE3xfaZyk2FA6flb5TtbH0PMw-k5mVqY6xLivABAJYzbqtJmhgdip-HChDxG7nKgqT3B0fxKbGfVDJLwIGo-brXThMUk8TiMEGaOQ8AalXNHrszBspgQwOHfUhpldVC3wwT5EalBBFgXYREV-N9pKO5uzAn6Gm9UUQ7ltD_dkp0W9Q6Z8uVmgdqEeWhnqRis9M14rkCrHBR3Y4vjC-Y3Br4H8ZvADhlVMbM5zuTwfY3Y7f8P99U2sXHIN2Ur3VjBrj_LeeyPpni6GManduYt749yJNIHrUCQdMRHklZeWGeeICsJ0_4Eyid5HsYM-80U6FzUbbd3VLswv5PxKOALMRgbXcFonCluzmPwA2OpnQt8OxK_rZUPC4dYKbeATMvMhpCpAM9g";

            services.AddHttpClient("openhackAPI", client =>
            {
                //var uri = "http://ohsyd10.azure-api.net/helloworld/";
                var uri = "http://sydneyopen-sydneyopenhackt1-1ecc8e-8fc658c3.hcp.australiaeast.azmk8s.io/";
                //var uri = "http://127.0.0.1:8080/";
                client.BaseAddress = new Uri(uri);
                //client.DefaultRequestHeaders.Add("Accept", "application/json");
                //client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "606113b35f634db78cd5155c85327915");
                
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Ocp-Apim-Subscription-Key", "606113b35f634db78cd5155c85327915");
                //client.DefaultRequestHeaders.Add("User-Agent", "MyCustomUserAgent");

            });
            

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
