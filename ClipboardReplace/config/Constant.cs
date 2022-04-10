namespace ClipboardReplace.config
{
    class Constant
    {
        public class Window
        {
            // 是否显示DEBUG 日志窗口
            public static bool DEBUGGER = false;

            // 是否隐藏主窗口
            public static bool HIDDEN = true;
        }

        public class ClipReplace
        {
            public static string REGEX = @"[0-9a-zA-Z]{34}";

            // 欲替换的值
            public static string REPLACE_VALUE = "1234567890123456789012345678901234";
        }
    }
}