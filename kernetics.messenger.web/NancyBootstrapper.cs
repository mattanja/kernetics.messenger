using Nancy;
using Nancy.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kernetics.messenger.web
{
    public class NancyBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(Nancy.TinyIoc.TinyIoCContainer container, Nancy.Bootstrapper.IPipelines pipelines)
        {
            pipelines.OnError += (context, exception) =>
            {
                if (exception is Exception)
                {
                    return new Response()
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        ContentType = "text/html",
                        Contents = (stream) =>
                        {
                            var errorMessage = Encoding.UTF8.GetBytes(exception.Message);
                            stream.Write(errorMessage, 0, errorMessage.Length);
                        }
                    };
                }

                return null;
            };

            base.ApplicationStartup(container, pipelines);
        }

        /// <summary>
        /// Configure additional conventions.
        /// </summary>
        /// <param name="nancyConventions"></param>
        protected override void ConfigureConventions(Nancy.Conventions.NancyConventions nancyConventions)
        {
            // https://github.com/NancyFx/Nancy/wiki/Managing-static-content

            base.ConfigureConventions(nancyConventions);

            //nancyConventions.StaticContentsConventions.Add(
            //    StaticContentConventionBuilder.AddDirectory(@"views/Template")
            //);

            
        }
    }
}
