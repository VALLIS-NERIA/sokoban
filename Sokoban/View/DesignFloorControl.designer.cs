﻿namespace Sokoban.View {
    partial class DesignFloorControl {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.SuspendLayout();
            // 
            // DesignFloorControl
            // 
            this.CausesValidation = false;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Size = new System.Drawing.Size(35, 35);
            this.Click += new System.EventHandler(this.DesignFloorControl_Click);
            this.Enter += new System.EventHandler(this.FloorControl_Enter);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
