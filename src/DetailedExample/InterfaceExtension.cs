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

    [StartupExtensionOptions(StartupPriority: ExtensionPriorities.InterfaceExtension)]
    class InterfaceExtension : AlphaDrive.InterfaceExtension<InterfaceDesigner> {
        protected override Task<bool> Startup(UIElement ThisInterface) {

            var InjectionPoint = AlphaDrive.Application.Extension<AlphaDrive.Windows.Extensions.ControllerDialogExtension>();

            AttachItems(this.Interface.SourceContainer, InjectionPoint.ControllerDialog.ApplicationMenuStrip);

            return Success;

        }
    }


}
