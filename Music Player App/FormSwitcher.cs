
namespace Music_Player_App
{
    internal class FormSwitcher
    {
        public static void OpenNewForm<T>(Form currentForm, params object[] constructorParams) where T : Form
        {
            // Get the position and size of the current form
            int x = currentForm.Location.X;
            int y = currentForm.Location.Y;
            int width = currentForm.Width;
            int height = currentForm.Height;

            // Create a new instance of the desired form type
            T? newForm;
            if (constructorParams.Length > 0)
                newForm = (T?)Activator.CreateInstance(typeof(T), constructorParams);
            else
                newForm = Activator.CreateInstance<T>();

            if(newForm == null) return; 
            // Set the position and size of the new form
            newForm.StartPosition = FormStartPosition.Manual;
            newForm.Location = new Point(x, y);

            if (IsFormFullScreen(currentForm)) 
                newForm.WindowState = FormWindowState.Maximized;
            else
            { 
                newForm.Width = width;
                newForm.Height = height;
            }

            // Show the new form and close the current form
            currentForm.Hide();
            newForm.ShowDialog();
            currentForm.Close();
        }

        public static bool IsFormFullScreen(Form form) => form.WindowState == FormWindowState.Maximized;
    }
}
