using kernetics.messenger.model.Services;
using Nancy;
using Nancy.Authentication.Forms;
using Nancy.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kernetics.messenger.web {
    public class Bootstrapper : DefaultNancyBootstrapper {
        protected override void ApplicationStartup(Nancy.TinyIoc.TinyIoCContainer container, Nancy.Bootstrapper.IPipelines pipelines) {
            // Setup IoC
            container.Register<IDataStore>(new kernetics.messenger.database.DataStore());
            //container.Register<IUserMapper>();

            // TODO: Setup authentication
            //var formsAuthConfiguration = new Nancy.Authentication.Forms.FormsAuthenticationConfiguration() {
            //    RedirectUrl = "~/login",
            //    UserMapper = container.Resolve<IUserMapper>(),
            //};
            //Nancy.Authentication.Forms.FormsAuthentication.Enable(pipelines, formsAuthConfiguration);

            // Error handling
            pipelines.OnError += (context, exception) => {
                if (exception is Exception) {
                    return new Response() {
                        StatusCode = HttpStatusCode.NotFound,
                        ContentType = "text/html",
                        Contents = (stream) => {
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

        /// <summary>
        /// RequestStartup
        /// </summary>
        /// <param name="container"></param>
        /// <param name="pipelines"></param>
        /// <param name="context"></param>
        protected override void RequestStartup(Nancy.TinyIoc.TinyIoCContainer container, Nancy.Bootstrapper.IPipelines pipelines, NancyContext context) {
            base.RequestStartup(container, pipelines, context);
        }

        /// <summary>
        /// ConfigureConventions
        /// </summary>
        /// <param name="nancyConventions"></param>
        protected override void ConfigureConventions(Nancy.Conventions.NancyConventions nancyConventions) {
            // https://github.com/NancyFx/Nancy/wiki/Managing-static-content

            base.ConfigureConventions(nancyConventions);
            nancyConventions.StaticContentsConventions.Add(Nancy.Conventions.StaticContentConventionBuilder.AddDirectory("/", "public"));
        }

        /// <summary>
        /// RootPathProvider
        /// </summary>
        protected override Type RootPathProvider {
            get {
                return typeof(CustomRootPathProvider);
            }
        }
    }
}
