using Nancy;
using Nancy.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kernetics.messenger.web
{
    public class Bootstrapper : DefaultNancyBootstrapper
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

                Console.WriteLine("Error");
                return null;
            };

            base.ApplicationStartup(container, pipelines);
        }

        protected override void ConfigureConventions(Nancy.Conventions.NancyConventions nancyConventions)
        {
            // https://github.com/NancyFx/Nancy/wiki/Managing-static-content

            base.ConfigureConventions(nancyConventions);
            nancyConventions.StaticContentsConventions.Add(Nancy.Conventions.StaticContentConventionBuilder.AddDirectory("/", "public"));
        }

        protected override Type RootPathProvider
        {
            get
            {
                return typeof(CustomRootPathProvider);
            }
        }
    }
}
