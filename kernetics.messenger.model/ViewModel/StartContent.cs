﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kernetics.messenger.model.ViewModel {
    /// <summary>
    /// Sample content view model.
    /// </summary>
    public class StartContent : ContentBase {
        public List<Mail.Member> Members { get; set; }
    }
}
