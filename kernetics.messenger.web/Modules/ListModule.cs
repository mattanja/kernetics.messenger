using kernetics.messenger.model.Services;
using kernetics.messenger.model.ViewModel.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kernetics.messenger.web.Modules {
    public class ListModule : SecureModule {
        public ListModule(IDataStore dataStore) {
            this.Get["/list"] = _ => {
                var model = this.GetDefaultModel<ListContent>(title: "List-Management");

                return this.View["index.cshtml", model];
            };

            this.Get["/list/edit/(listid?)"] = _ => {
                var model = this.GetDefaultModel<ListContent>(title: "Create list");

                return this.View["index.cshtml", model];
            };
        }
    }
}
