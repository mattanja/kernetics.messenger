using kernetics.messenger.model.ViewModel;
using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kernetics.messenger.web.Modules
{
    public class HomeModule : BaseModule
    {
        public HomeModule()
        {
            Get["/"] = _ =>
            {
                this.Model = this.GetDefaultModel();
                this.Model.Page.Title = "Start";

                return View["start.cshtml", this.Model];
            };

            Get["/error"] = _ => { throw new NotImplementedException(); };
        }
    }
}
