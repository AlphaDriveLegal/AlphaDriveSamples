using AlphaDrive.Dav;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailedExample {

    /// <summary>
    /// //This class will add items into matter folders.  Specifically, it just adds the "Matter Notes" virtual folder.
    /// </summary>
    [ListerFor(typeof(MatterFolder))]
    public class MatterNoteFolderLister : ListerSync {

        protected override void GetChildren(WebDavContext Context, FileSystemFolder Parent, List<FileSystemObject> Output) {

            if (!Settings.Default.MatterNotesExtension_Enabled) {
                return;
            }

            Output.Add(new MatterNoteFolder(Context, Parent));

        }

    }
}