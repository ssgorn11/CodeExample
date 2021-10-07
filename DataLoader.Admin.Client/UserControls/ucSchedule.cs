using DataLoader.Admin.Client.Forms;
using DataLoader.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataLoader.Admin.Client
{
    public partial class ucSchedule : UserControl, IReloadData
    {
        private IEnumerable<ScheduleDto> _scheduleList;
        private IScheduleService _scheduleService;
        
        public IEnumerable<RepeatIntervalType> RepeatIntervalTypeList => RepeatIntervalTypeExtention.RepeatIntervalTypeList;
        public IEnumerable<BorderSeachIntervalType> BorderSeachIntervalTypeList => BorderSeachIntervalTypeExtention.BorderSeachIntervalTypeList;
        public IEnumerable<BorderSeachIntervalDirection> BorderSeachIntervalDirectionList => BorderSeachIntervalDirectionExtention.BorderSeachIntervalDirectionList;

        public ucSchedule()
        {
            InitializeComponent();
            _scheduleService = AdminFactory.Resolve<IScheduleService>();
            repeatIntervalTypeDataGridViewTextBoxColumn.DataSource = RepeatIntervalTypeList.ToList();
            borderSeachIntervalTypeDataGridViewTextBoxColumn.DataSource = BorderSeachIntervalTypeList.ToList();
            borderSeachIntervalDirectionDataGridViewTextBoxColumn.DataSource = BorderSeachIntervalDirectionList.ToList();
        }

        public async Task ReloadData()
        {
            bindingSourceScedule.DataSource = null;
            using (var lo = new ucLoadProgress())
            {
                lo.Show(this);
                _scheduleList = await _scheduleService.GetAsync();
            }
            bindingSourceScedule.DataSource = _scheduleList;
        }

        private async void bindingSourceScedule_CurrentChanged(object sender, EventArgs e)
        {
            var cur = (bindingSourceScedule.Current as ScheduleDto);
            if (cur != null)
                await ucScheduleTag1.ReloadData(cur.Id);
        }

        private async void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            await ReloadData();
        }

        private async void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            using (var frm = new ScheduleEditForm())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    await _scheduleService.AddAsync(frm.ScheduleDto);
                    await ReloadData();
                }
            }
        }

        private async void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            if ((bindingSourceScedule.Current as ScheduleDto) != null)
            {
                using (var frm = new ScheduleEditForm((bindingSourceScedule.Current as ScheduleDto)))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        await _scheduleService.UpdateAsync(frm.ScheduleDto);
                        await ReloadData();
                    }
                }
            }
        }

        private async void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            if ((bindingSourceScedule.Current as ScheduleDto) != null
                && MessageBox.Show("Уверены, что хотите удалить запись?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    await _scheduleService.DeleteAsync((bindingSourceScedule.Current as ScheduleDto).Id);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dataGridViewSchedule_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            toolStripButtonEdit_Click(sender, e);
        }
    }
}
