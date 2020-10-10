using Filemanager;

namespace FileManager
{
    public class FileManager
    {
        public FileManager() {
            FolderHandler fileHandler = new FolderHandler();
            fileHandler.SearchDrive();
        }
    }
}