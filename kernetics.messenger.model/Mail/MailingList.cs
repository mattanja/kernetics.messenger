using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kernetics.messenger.model.Mail
{
    public class MailingList
    {
        private IEnumerable<Member> members;

        public Guid Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Member> Members {
            get {
                if (members == null) {
                    members = new List<Member>();
                }
                return members;
            }
            set { members = value; }
        }

    }
}
