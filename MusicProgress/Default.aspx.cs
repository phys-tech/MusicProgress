using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MusicProgress.Backend;

namespace MusicProgress
{ 

    public static class GlobalPath
    {
        public static string GlobalShit;
    }

    
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GlobalPath.GlobalShit = Server.MapPath("~");
            lDebugInfo.Text = "Global path1: " + GlobalPath.GlobalShit + "\n" + Environment.NewLine;
            string folder = Server.MapPath("~/App_Data/uploads");
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);
            GlobalPath.GlobalShit = folder;
            lDebugInfo.Text += "Global path2: " + GlobalPath.GlobalShit;
        }

        protected void bUpload_Click(object sender, EventArgs e)
        {
            int counter = 0;
            foreach (HttpPostedFile file in MyFileUpload.PostedFiles)
            {
                if (file == null || file.ContentLength == 0)
                    lStatus.Text = "Файл пуст";

                else if (Path.GetExtension(file.FileName) != ".txt")
                    lStatus.Text = "Файл должен быть с расширением .txt";

                else if (file.ContentLength > 1024 * 1024 * 4)
                    lStatus.Text = "Файл больше 4 МБ";

                else
                {
                    // extract only the filename
                    string fileName = Path.GetFileName(file.FileName);
                    // store the file inside ~/App_Data/uploads folder
                    string path = Path.Combine(GlobalPath.GlobalShit, fileName);
                    file.SaveAs(path);
                    counter++;
                    lStatus.Text = "Успешно загружен файл: " + (MyFileUpload.PostedFile.FileName);
                }
            }
            lStatus.Text = "Успешно загружено файлов: " + counter.ToString() + ", последний: " + (MyFileUpload.PostedFile.FileName);
            MySingleton.GetMe().ReloadData();
        }
    }
}