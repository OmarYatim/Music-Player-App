
namespace Music_Player_App
{
    internal class MessageBoxHelper
    {
        public static void ShowMessageBox(string msg, string caption) => MessageBox.Show(msg, caption);

        public static DialogResult ConfirmEditBox(string msg, string caption) => MessageBox.Show(msg, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        public static void ShowErrorBox(string msg, string caption) => MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
