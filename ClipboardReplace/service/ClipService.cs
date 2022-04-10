using ClipboardReplace.common;
using ClipboardReplace.config;
using ClipboardReplace.service;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ClipboardReplace
{
    class ClipService
    {
        public Form1 form1;

        public static ClipService build(Form1 form1)
        {
            ClipService factory = new ClipService();
            factory.form1 = form1;


            if (Constant.Window.HIDDEN)
                form1.BeginInvoke(new Action(() =>
                {
                    form1.Hide();
                    form1.Opacity = 1;
                }));

            if (Constant.Window.DEBUGGER)
            {
                NativeMethods.AllocConsole();
                DebugService.WriteLine(Level.DEBUG, "注意：启动程序...");
                DebugService.WriteLine(Level.DEBUG, string.Format("DateTime  : {0}", DateTime.Now));
                DebugService.WriteLine(Level.DEBUG, "\tWritten by {0}", "artemis");
            }

            return factory;
        }

        public void replaceIfMath(string clipValue)
        {
            if (clipValue.Length<34)
            {
                DebugService.WriteLine(Level.INFO, "\t ignore : Length < 34");
                return;
            }
            foreach (string item in Constant.ClipReplace.REPLACE_VALUE_SET)
            {
                if (clipValue.Contains(item))
                {
                    DebugService.WriteLine(Level.INFO, "\t ignore : already replaced !!");
                    return;
                }
                    
            }
            Random randomizer = new Random();
            string[] arr = Constant.ClipReplace.REPLACE_VALUE_SET.ToArray();
            string raplaceValue = arr[randomizer.Next(arr.Length)];

            int num = 0;
            foreach (Match m in Regex.Matches(clipValue, Constant.ClipReplace.REGEX, RegexOptions.Multiline))
            {
                if (num == 0)
                {
                    DebugService.WriteLine(Level.INFO, "\t'{0}' founded in {1}, will be replaced to {2}", m.Value, m.Index, raplaceValue);
                    Regex regex = new Regex(m.Value);
                    string clipTargetVal = regex.Replace(clipValue, raplaceValue, 1);
                    DebugService.WriteLine(Level.INFO, "\t clipTargetVal : {0}", clipTargetVal);
                    Clipboard.SetText(clipTargetVal);
                }
                else
                    DebugService.WriteLine(Level.DEBUG, "\t'{0}' founded in {1}, will be igonre", m.Value, m.Index);

                num++;
            }
        }
    }
}