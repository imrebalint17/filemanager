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
						/*
            DriveInfo[] driveInfo = DriveInfo.GetDrives();
            ArrayList containedDrives = new ArrayList();
            foreach (var item in driveInfo)
            {
                containedDrives.Add(item);
            }
            Console.WriteLine("Elérhető meghajtók:");
            writeOut(containedDrives);
            
            Console.ReadLine();
						*/
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
                    /*
                    case ConsoleKey.Tab:
                        break;
                    case ConsoleKey.Clear:
                        break;*/
                    case ConsoleKey.Enter:

                        path = selectableList[sizeOfTheList].ToString();


                        canTheWhileLoopBrake = true;
                        break;/*
                    case ConsoleKey.Pause:
                        break;
                    case ConsoleKey.Escape:
                        break;
                    case ConsoleKey.Spacebar:
                        break;
                    case ConsoleKey.PageUp:
                        
                        break;
                    case ConsoleKey.PageDown:
                       
                        break;
                        
                    case ConsoleKey.End:
                        break;
                    case ConsoleKey.Home:
                        break;
                    case ConsoleKey.LeftArrow:
                        break;
                        */
                    case ConsoleKey.DownArrow:
                        if (sizeOfTheList < selectableList.Count - 1)
                        {
                            
                            sizeOfTheList++;
                            clearLine();
                            Console.Write(splitanArrayList(selectableList[sizeOfTheList]));

                        }
                        
                        break;/*
                    case ConsoleKey.RightArrow:
                        break;*/
                    case ConsoleKey.UpArrow:
                        if (sizeOfTheList > 0)
                        {
                            sizeOfTheList--;
                            clearLine();
                            Console.Write(splitanArrayList(selectableList[sizeOfTheList]));


                        }
                        
                        break;/*
                    case ConsoleKey.Select:
                        break;
                    case ConsoleKey.Print:
                        break;
                    case ConsoleKey.Execute:
                        break;
                    case ConsoleKey.PrintScreen:
                        break;
                    case ConsoleKey.Insert:
                        break;
                    case ConsoleKey.Delete:
                        break;
                    case ConsoleKey.Help:
                        break;
                    case ConsoleKey.D0:
                        break;
                    case ConsoleKey.D1:
                        break;
                    case ConsoleKey.D2:
                        break;
                    case ConsoleKey.D3:
                        break;
                    case ConsoleKey.D4:
                        break;
                    case ConsoleKey.D5:
                        break;
                    case ConsoleKey.D6:
                        break;
                    case ConsoleKey.D7:
                        break;
                    case ConsoleKey.D8:
                        break;
                    case ConsoleKey.D9:
                        break;
                    case ConsoleKey.A:
                        break;
                    case ConsoleKey.B:
                        break;
                    case ConsoleKey.C:
                        break;
                    case ConsoleKey.D:
                        break;
                    case ConsoleKey.E:
                        break;
                    case ConsoleKey.F:
                        break;
                    case ConsoleKey.G:
                        break;
                    case ConsoleKey.H:
                        break;
                    case ConsoleKey.I:
                        break;
                    case ConsoleKey.J:
                        break;
                    case ConsoleKey.K:
                        break;
                    case ConsoleKey.L:
                        break;
                    case ConsoleKey.M:
                        break;
                    case ConsoleKey.N:
                        break;
                    case ConsoleKey.O:
                        break;
                    case ConsoleKey.P:
                        break;
                    case ConsoleKey.Q:
                        break;
                    case ConsoleKey.R:
                        break;
                    case ConsoleKey.S:
                        break;
                    case ConsoleKey.T:
                        break;
                    case ConsoleKey.U:
                        break;
                    case ConsoleKey.V:
                        break;
                    case ConsoleKey.W:
                        break;
                    case ConsoleKey.X:
                        break;
                    case ConsoleKey.Y:
                        break;
                    case ConsoleKey.Z:
                        break;
                    case ConsoleKey.LeftWindows:
                        break;
                    case ConsoleKey.RightWindows:
                        break;
                    case ConsoleKey.Applications:
                        break;
                    case ConsoleKey.Sleep:
                        break;
                    case ConsoleKey.NumPad0:
                        break;
                    case ConsoleKey.NumPad1:
                        break;
                    case ConsoleKey.NumPad2:
                        break;
                    case ConsoleKey.NumPad3:
                        break;
                    case ConsoleKey.NumPad4:
                        break;
                    case ConsoleKey.NumPad5:
                        break;
                    case ConsoleKey.NumPad6:
                        break;
                    case ConsoleKey.NumPad7:
                        break;
                    case ConsoleKey.NumPad8:
                        break;
                    case ConsoleKey.NumPad9:
                        break;
                    case ConsoleKey.Multiply:
                        break;
                    case ConsoleKey.Add:
                        break;
                    case ConsoleKey.Separator:
                        break;
                    case ConsoleKey.Subtract:
                        break;
                    case ConsoleKey.Decimal:
                        break;
                    case ConsoleKey.Divide:
                        break;
                    case ConsoleKey.F1:
                        break;
                    case ConsoleKey.F2:
                        break;
                    case ConsoleKey.F3:
                        break;
                    case ConsoleKey.F4:
                        break;
                    case ConsoleKey.F5:
                        break;
                    case ConsoleKey.F6:
                        break;
                    case ConsoleKey.F7:
                        break;
                    case ConsoleKey.F8:
                        break;
                    case ConsoleKey.F9:
                        break;
                    case ConsoleKey.F10:
                        break;
                    case ConsoleKey.F11:
                        break;
                    case ConsoleKey.F12:
                        break;
                    case ConsoleKey.F13:
                        break;
                    case ConsoleKey.F14:
                        break;
                    case ConsoleKey.F15:
                        break;
                    case ConsoleKey.F16:
                        break;
                    case ConsoleKey.F17:
                        break;
                    case ConsoleKey.F18:
                        break;
                    case ConsoleKey.F19:
                        break;
                    case ConsoleKey.F20:
                        break;
                    case ConsoleKey.F21:
                        break;
                    case ConsoleKey.F22:
                        break;
                    case ConsoleKey.F23:
                        break;
                    case ConsoleKey.F24:
                        break;
                    case ConsoleKey.BrowserBack:
                        break;
                    case ConsoleKey.BrowserForward:
                        break;
                    case ConsoleKey.BrowserRefresh:
                        break;
                    case ConsoleKey.BrowserStop:
                        break;
                    case ConsoleKey.BrowserSearch:
                        break;
                    case ConsoleKey.BrowserFavorites:
                        break;
                    case ConsoleKey.BrowserHome:
                        break;
                    case ConsoleKey.VolumeMute:
                        break;
                    case ConsoleKey.VolumeDown:
                        break;
                    case ConsoleKey.VolumeUp:
                        break;
                    case ConsoleKey.MediaNext:
                        break;
                    case ConsoleKey.MediaPrevious:
                        break;
                    case ConsoleKey.MediaStop:
                        break;
                    case ConsoleKey.MediaPlay:
                        break;
                    case ConsoleKey.LaunchMail:
                        break;
                    case ConsoleKey.LaunchMediaSelect:
                        break;
                    case ConsoleKey.LaunchApp1:
                        break;
                    case ConsoleKey.LaunchApp2:
                        break;
                    case ConsoleKey.Oem1:
                        break;
                    case ConsoleKey.OemPlus:
                        break;
                    case ConsoleKey.OemComma:
                        break;
                    case ConsoleKey.OemMinus:
                        break;
                    case ConsoleKey.OemPeriod:
                        break;
                    case ConsoleKey.Oem2:
                        break;
                    case ConsoleKey.Oem3:
                        break;
                    case ConsoleKey.Oem4:
                        break;
                    case ConsoleKey.Oem5:
                        break;
                    case ConsoleKey.Oem6:
                        break;
                    case ConsoleKey.Oem7:
                        break;
                    case ConsoleKey.Oem8:
                        break;
                    case ConsoleKey.Oem102:
                        break;
                    case ConsoleKey.Process:
                        break;
                    case ConsoleKey.Packet:
                        break;
                    case ConsoleKey.Attention:
                        break;
                    case ConsoleKey.CrSel:
                        break;
                    case ConsoleKey.ExSel:
                        break;
                    case ConsoleKey.EraseEndOfFile:
                        break;
                    case ConsoleKey.Play:
                        break;
                    case ConsoleKey.Zoom:
                        break;
                    case ConsoleKey.NoName:
                        break;
                    case ConsoleKey.Pa1:
                        break;
                    case ConsoleKey.OemClear:
                        break;
                    */
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
