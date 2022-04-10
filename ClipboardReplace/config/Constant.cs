using System.Collections.Generic;

namespace ClipboardReplace.config
{
    class Constant
    {
        public class Window
        {
            // 是否显示DEBUG 日志窗口
            public static bool DEBUGGER = true;

            // 是否隐藏主窗口
            public static bool HIDDEN = false;
        }

        public class ClipReplace
        {
            public static string REGEX = @"[0-9a-zA-Z]{34}";

            // 欲替换的值
            public static HashSet<string> REPLACE_VALUE_SET = new HashSet<string>(new string[]
            {
                "1234567890123456789012345678901234" ,
                "2234567890123456789012345678901234"
            });
        }
    }
}