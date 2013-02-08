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
        protected ViewBase<TContent> GetDefaultModel<TContent>(ViewBase<TContent> model = null, string title = null) where TContent : ContentBase
        {
            if (model == null)
            {
                model = new ViewBase<TContent>();
            }

            var page = new PageBase()
            {
                IsAuthenticated = this.Context.CurrentUser != null,
                PreFixTitle = "messenger -",
                Title = title,
                CurrentUserName = this.Context.CurrentUser != null ? this.Context.CurrentUser.UserName : "",
                Errors = new List<ErrorModel>()
            };

            model.Page = page;

            return model;
        }
    }
}
