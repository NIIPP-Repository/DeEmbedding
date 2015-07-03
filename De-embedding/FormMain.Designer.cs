namespace De_embedding
{
    partial class FormMain
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLoadDataFolder = new System.Windows.Forms.Button();
            this.btnStartCalc = new System.Windows.Forms.Button();
            this.gbMeasuredStructures = new System.Windows.Forms.GroupBox();
            this.btnLoadDataFiles = new System.Windows.Forms.Button();
            this.listBoxFiles = new System.Windows.Forms.ListBox();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сервисToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbChooseAlgo = new System.Windows.Forms.GroupBox();
            this.rbPadOpenShort = new System.Windows.Forms.RadioButton();
            this.rbLTwoL = new System.Windows.Forms.RadioButton();
            this.rbOpenShort = new System.Windows.Forms.RadioButton();
            this.rbOpen = new System.Windows.Forms.RadioButton();
            this.gbLoadTemplates = new System.Windows.Forms.GroupBox();
            this.pbTwoLine = new System.Windows.Forms.PictureBox();
            this.pbLine = new System.Windows.Forms.PictureBox();
            this.pbOpen = new System.Windows.Forms.PictureBox();
            this.pbShort = new System.Windows.Forms.PictureBox();
            this.lblPadPath = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnLoadPadPattern = new System.Windows.Forms.Button();
            this.lblTwoLinePath = new System.Windows.Forms.Label();
            this.lblTwoLine = new System.Windows.Forms.Label();
            this.lblLinePath = new System.Windows.Forms.Label();
            this.lblLine = new System.Windows.Forms.Label();
            this.lblShortPath = new System.Windows.Forms.Label();
            this.lblShort = new System.Windows.Forms.Label();
            this.lblOpenPath = new System.Windows.Forms.Label();
            this.lblOpen = new System.Windows.Forms.Label();
            this.gbMeasuredStructures.SuspendLayout();
            this.menuStripMain.SuspendLayout();
            this.gbChooseAlgo.SuspendLayout();
            this.gbLoadTemplates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTwoLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOpen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbShort)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadDataFolder
            // 
            this.btnLoadDataFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoadDataFolder.Location = new System.Drawing.Point(15, 562);
            this.btnLoadDataFolder.Name = "btnLoadDataFolder";
            this.btnLoadDataFolder.Size = new System.Drawing.Size(117, 23);
            this.btnLoadDataFolder.TabIndex = 0;
            this.btnLoadDataFolder.Text = "Загрузить папку";
            this.btnLoadDataFolder.UseVisualStyleBackColor = true;
            this.btnLoadDataFolder.Click += new System.EventHandler(this.btnLoadDataFolder_Click);
            // 
            // btnStartCalc
            // 
            this.btnStartCalc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartCalc.Location = new System.Drawing.Point(326, 590);
            this.btnStartCalc.Name = "btnStartCalc";
            this.btnStartCalc.Size = new System.Drawing.Size(301, 38);
            this.btnStartCalc.TabIndex = 1;
            this.btnStartCalc.Text = "Деэмбеддинг";
            this.btnStartCalc.UseVisualStyleBackColor = true;
            this.btnStartCalc.Click += new System.EventHandler(this.btnStartCalc_Click);
            // 
            // gbMeasuredStructures
            // 
            this.gbMeasuredStructures.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMeasuredStructures.Controls.Add(this.btnLoadDataFiles);
            this.gbMeasuredStructures.Controls.Add(this.listBoxFiles);
            this.gbMeasuredStructures.Controls.Add(this.btnLoadDataFolder);
            this.gbMeasuredStructures.Location = new System.Drawing.Point(12, 28);
            this.gbMeasuredStructures.Name = "gbMeasuredStructures";
            this.gbMeasuredStructures.Size = new System.Drawing.Size(308, 600);
            this.gbMeasuredStructures.TabIndex = 3;
            this.gbMeasuredStructures.TabStop = false;
            this.gbMeasuredStructures.Text = "Список файлов с измерениями";
            // 
            // btnLoadDataFiles
            // 
            this.btnLoadDataFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadDataFiles.Location = new System.Drawing.Point(173, 562);
            this.btnLoadDataFiles.Name = "btnLoadDataFiles";
            this.btnLoadDataFiles.Size = new System.Drawing.Size(117, 23);
            this.btnLoadDataFiles.TabIndex = 1;
            this.btnLoadDataFiles.Text = "Загрузить файлы";
            this.btnLoadDataFiles.UseVisualStyleBackColor = true;
            this.btnLoadDataFiles.Click += new System.EventHandler(this.btnLoadDataFiles_Click);
            // 
            // listBoxFiles
            // 
            this.listBoxFiles.AllowDrop = true;
            this.listBoxFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxFiles.FormattingEnabled = true;
            this.listBoxFiles.Location = new System.Drawing.Point(15, 19);
            this.listBoxFiles.Name = "listBoxFiles";
            this.listBoxFiles.Size = new System.Drawing.Size(275, 537);
            this.listBoxFiles.TabIndex = 0;
            this.listBoxFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBoxFiles_DragDrop);
            this.listBoxFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBoxFiles_DragEnter);
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.сервисToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(639, 24);
            this.menuStripMain.TabIndex = 4;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.закрытьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // закрытьToolStripMenuItem
            // 
            this.закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
            this.закрытьToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.закрытьToolStripMenuItem.Text = "Закрыть";
            this.закрытьToolStripMenuItem.Click += new System.EventHandler(this.закрытьToolStripMenuItem_Click);
            // 
            // сервисToolStripMenuItem
            // 
            this.сервисToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.настройкиToolStripMenuItem});
            this.сервисToolStripMenuItem.Name = "сервисToolStripMenuItem";
            this.сервисToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.сервисToolStripMenuItem.Text = "Сервис";
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // gbChooseAlgo
            // 
            this.gbChooseAlgo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbChooseAlgo.Controls.Add(this.rbPadOpenShort);
            this.gbChooseAlgo.Controls.Add(this.rbLTwoL);
            this.gbChooseAlgo.Controls.Add(this.rbOpenShort);
            this.gbChooseAlgo.Controls.Add(this.rbOpen);
            this.gbChooseAlgo.Location = new System.Drawing.Point(326, 28);
            this.gbChooseAlgo.Name = "gbChooseAlgo";
            this.gbChooseAlgo.Size = new System.Drawing.Size(301, 116);
            this.gbChooseAlgo.TabIndex = 5;
            this.gbChooseAlgo.TabStop = false;
            this.gbChooseAlgo.Text = "Выбор метода деэмбеддинга";
            // 
            // rbPadOpenShort
            // 
            this.rbPadOpenShort.AutoSize = true;
            this.rbPadOpenShort.Location = new System.Drawing.Point(15, 88);
            this.rbPadOpenShort.Name = "rbPadOpenShort";
            this.rbPadOpenShort.Size = new System.Drawing.Size(113, 17);
            this.rbPadOpenShort.TabIndex = 8;
            this.rbPadOpenShort.TabStop = true;
            this.rbPadOpenShort.Text = "Pad - Open - Short";
            this.rbPadOpenShort.UseVisualStyleBackColor = true;
            this.rbPadOpenShort.CheckedChanged += new System.EventHandler(this.rbPadOpenShort_CheckedChanged);
            // 
            // rbLTwoL
            // 
            this.rbLTwoL.AutoSize = true;
            this.rbLTwoL.Location = new System.Drawing.Point(15, 65);
            this.rbLTwoL.Name = "rbLTwoL";
            this.rbLTwoL.Size = new System.Drawing.Size(52, 17);
            this.rbLTwoL.TabIndex = 7;
            this.rbLTwoL.TabStop = true;
            this.rbLTwoL.Text = "L - 2L";
            this.rbLTwoL.UseVisualStyleBackColor = true;
            this.rbLTwoL.CheckedChanged += new System.EventHandler(this.rbLTwoL_CheckedChanged);
            // 
            // rbOpenShort
            // 
            this.rbOpenShort.AutoSize = true;
            this.rbOpenShort.Location = new System.Drawing.Point(15, 42);
            this.rbOpenShort.Name = "rbOpenShort";
            this.rbOpenShort.Size = new System.Drawing.Size(85, 17);
            this.rbOpenShort.TabIndex = 6;
            this.rbOpenShort.TabStop = true;
            this.rbOpenShort.Text = "Open - Short";
            this.rbOpenShort.UseVisualStyleBackColor = true;
            this.rbOpenShort.CheckedChanged += new System.EventHandler(this.rbOpenShort_CheckedChanged);
            // 
            // rbOpen
            // 
            this.rbOpen.AutoSize = true;
            this.rbOpen.Location = new System.Drawing.Point(15, 19);
            this.rbOpen.Name = "rbOpen";
            this.rbOpen.Size = new System.Drawing.Size(51, 17);
            this.rbOpen.TabIndex = 5;
            this.rbOpen.TabStop = true;
            this.rbOpen.Text = "Open";
            this.rbOpen.UseVisualStyleBackColor = true;
            this.rbOpen.CheckedChanged += new System.EventHandler(this.rbOpen_CheckedChanged);
            // 
            // gbLoadTemplates
            // 
            this.gbLoadTemplates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbLoadTemplates.Controls.Add(this.pbTwoLine);
            this.gbLoadTemplates.Controls.Add(this.pbLine);
            this.gbLoadTemplates.Controls.Add(this.pbOpen);
            this.gbLoadTemplates.Controls.Add(this.pbShort);
            this.gbLoadTemplates.Controls.Add(this.lblPadPath);
            this.gbLoadTemplates.Controls.Add(this.label8);
            this.gbLoadTemplates.Controls.Add(this.btnLoadPadPattern);
            this.gbLoadTemplates.Controls.Add(this.lblTwoLinePath);
            this.gbLoadTemplates.Controls.Add(this.lblTwoLine);
            this.gbLoadTemplates.Controls.Add(this.lblLinePath);
            this.gbLoadTemplates.Controls.Add(this.lblLine);
            this.gbLoadTemplates.Controls.Add(this.lblShortPath);
            this.gbLoadTemplates.Controls.Add(this.lblShort);
            this.gbLoadTemplates.Controls.Add(this.lblOpenPath);
            this.gbLoadTemplates.Controls.Add(this.lblOpen);
            this.gbLoadTemplates.Location = new System.Drawing.Point(326, 150);
            this.gbLoadTemplates.Name = "gbLoadTemplates";
            this.gbLoadTemplates.Size = new System.Drawing.Size(301, 434);
            this.gbLoadTemplates.TabIndex = 6;
            this.gbLoadTemplates.TabStop = false;
            this.gbLoadTemplates.Text = "Выбор шаблонов";
            // 
            // pbTwoLine
            // 
            this.pbTwoLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbTwoLine.Enabled = false;
            this.pbTwoLine.Image = global::De_embedding.Properties.Resources.twoLineBWPic;
            this.pbTwoLine.Location = new System.Drawing.Point(164, 215);
            this.pbTwoLine.Name = "pbTwoLine";
            this.pbTwoLine.Size = new System.Drawing.Size(120, 129);
            this.pbTwoLine.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTwoLine.TabIndex = 20;
            this.pbTwoLine.TabStop = false;
            this.pbTwoLine.Click += new System.EventHandler(this.pbTwoLine_Click);
            this.pbTwoLine.DragDrop += new System.Windows.Forms.DragEventHandler(this.pbTwoLine_DragDrop);
            this.pbTwoLine.DragEnter += new System.Windows.Forms.DragEventHandler(this.pbTwoLine_DragEnter);
            this.pbTwoLine.MouseEnter += new System.EventHandler(this.pbTwoLine_MouseEnter);
            this.pbTwoLine.MouseLeave += new System.EventHandler(this.pbTwoLine_MouseLeave);
            // 
            // pbLine
            // 
            this.pbLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbLine.Enabled = false;
            this.pbLine.Image = global::De_embedding.Properties.Resources.lineBWPic;
            this.pbLine.Location = new System.Drawing.Point(14, 215);
            this.pbLine.Name = "pbLine";
            this.pbLine.Size = new System.Drawing.Size(120, 129);
            this.pbLine.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLine.TabIndex = 19;
            this.pbLine.TabStop = false;
            this.pbLine.Click += new System.EventHandler(this.pbLine_Click);
            this.pbLine.DragDrop += new System.Windows.Forms.DragEventHandler(this.pbLine_DragDrop);
            this.pbLine.DragEnter += new System.Windows.Forms.DragEventHandler(this.pbLine_DragEnter);
            this.pbLine.MouseEnter += new System.EventHandler(this.pbLine_MouseEnter);
            this.pbLine.MouseLeave += new System.EventHandler(this.pbLine_MouseLeave);
            // 
            // pbOpen
            // 
            this.pbOpen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbOpen.Enabled = false;
            this.pbOpen.Image = global::De_embedding.Properties.Resources.openBWPic;
            this.pbOpen.Location = new System.Drawing.Point(15, 40);
            this.pbOpen.Name = "pbOpen";
            this.pbOpen.Size = new System.Drawing.Size(119, 129);
            this.pbOpen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbOpen.TabIndex = 18;
            this.pbOpen.TabStop = false;
            this.pbOpen.Click += new System.EventHandler(this.pbOpen_Click);
            this.pbOpen.DragDrop += new System.Windows.Forms.DragEventHandler(this.pbOpen_DragDrop);
            this.pbOpen.DragEnter += new System.Windows.Forms.DragEventHandler(this.pbOpen_DragEnter);
            this.pbOpen.MouseEnter += new System.EventHandler(this.pbOpen_MouseEnter);
            this.pbOpen.MouseLeave += new System.EventHandler(this.pbOpen_MouseLeave);
            // 
            // pbShort
            // 
            this.pbShort.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbShort.Enabled = false;
            this.pbShort.Image = global::De_embedding.Properties.Resources.shortBWPic;
            this.pbShort.Location = new System.Drawing.Point(165, 40);
            this.pbShort.Name = "pbShort";
            this.pbShort.Size = new System.Drawing.Size(119, 129);
            this.pbShort.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbShort.TabIndex = 17;
            this.pbShort.TabStop = false;
            this.pbShort.Click += new System.EventHandler(this.pbShort_Click);
            this.pbShort.DragDrop += new System.Windows.Forms.DragEventHandler(this.pbShort_DragDrop);
            this.pbShort.DragEnter += new System.Windows.Forms.DragEventHandler(this.pbShort_DragEnter);
            this.pbShort.MouseEnter += new System.EventHandler(this.pbShort_MouseEnter);
            this.pbShort.MouseLeave += new System.EventHandler(this.pbShort_MouseLeave);
            // 
            // lblPadPath
            // 
            this.lblPadPath.AutoSize = true;
            this.lblPadPath.Location = new System.Drawing.Point(68, 403);
            this.lblPadPath.Name = "lblPadPath";
            this.lblPadPath.Size = new System.Drawing.Size(66, 13);
            this.lblPadPath.TabIndex = 16;
            this.lblPadPath.Text = "<undefined>";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 383);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Pad :";
            // 
            // btnLoadPadPattern
            // 
            this.btnLoadPadPattern.Location = new System.Drawing.Point(16, 399);
            this.btnLoadPadPattern.Name = "btnLoadPadPattern";
            this.btnLoadPadPattern.Size = new System.Drawing.Size(46, 20);
            this.btnLoadPadPattern.TabIndex = 14;
            this.btnLoadPadPattern.Text = "...";
            this.btnLoadPadPattern.UseVisualStyleBackColor = true;
            this.btnLoadPadPattern.Click += new System.EventHandler(this.btnLoadPadPattern_Click);
            // 
            // lblTwoLinePath
            // 
            this.lblTwoLinePath.AutoSize = true;
            this.lblTwoLinePath.Location = new System.Drawing.Point(161, 347);
            this.lblTwoLinePath.Name = "lblTwoLinePath";
            this.lblTwoLinePath.Size = new System.Drawing.Size(66, 13);
            this.lblTwoLinePath.TabIndex = 13;
            this.lblTwoLinePath.Text = "<undefined>";
            // 
            // lblTwoLine
            // 
            this.lblTwoLine.AutoSize = true;
            this.lblTwoLine.Location = new System.Drawing.Point(162, 199);
            this.lblTwoLine.Name = "lblTwoLine";
            this.lblTwoLine.Size = new System.Drawing.Size(42, 13);
            this.lblTwoLine.TabIndex = 12;
            this.lblTwoLine.Text = "2 Line :";
            // 
            // lblLinePath
            // 
            this.lblLinePath.AutoSize = true;
            this.lblLinePath.Location = new System.Drawing.Point(11, 347);
            this.lblLinePath.Name = "lblLinePath";
            this.lblLinePath.Size = new System.Drawing.Size(66, 13);
            this.lblLinePath.TabIndex = 10;
            this.lblLinePath.Text = "<undefined>";
            // 
            // lblLine
            // 
            this.lblLine.AutoSize = true;
            this.lblLine.Location = new System.Drawing.Point(13, 199);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(33, 13);
            this.lblLine.TabIndex = 9;
            this.lblLine.Text = "Line :";
            // 
            // lblShortPath
            // 
            this.lblShortPath.AutoSize = true;
            this.lblShortPath.Location = new System.Drawing.Point(161, 172);
            this.lblShortPath.Name = "lblShortPath";
            this.lblShortPath.Size = new System.Drawing.Size(66, 13);
            this.lblShortPath.TabIndex = 7;
            this.lblShortPath.Text = "<undefined>";
            // 
            // lblShort
            // 
            this.lblShort.AutoSize = true;
            this.lblShort.Location = new System.Drawing.Point(166, 24);
            this.lblShort.Name = "lblShort";
            this.lblShort.Size = new System.Drawing.Size(38, 13);
            this.lblShort.TabIndex = 6;
            this.lblShort.Text = "Short :";
            // 
            // lblOpenPath
            // 
            this.lblOpenPath.AutoSize = true;
            this.lblOpenPath.Location = new System.Drawing.Point(12, 172);
            this.lblOpenPath.Name = "lblOpenPath";
            this.lblOpenPath.Size = new System.Drawing.Size(66, 13);
            this.lblOpenPath.TabIndex = 4;
            this.lblOpenPath.Text = "<undefined>";
            // 
            // lblOpen
            // 
            this.lblOpen.AutoSize = true;
            this.lblOpen.Location = new System.Drawing.Point(11, 24);
            this.lblOpen.Name = "lblOpen";
            this.lblOpen.Size = new System.Drawing.Size(39, 13);
            this.lblOpen.TabIndex = 3;
            this.lblOpen.Text = "Open :";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(639, 640);
            this.Controls.Add(this.gbLoadTemplates);
            this.Controls.Add(this.gbChooseAlgo);
            this.Controls.Add(this.gbMeasuredStructures);
            this.Controls.Add(this.btnStartCalc);
            this.Controls.Add(this.menuStripMain);
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "De-embedding";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.gbMeasuredStructures.ResumeLayout(false);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.gbChooseAlgo.ResumeLayout(false);
            this.gbChooseAlgo.PerformLayout();
            this.gbLoadTemplates.ResumeLayout(false);
            this.gbLoadTemplates.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTwoLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOpen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbShort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadDataFolder;
        private System.Windows.Forms.Button btnStartCalc;
        private System.Windows.Forms.GroupBox gbMeasuredStructures;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem закрытьToolStripMenuItem;
        private System.Windows.Forms.ListBox listBoxFiles;
        private System.Windows.Forms.Button btnLoadDataFiles;
        private System.Windows.Forms.GroupBox gbChooseAlgo;
        private System.Windows.Forms.GroupBox gbLoadTemplates;
        private System.Windows.Forms.Label lblOpen;
        private System.Windows.Forms.Label lblOpenPath;
        private System.Windows.Forms.Label lblLinePath;
        private System.Windows.Forms.Label lblLine;
        private System.Windows.Forms.Label lblShortPath;
        private System.Windows.Forms.Label lblShort;
        private System.Windows.Forms.Label lblPadPath;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnLoadPadPattern;
        private System.Windows.Forms.Label lblTwoLinePath;
        private System.Windows.Forms.Label lblTwoLine;
        private System.Windows.Forms.RadioButton rbOpen;
        private System.Windows.Forms.RadioButton rbPadOpenShort;
        private System.Windows.Forms.RadioButton rbLTwoL;
        private System.Windows.Forms.RadioButton rbOpenShort;
        private System.Windows.Forms.PictureBox pbShort;
        private System.Windows.Forms.PictureBox pbLine;
        private System.Windows.Forms.PictureBox pbTwoLine;
        private System.Windows.Forms.PictureBox pbOpen;
        private System.Windows.Forms.ToolStripMenuItem сервисToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
    }
}

