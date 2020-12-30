using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Тестовое_приложение_по_поиску_файлов__в_репозитории
{
    public partial class Form1 : Form
    {
        public List<string> Matches = new List<string> { };
        public string SearchResult { get; set; }
        public int CounterOfMatches { get; set; }
        public Form1()
        {
            InitializeComponent();

            try
            {
                textBoxPathString.Text = File.ReadAllText("lastSearch.txt");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            TextBoxTime.Text = "00h:00m:00s:00ms";

        }
        public void FormatOfSearch(string fileName,string fileExtension, string path, List<string> accesibleDirectorys, bool IsWithRecursion)
        {

            if (IsWithRecursion == true)
            {
                foreach (var folder in accesibleDirectorys)
                {
                    if (fileExtension != "" && fileName != "")
                    {
                        if (Directory.GetFiles(folder).ToList().Exists(file => file.Split('\\').Last().Split('.')[0] == fileName
                        && Directory.GetFiles(folder).ToList().Exists(extension => extension.Split('\\').Last().Split('.')[extension.Split('\\').Last().Split('.').Length - 1] == fileExtension)))
                        {
                            SearchResult = folder;
                            //  Matches.Add(folder);

                          break;
                        }
                        else
                        {
                            АccessibleDirectory(folder, fileName, fileExtension);
                        }

                    }
                    else if (fileName != "" && fileExtension == "")
                    {
                        if (Directory.GetFiles(folder).ToList().Exists(file => file.Split('\\').Last().Split('.')[0] == fileName))
                        {
                            SearchResult = folder;
                          //  Matches.Add(folder);

                             break;
                        }
                        else
                        {
                            АccessibleDirectory(folder, fileName, fileExtension);
                        }
                    }
                    else if (fileExtension != "" && fileName == "")
                    {
                        if (Directory.GetFiles(folder).ToList().Exists(extension => extension.Split('\\').Last().Split('.')[extension.Split('\\').Last().Split('.').Length - 1] == fileExtension))
                        {
                            SearchResult = folder;
                         //   Matches.Add(folder);

                            break;
                        }
                        else
                        {
                            АccessibleDirectory(folder, fileName, fileExtension);
                        }

                    }
                }
                    
                
            }
            else
            {
                if (fileExtension != "" && fileName != "")
                {
                    if (Directory.GetFiles(path).ToList().Exists(extension => extension.Split('\\').Last().Split('.')[extension.Split('\\').Last().Split('.').Length - 1] == fileExtension)
                        && Directory.GetFiles(path).ToList().Exists(file => file.Split('\\').Last().Split('.')[0] == fileName))
                    {
                        SearchResult = path;
                        //Matches.Add(path);

                    }
                }
                else if (fileName != "" && fileExtension == "")
                {
                    if (Directory.GetFiles(path).ToList().Exists(file => file.Split('\\').Last().Split('.')[0] == fileName))
                    {
                        SearchResult = path;
                        //  Matches.Add(path);

                    }
                }
                else if (fileExtension != "" && fileName == "")
                {
                    if (Directory.GetFiles(path).ToList().Exists(extension => extension.Split('\\').Last().Split('.')[extension.Split('\\').Last().Split('.').Length - 1] == fileExtension))
                    {
                        SearchResult = path;
                        // Matches.Add(path);

                    }
                }
            }
           
        }
        public void АccessibleDirectory(string path, string fileName, string fileExtension)
        {

            List<string> directoris = Directory.GetDirectories(path).ToList();

            string[] massOfAccesibleDirectorys = new string[directoris.Count];
            directoris.CopyTo(massOfAccesibleDirectorys);

            List<string> accesibleDirectorys = directoris.ToList();

            for (int i = 0; i < directoris.Count; i++)
            {
                try
                {

                    Directory.GetFiles(directoris[i]);
                }
                catch
                {
                    accesibleDirectorys.Remove(directoris[i]);
                }
            }
            if (accesibleDirectorys.Count == 0)
            {
                FormatOfSearch(fileName, fileExtension, path, accesibleDirectorys, false);
                
            }
            else
            {
                FormatOfSearch(fileName, fileExtension, path, accesibleDirectorys, true);

            }
           
        }  
        private async void Search_Click(object sender, EventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();

            if (textBoxFileName.Text.Equals("") & textBoxFileExtension.Text.Equals(""))
                MessageBox.Show("Укажите параметры для поиска");
            else if (textBoxPathString.Text.Length == 0)
                MessageBox.Show("Выберите начальную директорию поиска");
            else
            {
                TextBoxTime.Text = "00h:00m:00s:00ms";
                stopWatch.Start();
                CounterOfMatches = 0;

                treeView1.Nodes.Clear();
                SearchResult = null;

                try
                {

                    File.WriteAllText("lastSearch.txt", textBoxPathString.Text);

                    if (textBoxFileName.Text != null||textBoxFileExtension!=null)
                    {
                        await Task.Run(() => АccessibleDirectory(textBoxPathString.Text, textBoxFileName.Text,textBoxFileExtension.Text));
                        if (SearchResult != null)
                        {
                            GC.Collect();
                            CounterForTree = 0; 
                            treeView1.Nodes.Add(CreateNodes(SearchResult, SearchResult.Split('\\')[0],textBoxFileName.Text));
                            
                        }
                        else
                        {
                            MessageBox.Show("Файл не обнаружен");
                            GC.Collect();
                        }

                    }
                   
                    else
                    {
                        MessageBox.Show("Пустой поисковый запрос");
                    }
                  //  TextBoxCounter.Text = CounterOfMatches.ToString();
                    foreach (var item in Matches)
                    {
                        TextBoxCounter.Text = item;
                    }
                    stopWatch.Stop();

                    TimeSpan ts = stopWatch.Elapsed;

                    string elapsedTime = String.Format("{0:00}h:{1:00}m:{2:00}s.{3:00}ms",
                        ts.Hours, ts.Minutes, ts.Seconds,ts.Milliseconds);

                    TextBoxTime.Text = elapsedTime;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {

                    GC.Collect();
                }
            }
        }

        public int CounterForTree { get; set; }
        private TreeNode CreateNodes(string directoryPath, string folderName, string fileName)
        {
            TreeNode Node = new TreeNode(folderName);
            string[] mass = directoryPath.Split('\\');

            while (CounterForTree< mass.Length - 1)
            { 
                CounterForTree++;
                Node.Nodes.Add(CreateNodes(directoryPath,mass[CounterForTree], fileName));
                return Node;

            }

                foreach (var file in Directory.GetFiles(SearchResult))
            {
                if (file.Split('\\').Last().Split('.')[0] == fileName)
                {
                    Node.Nodes.Add(file.Split('\\')[file.Split('\\').Length - 1]).ForeColor = Color.DarkGreen;
                }
                //else
                //    Node.Nodes.Add(file.Split('\\')[file.Split('\\').Length - 1]);
            }
            
                

            return Node;

        }

        private void PathBackSpace_Click(object sender, EventArgs e)
        {
            textBoxPathString.Clear();
        }

        private void FormatBackSpace_Click(object sender, EventArgs e)
        {
            textBoxFileName.Clear();
        }

        private void FileExtensionBackSpace_Click(object sender, EventArgs e)
        {
            textBoxFileExtension.Clear();
        }


    }
}
