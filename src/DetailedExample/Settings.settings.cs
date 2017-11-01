using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailedExample {

    [System.Configuration.SettingsProvider(typeof(AlphaDrive.SettingsProvider))] //<=== This is important!  Read Below.
    partial class Settings {
        
        /*
        
        Because this is a partial class, it will be merged with our actual settings designer class.
        The purpose of this class is to make it easy to apply the "Settings Provider" attribute above.
        That settings provider stores things in AlphaDrive registry keys so that settings are persisted
        between application upgrades.
        
         */
    }
}
