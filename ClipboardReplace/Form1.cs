using ClipboardReplace.common;
using ClipboardReplace.service;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ClipboardReplace
{
    public partial class Form1 : Form

    {
        ClipService clipService;

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            clipService = ClipService.build(this);
            NativeMethods.AddClipboardFormatListener(this.Handle);
            DebugService.WriteLine(Level.DEBUG, "Start Listener Clipboard");
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            NativeMethods.RemoveClipboardFormatListener(this.Handle);
            DebugService.WriteLine(Level.DEBUG, "Stop Listener Clipboard");
            base.OnClosing(e);
        }

        protected override void DefWndProc(ref Message m)
        {
            if (m.Msg == NativeMethods.WM_CLIPBOARDUPDATE)
            {
                if (Clipboard.ContainsText())
                {
                    try
                    {
                        DebugService.WriteLine(Level.DEBUG, @"Clipboard GET {0}:{1}", "TEXT", "\r\n--------------------\r\n" +  Clipboard.GetText() + "\r\n--------------------\r\n");
                        clipService.replaceIfMath(Clipboard.GetText());
                    }
                    catch (Exception e)
                    {
                        DebugService.WriteLine(Level.ERROR, @"Clipboard GET ERROR MSG {0}", e.Message);
                    }
                }
                else
                {
                    DebugService.WriteLine(Level.DEBUG, @"Clipboard GET {0}", "OTHERS");
                }
            }
            else
            {
                base.DefWndProc(ref m);
            }
        }
    }
}