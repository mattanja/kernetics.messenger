using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kernetics.messenger.model.ViewModel
{
    public class PageBase
    {
        private List<ErrorModel> errors;

        public String Title { get; set; }
        public String PreFixTitle { get; set; }
        public bool IsAuthenticated { get; set; }

        public List<ErrorModel> Errors
        {
            get
            {
                if (errors == null)
                {
                    errors = new List<ErrorModel>();
                }
                return errors;
            }
            set { errors = value; }
        }

        public string CurrentUserName { get; set; }
    }
}
