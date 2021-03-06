﻿using kernetics.messenger.model.Mail;
using kernetics.messenger.model.Services;
using kernetics.messenger.model.ViewModel;
using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kernetics.messenger.web.Modules {
    public class HomeModule : BaseModule {
        public HomeModule(IDataStore dataStore) {
            Get["/"] = _ => {
                var model = this.GetDefaultModel<StartContent>();
                model.Page.Title = "Start";

                using (var session = dataStore.DocumentStore.OpenSession()) {
                    session.Store(new Member() { Id = Guid.NewGuid(), Firstname = "Test", Lastname = "Last", Email = "test@test.com" });
                    session.SaveChanges();
                }

                using (var session = dataStore.DocumentStore.OpenSession()) {
                    var content = new StartContent();
                    content.Members = session.Query<Member>().ToList();
                    model.Content = content;
                }

                return View["start.cshtml", model];
            };

            Get["/cleanup"] = _ => {
                var model = this.GetDefaultModel<StartContent>();
                model.Page.Title = "Cleanup";

                using (var session = dataStore.DocumentStore.OpenSession()) {
                    //dataStore.DocumentStore.DatabaseCommands.DeleteByIndex
                    //session.SaveChanges();
                }

                return View["start.cshtml", model];
            };

            Get["/error"] = _ => { throw new NotImplementedException(); };
        }
    }
}
