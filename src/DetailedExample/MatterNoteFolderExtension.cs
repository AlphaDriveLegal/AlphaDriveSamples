using AlphaDrive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailedExample {

    /// <summary>
    /// This extension handles telling the framework that we want to make sure that we keep Matter notes in sync.
    /// Notice that this class is talking to the "Settings" class to find out whether we're enabled or not.
    /// </summary>
    /// 
    [StartupExtensionOptions(StartupPriority: ExtensionPriorities.MatterNoteFolderExtension)]
    public class MatterNoteFolderExtension : AlphaDrive.StartupExtension {

        /*
            Extensions go through four different phases
            1.  All Extensions get Created (constructor).
            2.  All Extensions get Initialized.
            3.  All Extensions get Started.
            4.  All Extensions get Shutdown.

            The Initialize step is where extensions should attach to other extensions.
            It is before heavy lifting code has really started running.
 
            The Startup step is where the component starts doing actual work.

            The Shutdown step is called when AlphaDrive is shutting down and is the cleanup step.
       
             */


        protected override Task<bool> Initialize(StartupExtension ThisExtension) {

            var Extension = AlphaDrive.Application.Extension<AlphaDrive.Data.Connectivity.ConnectivityExtension>();

            Extension.ShouldPreloadApiEvent += this.Extension_ShouldPreloadApiEvent;
            Extension.ShouldRefreshApiEvent += this.Extension_ShouldPreloadApiEvent;

            return Success;
        }

        protected override Task<bool> Startup(StartupExtension ThisExtension) {
            return Success;
        }

        protected override Task<bool> Shutdown(StartupExtension ThisExtension) {
            var Extension = AlphaDrive.Application.Extension<AlphaDrive.Data.Connectivity.ConnectivityExtension>();

            Extension.ShouldPreloadApiEvent -= this.Extension_ShouldPreloadApiEvent;
            Extension.ShouldRefreshApiEvent -= this.Extension_ShouldPreloadApiEvent;

            return Success;
        }

        private Task Extension_ShouldPreloadApiEvent(object sender, AlphaDrive.Data.Connectivity.ShouldLoadApi e) {
            if (e.API is Clio.API.Repository.MatterNoteApiCached && Settings.Default.MatterNotesExtension_Enabled) {
                e.Handled = true;
                e.Result = true;
            }

            return Task.CompletedTask;
        }

    }
}
