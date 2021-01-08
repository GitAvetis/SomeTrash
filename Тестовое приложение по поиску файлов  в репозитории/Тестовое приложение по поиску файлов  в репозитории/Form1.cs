using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Тестовое_приложение_по_поиску_файлов__в_репозитории
{
    public partial class Form1 : Form
    {
        public string SearchResult { get; set; }
        public string ActualDirectory{ get; set; }
        public int CounterOfMatches { get; set; }
        public bool FileFounded { get; set; }
        public int SearchFormat { get; set; }
        public Form1()
        {
            InitializeComponent();

            try
            {
                textBoxPathString.Text = File.ReadAllText("lastSearch.txt");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            TextBoxTime.Text = "0h:0m:0s:0ms";
            
        }
       
        public void FormatOfSearch(string fileName,string fileExtension, string path, List<string> accesibleDirectorys, bool IsWithRecursion, int switchNum)
        {

            if (IsWithRecursion == true)
            {
                foreach (var folder in accesibleDirectorys)
                {
                    ActualDirectory = folder;
                    switch (SearchFormat)
                    {
                        case 1://name and extension
                            if (Directory.GetFiles(folder).ToList().Exists(file => file.Split('\\').Last().Split('.')[0] == fileName
                             && Directory.GetFiles(folder).ToList().Exists(extension => extension.Split('\\').Last().Split('.')[extension.Split('\\').Last().Split('.').Length - 1] == fileExtension)))
                            {
                                SearchResult = folder;
                                FileFounded = true;

                                break;
                            }
                            else
                            {
                                АccessibleDirectory(folder, fileName, fileExtension);
                            }

                            break;

                        case 2:// only name
                            if (Directory.GetFiles(folder).ToList().Exists(file => file.Split('\\').Last().Split('.')[0] == fileName))
                            {
                                SearchResult = folder;
                                FileFounded = true;

                                break;
                            }
                            else
                            {
                                АccessibleDirectory(folder, fileName, fileExtension);
                            }

                            break;
                        case 3://only extension
                            if (Directory.GetFiles(folder).ToList().Exists(extension => extension.Split('\\').Last().Split('.')[extension.Split('\\').Last().Split('.').Length - 1] == fileExtension))
                            {
                                SearchResult = folder;
                                FileFounded = true;

                                break;
                            }
                            else
                            {
                                АccessibleDirectory(folder, fileName, fileExtension);
                            }

                            break;

                    }

                }
                    
            }
            else
            {
                ActualDirectory = path;

                switch (SearchFormat)
                {
                    case 1://name and extension

                        if (Directory.GetFiles(path).ToList().Exists(extension => extension.Split('\\').Last().Split('.')[extension.Split('\\').Last().Split('.').Length - 1] == fileExtension)
                        && Directory.GetFiles(path).ToList().Exists(file => file.Split('\\').Last().Split('.')[0] == fileName))
                        {
                            SearchResult = path;
                            FileFounded = true;
                        }

                        break;

                    case 2://only name

                        if (Directory.GetFiles(path).ToList().Exists(file => file.Split('\\').Last().Split('.')[0] == fileName))
                        {
                            SearchResult = path;
                            FileFounded = true;
                        }

                        break;

                    case 3://only extension

                        if (Directory.GetFiles(path).ToList().Exists(extension => extension.Split('\\').Last().Split('.')[extension.Split('\\').Last().Split('.').Length - 1] == fileExtension))
                        {
                            SearchResult = path;
                            FileFounded = true;
                        }

                        break;
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
                FormatOfSearch(fileName, fileExtension, path, accesibleDirectorys, false, SearchFormat);     

            else if(accesibleDirectorys.Count!=0 && FileFounded == false)
                FormatOfSearch(fileName, fileExtension, path, accesibleDirectorys, true, SearchFormat);
            
        }  
        private async void Search_Click(object sender, EventArgs e)
        {
            Timer FormTimer = new Timer
            {
                Interval = 1
            };
            FileFounded = false;
            SearchFormat = 0;

            if (textBoxFileName.Text.Equals("") & textBoxFileExtension.Text.Equals(""))
                MessageBox.Show("Укажите параметры для поиска");
            else if (textBoxPathString.Text.Length == 0)
                MessageBox.Show("Выберите начальную директорию поиска");
            else
            {
                if (textBoxFileName.Text.Equals("") == false && textBoxFileExtension.Text.Equals("") == false)
                    SearchFormat = 1;
                else if (textBoxFileName.Text.Equals("") == false && textBoxFileExtension.Text.Equals("") != false)
                    SearchFormat = 2;
                else if (textBoxFileName.Text.Equals("") != false && textBoxFileExtension.Text.Equals("") == false)
                    SearchFormat = 3;

                    TextBoxTime.Text = "0h:0m:0s:0ms";
                treeView1.Nodes.Clear();
                SearchResult = null;
                ActualDirectory = null;
                int milSec, sec, min, hour;
                milSec = sec = min = hour = 0;

                FormTimer.Start();
                FormTimer.Tick += new EventHandler(FormTimer_Tick);

                void FormTimer_Tick(object sender2, EventArgs e2)
                {
                    if (milSec == 60) { milSec = 00; sec++; }
                    
                    if (sec == 60) { sec = 00; min++; }

                    if (min == 60) { min = 00; hour++;}

                    TextBoxTime.Text = $"{hour}h:{min}m:{sec}s:{milSec++}ms ";
                    if(FileFounded==false)
                        textBoxActualDirectory.Text = ActualDirectory;
                    else
                        textBoxActualDirectory.Text = SearchResult;
                }

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
                            treeView1.Nodes.Add(CreateNodes(SearchResult, SearchResult.Split('\\')[0],textBoxFileName.Text, textBoxFileExtension.Text));                          
                        }
                        else
                        {
                            FormTimer.Stop();
                            GC.Collect();
                        }

                    }
                   
                    else
                    {
                        FormTimer.Stop();
                        MessageBox.Show("Пустой поисковый запрос");
                    }

                    FormTimer.Stop();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (FileFounded == false)
                        textBoxActualDirectory.Text = "Подходящих файлов не обнаружено";
                    else
                        textBoxActualDirectory.Text = SearchResult;
                    GC.Collect();

                }
            }
        }

        public int CounterForTree { get; set; }
        private TreeNode CreateNodes(string directoryPath, string folderName, string fileName,string fileExtension)
        {
            TreeNode Node = new TreeNode(folderName);
            string[] mass = directoryPath.Split('\\');

            while (CounterForTree< mass.Length - 1)
            { 
                CounterForTree++;
                Node.Nodes.Add(CreateNodes(directoryPath,mass[CounterForTree], fileName, fileExtension));
                return Node;

            }

            foreach (var file in Directory.GetFiles(SearchResult))
            {
                switch (SearchFormat)
                {
                    case 1://search by name and extension
                        if ((file.Split('\\').Last().Split('.')[0] == fileName) &&
                            (file.Split('\\').Last().Split('.')[file.Split('\\').Last().Split('.').Length - 1] == fileExtension))
                        {
                            Node.Nodes.Add(file.Split('\\')[file.Split('\\').Length - 1]).ForeColor = Color.DarkGreen;
                        }
                        else
                            Node.Nodes.Add(file.Split('\\')[file.Split('\\').Length - 1]).ForeColor = Color.Black;
                        break;

                    case 2://search by name
                        if (file.Split('\\').Last().Split('.')[0] == fileName)
                            Node.Nodes.Add(file.Split('\\')[file.Split('\\').Length - 1]).ForeColor = Color.DarkGreen;
                        else
                            Node.Nodes.Add(file.Split('\\')[file.Split('\\').Length - 1]).ForeColor = Color.Black;
                        break;

                    case 3://search by extension
                        if (file.Split('\\').Last().Split('.')[file.Split('\\').Last().Split('.').Length - 1] == fileExtension)
                            Node.Nodes.Add(file.Split('\\')[file.Split('\\').Length - 1]).ForeColor = Color.DarkGreen;
                        else
                            Node.Nodes.Add(file.Split('\\')[file.Split('\\').Length - 1]).ForeColor = Color.Black;
                        break;
                }
              
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
