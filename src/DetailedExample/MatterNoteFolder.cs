using AlphaDrive.Dav;
using Clio.API.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailedExample {
    public class MatterNoteFolder : FileSystemFolder {
        
        //This class defines the operations for the MatterNoteFolder.
        public MatterNoteFolder(WebDavContext Context, FileSystemFolder Parent) : base(Context, Parent) {

        }

        protected override IEnumerator<string> Names() {
        
            //Choose a long/short name based on settings
            yield return ResolveName("[Matter Notes]", "[Notes]");

            //Or use this as a name.
            yield return "[Info]";
        }

        
        public override async Task<FileSystemFile> CreateFileAsync(string FileName, Stream Contents) {

            //We're only going to allow creating text files.
            var Extension = System.IO.Path.GetExtension(FileName);
            if(!string.Equals(Extension, ".txt", StringComparison.InvariantCultureIgnoreCase)) {
                throw Exceptions.NeedPermissionException;
            }


            //And we're going to make sure that we're inside a matter (just in case!)
            var MatterParent = Parent.Parent<MatterFolder>();

            var PotentialMatterId = MatterParent?.Matter?.ID;

            if (!(PotentialMatterId is long MatterId)) {
                throw Exceptions.NeedPermissionException;
            }

            //Now we're going to create the object in Clio.
            var NamePart = System.IO.Path.GetFileNameWithoutExtension(FileName);
            var Reader = new System.IO.StreamReader(Contents);
            var Detail = Reader.ReadToEnd();

            var API = AlphaDrive.SharedApiClient.Instance.MatterNotes;
            var result = await API.Add(new MatterNoteCreateCommand() {
                Date = DateTime.UtcNow,
                Subject = NamePart,
                Detail = Detail,
                MatterId = MatterId
            }).DefaultAwait();

            return new MatterNoteFile(Context, this, result.Response);
        }

    }
}
