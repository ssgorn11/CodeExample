using DataLoader.Admin.Client.Forms;
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

namespace DataLoader.Admin.Client.UserControls
{
    public partial class ucTags : UserControl, IReloadData
    {
        private ITagService _tagService;
        private IScheduleService _scheduleService;

        private IEnumerable<TagDto> _tagList;
        private IEnumerable<ScheduleDto> _scheduleList;

        public ucTags()
        {
            InitializeComponent();
            _tagService = AdminFactory.Resolve<ITagService>();
            _scheduleService = AdminFactory.Resolve<IScheduleService>();
        }

        public async Task ReloadData()
        {
            scheduleDtoBindingSource.DataSource = null;
            scheduleTagDtoBindingSource.DataSource = null;
            using (var lo = new ucLoadProgress())
            {
                lo.Show(this);
                _tagList = await _tagService.GetTagsAsync();
            }
            scheduleTagDtoBindingSource.DataSource = _tagList;
        }

        private async void scheduleTagDtoBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var cur = (scheduleTagDtoBindingSource.Current as TagDto);
            if (cur != null)
            {
                scheduleDtoBindingSource.DataSource = null;
                using (var lo = new ucLoadProgress())
                {
                    lo.Show(this);
                    _scheduleList = await _scheduleService.GetSchedulesByTagAsync(cur.Id);
                }
                scheduleDtoBindingSource.DataSource = _scheduleList;
            }
        }

        private async void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            await ReloadData();
        }

        private async void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            using (var frm = new TagEditForm())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    await _tagService.AddAsync(frm.TagDto);
                    await ReloadData();
                }
            }
        }

        private async void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            if ((scheduleTagDtoBindingSource.Current as TagDto) != null)
            {
                using (var frm = new TagEditForm((scheduleTagDtoBindingSource.Current as TagDto)))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        await _tagService.UpdateAsync(frm.TagDto);
                        await ReloadData();
                    }
                }
            }
        }

        private async void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            if ((scheduleTagDtoBindingSource.Current as TagDto) != null
                && MessageBox.Show("Уверены, что хотите удалить запись?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    await _tagService.DeleteAsync((scheduleTagDtoBindingSource.Current as TagDto).Id);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dataGridViewTags_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            toolStripButtonEdit_Click(sender, e);
        }

        private void textBoxTag_TextChanged(object sender, EventArgs e)
        {
            scheduleTagDtoBindingSource.DataSource = _tagList.Where(x => x.Tag.ToLower().Contains(textBoxTag.Text?.ToLower()));
        }

        private void textBoxComment_TextChanged(object sender, EventArgs e)
        {
            scheduleTagDtoBindingSource.DataSource = _tagList.Where(x => x.Comment.ToLower().Contains(textBoxComment.Text?.ToLower()));
        }
    }
}
