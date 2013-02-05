using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kernetics.messenger.model.ViewModel
{
    public class ViewBase {
        public PageBase Page { get; set; }
    }

    public class ViewBase<TContent> : ViewBase where TContent : ContentBase
    {
        public TContent Content { get; set; }
    }
}
