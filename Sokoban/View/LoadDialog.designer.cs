namespace Sokoban.View {
    partial class LoadDialog {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.cancelCommandLink = new Sokoban.View.CommandLink();
            this.openDialogCommandLink = new Sokoban.View.CommandLink();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Or...";
            // 
            // cancelCommandLink
            // 
            this.cancelCommandLink.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cancelCommandLink.Location = new System.Drawing.Point(12, 75);
            this.cancelCommandLink.Name = "cancelCommandLink";
            this.cancelCommandLink.Size = new System.Drawing.Size(460, 45);
            this.cancelCommandLink.TabIndex = 0;
            this.cancelCommandLink.Text = "Cancel";
            this.cancelCommandLink.UseVisualStyleBackColor = true;
            this.cancelCommandLink.Click += new System.EventHandler(this.cancelCommandLink_Click);
            // 
            // openDialogCommandLink
            // 
            this.openDialogCommandLink.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.openDialogCommandLink.Location = new System.Drawing.Point(12, 12);
            this.openDialogCommandLink.Name = "openDialogCommandLink";
            this.openDialogCommandLink.Size = new System.Drawing.Size(460, 45);
            this.openDialogCommandLink.TabIndex = 0;
            this.openDialogCommandLink.Text = "Open a level from file (&O)";
            this.openDialogCommandLink.UseVisualStyleBackColor = true;
            this.openDialogCommandLink.Click += new System.EventHandler(this.openDialogCommandLink_Click);
            // 
            // LoadDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelCommandLink);
            this.Controls.Add(this.openDialogCommandLink);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoadDialog";
            this.Text = "LoadDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sokoban.View.CommandLink openDialogCommandLink;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private CommandLink cancelCommandLink;
    }
}