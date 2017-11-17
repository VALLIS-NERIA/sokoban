using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sokoban.View {
    public partial class LoadDialog : Form {
        public LoadDialog() {
            InitializeComponent();
        }
        public string FileName { get; private set; }
        private void openDialogCommandLink_Click(object sender, EventArgs e) {
            var result = this.openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) {
                var fn = this.openFileDialog1.FileName;
                this.FileName = fn;
                this.DialogResult = DialogResult.OK;
            }
            Close();
        }

        private void cancelCommandLink_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
