using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace addWhiteSpace2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            //open.Filter = "jpeps|*.jpg";

            if(open.ShowDialog() == DialogResult.OK)
            {
               // pictureBox1.ImageLocation = open.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Bitmap originalImage = new Bitmap(40, 40);
            //using (Graphics g = Graphics.FromImage(originalImage)) { g.Clear(Color.White); }

           // Bitmap originalImage = new Bitmap(pictureBox1.Image);

            Bitmap newImage = new Bitmap(400, 511);
            using (Graphics graphics = Graphics.FromImage(newImage))
            {
                graphics.Clear(Color.White);
               // int x = (newImage.Width - originalImage.Width) / 2;
                //int y = (newImage.Height - originalImage.Height) ;

               // originalImage = new Bitmap(originalImage.Width, newImage.Height);
               // graphics.DrawImage(originalImage, x, y);
            }
            //pictureBox2.Image = newImage;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
           // pictureBox2.Image.Save(@"C:\Users\Jens\Desktop\temp\wijnen\test.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            // C:\Users\Jens\OneDrive\documents\!WORK\2020\4_webshop\images\unsort_vofjolie
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                var imageLoaded = open.FileName;
                //pictureBox1.ImageLocation = imageLoaded;

                Bitmap originalImage = new Bitmap( imageLoaded );

                // get height
                // get width 
                // height - width =   A.rest
                // A.rest / 2 =   B.waarde_1kant
                // voeg whitespace toe met width = B en height van image 

                var rest = originalImage.Height - originalImage.Width;
                var side = rest / 2;

                Bitmap newImage = new Bitmap( ( side + originalImage.Width + side), originalImage.Height);
                using (Graphics graphics = Graphics.FromImage(newImage))
                {
                    graphics.Clear(Color.Red);
                    int x = (newImage.Width - originalImage.Width) / 2;
                    int y = (newImage.Height - originalImage.Height);

                    // originalImage = new Bitmap(originalImage.Width, newImage.Height);
                    graphics.DrawImage(originalImage, x, y);
                }
                newImage.Save(@"C:\Users\Jens\Desktop\square_images_wijnen\" + open.SafeFileName, System.Drawing.Imaging.ImageFormat.Jpeg);

            }
        }



        public static String[] GetFilesFrom(String searchFolder, String[] filters, bool isRecursive)
        {
            List<String> filesFound = new List<String>();
            var searchOption = isRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            foreach (var filter in filters)
            {
                filesFound.AddRange(Directory.GetFiles(searchFolder, String.Format("*.{0}", filter), searchOption));
            }
            return filesFound.ToArray();
        }

        //string globalPath = @"C:\Users\Jens\Desktop\work_programming\stef_webshop\original_image";
        //string globalPathDestination = @"C:\Users\Jens\Desktop\work_programming\stef_webshop\square_image\";

        string globalPath = @"C:\Users\Jens\Desktop\convert\original";
        string globalPathDestination = @"C:\Users\Jens\Desktop\convert\destination\";



        private void button6_Click(object sender, EventArgs e)
        {
            String searchFolder = globalPath;
            var filters = new String[] { "jpg", "jpeg", "png", "gif", "tiff", "bmp", "svg" };
            var files = GetFilesFrom(searchFolder, filters, false);

            foreach(var file in files)
            {


                //Bitmap b = new Bitmap(Server.MapPath("~/uploadedimages/sampleimage.jpg"));
                var imageLoaded = file;
                //pictureBox1.ImageLocation = imageLoaded;

                //Bitmap originalImage = new Bitmap(imageLoaded);
                Bitmap originalImage = new Bitmap(@"" + file + "");


                //Bitmap bitmap = Properties.Resources.file;
                // get height
                // get width 
                // height - width =   A.rest
                // A.rest / 2 =   B.waarde_1kant
                // voeg whitespace toe met width = B en height van image 

                var rest = originalImage.Height - originalImage.Width;
                var side = rest / 2;

                Bitmap newImage = new Bitmap((side + originalImage.Width + side), originalImage.Height);
                using (Graphics graphics = Graphics.FromImage(newImage))
                {
                    graphics.Clear(Color.White);
                    int x = (newImage.Width - originalImage.Width) / 2;
                    int y = (newImage.Height - originalImage.Height);

                    // originalImage = new Bitmap(originalImage.Width, newImage.Height);
                    graphics.DrawImage(originalImage, x, y);
                }

                // remove path from string 
                // C:\Users\Jens\OneDrive\documents\!WORK\2020\4_webshop\images\unsort_vofjolie

                string pathToFile = globalPath;
                string fileName = file.Replace(pathToFile + "\\", "");
                newImage.Save(globalPathDestination + fileName, System.Drawing.Imaging.ImageFormat.Jpeg);

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            String searchFolder = globalPath;
            var filters = new String[] { "jpg", "jpeg", "png", "gif", "tiff", "bmp", "svg" };
            var files = GetFilesFrom(searchFolder, filters, false);



            foreach (var file in files)
            {


                //Bitmap b = new Bitmap(Server.MapPath("~/uploadedimages/sampleimage.jpg"));
                var imageLoaded = file;
                //pictureBox1.ImageLocation = imageLoaded;

                //Bitmap originalImage = new Bitmap(imageLoaded);
                Bitmap originalImage = new Bitmap(@"" + file + "");


                //Bitmap bitmap = Properties.Resources.file;
                // get height
                // get width 
                // height - width =   A.rest
                // A.rest / 2 =   B.waarde_1kant
                // voeg whitespace toe met width = B en height van image 

                var rest = originalImage.Width - originalImage.Height;
                var side = rest / 2;

                Bitmap newImage = new Bitmap(originalImage.Width, (side + originalImage.Height + side ));
                using (Graphics graphics = Graphics.FromImage(newImage))
                {
                    graphics.Clear(Color.White);
                    int x = (newImage.Width - originalImage.Width);
                    int y = (newImage.Height - originalImage.Height) / 2;

                    // originalImage = new Bitmap(originalImage.Width, newImage.Height);
                    graphics.DrawImage(originalImage, x, y);
                }

                // remove path from string 
                // C:\Users\Jens\OneDrive\documents\!WORK\2020\4_webshop\images\unsort_vofjolie

                string pathToFile = globalPath;
                string fileName = file.Replace(pathToFile + "\\", "");
                newImage.Save(globalPathDestination + fileName, System.Drawing.Imaging.ImageFormat.Jpeg);

            }
        }


        string original_images_folder = @"C:\Users\Jens\Desktop\convert\original";
        //string globalPathDestination = @"C:\Users\Jens\Desktop\convert\destination\";

        Bitmap newImage;
        private void button8_Click(object sender, EventArgs e)
        {

            OpenFileDialog folderBrowser = new OpenFileDialog();
            // Set validate names and check file exists to false otherwise windows will
            // not let you select "Folder Selection."
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            // Always default to Folder Selection.
            folderBrowser.FileName = "Folder Selection.";


            // OPTIE 1
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                original_images_folder = Path.GetDirectoryName(folderBrowser.FileName);
                // ...
            }

            // OPTIE 2
            /*
            FolderBrowserDialog diag = new FolderBrowserDialog();
            if (diag.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string folder = diag.SelectedPath;  //selected folder path

            }
            */


            // MOVE FILES TO ORIGINAL_IMAGES FOLDER
            string folderNameOriginalImages = "original_images";
            string folderNameNewImages = "new_images";

            string insideFolderOriginalImagesFolder = original_images_folder + "\\" + folderNameOriginalImages;
            string insideFolderNewImagesFolder = original_images_folder + "\\" + folderNameNewImages;


            System.IO.Directory.CreateDirectory(String.Format(@"{0}/{1}", original_images_folder, folderNameOriginalImages));
            System.IO.Directory.CreateDirectory(String.Format(@"{0}/{1}", original_images_folder, folderNameNewImages));

            var diSource = new DirectoryInfo(original_images_folder);
            var diTarget = new DirectoryInfo(insideFolderOriginalImagesFolder);

            CopyAll(diSource, diTarget);


            String searchFolder = insideFolderOriginalImagesFolder;
                var filters = new String[] { "jpg", "jpeg", "png", "gif", "tiff", "bmp", "svg" };
                var files = GetFilesFrom(insideFolderOriginalImagesFolder, filters, false);


                foreach (var file in files)
                {
                    Bitmap originalImage = new Bitmap(@"" + file + "");

                    if ( originalImage.Width > originalImage.Height ) {

                        var rest = originalImage.Width - originalImage.Height;
                        var side = rest / 2;

                        newImage = new Bitmap(originalImage.Width, (side + originalImage.Height + side));
                    saveNewImage(file, originalImage, newImage, insideFolderOriginalImagesFolder, insideFolderNewImagesFolder);

                }
                else if ( originalImage.Width < originalImage.Height ) {
                        var rest = originalImage.Height - originalImage.Width;
                        var side = rest / 2;

                        newImage = new Bitmap((side + originalImage.Width + side), originalImage.Height);


                    saveNewImage(file, originalImage, newImage, insideFolderOriginalImagesFolder, insideFolderNewImagesFolder);
                }
                else { }



            }
        }




        public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                //Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
                //fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
                fi.MoveTo(Path.Combine(target.FullName, fi.Name));
            }


            // Copy each subdirectory using recursion.
            /*
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
            */
        }

        private void saveNewImage(string file, Bitmap originalImage, Bitmap newImage, string originalPath, string newPath )
        {
            using (Graphics graphics = Graphics.FromImage(newImage))
            {
                graphics.Clear(Color.White);
                int x = (newImage.Width - originalImage.Width) / 2;
                int y = (newImage.Height - originalImage.Height) / 2;

                graphics.DrawImage(originalImage, x, y);
            }

            string pathToFile = originalPath;
            string fileName = file.Replace(pathToFile + "\\", "");
            newImage.Save(newPath + "\\" + fileName, System.Drawing.Imaging.ImageFormat.Jpeg);

        }


    }
}
