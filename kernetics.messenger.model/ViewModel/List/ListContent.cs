using kernetics.messenger.model.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kernetics.messenger.model.ViewModel.List {
    public class ListContent : ContentBase {
        private IEnumerable<MailingList> mailingLists;

        /// <summary>
        /// MailingLists
        /// </summary>
        public IEnumerable<MailingList> MailingLists {
            get {
                if (mailingLists == null) {
                    mailingLists = new List<MailingList>();
                }
                return mailingLists;
            }
            set { mailingLists = value; }
        }

    }
}
