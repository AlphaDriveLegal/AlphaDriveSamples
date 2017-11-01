using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailedExample {

/// <summary>
/// This class provides the constants that are needed to order items
/// </summary>
    class ExtensionPriorities {

        /// <summary>
        /// Make this item's setting panel show up after the "File Settings" panel.
        /// </summary>
        public const long Settings = 
            AlphaDrive.Windows.Extensions.SettingPanelPriorities.File_Settings 
            + AlphaDrive.Windows.Extensions.SettingPanelPriorities.MEDIUM
            ;

        /// <summary>
        /// Load this item after the "Preload Data" step.
        /// </summary>
        public const long MatterNoteFolderExtension =
            AlphaDrive.Windows.Extensions.StartupExtensionPriorities.STARTUP_PreloadData
            + AlphaDrive.Windows.Extensions.StartupExtensionPriorities.MEDIUM
            ;

        /// <summary>
        /// Load this extension after the Controller (the main black bar UI) has been brought up.
        /// </summary>
        public const long InterfaceExtension =
            AlphaDrive.Windows.Extensions.StartupExtensionPriorities.STARTUP_Controller
            + AlphaDrive.Windows.Extensions.StartupExtensionPriorities.MEDIUM
            ;

    }
}
