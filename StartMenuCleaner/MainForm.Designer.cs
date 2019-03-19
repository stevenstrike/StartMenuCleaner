namespace StartMenuCleaner
{
    partial class MainForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.scanButton = new System.Windows.Forms.Button();
            this.scanCustomButton = new System.Windows.Forms.Button();
            this.customSearchTextBox = new System.Windows.Forms.TextBox();
            this.removeButton = new System.Windows.Forms.Button();
            this.selectCheckboxButton = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.resultsCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.logLB = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // scanButton
            // 
            this.scanButton.Location = new System.Drawing.Point(17, 16);
            this.scanButton.Margin = new System.Windows.Forms.Padding(4);
            this.scanButton.Name = "scanButton";
            this.scanButton.Size = new System.Drawing.Size(100, 28);
            this.scanButton.TabIndex = 0;
            this.scanButton.Text = "Scan";
            this.scanButton.UseVisualStyleBackColor = true;
            this.scanButton.Click += new System.EventHandler(this.scanButton_Click);
            // 
            // scanCustomButton
            // 
            this.scanCustomButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.scanCustomButton.Location = new System.Drawing.Point(1269, 16);
            this.scanCustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.scanCustomButton.Name = "scanCustomButton";
            this.scanCustomButton.Size = new System.Drawing.Size(140, 28);
            this.scanCustomButton.TabIndex = 1;
            this.scanCustomButton.Text = "Custom Scan";
            this.scanCustomButton.UseVisualStyleBackColor = true;
            this.scanCustomButton.Click += new System.EventHandler(this.scanCustomButton_Click);
            // 
            // customSearchTextBox
            // 
            this.customSearchTextBox.Location = new System.Drawing.Point(127, 18);
            this.customSearchTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.customSearchTextBox.Name = "customSearchTextBox";
            this.customSearchTextBox.Size = new System.Drawing.Size(1133, 22);
            this.customSearchTextBox.TabIndex = 2;
            this.customSearchTextBox.Click += new System.EventHandler(this.customSearchTextBox_Click);
            this.customSearchTextBox.TextChanged += new System.EventHandler(this.customSearchTextBox_TextChanged);
            this.customSearchTextBox.Enter += new System.EventHandler(this.customSearchTextBox_Enter);
            this.customSearchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.customSearchTextBox_KeyPress);
            this.customSearchTextBox.Leave += new System.EventHandler(this.customSearchTextBox_Leave);
            // 
            // removeButton
            // 
            this.removeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.removeButton.Location = new System.Drawing.Point(1269, 577);
            this.removeButton.Margin = new System.Windows.Forms.Padding(4);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(140, 28);
            this.removeButton.TabIndex = 4;
            this.removeButton.Text = "Remove Shortcut";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // selectCheckboxButton
            // 
            this.selectCheckboxButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.selectCheckboxButton.Location = new System.Drawing.Point(17, 577);
            this.selectCheckboxButton.Margin = new System.Windows.Forms.Padding(4);
            this.selectCheckboxButton.Name = "selectCheckboxButton";
            this.selectCheckboxButton.Size = new System.Drawing.Size(140, 28);
            this.selectCheckboxButton.TabIndex = 5;
            this.selectCheckboxButton.Text = "Select All/None";
            this.selectCheckboxButton.UseVisualStyleBackColor = true;
            this.selectCheckboxButton.Click += new System.EventHandler(this.selectCheckboxButton_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(13, 51);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.resultsCheckedListBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.logLB);
            this.splitContainer1.Size = new System.Drawing.Size(1396, 519);
            this.splitContainer1.SplitterDistance = 395;
            this.splitContainer1.TabIndex = 6;
            // 
            // resultsCheckedListBox
            // 
            this.resultsCheckedListBox.CheckOnClick = true;
            this.resultsCheckedListBox.FormattingEnabled = true;
            this.resultsCheckedListBox.Location = new System.Drawing.Point(1, 1);
            this.resultsCheckedListBox.Margin = new System.Windows.Forms.Padding(4);
            this.resultsCheckedListBox.Name = "resultsCheckedListBox";
            this.resultsCheckedListBox.Size = new System.Drawing.Size(1391, 395);
            this.resultsCheckedListBox.TabIndex = 4;
            // 
            // logLB
            // 
            this.logLB.FormattingEnabled = true;
            this.logLB.ItemHeight = 16;
            this.logLB.Location = new System.Drawing.Point(4, 5);
            this.logLB.Name = "logLB";
            this.logLB.Size = new System.Drawing.Size(1389, 116);
            this.logLB.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1425, 620);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.selectCheckboxButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.customSearchTextBox);
            this.Controls.Add(this.scanCustomButton);
            this.Controls.Add(this.scanButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button scanButton;
        private System.Windows.Forms.Button scanCustomButton;
        private System.Windows.Forms.TextBox customSearchTextBox;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button selectCheckboxButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckedListBox resultsCheckedListBox;
        private System.Windows.Forms.ListBox logLB;
    }
}

