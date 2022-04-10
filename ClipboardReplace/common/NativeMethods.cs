using System;
using System.Runtime.InteropServices;

namespace ClipboardReplace.common
{
    class NativeMethods
    {
        [DllImport("kernel32.dll")]
        public static extern Boolean AllocConsole();

        [DllImport("kernel32.dll")]
        public static extern Boolean FreeConsole();


        [DllImport("user32.dll")]
        public static extern bool AddClipboardFormatListener(IntPtr hwnd);

        [DllImport("user32.dll")]
        public static extern bool RemoveClipboardFormatListener(IntPtr hwnd);

        public static int WM_CLIPBOARDUPDATE = 0x031D;
    }
}