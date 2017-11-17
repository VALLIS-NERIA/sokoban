using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sokoban.Controller;
using Sokoban.Model;

namespace Sokoban.View {
    public partial class FilerView : Form, IFilerView {
        public FilerView() { InitializeComponent(); }

        private enum OperationMode {
            Load,
            Save
        }

        private IFilerController controller;
        private OperationMode mode;
        private string loadedFile = null;
        private IFileable gameToSave = null;
        private string _recentFile = null;

        private string recentFile {
            get => this._recentFile;
            set {
                this.recentCommandLink.Enabled = true;
                this.recentCommandLink.Note = this.recentFile;
                this.recentCommandLink.Text = Path.GetFileName(this.recentFile);
                this._recentFile = value;
            }
        }

        public string LoadedFile => this.loadedFile;

        public string RecentFile {
            get => this.recentFile;
        }

        public void SetController(IFilerController controller) { this.controller = controller; }

        public DialogResult LoadDialog() {
            this.Text = "Open";
            this.mode = OperationMode.Load;
            return ShowDialog();
        }

        public DialogResult SaveDialog(IFileable fileable) {
            this.Text = "Save";
            this.mode = OperationMode.Save;
            this.gameToSave = fileable;
            return ShowDialog();
        }

        private void dialogCommandLink_Click(object sender, EventArgs e) {
            if (this.mode == OperationMode.Load) {
                this.openFileDialog1.Title = "Open a file";
                var result = this.openFileDialog1.ShowDialog();
                if (result == DialogResult.OK) {
                    var fn = this.openFileDialog1.FileName;
                    this.loadedFile = this.controller.LoadFile(fn);
                    this.recentFile = fn;
                    this.DialogResult = DialogResult.OK;
                    Close();
                }
            }
            else if (this.mode == OperationMode.Save) {
                this.openFileDialog1.Title = "Save as ...";
                var result = this.openFileDialog1.ShowDialog();
                if (result == DialogResult.OK) {
                    var fn = this.openFileDialog1.FileName;
                    this.controller.SaveToFile(this.gameToSave, fn);
                    this.recentFile = fn;
                    this.DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }

        private void cancelCommandLink_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}