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
    public partial class NewMapDialog : Form {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public NewMapDialog() {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e) {
            try {
                this.Width = int.Parse(this.widthTextBox.Text);
                this.Height = int.Parse(this.heightTextBox.Text);
                this.DialogResult = DialogResult.OK;
                Close();
            }
            catch (FormatException ) {
                MessageBox.Show("Invalid input!");
            }
        }

        private void cancelButton_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
