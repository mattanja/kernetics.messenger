using kernetics.messenger.model.ViewModel;
using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kernetics.messenger.web.Modules
{
    public abstract class BaseModule : NancyModule
    {
        public ViewBase Model { get; set; }

        public BaseModule()
        {
        }

        public BaseModule(string modulepath)
            : base(modulepath)
        {
        }

        /// <summary>
        /// Setup default page model properties.
        /// </summary>
        protected ViewBase GetDefaultModel(ViewBase model = null)
        {
            if (model == null)
            {
                model = new ViewBase();
            }

            var page = new PageBase()
            {
                IsAuthenticated = this.Context.CurrentUser != null,
                PreFixTitle = "messenger -",
                CurrentUserName = this.Context.CurrentUser != null ? this.Context.CurrentUser.UserName : "",
                Errors = new List<ErrorModel>()
            };

            model.Page = page;

            return model;
        }
    }
}
