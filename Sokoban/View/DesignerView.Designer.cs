namespace Sokoban.View {
    partial class DesignerView {
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
            this.buttonPlayer = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonBlock = new System.Windows.Forms.Button();
            this.buttonGoal = new System.Windows.Forms.Button();
            this.buttonWall = new System.Windows.Forms.Button();
            this.buttonEmpty = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonPlayer
            // 
            this.buttonPlayer.BackgroundImage = global::Sokoban.Properties.Resources.player;
            this.buttonPlayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonPlayer.Location = new System.Drawing.Point(164, 0);
            this.buttonPlayer.Name = "buttonPlayer";
            this.buttonPlayer.Size = new System.Drawing.Size(35, 35);
            this.buttonPlayer.TabIndex = 1;
            this.buttonPlayer.UseVisualStyleBackColor = true;
            this.buttonPlayer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonPlayer_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNew,
            this.menuOpen,
            this.menuSave});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(199, 25);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuNew
            // 
            this.menuNew.Name = "menuNew";
            this.menuNew.Size = new System.Drawing.Size(46, 21);
            this.menuNew.Text = "New";
            this.menuNew.Click += new System.EventHandler(this.menuNew_Click);
            // 
            // menuOpen
            // 
            this.menuOpen.Name = "menuOpen";
            this.menuOpen.Size = new System.Drawing.Size(52, 21);
            this.menuOpen.Text = "Open";
            this.menuOpen.Click += new System.EventHandler(this.menuOpen_Click);
            // 
            // menuSave
            // 
            this.menuSave.Name = "menuSave";
            this.menuSave.Size = new System.Drawing.Size(47, 21);
            this.menuSave.Text = "Save";
            this.menuSave.Click += new System.EventHandler(this.menuSave_Click);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panel1.Location = new System.Drawing.Point(0, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(0, 0);
            this.panel1.TabIndex = 0;
            // 
            // buttonBlock
            // 
            this.buttonBlock.BackgroundImage = global::Sokoban.Properties.Resources.block;
            this.buttonBlock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonBlock.Location = new System.Drawing.Point(123, 0);
            this.buttonBlock.Name = "buttonBlock";
            this.buttonBlock.Size = new System.Drawing.Size(35, 35);
            this.buttonBlock.TabIndex = 1;
            this.buttonBlock.UseVisualStyleBackColor = true;
            this.buttonBlock.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonBlock_Click);
            // 
            // buttonGoal
            // 
            this.buttonGoal.BackgroundImage = global::Sokoban.Properties.Resources.goal;
            this.buttonGoal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonGoal.Location = new System.Drawing.Point(82, 0);
            this.buttonGoal.Name = "buttonGoal";
            this.buttonGoal.Size = new System.Drawing.Size(35, 35);
            this.buttonGoal.TabIndex = 1;
            this.buttonGoal.UseVisualStyleBackColor = true;
            this.buttonGoal.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonGoal_Click);
            // 
            // buttonWall
            // 
            this.buttonWall.BackgroundImage = global::Sokoban.Properties.Resources.wall;
            this.buttonWall.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonWall.Location = new System.Drawing.Point(41, 0);
            this.buttonWall.Name = "buttonWall";
            this.buttonWall.Size = new System.Drawing.Size(35, 35);
            this.buttonWall.TabIndex = 1;
            this.buttonWall.UseVisualStyleBackColor = true;
            this.buttonWall.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonWall_Click);
            // 
            // buttonEmpty
            // 
            this.buttonEmpty.BackColor = System.Drawing.SystemColors.Control;
            this.buttonEmpty.BackgroundImage = global::Sokoban.Properties.Resources.empty;
            this.buttonEmpty.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonEmpty.Location = new System.Drawing.Point(0, 0);
            this.buttonEmpty.Name = "buttonEmpty";
            this.buttonEmpty.Size = new System.Drawing.Size(35, 35);
            this.buttonEmpty.TabIndex = 1;
            this.buttonEmpty.UseVisualStyleBackColor = false;
            this.buttonEmpty.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonEmpty_Click);
            // 
            // panel2
            // 
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Controls.Add(this.buttonEmpty);
            this.panel2.Controls.Add(this.buttonPlayer);
            this.panel2.Controls.Add(this.buttonBlock);
            this.panel2.Controls.Add(this.buttonWall);
            this.panel2.Controls.Add(this.buttonGoal);
            this.panel2.Location = new System.Drawing.Point(0, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 35);
            this.panel2.TabIndex = 4;
            // 
            // DesignerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(199, 223);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DesignerView";
            this.Text = "DesignerView";
            this.Resize += new System.EventHandler(this.DesignerView_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonEmpty;
        private System.Windows.Forms.Button buttonWall;
        private System.Windows.Forms.Button buttonGoal;
        private System.Windows.Forms.Button buttonBlock;
        private System.Windows.Forms.Button buttonPlayer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuNew;
        private System.Windows.Forms.FlowLayoutPanel panel1;
        private System.Windows.Forms.ToolStripMenuItem menuOpen;
        private System.Windows.Forms.ToolStripMenuItem menuSave;
        private System.Windows.Forms.Panel panel2;
    }
}