using System.Windows.Forms;

namespace HiHoga.Util
{
    public class FileControl
    {
        static public string GetFileNameShowDialog()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                //
            }

            return dlg.FileName;
        }
    }
}
