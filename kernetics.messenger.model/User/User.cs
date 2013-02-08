using Nancy.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kernetics.messenger.model.User {
    public class User : IUserIdentity {

        protected IEnumerable<string> claims;

        /// <summary>
        /// Claims
        /// </summary>
        public IEnumerable<string> Claims {
            get {
                if (claims == null) {
                    claims = new List<string>();
                }
                return claims;
            }
            set {
                this.claims = value;
            }
        }

        /// <summary>
        /// UserName
        /// </summary>
        public string UserName { get; set; }
    }
}
