using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailedExample {
    class ExtensionPriorities {

        public const long Settings = 
            AlphaDrive.Windows.Extensions.SettingPanelPriorities.File_Settings 
            + AlphaDrive.Windows.Extensions.SettingPanelPriorities.MEDIUM
            ;

        public const long MatterNoteFolderExtension =
            AlphaDrive.Windows.Extensions.StartupExtensionPriorities.STARTUP_PreloadData
            + AlphaDrive.Windows.Extensions.StartupExtensionPriorities.MEDIUM
            ;

        public const long InterfaceExtension =
            AlphaDrive.Windows.Extensions.StartupExtensionPriorities.STARTUP_Controller
            + AlphaDrive.Windows.Extensions.StartupExtensionPriorities.MEDIUM
            ;

    }
}
