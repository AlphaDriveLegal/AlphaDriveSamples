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
    class MatterNoteFolderExtension : AlphaDrive.StartupExtension {
        protected override Task<bool> Initialize(StartupExtension ThisExtension) {

            var Extension = AlphaDrive.Application.Extension<AlphaDrive.Data.Connectivity.ConnectivityExtension>();

            Extension.ShouldPreloadApiEvent += this.Extension_ShouldPreloadApiEvent;
            Extension.ShouldRefreshApiEvent += this.Extension_ShouldPreloadApiEvent;

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
