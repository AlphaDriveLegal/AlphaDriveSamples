using AlphaDrive;
using AlphaDrive.Dav;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Clio.API.Repository;

namespace DetailedExample {
    public class MatterNoteFile : FileSystemFile {

        //This class wraps a Matter Note and turns it into a virtual file.


        public Clio.API.Repository.MatterNoteJson MatterNote { get; private set; }

        public MatterNoteFile(WebDavContext Context, FileSystemFolder Parent, Clio.API.Repository.MatterNoteJson MatterNote) : base(Context, Parent) {
            if (MatterNote == null) {
                throw new ArgumentException(nameof(MatterNote));
            }

            this.MatterNote = MatterNote;

        }

        protected override IEnumerator<string> Names() {
            //These are multiple names we can use in case there is a conflict in the names.
            yield return $"{MatterNote.Subject}.txt";
            yield return $"{MatterNote.Subject}({MatterNote.Date.ToGlobalDate()}).txt";
            yield return $"{MatterNote.Subject}({MatterNote.ID}).txt";
        }

        //Return info from the matter.
        public override long? ContentLength {
            get {
                return MatterNote.Detail?.Length;
            }
        }

        public override DateTimeOffset? Created {
            get {
                return MatterNote.Created_At;
            }
        }

        public override DateTimeOffset? Modified {
            get {
                return MatterNote.Updated_At;
            }
        }

        protected override async Task<FileSystemFile> MoveToAsync(FileSystemFolder DestFolder, string DestName, FileSystemFile ItemToOverwrite) {

            if(!(DestFolder is MatterNoteFolder Shortcut) || ItemToOverwrite != null) {
                return await base.MoveToAsync(DestFolder, DestName, ItemToOverwrite).DefaultAwait();
            }

            var Extension = System.IO.Path.GetExtension(DestName);
            if(!string.Equals(Extension, ".txt", StringComparison.InvariantCultureIgnoreCase)) {
                throw Exceptions.NeedPermissionException;
            }

            //And we're going to make sure that we're inside a matter (just in case!)
            var MatterParent = Parent.Parent<MatterFolder>();

            var PotentialMatterId = MatterParent?.Matter?.ID;

            if (!(PotentialMatterId is long MatterId)) {
                throw Exceptions.NeedPermissionException;
            }

            var FileName = System.IO.Path.GetFileNameWithoutExtension(DestName);
            var ret = await AlphaDrive.SharedApiClient.Instance.MatterNotes.Update(this.MatterNote.ID, new MatterNoteCreateCommand() {
                Date = MatterNote.Date?.DateTime ?? DateTime.Now,
                Subject = FileName,
                Detail = MatterNote.Detail,
                

            }).DefaultAwait();

            return new MatterNoteFile(Context, DestFolder, ret.Response);
        }


        public override Task<Stream> ReadAsync() {
            var ret = new System.IO.MemoryStream(System.Text.Encoding.Default.GetBytes(MatterNote.Detail));

            return ret.ToResult<Stream>();
        }

        public override async Task DeleteAsync() {
            await SharedApiClient.Instance.MatterNotes.Delete(MatterNote.ID)
                .DefaultAwait()
                ;
        }

        public override async Task<bool> WriteAsync(Stream Content, string contentType, long startIndex, long totalFileSize) {
            var StreamReader = new System.IO.StreamReader(Content);
            var NewContent = StreamReader.ReadToEnd();

            await SharedApiClient.Instance.MatterNotes.Update(MatterNote.ID, new MatterNoteCreateCommand() {
                Subject = MatterNote.Subject,
                Detail = NewContent,
                MatterId = MatterNote.Matter,
                Date = DateTime.UtcNow,
            }).DefaultAwait();

            return true;
        }

    }
}
