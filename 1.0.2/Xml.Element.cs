using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Management;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
using System.Threading;


namespace DCL
{

  
    

    public class Xcase
    {

       


        private const int MF_BYCOMMAND = 0x00000000;
        public const int SC_CLOSE = 0xF060;
        public const int SC_MINIMIZE = 0xF020;
        public const int SC_MAXIMIZE = 0xF030;
        public const int SC_SIZE = 0xF000;

        [DllImport("user32.dll")]
        public static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        public static string from = "";
        public static void index(/*string Import*/)
        {
            HotKeyManager.RegisterHotKey(Keys.F1, KeyModifiers.Control);
            HotKeyManager.HotKeyPressed += new EventHandler<HotKeyEventArgs>(HotKeyManager_HotKeyPressed);
            Console.ReadLine();  

         //   int ass = Import.Length;


// MessageBox.Show(Import.PadLeft(ass));

            string text = File.ReadAllText(/*Import.PadLeft(ass)*/from);
            text = text.Replace("{", "<").Replace("}", ">").Replace("#", "/").Replace("\\\\", "\\").Replace("<i[","<import>").Replace("]i>","</import>").Replace("import(","<import>").Replace(")end import","</import>").Replace("cursor = false","<cursorE/>"); ;
            File.WriteAllText(from, text);
           
            
            // Start with XmlReader object
            //here, we try to setup Stream between the XML file nad xmlReader
            using (XmlReader reader = XmlReader.Create(from))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        //return only when you have START tag

                        switch (reader.Name.ToString())
                        {
                            case "nw:msgb":
                                MessageBox.Show(reader.ReadString(), reader.ReadString());
                                break;
                            case "msgb":
                                MessageBox.Show(reader.ReadString(), from);
                                break;
                            case "sysdir:env":
                                Console.WriteLine(Environment.SystemDirectory);
                                break;
                            case "machinename:env":
                                Console.WriteLine(Environment.MachineName);
                                break;
                            case "usrnm:env":
                                Console.WriteLine(Environment.UserName);
                                break;
                            case "usrdomain:env":
                                Console.WriteLine(Environment.UserDomainName);
                                break;
                            case "newln:env":
                                Console.WriteLine(Environment.NewLine);
                                break;
                            case "cursorE":
                                Console.CursorVisible = false;
                                break;
                            case "print":
                                Console.WriteLine(reader.ReadString().Replace("fuck", "****"));
                                break;
                            //fore color
                            //color
                            case "whitefore":
                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case "blackfore":
                                Console.ForegroundColor = ConsoleColor.Black;
                                break;

                            case "bluefore":
                                Console.ForegroundColor = ConsoleColor.Blue;
                                break;

                            case "cyanfore":
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                break;

                            case "redfore":
                                Console.ForegroundColor = ConsoleColor.Red;
                                break;

                            case "yellowfore":
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                break;

                            case "greenfore":

                                Console.ForegroundColor = ConsoleColor.Green;
                                break;


                            case "grayfore":
                                Console.ForegroundColor = ConsoleColor.Gray;
                                break;

                            ///color
                            ///
                            ///fore color
                            ///
                           
                            case "whitebackground":
                                Console.BackgroundColor = ConsoleColor.White;
                                break;
                            case "blackbackground":
                                Console.BackgroundColor = ConsoleColor.Black;
                                break;

                            case "bluebackground":
                                Console.BackgroundColor = ConsoleColor.Blue;
                                break;

                            case "cyanbackground":
                                Console.BackgroundColor = ConsoleColor.Cyan;
                                break;

                            case "redbackground":
                                Console.BackgroundColor = ConsoleColor.Red;
                                break;

                            case "yellowbackground":
                                Console.BackgroundColor = ConsoleColor.Yellow;
                                break;

                            case "greenbackground":
                                Console.BackgroundColor = ConsoleColor.Green;
                                break;


                            case "graybackground":
                                Console.BackgroundColor = ConsoleColor.Gray;
                                break;
                            ///back
                            ///
                            case "FileCreate:IO":
                                //  if (File.Exists(reader.ReadString()))
                                // {
                                //MessageBox.Show("error the file "+reader.ReadString() + "has exist",contains,MessageBoxButtons.YesNo,MessageBoxIcon.Error);
                                // }
                                //else
                                // {
                                File.Create(reader.ReadString());
                                // }
                                break;

                            case "DirectoryCreate:IO":

                                //  if (File.Exists(reader.ReadString()))
                                // {
                                //MessageBox.Show("error the file "+reader.ReadString() + "has exist",contains,MessageBoxButtons.YesNo,MessageBoxIcon.Error);
                                // }
                                //else
                                // {
                                Directory.CreateDirectory(reader.ReadString());
                                // }
                                break;
                            case "FileDelete:IO":

                                // Selects all the title elements that have an attribute named lang

                                // It was found, manipulate it.
                                File.Delete(reader.ReadString());
                                break;

                            case "Yncancel":
                                Console.WriteLine(reader.ReadString());
                                switch (Console.ReadLine())
                                {
                                    case "Y": case "y":
                                        break;
                                    case "N":case "n":
                                        Environment.Exit(0);
                                        break;
                                }
                                break;



                            case "DirectoryDeletel:IO":
                                Directory.Delete(reader.ReadString());
                                break;
                            case "title":

                                //XDocument doc = new XDocument();


                                Console.Title = reader.ReadString();

                                break;
                            case "process":
                                Process.Start(reader.ReadString());
                                break;



                            case "readline":
                                Console.ReadLine();
                                break;
                            case "readkey":
                                Console.ReadKey();
                                break;
                            case "read":
                                Console.Read();
                                break;
                            case "osv:env":
                                Console.WriteLine(Environment.OSVersion);
                                break;
                            case "msgbox":
                                MessageBox.Show(reader.ReadString(), from);
                                break;
                            case "q:msgbox":
                                MessageBox.Show(reader.ReadString(), from, MessageBoxButtons.OK, MessageBoxIcon.Question);

                                break;
                            case "e:msgbox":
                                MessageBox.Show(reader.ReadString(), from, MessageBoxButtons.OK, MessageBoxIcon.Error);

                                break;

                            case "w:msgbox":
                                MessageBox.Show(reader.ReadString(), from, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                break;

                            case "readalltext:IO":
                                string sf = File.ReadAllText(reader.ReadString());
                                Console.WriteLine(sf);

                                break;
                            case "importbase_containsResizeFalse:publicimport":
                                IntPtr handle = GetConsoleWindow();
                                IntPtr sysMenu = GetSystemMenu(handle, false);

                                if (handle != IntPtr.Zero)
                                {

                                    DeleteMenu(sysMenu, SC_SIZE, MF_BYCOMMAND);
                                }
                                Console.Read();
                                break;
                            case "today:datetime":
                                Console.WriteLine(DateTime.Today);
                                break;

                            case "request_object-move:IO":
                                strings.ExcuteString.tar = reader.ReadString();

                                break;
                            case "request_To-move:IO":
                                strings.ExcuteString.tar = reader.ReadString();
                                break;




                            case "movefile":
                                string a = strings.ExcuteString.tar;
                                string b = strings.ExcuteString.to;
                                File.Move(a, b);
                                break;
                            case "import":
                                using (XmlReader module = XmlReader.Create(reader.ReadString()))
                                {
                                    while (module.Read())
                                    {
                                        if (module.IsStartElement())
                                        {
                                            //return only when you have START tag

                                            switch (module.Name.ToString())
                                            {


                                                case "debugsID":
                                                    Console.WriteLine(@"copyright 2021 by bitcores LLC
website: Dryginbase.ml/dcl
verrsion: 1.0
you are using: import element");
                                                    break;
                                                case "nw:msgb":
                                                    MessageBox.Show(module.ReadString(), module.ReadString());
                                                    break;
                                                case "msgb":
                                                    MessageBox.Show(module.ReadString(), from);
                                                    break;
                                                case "sysdir:env":
                                                    Console.WriteLine(Environment.SystemDirectory);
                                                    break;
                                                case "machinename:env":
                                                    Console.WriteLine(Environment.MachineName);
                                                    break;
                                                case "usrnm:env":
                                                    Console.WriteLine(Environment.UserName);
                                                    break;
                                                case "usrdomain:env":
                                                    Console.WriteLine(Environment.UserDomainName);
                                                    break;
                                                case "newln:env":
                                                    Console.WriteLine(Environment.NewLine);
                                                    break;

                                                case "print":
                                                    Console.WriteLine(module.ReadString().Replace("fuck", "****"));
                                                    break;
                                                //fore color
                                                //color
                                                case "whitefore":
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    break;
                                                case "blackfore":
                                                    Console.ForegroundColor = ConsoleColor.Black;
                                                    break;

                                                case "bluefore":
                                                    Console.ForegroundColor = ConsoleColor.Blue;
                                                    break;

                                                case "cyanfore":
                                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                                    break;

                                                case "redfore":
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    break;

                                                case "yellowfore":
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    break;

                                                case "greenfore":

                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    break;
                                                case "mathrandoms":
                                                    Random m = new Random();
                                                    for (int i = 0; i < 1; i++)
                                                    {
                                                        Console.WriteLine(m.NextDouble());
                                                    }
                                                        break;

                                                case "grayfore":
                                                    Console.ForegroundColor = ConsoleColor.Gray;
                                                    break;

                                                ///color
                                                ///
                                                ///fore color
                                                ///
                                                case "whitebackground":
                                                    Console.BackgroundColor = ConsoleColor.White;
                                                    break;
                                                case "blackbackground":
                                                    Console.BackgroundColor = ConsoleColor.Black;
                                                    break;

                                                case "bluebackground":
                                                    Console.BackgroundColor = ConsoleColor.Blue;
                                                    break;

                                                case "cyanbackground":
                                                    Console.BackgroundColor = ConsoleColor.Cyan;
                                                    break;

                                                case "redbackground":
                                                    Console.BackgroundColor = ConsoleColor.Red;
                                                    break;

                                                case "yellowbackground":
                                                    Console.BackgroundColor = ConsoleColor.Yellow;
                                                    break;

                                                case "greenbackground":
                                                    Console.BackgroundColor = ConsoleColor.Green;
                                                    break;


                                                case "graybackground":
                                                    Console.BackgroundColor = ConsoleColor.Gray;
                                                    break;
                                                ///back
                                                ///
                                                case "FileCreate:IO":
                                                    //  if (File.Exists(reader.ReadString()))
                                                    // {
                                                    //MessageBox.Show("error the file "+reader.ReadString() + "has exist",contains,MessageBoxButtons.YesNo,MessageBoxIcon.Error);
                                                    // }
                                                    //else
                                                    // {
                                                    File.Create(module.ReadString());
                                                    // }
                                                    break;

                                                case "DirectoryCreate:IO":

                                                    //  if (File.Exists(reader.ReadString()))
                                                    // {
                                                    //MessageBox.Show("error the file "+reader.ReadString() + "has exist",contains,MessageBoxButtons.YesNo,MessageBoxIcon.Error);
                                                    // }
                                                    //else
                                                    // {
                                                    Directory.CreateDirectory(module.ReadString());
                                                    // }
                                                    break;
                                                case "FileDelete:IO":

                                                    // Selects all the title elements that have an attribute named lang

                                                    // It was found, manipulate it.
                                                    File.Delete(module.ReadString());
                                                    break;





                                                case "DirectoryDeletel:IO":
                                                    Directory.Delete(module.ReadString());
                                                    break;
                                                case "title":

                                                    //XDocument doc = new XDocument();


                                                    Console.Title = module.ReadString();

                                                    break;
                                                case "process":
                                                    Process.Start(module.ReadString());
                                                    break;
                                                case "yesno":
                                                    while (true)
                                                    {
                                                        switch (Console.ReadLine())
                                                        {
                                                            case "y":case "Y":

                                                                break;
                                                        }
                                                    }
                                                    break;

                                                case "readline":
                                                    Console.ReadLine();
                                                    break;
                                                case "readkey":
                                                    Console.ReadKey();
                                                    break;
                                                case "read":
                                                    Console.Read();
                                                    break;
                                                case "osv:env":
                                                    Console.WriteLine(Environment.OSVersion);
                                                    break;
                                                case "msgbox":
                                                    MessageBox.Show(module.ReadString(), from);
                                                    break;
                                                case "q:msgbox":
                                                    MessageBox.Show(module.ReadString(), from, MessageBoxButtons.OK, MessageBoxIcon.Question);

                                                    break;
                                                case "e:msgbox":
                                                    MessageBox.Show(module.ReadString(), from, MessageBoxButtons.OK, MessageBoxIcon.Error);

                                                    break;

                                                case "w:msgbox":
                                                    MessageBox.Show(module.ReadString(), from, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                                    break;

                                                case "readalltext:IO":
                                                    string s = File.ReadAllText(module.ReadString());
                                                    Console.WriteLine(s);

                                                    break;
                                                case "importbase_containsResizeFalse:publicimport":
                                                    IntPtr handle1 = GetConsoleWindow();
                                                    IntPtr sysMenu1 = GetSystemMenu(handle1, false);

                                                    if (handle1 != IntPtr.Zero)
                                                    {

                                                        DeleteMenu(sysMenu1, SC_SIZE, MF_BYCOMMAND);
                                                    }
                                                    Console.Read();
                                                    break;
                                                case "today:datetime":
                                                    Console.WriteLine(DateTime.Today);
                                                    break;

                                                case "request_object-move:IO":
                                                    strings.ExcuteString.tar = module.ReadString();

                                                    break;
                                                case "request_To-move:IO":
                                                    strings.ExcuteString.tar = module.ReadString();
                                                    break;


                                                
                                                case "movefile":

                                                    string ai = strings.ExcuteString.tar;
                                                    string bi = strings.ExcuteString.to;

                                                    File.Move(ai, bi);
                                                    break;
                                                case "w":
                                                    Console.WriteLine(module.ReadString());
                                                    break;

                                            }
                                        }
                                    }
                                }
                                break;

                        }
                    }
                }
            }

            switch (Console.ReadLine())
            {

            }
            

        }

        /// <summary>
        /// ACTIVE
        /// </summary>

        public static void index_noI()
        {
            while (true)
            {
                string sssssss;
                sssssss = Console.ReadLine();
                string text = File.ReadAllText(from);
                text = text.Replace("{", "<").Replace("}", ">").Replace("#", "/").Replace("\\\\", "\\").Replace("<i[", "<import>").Replace("]i>", "</import>").Replace("import(", "<import>").Replace(")end import", "</import>").Replace("cursor = false", "<cursorE/>"); ;
                File.WriteAllText(from, text);


                // Start with XmlReader object
                //here, we try to setup Stream between the XML file nad xmlReader
                using (XmlReader reader = XmlReader.Create(sssssss))
                {
                    while (reader.Read())
                    {
                        if (reader.IsStartElement())
                        {
                            //return only when you have START tag

                            switch (reader.Name.ToString())
                            {
                                case "nw:msgb":
                                    MessageBox.Show(reader.ReadString(), reader.ReadString());
                                    break;
                                case "msgb":
                                    MessageBox.Show(reader.ReadString(), "Console Dryginbase");
                                    break;
                                case "sysdir:env":
                                    Console.WriteLine(Environment.SystemDirectory);
                                    break;
                                case "machinename:env":
                                    Console.WriteLine(Environment.MachineName);
                                    break;
                                case "usrnm:env":
                                    Console.WriteLine(Environment.UserName);
                                    break;
                                case "usrdomain:env":
                                    Console.WriteLine(Environment.UserDomainName);
                                    break;
                                case "newln:env":
                                    Console.WriteLine(Environment.NewLine);
                                    break;
                                case "cursorE":
                                    Console.CursorVisible = false;
                                    break;
                                case "print":
                                    Console.WriteLine(reader.ReadString().Replace("fuck", "****"));
                                    break;
                                //fore color
                                //color
                                case "whitefore":
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine(reader.ReadString().Replace("fuck", "****"));
                                   
                                    break;
                                case "blackfore":
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.WriteLine(reader.ReadString().Replace("fuck", "****"));
                                   
                                    break;

                                case "bluefore":
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.WriteLine(reader.ReadString().Replace("fuck", "****"));
                                   
                                    break;

                                case "cyanfore":
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine(reader.ReadString().Replace("fuck", "****"));
                                   
                                    break;
       
                                    break;
                                case "redfore":
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine(reader.ReadString().Replace("fuck", "****"));
                                   
                                    break;

                                case "yellowfore":
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine(reader.ReadString().Replace("fuck", "****"));
                                   
                                    break;

                                case "greenfore":

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine(reader.ReadString().Replace("fuck", "****"));
                                   
                                    break;


                                case "grayfore":
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    Console.WriteLine(reader.ReadString().Replace("fuck", "****"));
                                   
                                    break;

                                ///color
                                ///
                                ///fore color
                                ///

                                case "whitebackground":
                                    Console.BackgroundColor = ConsoleColor.White;
                                    Console.WriteLine(reader.ReadString().Replace("fuck", "****"));
                                   
                                    break;
                                case "blackbackground":
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.WriteLine(reader.ReadString().Replace("fuck", "****"));
                                   
                                    break;

                                case "bluebackground":
                                    Console.BackgroundColor = ConsoleColor.Blue;
                                    Console.WriteLine(reader.ReadString().Replace("fuck", "****"));
                                   
                                    break;

                                case "cyanbackground":
                                    Console.BackgroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine(reader.ReadString().Replace("fuck", "****"));
                                   
                                    break;

                                case "redbackground":
                                    
                                    Console.BackgroundColor = ConsoleColor.Red;
                                    Console.WriteLine(reader.ReadString().Replace("fuck", "****"));
                                   
                                    break;

                                case "yellowbackground":
                                    Console.BackgroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine(reader.ReadString().Replace("fuck", "****"));
                                   
                                    break;

                                case "greenbackground":
                                    Console.BackgroundColor = ConsoleColor.Green;
                                    Console.WriteLine(reader.ReadString().Replace("fuck", "****"));
                                   
                                    break;


                                case "graybackground":
                                    Console.BackgroundColor = ConsoleColor.Gray;
                                    Console.WriteLine(reader.ReadString().Replace("fuck", "****"));
                                   
                                    break;
                                ///back
                                ///
                                case "FileCreate:IO":
                                    //  if (File.Exists(reader.ReadString()))
                                    // {
                                    //MessageBox.Show("error the file "+reader.ReadString() + "has exist",contains,MessageBoxButtons.YesNo,MessageBoxIcon.Error);
                                    // }
                                    //else
                                    // {
                                    File.Create(reader.ReadString());
                                    // }
                                    break;

                                case "DirectoryCreate:IO":

                                    //  if (File.Exists(reader.ReadString()))
                                    // {
                                    //MessageBox.Show("error the file "+reader.ReadString() + "has exist",contains,MessageBoxButtons.YesNo,MessageBoxIcon.Error);
                                    // }
                                    //else
                                    // {
                                    Directory.CreateDirectory(reader.ReadString());
                                    // }
                                    break;
                                case "FileDelete:IO":

                                    // Selects all the title elements that have an attribute named lang

                                    // It was found, manipulate it.
                                    File.Delete(reader.ReadString());
                                    break;

                                case "Yncancel":
                                    Console.WriteLine(reader.ReadString());
                                    switch (Console.ReadLine())
                                    {
                                        case "Y":
                                        case "y":
                                            break;
                                        case "N":
                                        case "n":
                                            Environment.Exit(0);
                                            break;
                                    }
                                    break;



                                case "DirectoryDeletel:IO":
                                    Directory.Delete(reader.ReadString());
                                    break;
                                case "title":

                                    //XDocument doc = new XDocument();


                                    Console.Title = reader.ReadString();

                                    break;
                                case "process":
                                    Process.Start(reader.ReadString());
                                    break;

                                case "":
                                  
                                    break;

                                case "readline":
                                    Console.ReadLine();
                                    break;
                                case "readkey":
                                    Console.ReadKey();
                                    break;
                                case "read":
                                    Console.Read();
                                    break;
                                case "osv:env":
                                    Console.WriteLine(Environment.OSVersion);
                                    break;
                                case "msgbox":
                                    MessageBox.Show(reader.ReadString(), "Console Dryginbase");
                                    break;
                                case "q:msgbox":
                                    MessageBox.Show(reader.ReadString(), "Console Dryginbase", MessageBoxButtons.OK, MessageBoxIcon.Question);

                                    break;
                                case "e:msgbox":
                                    MessageBox.Show(reader.ReadString(), "Console Dryginbase", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                    break;

                                case "w:msgbox":
                                    MessageBox.Show(reader.ReadString(), "Console Dryginbase", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                    break;

                                case "readalltext:IO":
                                    string sf = File.ReadAllText(reader.ReadString());
                                    Console.WriteLine(sf);

                                    break;
                                case "importbase_containsResizeFalse:publicimport":
                                    IntPtr handle = GetConsoleWindow();
                                    IntPtr sysMenu = GetSystemMenu(handle, false);

                                    if (handle != IntPtr.Zero)
                                    {

                                        DeleteMenu(sysMenu, SC_SIZE, MF_BYCOMMAND);
                                    }
                                    Console.Read();
                                    break;
                                case "today:datetime":
                                    Console.WriteLine(DateTime.Today);
                                    break;

                                case "request_object-move:IO":
                                    strings.ExcuteString.tar = reader.ReadString();

                                    break;
                                case "request_To-move:IO":
                                    strings.ExcuteString.tar = reader.ReadString();
                                    break;
                                    



                                case "movefile":
                                    string a = strings.ExcuteString.tar;
                                    string b = strings.ExcuteString.to;
                                    File.Move(a, b);
                                    break;
                                case "import":
                                    using (XmlReader module = XmlReader.Create(reader.ReadString()))
                                    {
                                        while (module.Read())
                                        {
                                            if (module.IsStartElement())
                                            {
                                                //return only when you have START tag

                                                switch (module.Name.ToString())
                                                {


                                                    case "debugsID":
                                                        Console.WriteLine(@"copyright 2021 by bitcores LLC
website: Dryginbase.ml/dcl
verrsion: 1.0
you are using: import element");
                                                        break;
                                                    case "nw:msgb":
                                                        MessageBox.Show(module.ReadString(), module.ReadString());
                                                        break;
                                                    case "msgb":
                                                        MessageBox.Show(module.ReadString(), "Console Dryginbase");
                                                        break;
                                                    case "sysdir:env":
                                                        Console.WriteLine(Environment.SystemDirectory);
                                                        break;
                                                    case "machinename:env":
                                                        Console.WriteLine(Environment.MachineName);
                                                        break;
                                                    case "usrnm:env":
                                                        Console.WriteLine(Environment.UserName);
                                                        break;
                                                    case "usrdomain:env":
                                                        Console.WriteLine(Environment.UserDomainName);
                                                        break;
                                                    case "newln:env":
                                                        Console.WriteLine(Environment.NewLine);
                                                        break;

                                                    case "print":
                                                        Console.WriteLine(module.ReadString().Replace("fuck", "****"));
                                                        break;
                                                    //fore color
                                                    //color
                                                    case "whitefore":
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(reader.ReadString().Replace("fuck", "****"));
                                   
                                                        break;
                                                    case "blackfore":
                                                        Console.ForegroundColor = ConsoleColor.Black;
                                                        Console.WriteLine(reader.ReadString().Replace("fuck", "****"));
                                   
                                                        break;

                                                    case "bluefore":
                                                        Console.ForegroundColor = ConsoleColor.Blue;
                                                        Console.WriteLine(reader.ReadString().Replace("fuck", "****"));
                                   
                                                        break;

                                                    case "cyanfore":
                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        
                                                      Console.WriteLine(reader.ReadString().Replace("fuck", "****"));
                                   
                                                        break;

                                                    case "redfore":
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine(reader.ReadString().Replace("fuck", "****"));
                                   
                                                        break;

                                                    case "yellowfore":
                                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                                        Console.WriteLine(reader.ReadString().Replace("fuck", "****"));
                                   
                                                        break;

                                                    case "greenfore":

                                                        Console.ForegroundColor = ConsoleColor.Green;
                                                        Console.WriteLine(reader.ReadString().Replace("fuck", "****"));
                                   
                                                        break;
                                                    case "mathrandoms":
                                                        Random m = new Random();
                                                        for (int i = 0; i < 1; i++)
                                                        {
                                                            Console.WriteLine(m.NextDouble());
                                                        }
                                                        break;

                                                    case "grayfore":
                                                        
                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        Console.WriteLine(reader.ReadString().Replace("fuck", "****"));
                                   
                                                        break;

                                                    ///color
                                                    ///
                                                    ///fore color
                                                    ///
                                                    case "whitebackground":
                                                        Console.BackgroundColor = ConsoleColor.White;
                                                        Console.WriteLine(reader.ReadString().Replace("fuck", "****"));
                                   
                                                        break;
                                                    case "blackbackground":
                                                        Console.BackgroundColor = ConsoleColor.Black;
                                                        Console.WriteLine(reader.ReadString().Replace("fuck", "****"));
                                   
                                                        break;

                                                    case "bluebackground":
                                                        Console.BackgroundColor = ConsoleColor.Blue;
                                                        Console.WriteLine(reader.ReadString().Replace("fuck", "****"));
                                   
                                                        break;

                                                    case "cyanbackground":
                                                        Console.BackgroundColor = ConsoleColor.Cyan;
                                                        Console.WriteLine(reader.ReadString().Replace("fuck", "****"));
                                   
                                                        break;

                                                    case "redbackground":
                                                        Console.BackgroundColor = ConsoleColor.Red;
                                                        Console.WriteLine(reader.ReadString().Replace("fuck", "****"));
                                   
                                                        break;

                                                    case "yellowbackground":
                                                        Console.BackgroundColor = ConsoleColor.Yellow;
                                                        Console.WriteLine(reader.ReadString().Replace("fuck", "****"));
                                   
                                                        break;

                                                    case "greenbackground":
                                                        Console.BackgroundColor = ConsoleColor.Green;
                                                        Console.WriteLine(reader.ReadString().Replace("fuck", "****"));
                                   
                                                        break;


                                                    case "graybackground":
                                                        Console.BackgroundColor = ConsoleColor.Gray;
                                                        Console.WriteLine(reader.ReadString().Replace("fuck", "****"));
                                   
                                                        break;
                                                    ///back
                                                    ///
                                                    case "FileCreate:IO":
                                                        //  if (File.Exists(reader.ReadString()))
                                                        // {
                                                        //MessageBox.Show("error the file "+reader.ReadString() + "has exist",contains,MessageBoxButtons.YesNo,MessageBoxIcon.Error);
                                                        // }
                                                        //else
                                                        // {
                                                        File.Create(module.ReadString());
                                                        // }
                                                        break;

                                                    case "DirectoryCreate:IO":

                                                        //  if (File.Exists(reader.ReadString()))
                                                        // {
                                                        //MessageBox.Show("error the file "+reader.ReadString() + "has exist",contains,MessageBoxButtons.YesNo,MessageBoxIcon.Error);
                                                        // }
                                                        //else
                                                        // {
                                                        Directory.CreateDirectory(module.ReadString());
                                                        // }
                                                        break;
                                                    case "FileDelete:IO":

                                                        // Selects all the title elements that have an attribute named lang

                                                        // It was found, manipulate it.
                                                        File.Delete(module.ReadString());
                                                        break;





                                                    case "DirectoryDeletel:IO":
                                                        Directory.Delete(module.ReadString());
                                                        break;
                                                    case "title":

                                                        //XDocument doc = new XDocument();


                                                        Console.Title = module.ReadString();

                                                        break;
                                                    case "process":
                                                        Process.Start(module.ReadString());
                                                        break;
                                                    case "yesno":
                                                        while (true)
                                                        {
                                                            switch (Console.ReadLine())
                                                            {
                                                                case "y":
                                                                case "Y":

                                                                    break;
                                                            }
                                                        }
                                                        break;

                                                    case "readline":
                                                        Console.ReadLine();
                                                        break;
                                                    case "readkey":
                                                        Console.ReadKey();
                                                        break;
                                                    case "read":
                                                        Console.Read();
                                                        break;
                                                    case "osv:env":
                                                        Console.WriteLine(Environment.OSVersion);
                                                        break;
                                                    case "msgbox":
                                                        MessageBox.Show(module.ReadString(), "Console Dryginbase");
                                                        break;
                                                    case "q:msgbox":
                                                        MessageBox.Show(module.ReadString(), "Console Dryginbase", MessageBoxButtons.OK, MessageBoxIcon.Question);

                                                        break;
                                                    case "e:msgbox":
                                                        MessageBox.Show(module.ReadString(), "Console Dryginbase", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                                        break;

                                                    case "w:msgbox":
                                                        MessageBox.Show(module.ReadString(), "Console Dryginbase", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                                        break;

                                                    case "readalltext:IO":
                                                        string s = File.ReadAllText(module.ReadString());
                                                        Console.WriteLine(s);

                                                        break;
                                                    case "resizefalse:publicimport":
                                                        IntPtr handle1 = GetConsoleWindow();
                                                        IntPtr sysMenu1 = GetSystemMenu(handle1, false);

                                                        if (handle1 != IntPtr.Zero)
                                                        {

                                                            DeleteMenu(sysMenu1, SC_SIZE, MF_BYCOMMAND);
                                                        }
                                                        Console.Read();
                                                        break;
                                                    case "today:datetime":
                                                        Console.WriteLine(DateTime.Today);
                                                        break;

                                                    case "request_object-move:IO":
                                                        strings.ExcuteString.tar = module.ReadString();

                                                        break;
                                                    case "request_To-move:IO":
                                                        strings.ExcuteString.tar = module.ReadString();
                                                        break;



                                                    case "movefile":

                                                        string ai = strings.ExcuteString.tar;
                                                        string bi = strings.ExcuteString.to;

                                                        File.Move(ai, bi);
                                                        break;

                                                    case "rename:IO":
                                                        strings.ExcuteString.RenFile = module.ReadString();

                                                        break;
                                                    case "renameTo:IO":
                                                        strings.ExcuteString.RenTo = module.ReadString();
                                                        break;



                                                    case "rename":

                                                        string sasx = strings.ExcuteString.tar;
                                                        string skss = strings.ExcuteString.to;

                                                      //9832U0FDNDKAXBASIUSA 
                                                        
                                                        break;

                                                    case "w":
                                                        Console.WriteLine(module.ReadString());
                                                        break;
                                                    case "Dryginbase":
                                                        break;
                                                    default:
                                                        
                                                        Console.WriteLine("error element");
                                                        break;
                                                }
                                            }
                                        }
                                    }
                                    break;

                            }
                        }
                    } Console.ReadLine();

                }

                switch (Console.ReadLine())
                {

                }
            }




           




        }

        public void Method()
        {
            throw new System.NotImplementedException();
        }


        public static class HotKeyManager
        {
            public static event EventHandler<HotKeyEventArgs> HotKeyPressed;

            public static int RegisterHotKey(Keys key, KeyModifiers modifiers)
            {
                _windowReadyEvent.WaitOne();
                int id = System.Threading.Interlocked.Increment(ref _id);
                _wnd.Invoke(new RegisterHotKeyDelegate(RegisterHotKeyInternal), _hwnd, id, (uint)modifiers, (uint)key);
                return id;
            }

            public static void UnregisterHotKey(int id)
            {
                _wnd.Invoke(new UnRegisterHotKeyDelegate(UnRegisterHotKeyInternal), _hwnd, id);
            }

            delegate void RegisterHotKeyDelegate(IntPtr hwnd, int id, uint modifiers, uint key);
            delegate void UnRegisterHotKeyDelegate(IntPtr hwnd, int id);

            private static void RegisterHotKeyInternal(IntPtr hwnd, int id, uint modifiers, uint key)
            {
                RegisterHotKey(hwnd, id, modifiers, key);
            }

            private static void UnRegisterHotKeyInternal(IntPtr hwnd, int id)
            {
                UnregisterHotKey(_hwnd, id);
            }

            private static void OnHotKeyPressed(HotKeyEventArgs e)
            {
                if (HotKeyManager.HotKeyPressed != null)
                {
                    HotKeyManager.HotKeyPressed(null, e);
                }
            }

            private static volatile MessageWindow _wnd;
            private static volatile IntPtr _hwnd;
            private static ManualResetEvent _windowReadyEvent = new ManualResetEvent(false);
            static HotKeyManager()
            {
                Thread messageLoop = new Thread(delegate()
                {
                    Application.Run(new MessageWindow());
                });
                messageLoop.Name = "MessageLoopThread";
                messageLoop.IsBackground = true;
                messageLoop.Start();
            }

            private class MessageWindow : Form
            {
                public MessageWindow()
                {
                    _wnd = this;
                    _hwnd = this.Handle;
                    _windowReadyEvent.Set();
                }

                protected override void WndProc(ref Message m)
                {
                    if (m.Msg == WM_HOTKEY)
                    {
                        HotKeyEventArgs e = new HotKeyEventArgs(m.LParam);
                        HotKeyManager.OnHotKeyPressed(e);
                    }

                    base.WndProc(ref m);
                }

                protected override void SetVisibleCore(bool value)
                {
                    // Ensure the window never becomes visible
                    base.SetVisibleCore(false);
                }

                private const int WM_HOTKEY = 0x312;
            }

            [DllImport("user32", SetLastError = true)]
            private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

            [DllImport("user32", SetLastError = true)]
            private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

            private static int _id = 0;
        }


        public class HotKeyEventArgs : EventArgs
        {
            public readonly Keys Key;
            public readonly KeyModifiers Modifiers;

            public HotKeyEventArgs(Keys key, KeyModifiers modifiers)
            {
                this.Key = key;
                this.Modifiers = modifiers;
            }

            public HotKeyEventArgs(IntPtr hotKeyParam)
            {
                uint param = (uint)hotKeyParam.ToInt64();
                Key = (Keys)((param & 0xffff0000) >> 16);
                Modifiers = (KeyModifiers)(param & 0x0000ffff);
            }
        }

        [Flags]
        public enum KeyModifiers
        {
            Alt = 1,
            Control = 2,
            Shift = 4,
            Windows = 8,
            NoRepeat = 0x4000
        }
        //hot key active
        static void HotKeyManager_HotKeyPressed(object sender, HotKeyEventArgs e)
        {
            new about_us().Show();
        }

    }

    namespace strings
    {
        public class ExcuteString
        {
            public static string tar;
            public static string to;
           //
            public static string RenFile;
            public static string RenTo;


        }
        
    }
    namespace DLLIMPORT
    {
        public class HideConsole
        {


        }
    }



}
