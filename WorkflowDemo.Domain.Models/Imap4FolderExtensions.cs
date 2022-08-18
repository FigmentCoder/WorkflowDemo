using EAGetMail;

namespace WorkflowDemo.Domain.Models
{
    public static class Imap4FolderExtensions
    {
        public static bool IsIncluded(this Imap4Folder imap4Folder)
            => imap4Folder.Name.Equals("Drafts") ||
               imap4Folder.Name.Equals("Sent") || 
               imap4Folder.Name.Equals("spam") ||
               imap4Folder.Name.Equals("Trash");
    }
}