using Filemanager;

namespace FileManager
{
    public class FileManager
    {
        public FileManager() {
            FolderHandler fc = new FolderHandler();
            fc.SearchDrive();
        }
    }
}
