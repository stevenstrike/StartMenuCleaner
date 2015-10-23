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
            this.resultsCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.removeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // scanButton
            // 
            this.scanButton.Location = new System.Drawing.Point(13, 13);
            this.scanButton.Name = "scanButton";
            this.scanButton.Size = new System.Drawing.Size(75, 23);
            this.scanButton.TabIndex = 0;
            this.scanButton.Text = "Scan";
            this.scanButton.UseVisualStyleBackColor = true;
            this.scanButton.Click += new System.EventHandler(this.scanButton_Click);
            // 
            // scanCustomButton
            // 
            this.scanCustomButton.Location = new System.Drawing.Point(952, 13);
            this.scanCustomButton.Name = "scanCustomButton";
            this.scanCustomButton.Size = new System.Drawing.Size(105, 23);
            this.scanCustomButton.TabIndex = 1;
            this.scanCustomButton.Text = "Scan Custom";
            this.scanCustomButton.UseVisualStyleBackColor = true;
            this.scanCustomButton.Click += new System.EventHandler(this.scanCustomButton_Click);
            // 
            // customSearchTextBox
            // 
            this.customSearchTextBox.Location = new System.Drawing.Point(95, 15);
            this.customSearchTextBox.Name = "customSearchTextBox";
            this.customSearchTextBox.Size = new System.Drawing.Size(851, 20);
            this.customSearchTextBox.TabIndex = 2;
            this.customSearchTextBox.Click += new System.EventHandler(this.customSearchTextBox_Click);
            this.customSearchTextBox.TextChanged += new System.EventHandler(this.customSearchTextBox_TextChanged);
            this.customSearchTextBox.Enter += new System.EventHandler(this.customSearchTextBox_Enter);
            this.customSearchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.customSearchTextBox_KeyPress);
            this.customSearchTextBox.Leave += new System.EventHandler(this.customSearchTextBox_Leave);
            // 
            // resultsCheckedListBox
            // 
            this.resultsCheckedListBox.CheckOnClick = true;
            this.resultsCheckedListBox.FormattingEnabled = true;
            this.resultsCheckedListBox.Location = new System.Drawing.Point(13, 43);
            this.resultsCheckedListBox.Name = "resultsCheckedListBox";
            this.resultsCheckedListBox.Size = new System.Drawing.Size(1044, 424);
            this.resultsCheckedListBox.TabIndex = 3;
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(952, 469);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(105, 23);
            this.removeButton.TabIndex = 4;
            this.removeButton.Text = "Remove Shortcut";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 504);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.resultsCheckedListBox);
            this.Controls.Add(this.customSearchTextBox);
            this.Controls.Add(this.scanCustomButton);
            this.Controls.Add(this.scanButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button scanButton;
        private System.Windows.Forms.Button scanCustomButton;
        private System.Windows.Forms.TextBox customSearchTextBox;
        private System.Windows.Forms.CheckedListBox resultsCheckedListBox;
        private System.Windows.Forms.Button removeButton;
    }
}

