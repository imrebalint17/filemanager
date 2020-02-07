using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace Filemanager
{
    class Program
    {
        public string path = "";
        static void Main(string[] args)
        {
            Program pr = new Program();
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            pr.SearchDrive();
        }
        void SearchDrive()
        {
            WriteOut(new ArrayList(Directory.GetLogicalDrives()));
            Console.ReadLine();
        }
        void SearchTheFilesAndFolders()
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] fileInfo = directory.GetFiles("*");
            DirectoryInfo[] directoryInfo = directory.GetDirectories();
            ArrayList containedFilesAndDirectories = new ArrayList();
            foreach (var item in fileInfo)
            {
                containedFilesAndDirectories.Add(item);
            }
            foreach (var item in directoryInfo)
            {
                containedFilesAndDirectories.Add(item);
            }
            Console.Write("\n");
            Console.WriteLine("Elérhető mappák/fájlok:");
            WriteOut(containedFilesAndDirectories);
        }
        void SelectTheFiles(ArrayList selectableList)
        {
            int sizeOfTheList = 0;
            var input = selectableList[sizeOfTheList].ToString();
            Console.Write(input);
            bool canTheWhileLoopBrake = false;
            while (true)
            {

                var key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.Backspace:
                        StepBackOneDirectory();
                        break;
                    case ConsoleKey.LeftArrow:
                        StepBackOneDirectory();
                        break;
                    case ConsoleKey.H:
                        StepBackOneDirectory();
                        break;
                    case ConsoleKey.Enter:
                        path = selectableList[sizeOfTheList].ToString();
                        canTheWhileLoopBrake = true;
                        break;
                    case ConsoleKey.RightArrow:
                        path = selectableList[sizeOfTheList].ToString();
                        canTheWhileLoopBrake = true;
                        break;
                    case ConsoleKey.L:
                        path = selectableList[sizeOfTheList].ToString();
                        canTheWhileLoopBrake = true;
                        break;
                    case ConsoleKey.DownArrow:
                        sizeOfTheList = GoDown(sizeOfTheList, selectableList);
                        break;
                    case ConsoleKey.J:
                        sizeOfTheList = GoDown(sizeOfTheList, selectableList);
                        break;
                    case ConsoleKey.UpArrow:
                        sizeOfTheList = GoUp(sizeOfTheList, selectableList);
                        break;
                    case ConsoleKey.K:
                        sizeOfTheList = GoUp(sizeOfTheList, selectableList);
                        break;
                }

                if (canTheWhileLoopBrake == true)
                {
                    break;
                }
            }
            SearchTheFilesAndFolders();
        }
        int GoUp(int index, ArrayList selectableList)
        {
            if (index > 0)
            {
                index--;
                ClearLine();
                Console.Write(SplitanArrayList(selectableList[index]).ToString()+"\\");
            }
            return index;
        }
        int GoDown(int index, ArrayList selectableList)
        {
            if (index < selectableList.Count - 1)
            {
                index++;
                ClearLine();
                Console.Write(SplitanArrayList(selectableList[index]).ToString() + "\\");
            }
            return index;
        }
        void WriteOut(ArrayList OutWriteableList)
        {
            OutWriteableList.Sort() ;
            Console.Write("\n");
            if (OutWriteableList[0] is DirectoryInfo || OutWriteableList[0] is FileInfo)
            {
                foreach (var item in OutWriteableList)
                {

                    Console.WriteLine(SplitanArrayList(item));
                }
            }
            else
            {
                foreach (var item in OutWriteableList)
                {

                    Console.WriteLine(item);
                }
            }


            Console.Write("\n");
            SelectTheFiles(OutWriteableList);
        }

        void ClearLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
        string SplitanArrayList(System.Object splittableList)
        {
            string[] splitable = splittableList.ToString().Split('\\');

            Array.Reverse(splitable);
            if (splitable[0] != "")
            {
                return splitable[0];
            }
            else
            {
                return splitable[1];
            }
        }
        void StepBackOneDirectory()
        {
            string[] splitedPath = path.Split("\\");
            if (splitedPath.Length <= 2)
            {
                
                path = "";
                SearchDrive();
                //breakpoint
            }
            else
            {
                path = "";
                Array.Resize(ref splitedPath, splitedPath.Length - 2);
                foreach (var item in splitedPath)
                {
                    path += splitedPath + "\\";
                }
                SearchTheFilesAndFolders();
                    //breakpoint
            }
        }
    }
}
