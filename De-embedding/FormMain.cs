using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using SDKMath;
using SDKDeEmbedding;
using De_embedding.Properties;

namespace De_embedding
{
    public partial class FormMain : Form
    {
        string pathToFileOpenPattern,
               pathToFileShortPattern,
               pathToFileLinePattern,
               pathToFileTwoLinePattern,
               pathToFilePadPattern,
               currMethod = "undefined";
        List<string>
            pathesToDUTFile;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            pathesToDUTFile = new List<string>();

            pbOpen.AllowDrop = true;
            pbLine.AllowDrop = true;
            pbShort.AllowDrop = true;
            pbTwoLine.AllowDrop = true;
        }

        private void btnLoadDataFolder_Click(object sender, EventArgs e)
        {
            List<string> pathes = new List<string>();

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                DirectoryInfo di = new DirectoryInfo(fbd.SelectedPath);
                FileInfo[] listOfFiles = di.GetFiles();
                
                foreach (FileInfo fi in listOfFiles)
                {
                    if (fi.Extension.ToUpper() == ".S2P")
                        pathes.Add(fi.FullName);
                }
            }
            pathesToDUTFile.AddRange(pathes);

            listBoxFiles.BeginUpdate();
            listBoxFiles.Items.AddRange( GetName(pathes).ToArray() );
            listBoxFiles.EndUpdate();
        }

        private void btnLoadDataFiles_Click(object sender, EventArgs e)
        {
            List<string> pathes = new List<string>();

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string[] mas = ofd.FileNames;

                foreach (string path in mas)
                {
                    if (Path.GetExtension(path).ToUpper() == ".S2P")
                        pathes.Add(path);
                }
            }
            pathesToDUTFile.AddRange(pathes);

            listBoxFiles.BeginUpdate();
            listBoxFiles.Items.AddRange( GetName(pathes).ToArray() );
            listBoxFiles.EndUpdate();
        }

        public List<string> GetName(List<string > list)
        {
            List<string> res = new List<string>();
            foreach (string str in list)
            {
                res.Add(Path.GetFileName(str));
            }
            return res;
        }

        private string StartDeEmbedding()
        {
            string folderWithDataFile = Path.GetDirectoryName(pathesToDUTFile[0]) + "\\DeEmbedded";
            DirectoryInfo di = new DirectoryInfo(folderWithDataFile);
            if (!di.Exists)
                di.Create();

            switch (currMethod)
            {
                case "open":
                    if (pathToFileOpenPattern == null)
                    {
                        MessageBox.Show("Не выбран файл шаблона");
                        return null;
                    }
                    (new DeEmbedding()).OpenMethodDeEmbedding(pathToFileOpenPattern, pathesToDUTFile.ToArray(), folderWithDataFile);
                    break;
                case "l-2l":
                    if (pathToFileLinePattern == null || pathToFileTwoLinePattern == null)
                    {
                        MessageBox.Show("Не выбран файл шаблона");
                        return null;
                    }
                    (new DeEmbedding()).L2LMethodDeEmbedding(pathToFileLinePattern, pathToFileTwoLinePattern, pathesToDUTFile.ToArray(), folderWithDataFile);
                    break;
                case "open-short":
                    if (pathToFileOpenPattern == null || pathToFileShortPattern == null)
                    {
                        MessageBox.Show("Не выбран файл шаблона");
                        return null;
                    }
                    (new DeEmbedding()).OpenShortMethodDeEmbedding(pathToFileOpenPattern, pathToFileShortPattern, pathesToDUTFile.ToArray(), folderWithDataFile);
                    break;
                case "pad-open-short":
                    if (pathToFilePadPattern == null || pathToFileOpenPattern == null || pathToFileShortPattern == null)
                    {
                        MessageBox.Show("Не выбран файл шаблона");
                        return null;
                    }
                    (new DeEmbedding()).PadOpenShortMethodDeEmbedding(pathToFilePadPattern, pathToFileOpenPattern, pathToFileShortPattern, pathesToDUTFile.ToArray(), folderWithDataFile);
                    break;
            }

            return folderWithDataFile;
        }

        private void OpenFolderInExplorer(string path)
        {
            System.Diagnostics.Process Proc = new System.Diagnostics.Process();
            Proc.StartInfo.FileName = "explorer";
            Proc.StartInfo.Arguments = path;
            Proc.Start();
            Proc.Close();
        }

        private void btnStartCalc_Click(object sender, EventArgs e)
        {
            if (currMethod == "undefined")
                MessageBox.Show("Вы не выбрали метод деэмбеддинга!", "Подсказка");
            else
                if (pathesToDUTFile.Count == 0)
                    MessageBox.Show("Отсутствуют файлы с измерениями", "Подсказка");
                else
                {
                    string folderWithDataFile = StartDeEmbedding();
                    if (folderWithDataFile != null)
                        OpenFolderInExplorer(folderWithDataFile);
                }
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void LoadPatternFile(Label lbl, out string pathToPatternFile)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pathToPatternFile = ofd.FileName;
                lbl.Text = Path.GetFileName(ofd.FileName);
            }
            else
                pathToPatternFile = null;
        }

        private void btnLoadPadPattern_Click(object sender, EventArgs e)
        {
            LoadPatternFile(lblPadPath, out pathToFilePadPattern);
        }

        private void AllPicToBW()
        {
            pbOpen.Image = Resources.openBWPic;
            pbShort.Image = Resources.shortBWPic;
            pbLine.Image = Resources.lineBWPic;
            pbTwoLine.Image = Resources.twoLineBWPic;

            pbOpen.Enabled = false;
            pbShort.Enabled = false;
            pbLine.Enabled = false;
            pbTwoLine.Enabled = false;
            btnLoadPadPattern.Enabled = false;
        }

        private void rbOpen_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOpen.Checked)
            {
                currMethod = "open";
                AllPicToBW();
                pbOpen.Image = Resources.openPic;
                pbOpen.Enabled = true;
            }
        }

        private void rbOpenShort_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOpenShort.Checked)
            {
                currMethod = "open-short";
                AllPicToBW();
                pbOpen.Image = Resources.openPic;
                pbShort.Image = Resources.shortPic;
                pbOpen.Enabled = true;
                pbShort.Enabled = true;
            }
        }

        private void rbLTwoL_CheckedChanged(object sender, EventArgs e)
        {
            if (rbLTwoL.Checked)
            {
                currMethod = "l-2l";
                AllPicToBW();
                pbLine.Image = Resources.linePic;
                pbTwoLine.Image = Resources.twoLinePic;
                pbLine.Enabled = true;
                pbTwoLine.Enabled = true;
            }
        }

        private void rbPadOpenShort_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPadOpenShort.Checked)
            {
                currMethod = "pad-open-short";
                AllPicToBW();
                pbOpen.Image = Resources.openPic;
                pbShort.Image = Resources.shortPic;
                pbOpen.Enabled = true;
                pbShort.Enabled = true;
                btnLoadPadPattern.Enabled = true;
            }
        }

        private void pbOpen_Click(object sender, EventArgs e)
        {
            LoadPatternFile(lblOpenPath, out pathToFileOpenPattern);
        }

        private void pbLine_Click(object sender, EventArgs e)
        {
            LoadPatternFile(lblLinePath, out pathToFileLinePattern);
        }

        private void pbTwoLine_Click(object sender, EventArgs e)
        {
            LoadPatternFile(lblTwoLinePath, out pathToFileTwoLinePattern);
        }

        private void pbShort_Click(object sender, EventArgs e)
        {
            LoadPatternFile(lblShortPath, out pathToFileShortPattern);
        }

        private void pbOpen_MouseEnter(object sender, EventArgs e)
        {
            pbOpen.Image = Resources.openChoosePic;
        }

        private void pbOpen_MouseLeave(object sender, EventArgs e)
        {
            pbOpen.Image = Resources.openPic;
        }

        private void pbShort_MouseEnter(object sender, EventArgs e)
        {
            pbShort.Image = Resources.shortChoosePic;
        }

        private void pbShort_MouseLeave(object sender, EventArgs e)
        {
            pbShort.Image = Resources.shortPic;
        }

        private void pbLine_MouseEnter(object sender, EventArgs e)
        {
            pbLine.Image = Resources.lineChoosePic;
        }

        private void pbLine_MouseLeave(object sender, EventArgs e)
        {
            pbLine.Image = Resources.linePic;
        }

        private void pbTwoLine_MouseEnter(object sender, EventArgs e)
        {
            pbTwoLine.Image = Resources.twoLineChoosePic;
        }

        private void pbTwoLine_MouseLeave(object sender, EventArgs e)
        {
            pbTwoLine.Image = Resources.twoLinePic;
        }

        private void listBoxFiles_DragDrop(object sender, DragEventArgs e)
        {
            string[] masOfPathes = (String[])e.Data.GetData(DataFormats.FileDrop, false);

            List<string> pathes = new List<string>();
            foreach (String pathToFile in masOfPathes)
            {
                if (Path.GetExtension(pathToFile).ToUpper() == ".S2P")
                    pathes.Add(pathToFile);
            }
            pathesToDUTFile.AddRange(pathes);

            listBoxFiles.BeginUpdate();
            listBoxFiles.Items.AddRange(GetName(pathes).ToArray());
            listBoxFiles.EndUpdate();
        }

        private void listBoxFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void pbOpen_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void pbOpen_DragDrop(object sender, DragEventArgs e)
        {
            string[] masOfPathes = (String[])e.Data.GetData(DataFormats.FileDrop, false);

            pathToFileOpenPattern = masOfPathes[0];
            lblOpenPath.Text = Path.GetFileName(masOfPathes[0]);
        }

        private void pbShort_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void pbLine_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void pbTwoLine_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void pbShort_DragDrop(object sender, DragEventArgs e)
        {
            string[] masOfPathes = (String[])e.Data.GetData(DataFormats.FileDrop, false);

            pathToFileShortPattern = masOfPathes[0];
            lblShortPath.Text = Path.GetFileName(masOfPathes[0]);
        }

        private void pbLine_DragDrop(object sender, DragEventArgs e)
        {
            string[] masOfPathes = (String[])e.Data.GetData(DataFormats.FileDrop, false);

            pathToFileLinePattern = masOfPathes[0];
            lblLinePath.Text = Path.GetFileName(masOfPathes[0]);
        }

        private void pbTwoLine_DragDrop(object sender, DragEventArgs e)
        {
            string[] masOfPathes = (String[])e.Data.GetData(DataFormats.FileDrop, false);

            pathToFileTwoLinePattern = masOfPathes[0];
            lblTwoLinePath.Text = Path.GetFileName(masOfPathes[0]);
        }
    }
}
