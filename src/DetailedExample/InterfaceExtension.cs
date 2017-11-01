using AlphaDrive;
using AlphaDrive.Dav;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DetailedExample {

    /// <summary>
    /// This class creates a new "Interface Designer" class and then pulls out members and attaches them into the main interface.
    /// </summary>
    [StartupExtensionOptions(StartupPriority: ExtensionPriorities.InterfaceExtension)]
    public class InterfaceExtension : AlphaDrive.InterfaceExtension<InterfaceDesigner> {
        protected override Task<bool> Startup(UIElement ThisInterface) {
            
            //The InjectionPoint is the Destination extension.
            var InjectionPoint = AlphaDrive.Application.Extension<AlphaDrive.Windows.Extensions.ControllerDialogExtension>();

            //AttachItems takes all children from the SourceContainer and makes them children of the control in the InjectionPoint.
            //It also registers the items to be removed from the InjectionPoint when the component starts shutting down.
            AttachItems(this.Interface.SourceContainer, InjectionPoint.ControllerDialog.ApplicationMenuStrip);

            return Success;

        }
    }


}
