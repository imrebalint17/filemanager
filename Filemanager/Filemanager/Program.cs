using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Filemanager
{
    class Program
    {
        public Stack StackPath = new Stack();
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
            string path1 = StackPath.Peek().ToString();
           

            DirectoryInfo directory = new DirectoryInfo(path1);
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
                        StackPath.Push(selectableList[sizeOfTheList].ToString());
                        canTheWhileLoopBrake = true;
                        break;
                    case ConsoleKey.RightArrow:
                        StackPath.Push(selectableList[sizeOfTheList].ToString());
                        canTheWhileLoopBrake = true;
                        break;
                    case ConsoleKey.L:
                        StackPath.Push(selectableList[sizeOfTheList].ToString());
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
            
            openaFileorFolders(selectableList,sizeOfTheList);
        }
        void openaFileorFolders(ArrayList selectablelist,int index)
        {
           if( selectablelist[index] is FileInfo)
            {
                string path = StackPath.Pop().ToString();
                System.Diagnostics.Process.Start("HKEY_CLASSES_ROOT\\"+ path);
            }
            else
            {
                SearchTheFilesAndFolders();
            }
        }
        int GoUp(int index, ArrayList selectableList)
        {
            if (index > 0)
            {
                index--;
                ClearLine();
                if (selectableList[index] is FileInfo) { 
                Console.Write(SplitanArrayList(selectableList[index]).ToString());
                }
                else
                {
                    Console.Write(SplitanArrayList(selectableList[index]).ToString() + "\\");
                }
            }
            return index;
        }
        int GoDown(int index, ArrayList selectableList)
        {
            if (index < selectableList.Count - 1)
            {
                index++;
                ClearLine();
                if (selectableList[index] is FileInfo)
                {
                    Console.Write(SplitanArrayList(selectableList[index]).ToString());
                }
                else
                {
                    Console.Write(SplitanArrayList(selectableList[index]).ToString() + "\\");
                }
            }
            return index;
        }
        void WriteOut(ArrayList OutWriteableList)
        {
            
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
            string path;
            if (StackPath.Count < 2)
            {

                StackPath.Clear();
                SearchDrive();
                //breakpoint
            }
            else
            {
                path = "";
                path = StackPath.Pop().ToString();
                Console.WriteLine(path);
                SearchTheFilesAndFolders();
                //breakpoint
            }
        }
    }
}
