using kernetics.messenger.model.Services;
using kernetics.messenger.model.ViewModel.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kernetics.messenger.web.Modules {
    public class LoginModule : BaseModule {
        public LoginModule(IDataStore dataStore) {
            this.Get["/login"] = _ => {
                var model = this.GetDefaultModel<LoginContent>(title: "Login");

                if (this.Context.CurrentUser != null) {
                    // TODO: Already logged in
                }

                return this.View[model];
            };
        }
    }
}
