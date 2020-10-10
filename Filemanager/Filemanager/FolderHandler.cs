using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Filemanager
{
    class FolderHandler : Display
    {
        private readonly Stack<string> stackPath = new Stack<string>();

        public void SearchDrive()
        {
            var isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

            if (isWindows)
            {
                WriteOut(Directory.GetLogicalDrives().Select(ld => new Tuple<FileSystemInfo, string>(null, ld)));
                SelectTheFiles(Directory.GetLogicalDrives().Select(ld => new Tuple<FileSystemInfo, string>(null, ld)));
            }
            else
            {
                var directory = new DirectoryInfo(@"/home");

                WriteOut(directory.GetDirectories().Select(d => new Tuple<FileSystemInfo, string>(d, d.Name)));
                SelectTheFiles(directory.GetDirectories().Select(d => new Tuple<FileSystemInfo, string>(d, d.Name)));

            }

            Console.ReadLine();
        }

        private void SearchTheFilesAndFolders()
        {
            var path = new StringBuilder().AppendJoin(Path.DirectorySeparatorChar, stackPath.Reverse()).ToString();
            var directory = new DirectoryInfo(path);

            try
            {
                Console.Clear();
                var fileInfos = directory.GetFiles("*");
                var directoryInfos = directory.GetDirectories();
                var containedFilesAndDirectories = new List<FileSystemInfo>();

                foreach (var fileInfo in fileInfos)
                    containedFilesAndDirectories.Add(fileInfo);

                foreach (var directoryInfo in directoryInfos)
                    containedFilesAndDirectories.Add(directoryInfo);

                Console.WriteLine();
                Console.WriteLine("Elérhető mappák/fájlok:");

                WriteOut(containedFilesAndDirectories.Select(cfd => new Tuple<FileSystemInfo, string>(cfd, cfd.Name)));
                SelectTheFiles(containedFilesAndDirectories.Select(cfd => new Tuple<FileSystemInfo, string>(cfd, cfd.Name)));

            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n--------\nValami hiba történt... {ex.Message}\n--------");
                Console.ResetColor();

                StepBackOneDirectory();
            }
        }

        private void SelectTheFiles(IEnumerable<Tuple<FileSystemInfo, string>> fileInfos)
        {
            var sizeOfTheList = 0;
            var input = fileInfos.ElementAt(sizeOfTheList).Item2;
            var shouldStop = false;

            Console.Write(input);

            while (true)
            {
                var key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.Backspace:
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.H:
                        StepBackOneDirectory();
                        break;
                    case ConsoleKey.Enter:
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.L:
                        stackPath.Push(fileInfos.ElementAt(sizeOfTheList).Item2);
                        shouldStop = true;
                        break;
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.J:
                        sizeOfTheList = GoDown(fileInfos, sizeOfTheList);
                        break;
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.K:
                        sizeOfTheList = GoUp(fileInfos, sizeOfTheList);
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }

                if (shouldStop)
                    break;
            }

            OpenFileOrFolders(fileInfos, sizeOfTheList);
        }

        private void OpenFileOrFolders(IEnumerable<Tuple<FileSystemInfo, string>> fileInfos, int index)
        {
            if (fileInfos.ElementAt(index).Item1 is FileInfo)
            {
                var path = new StringBuilder().AppendJoin(Path.DirectorySeparatorChar, stackPath.Reverse()).ToString();
                Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });
            }

            SearchTheFilesAndFolders();
        }

        private int GoUp(IEnumerable<Tuple<FileSystemInfo, string>> fileInfos, int index)
        {
            if (index > 0)
            {
                index--;

                ClearLine();

                Console.Write(SplitFileSystemInfo(fileInfos.ElementAt(index).Item2));
            }

            return index;
        }

        protected int GoDown(IEnumerable<Tuple<FileSystemInfo, string>> fileInfos, int index)
        {
            if (index < fileInfos.Count() - 1)
            {
                index++;

                ClearLine();

                Console.Write(SplitFileSystemInfo(fileInfos.ElementAt(index).Item2));
            }

            return index;
        }

        private void StepBackOneDirectory()
        {
            if (stackPath.Count < 2)
            {
                stackPath.Clear();
                SearchDrive();
            }
            else
            {
                var path = stackPath.Pop();
                Console.WriteLine(path);
                SearchTheFilesAndFolders();
            }
        }
    }
}
