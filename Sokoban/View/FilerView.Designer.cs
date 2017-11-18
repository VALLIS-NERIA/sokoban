namespace Sokoban.View {
    partial class FilerView {
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
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.recentCommandLink = new Sokoban.View.CommandLink();
            this.cancelCommandLink = new Sokoban.View.CommandLink();
            this.dialogCommandLink = new Sokoban.View.CommandLink();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Choose a selection...";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // recentCommandLink
            // 
            this.recentCommandLink.Enabled = false;
            this.recentCommandLink.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.recentCommandLink.Location = new System.Drawing.Point(12, 103);
            this.recentCommandLink.Name = "recentCommandLink";
            this.recentCommandLink.Size = new System.Drawing.Size(450, 60);
            this.recentCommandLink.TabIndex = 0;
            this.recentCommandLink.Text = "No recent file.";
            this.recentCommandLink.UseVisualStyleBackColor = true;
            // 
            // cancelCommandLink
            // 
            this.cancelCommandLink.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cancelCommandLink.Location = new System.Drawing.Point(12, 169);
            this.cancelCommandLink.Name = "cancelCommandLink";
            this.cancelCommandLink.Size = new System.Drawing.Size(450, 60);
            this.cancelCommandLink.TabIndex = 0;
            this.cancelCommandLink.Text = "Cancel";
            this.cancelCommandLink.UseVisualStyleBackColor = true;
            this.cancelCommandLink.Click += new System.EventHandler(this.cancelCommandLink_Click);
            // 
            // dialogCommandLink
            // 
            this.dialogCommandLink.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.dialogCommandLink.ForeColor = System.Drawing.SystemColors.Highlight;
            this.dialogCommandLink.Location = new System.Drawing.Point(12, 37);
            this.dialogCommandLink.Name = "dialogCommandLink";
            this.dialogCommandLink.Note = "Open a dialog and select a file";
            this.dialogCommandLink.Size = new System.Drawing.Size(450, 60);
            this.dialogCommandLink.TabIndex = 0;
            this.dialogCommandLink.Text = "Open...";
            this.dialogCommandLink.UseVisualStyleBackColor = true;
            this.dialogCommandLink.Click += new System.EventHandler(this.dialogCommandLink_Click);
            // 
            // FilerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(474, 241);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.recentCommandLink);
            this.Controls.Add(this.cancelCommandLink);
            this.Controls.Add(this.dialogCommandLink);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FilerView";
            this.Text = "FilerView";
            this.Load += new System.EventHandler(this.FilerView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CommandLink dialogCommandLink;
        private System.Windows.Forms.Label label1;
        private CommandLink cancelCommandLink;
        private CommandLink recentCommandLink;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}