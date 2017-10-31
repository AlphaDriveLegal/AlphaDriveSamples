using AlphaDrive.Dav;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailedExample {

    //This class returns items that are children of a "Matter Note Folder"
    [ListerFor(typeof(MatterNoteFolder))]
    public class MatterNoteFileLister : ListerSync {
        protected override void GetChildren(WebDavContext Context, FileSystemFolder Parent, List<FileSystemObject> Output) {

            //Find our parent matter folder and get its MatterID.
            var ParentMatter = Parent.Parent<MatterFolder>();

            var ParentMatterId = ParentMatter?.Matter?.ID;

            if (!(ParentMatterId is long)) {
                return;
            }

            //Get the items our of our database that belong to the current matter.
            var API = AlphaDrive.SharedApiClient.Instance.MatterNotes;

            var Items = API.Where(x => x.Matter == ParentMatterId);

            //Return virtual files for each item
            foreach (var item in Items) {
                Output.Add(new MatterNoteFile(Context, Parent, item));
            }

        }
    }
}
