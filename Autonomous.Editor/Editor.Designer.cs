namespace Autonomous.Editor
{
    partial class Editor
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbProject = new System.Windows.Forms.TabPage();
            this.tabCtrlProject = new System.Windows.Forms.TabControl();
            this.tbIncludes = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.tbDefines = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tbFiles = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tbProject.SuspendLayout();
            this.tabCtrlProject.SuspendLayout();
            this.tbIncludes.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbProject);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1373, 638);
            this.tabControl1.TabIndex = 2;
            // 
            // tbProject
            // 
            this.tbProject.Controls.Add(this.tabCtrlProject);
            this.tbProject.Location = new System.Drawing.Point(4, 24);
            this.tbProject.Name = "tbProject";
            this.tbProject.Padding = new System.Windows.Forms.Padding(3);
            this.tbProject.Size = new System.Drawing.Size(1365, 610);
            this.tbProject.TabIndex = 0;
            this.tbProject.Text = "Project";
            this.tbProject.UseVisualStyleBackColor = true;
            // 
            // tabCtrlProject
            // 
            this.tabCtrlProject.Controls.Add(this.tbFiles);
            this.tabCtrlProject.Controls.Add(this.tbIncludes);
            this.tabCtrlProject.Controls.Add(this.tbDefines);
            this.tabCtrlProject.Location = new System.Drawing.Point(6, 6);
            this.tabCtrlProject.Name = "tabCtrlProject";
            this.tabCtrlProject.SelectedIndex = 0;
            this.tabCtrlProject.Size = new System.Drawing.Size(1353, 598);
            this.tabCtrlProject.TabIndex = 1;
            // 
            // tbIncludes
            // 
            this.tbIncludes.Controls.Add(this.listView1);
            this.tbIncludes.Controls.Add(this.btnOpenFile);
            this.tbIncludes.Location = new System.Drawing.Point(4, 24);
            this.tbIncludes.Name = "tbIncludes";
            this.tbIncludes.Padding = new System.Windows.Forms.Padding(3);
            this.tbIncludes.Size = new System.Drawing.Size(1345, 570);
            this.tbIncludes.TabIndex = 0;
            this.tbIncludes.Text = "Includes";
            this.tbIncludes.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(6, 6);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(331, 529);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 300;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(6, 541);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFile.TabIndex = 5;
            this.btnOpenFile.Text = "button1";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click_1);
            // 
            // tbDefines
            // 
            this.tbDefines.Location = new System.Drawing.Point(4, 24);
            this.tbDefines.Name = "tbDefines";
            this.tbDefines.Padding = new System.Windows.Forms.Padding(3);
            this.tbDefines.Size = new System.Drawing.Size(1345, 570);
            this.tbDefines.TabIndex = 1;
            this.tbDefines.Text = "Defines";
            this.tbDefines.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1365, 610);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tbFiles
            // 
            this.tbFiles.Location = new System.Drawing.Point(4, 24);
            this.tbFiles.Name = "tbFiles";
            this.tbFiles.Padding = new System.Windows.Forms.Padding(3);
            this.tbFiles.Size = new System.Drawing.Size(1345, 570);
            this.tbFiles.TabIndex = 2;
            this.tbFiles.Text = "Files";
            this.tbFiles.UseVisualStyleBackColor = true;
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1397, 662);
            this.Controls.Add(this.tabControl1);
            this.Name = "Editor";
            this.Text = "Editor";
            this.tabControl1.ResumeLayout(false);
            this.tbProject.ResumeLayout(false);
            this.tabCtrlProject.ResumeLayout(false);
            this.tbIncludes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl1;
        private TabPage tbProject;
        private TabPage tabPage2;
        private TabControl tabCtrlProject;
        private TabPage tbIncludes;
        private TabPage tbDefines;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private Button btnOpenFile;
        private TabPage tbFiles;
    }
}