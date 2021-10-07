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
    public partial class ucLoadProgress : UserControl
    {
        private DateTime _timeStart;
        private Timer _timer;
        private ContainerControl _parent;

        public ucLoadProgress()
        {
            InitializeComponent();
            
            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Tick += _timer_Tick;
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            if (!Visible && (DateTime.Now - _timeStart).TotalSeconds > 1)
                Visible = true;

            labelTime.Text = (DateTime.Now - _timeStart).ToString(@"hh\:mm\:ss");
            
            if (_parent == null)
                _timer.Stop();
        }

        public void Show(ContainerControl parent)
        {
            _parent = parent;
            Visible = false;
            if (!parent.Controls.Contains(this))
                parent.Controls.Add(this);

            this.BringToFront();

            if (parent.Width >= Width)
                this.Left = (parent.Width - Width) / 2;
            else
            {
                Width = parent.Width;
                Left = 0;
            }

            if (parent.Height >= Height)
                this.Top = (parent.Height - Height) / 2;
            else
            {
                Height = parent.Height;
                Top = 0;
            }

            _timeStart = DateTime.Now;
            //base.Show();

            _timer.Start();
        }

        public new void Dispose()
        {
            _timer.Stop();

            base.Dispose();
        }
    }
}
