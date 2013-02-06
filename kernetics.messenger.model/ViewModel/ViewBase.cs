using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kernetics.messenger.model.ViewModel
{
    /// <summary>
    /// Base view model for the layout.
    /// </summary>
    public class ViewBase {
        public PageBase Page { get; set; }
    }

    /// <summary>
    /// Generic view model to include the view model for the view.
    /// </summary>
    /// <typeparam name="TContent"></typeparam>
    public class ViewBase<TContent> : ViewBase where TContent : ContentBase
    {
        public TContent Content { get; set; }
    }
}
