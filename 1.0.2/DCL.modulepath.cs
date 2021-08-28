using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml;
namespace DCL.report
{
    public class bugs
    {
        public static string title = "";
        public static string messageBox = "";
        public static void Bcrash() 
        {
            Process DKU = new Process();
            DKU.StartInfo.FileName = "dryginbase.exe";
            DKU.Start();
            DKU.WaitForExit(10 * 60 * 1000);

            if (!DKU.HasExited)
                DKU.Kill();
            MessageBox.Show(messageBox,title);

            
        }
    }
}
