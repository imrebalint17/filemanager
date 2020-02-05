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
            
            pr.searchDrive();
        }
        void searchDrive()
		{
			writeOut(new ArrayList(DriveInfo.GetDrives()));
			Console.ReadLine();
        }
        void searchTheFilesAndFolders()
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
            //containedFilesAndDirectories.Sort();
            Console.Write("\n");
            Console.WriteLine("Elérhető mappák/fájlok:");
            writeOut(containedFilesAndDirectories);
        }
        void selectTheFiles(ArrayList selectableList)
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
                        stepBackOneDirectory();
                        break;
                    case ConsoleKey.Enter:
                        path = selectableList[sizeOfTheList].ToString();
                        canTheWhileLoopBrake = true;
                        break;
                   case ConsoleKey.DownArrow:
                        if (sizeOfTheList < selectableList.Count - 1)
                        {
                            
                            sizeOfTheList++;
                            clearLine();
                            Console.Write(splitanArrayList(selectableList[sizeOfTheList]));

                        }
                        
                        break;
                    case ConsoleKey.UpArrow:
                        if (sizeOfTheList > 0)
                        {
                            sizeOfTheList--;
                            clearLine();
                            Console.Write(splitanArrayList(selectableList[sizeOfTheList]));

                        }
                        break;
               }
               
                if(canTheWhileLoopBrake == true)
                {
                    break;
                }
            }
            searchTheFilesAndFolders();
        }
        void writeOut(ArrayList OutWriteableList)
        {
            if (OutWriteableList[0] is DirectoryInfo || OutWriteableList[0] is FileInfo)
            {
                foreach (var item in OutWriteableList)
                {
                    
                    Console.WriteLine(splitanArrayList(item));
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
            selectTheFiles(OutWriteableList);
        }
           
        void clearLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }    
            string splitanArrayList(System.Object splittableList)
            {
                string[] splitable = splittableList.ToString().Split('\\');
                
                Array.Reverse(splitable);
            if (splitable[0]!="")
            {
                return splitable[0];
            }
            else { 
                return splitable[1];
            }
        }
        void stepBackOneDirectory()
        {
            string[] bontott = path.Split("\\");
            
           /* foreach (var item in bontott)
            {
                Console.WriteLine(item);
            }*/
            if (bontott.Length < 2)
            {
                searchDrive();
                path = "";
            }
            else
            {
                path = "";
                Array.Resize(ref bontott, bontott.Length -2);
                foreach (var item in bontott)
                {
                    path += bontott + "\\";
                }
                searchTheFilesAndFolders();

            }
        }
        }
}
