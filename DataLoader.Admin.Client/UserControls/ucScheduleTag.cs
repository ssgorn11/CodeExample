using DataLoader.Admin.Client.Forms;
using DataLoader.Admin.HTTP;
using DataLoader.Service.Contract;
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
    public partial class ucScheduleTag : UserControl
    {
        private IEnumerable<ScheduleTagDto> _scheduleTagList;
        private int? _idSchedule;
        private ITagService _tagService;
        
        public IEnumerable<TypeOfIntervalSearch> TypeOfIntervalSearchList => TypeOfIntervalSearchExtention.TypeOfIntervalSearchList;

        public ucScheduleTag()
        {
            InitializeComponent();
            _tagService = AdminFactory.Resolve<ITagService>();
            typeOfIntervalSearchDataGridViewTextBoxColumn.DataSource = TypeOfIntervalSearchList.ToList();
        }

        public async Task ReloadData(int? idSchedule)
        {
            _idSchedule = idSchedule;
            bindingSourceTag.DataSource = null;
            if (idSchedule != null)
            {
                using (var lo = new ucLoadProgress())
                {
                    lo.Show(this);
                    _scheduleTagList = await _tagService.GetTagsByScheduleAsync((int)idSchedule);
                }
            }

            bindingSourceTag.DataSource = _scheduleTagList;
        }

        private void textBoxFind_TextChanged(object sender, EventArgs e)
        {
            bindingSourceTag.DataSource = _scheduleTagList.Where(x => x.Tag.ToLower().Contains(textBoxFind.Text?.ToLower()));
        }

        private async void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            await ReloadData(_idSchedule);
        }

        private async void toolStripButtonBound_Click(object sender, EventArgs e)
        {
            using (var frm = new TagListSelectForm(_idSchedule))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    using (var lo = new ucLoadProgress())
                    {
                        lo.Show(this);
                        await _tagService.BoundTagsAsync((int)_idSchedule, frm.TagsList.Where(x => (x.IsCheck ?? false))?.Select(x => (ScheduleTagDto)x));
                        await ReloadData(_idSchedule);
                    }
                }
            }
        }

        private async void toolStripButtonUnBound_Click(object sender, EventArgs e)
        {
            using (var frm = new TagListSelectForm(_idSchedule, _scheduleTagList))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    using (var lo = new ucLoadProgress())
                    {
                        lo.Show(this);
                        await _tagService.UnBoundTagsAsync((int)_idSchedule, frm.TagsList.Where(x => (x.IsCheck ?? false))?.Select(x => (ScheduleTagDto)x));
                        await ReloadData(_idSchedule);
                    }
                }
            }
        }
    }
}
