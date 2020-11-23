using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Тестовое_приложение_по_поиску_файлов__в_репозитории
{
    public partial class Form1 : Form
    {
        public delegate void FileFounded(string filePath);
        public event FileFounded Founded;
        public string searchResult { get; set; }
        public int Counter { get; set; }
        public Form1()
        {
            InitializeComponent();
            
            try
            {
                pathString.Text = File.ReadAllText("lastSearch.txt");
            }
            catch (Exception)
            {

            }

        }
        public bool FileSearch(string startPath, string fileName)
        {
            bool fileFounded=false;
            foreach (var file in Directory.GetFiles(startPath))
            {
                string[] mass = file.Split('\\');
                if (mass[mass.Length - 1] == fileName || fileName == (mass[mass.Length - 1]).Split('.')[0])
                {
                    searchResult = file;
                    fileFounded = true;
                    break;

                }

            }
            return fileFounded;
        }
        public string LastSearch { get; set; }
        private static string[] FolderPath(string startpath)
        {
            string[] directory = { "fail" };
            try
            {
                directory = Directory.GetDirectories(startpath);
                return directory;
            }
            catch (Exception)
            {

            }
            return directory;

        }
        //private static bool folderSearchResults(string[] folderPath, string fileName)
        //{
        //    bool searchResult = false;
        //    foreach (var file in folderPath)
        //    {
        //        if (file == fileName)
        //            searchResult = true;

        //        else
        //            searchResult = false;
        //    }
        //    return searchResult;
        //}
        private  void FileSearchResults(string startPath, string fileName)
        {

            if (fileName == "")
                MessageBox.Show("Укажите параметры поиска.");
            else
            {
                
                if(FileSearch(startPath, fileName) == true)
                {
                    searchResult = startPath;
                    
                }
                else
                {
                    foreach (var folder in Directory.GetDirectories(startPath))
                    {
                        string[] folders = Directory.GetFiles(folder);
                        if (folders.Length==0)
                        {
                            foreach (var file in Directory.GetDirectories(folder))
                            {
                                string[] mass = file.Split('\\');
                                if (mass[mass.Length - 1] == fileName)
                                {
                                    searchResult = file;

                                    break;

                                }
                                else FileSearchResults(folder, fileName);
                                if (searchResult != null)
                                    break;
                            }
                            FileSearchResults(folder, fileName);
                        }
                        else
                        {
                            foreach (var file in folders)
                            {
                                string[] mass = file.Split('\\');
                                if (mass[mass.Length - 1] == fileName)
                                {
                                    searchResult = file;

                                    break;

                                }
                                else FileSearchResults(folder, fileName);

                            }
                            if (searchResult != null)
                                break;
                        }
                        
                        if (searchResult != null)
                            break;
                    }
                }
            }
            
           
        }
        private string FileExtensionSearchResults(string[] folderPath, string fileExtention)
        {
            string searchResult = "No file here";
            foreach (var folder in folderPath)
            {
                foreach (var file in Directory.GetFiles(folder))
                {
                    string[] mass = file.Split('\\');
                    string[] fullName = mass[mass.Length - 1].Split('.');
                    if (fullName[fullName.Length - 1] == fileExtention)
                    {
                        Counter++;
                        return folder;
                    }


                }

            }
            return searchResult;
        }
        private void Search_Click(object sender, EventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            Counter = 0;
            //stopWatch.Stop();

            treeView1.Nodes.Clear();
            try
            {
                File.WriteAllText("lastSearch.txt", pathString.Text);
                if (textBox2.Text != null)
                {
                    // string path = FileSearchResults(FolderPath(pathString.Text), textBox2.Text);
                    FileSearchResults(pathString.Text, textBox2.Text);
                    string path="" ;
                    string[] mass = searchResult.Split('\\');
                    for (int i = 0; i < mass.Length-2; i++)
                    {
                        path += mass[i]+"\\";
                    }
                    path=path+mass[mass.Length-2];
                    
                    if (path != "No file here")
                        ListDirectory(treeView1, path);
                    else
                    {
                        if (fileExtension.Text != null)
                        {
                            string path2 = FileExtensionSearchResults(FolderPath(pathString.Text), fileExtension.Text);
                            if (path2 != "No file here")
                                ListDirectory(treeView1, path2);
                            else
                                MessageBox.Show("Нет подходящих файлов");
                        }
                    }
                }
                counterTextBox.Text = Counter.ToString();
                stopWatch.Stop();
                // Get the elapsed time as a TimeSpan value.
                TimeSpan ts = stopWatch.Elapsed;

                // Format and display the TimeSpan value.
                string elapsedTime = String.Format("{0:00}h:{1:00}m:{2:00}s.{3:00}ms",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds);
                timeTextBox.Text = elapsedTime;
            }
            catch (Exception ex)
            {
                if (searchResult == null)
                    MessageBox.Show("No file with this name in chosen area");
                else
                MessageBox.Show(ex.Message + "\n    Укажите боллее точный путь для поиска ");
            }
        

    } 

        
        private void ListDirectory(TreeView treeView, string path)
        {
            treeView.Nodes.Clear();
            var rootDirectoryInfo = new DirectoryInfo(path);

            treeView.Nodes.Add(CreateDirectoryNode(rootDirectoryInfo));

        }
        private static TreeNode CreateDirectoryNode(DirectoryInfo directoryInfo)
        {
            var directoryNode = new TreeNode(directoryInfo.Name);
            foreach (var directory in directoryInfo.GetDirectories())
                directoryNode.Nodes.Add(CreateDirectoryNode(directory));

            foreach (var file in directoryInfo.GetFiles())
                directoryNode.Nodes.Add(new TreeNode(file.Name));

            return directoryNode;

        }
        private void PathBackSpace_Click(object sender, EventArgs e)
        {
            pathString.Clear();
        }

        private void FormatBackSpace_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
        }

        private void FileExtensionBackSpace_Click(object sender, EventArgs e)
        {
            fileExtension.Clear();
        }
    }
}
