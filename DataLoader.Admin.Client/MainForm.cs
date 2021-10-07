using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataLoader.Admin.Client
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.tabControlMain.SelectedIndex = 0;
            tabControlMain.SelectedIndexChanged += tabControlMain_SelectedIndexChanged;
            tabControlMain_SelectedIndexChanged(sender, e);
        }

        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabControlMain.SelectedTab.Controls.OfType<IReloadData>()?.FirstOrDefault()?.ReloadData();
        }
    }
}
