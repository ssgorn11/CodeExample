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

namespace DataLoader.Admin.Client.Forms
{
    public partial class TagListSelectForm : Form
    {
        internal IList<TagCheck> TagsList { get; private set; }
        private ITagService _tagService;
        private int? _idSchedule;

        public IEnumerable<TypeOfIntervalSearch> TypeOfIntervalSearchList => TypeOfIntervalSearchExtention.TypeOfIntervalSearchList;

        public TagListSelectForm(int? idSchedule)
        {
            InitializeComponent();
            Column1.FalseValue = false;
            Column1.TrueValue = true;
            _idSchedule = idSchedule;
            _tagService = AdminFactory.Resolve<ITagService>();
            typeOfIntervalSearchDataGridViewTextBoxColumn.DataSource = TypeOfIntervalSearchList.ToList();
            Text = "Привязать ТЭГи к расписанию";
        }

        public TagListSelectForm(int? idSchedule, IEnumerable<ScheduleTagDto> tags)
            : this(idSchedule)
        {
            TagsList = tags.Select(x => new TagCheck(x)).ToList();
            Text = "Отвязать ТЭГи от расписания";
        }

        private async void TagListSelectForm_Load(object sender, EventArgs e)
        {
            tagCheckBindingSource.DataSource = null;
            if (TagsList == null)
            {
                using (var lo = new ucLoadProgress())
                {
                    lo.Show(this);
                    TagsList = (await _tagService.GetTagsNotInScheduleAsync((int)_idSchedule))?.Select(x => new TagCheck(x))?.ToList();
                }
            }
            tagCheckBindingSource.DataSource = TagsList;
            dataGridView1.Refresh();
        }

        private void textBoxFind_TextChanged(object sender, EventArgs e)
        {
            tagCheckBindingSource.DataSource = TagsList.Where(x => x.Tag.ToLower().Contains(textBoxFind.Text?.ToLower()));
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
