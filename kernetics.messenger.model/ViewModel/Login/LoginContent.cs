using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kernetics.messenger.model.User;

namespace kernetics.messenger.model.ViewModel.Login {
    public class LoginContent : ContentBase {
        public User.User User { get; set; }
    }
}
