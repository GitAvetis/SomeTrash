using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;

using System.Windows.Forms;

namespace Создание_программ_для_ЧПУ_с_двумя_головами
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            TextBoxFirstProgrammName.Text = openFileDialog1.FileName;
            TextBoxSecondProgrammName.Text = openFileDialog2.FileName;
            TextBoxResultName.Text = "new file";
            ToolTip tp = new ToolTip();
            tp.SetToolTip(button, openFileDialog1.FileName);
            tp.SetToolTip(button2, openFileDialog2.FileName);

        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (TextBoxResultName.TextLength != 0)
            {
               
                folderBrowserDialog1.ShowDialog();
                string path = AppContext.BaseDirectory;

                string folder = folderBrowserDialog1.SelectedPath;
                bool nameIsAvalible = false;
                int i = 1;
                while (nameIsAvalible != true)
                {
                    
                    if (File.Exists(folder + $"\\{TextBoxResultName.Text}.NC"))
                    {
                        TextBoxResultName.Text = $"new file({i})";
                        i++;
                    }
                    else
                        nameIsAvalible = true;

                }
                string resultFileName = folder + "\\" + TextBoxResultName.Text + ".NC";
                
                string[] pattern = File.ReadAllLines("Шаблон.txt");
                string[] firstCode = File.ReadAllLines(openFileDialog1.FileName);
                string[] secondCode = File.ReadAllLines(openFileDialog2.FileName);

                if (File.Exists(openFileDialog1.FileName) != true || File.Exists(openFileDialog2.FileName) !=true)
                    MessageBox.Show("Неправильно указан путь к одному из выбранных файлов");
                else if (File.Exists("Шаблон.txt") != true)
                    MessageBox.Show("Отсутсвует файл '\'Шаблон'\'");
                else
                {
                    string[] firstCodeAfterCut = firstCode.SkipWhile(x => x.StartsWith("G0") != true)
                                                     .TakeWhile(x => x.StartsWith("M") != true)
                                                     .ToArray();

                    string[] secondCodeAfterCut = secondCode.SkipWhile(x => x.StartsWith("G0") != true)
                                                            .TakeWhile(x => x.StartsWith("M") != true)
                                                            .ToArray();

                    string[] firstPatternPart = pattern.TakeWhile(x => x.StartsWith(" ") != true)
                                                            .ToArray();

                    string[] secondPatternPart = pattern.SkipWhile(x => x.StartsWith("M06 T2") != true)
                                                        .TakeWhile(x => x.StartsWith(" ") != true)
                                                        .ToArray();

                    string[] lastPatterPart = pattern.SkipWhile(x => x.StartsWith("G80") != true)
                                                     .Select(x => x)
                                                     .ToArray();
                    if (File.Exists(resultFileName) == true)
                    {
                        MessageBox.Show("Измените имя файла или место его сохранения. Файл с указанным именем уже существует в выбранной вами директории");
                    }
                    else
                    {
                        File.AppendAllLines(resultFileName, firstPatternPart);
                        File.AppendAllLines(resultFileName, firstCodeAfterCut);
                        File.AppendAllText(resultFileName, "M5\n");
                        File.AppendAllLines(resultFileName, secondPatternPart);
                        File.AppendAllLines(resultFileName, secondCodeAfterCut);
                        File.AppendAllLines(resultFileName, lastPatterPart);
                        Process.Start("explorer.exe", folder);
                        
                        ToolTip tp = new ToolTip();
                        tp.SetToolTip(button3, resultFileName);
                        tp.SetToolTip(TextBoxResultName, resultFileName);
                    }
                    if (checkBox1.Checked)
                    {
                        Process.Start(path+@"\NC Corrector v4.0\NC_Corrector.exe",resultFileName);
                    }
                }
            }
            else
            {
                MessageBox.Show("Вы не указали имя создаваемого файла");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
            int n = openFileDialog2.FileName.Split('\\').Length;
            TextBoxSecondProgrammName.Text = openFileDialog2.FileName.Split('\\')[n-1];
            ToolTip tp = new ToolTip();
            tp.SetToolTip(button2, openFileDialog2.FileName);
            tp.SetToolTip(TextBoxSecondProgrammName, openFileDialog2.FileName);

        }

        private void button_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            int n = openFileDialog1.FileName.Split('\\').Length;
            TextBoxFirstProgrammName.Text = openFileDialog1.FileName.Split('\\')[n-1];
            ToolTip tp = new ToolTip();
            tp.SetToolTip(button, openFileDialog1.FileName);
            tp.SetToolTip(TextBoxFirstProgrammName, openFileDialog1.FileName);
            
        }
       
    }
}
