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
    public partial class ScheduleEditForm : Form
    {
        public ScheduleDto ScheduleDto { get; private set; }

        public IEnumerable<RepeatIntervalType> RepeatIntervalTypeList => RepeatIntervalTypeExtention.RepeatIntervalTypeList;
        public IEnumerable<BorderSeachIntervalType> BorderSeachIntervalTypeList => BorderSeachIntervalTypeExtention.BorderSeachIntervalTypeList;
        public IEnumerable<BorderSeachIntervalDirection> BorderSeachIntervalDirectionList => BorderSeachIntervalDirectionExtention.BorderSeachIntervalDirectionList;

        public ScheduleEditForm()
        {
            InitializeComponent();
            ScheduleDto = new ScheduleDto();
            this.Text = "Создание расписания";
        }

        public ScheduleEditForm(ScheduleDto dto)
            : this()
        {
            ScheduleDto = dto;
            this.Text = "Редактирование расписания";
        }

        private void ScheduleEditForm_Load(object sender, EventArgs e)
        {
            textBoxName.DataBindings.Add(new Binding("Text", ScheduleDto, "Name"));
            if (ScheduleDto.TimeStart < dateTimePickerDate.MinDate)
                ScheduleDto.TimeStart = DateTime.Now.Date;
            dateTimePickerDate.DataBindings.Add(new Binding("Value", ScheduleDto, "TimeStart"));

            numericUpDownInterval.DataBindings.Add(new Binding("Value", ScheduleDto, "RepeatInterval"));
            comboBoxIntervalType.DataSource = RepeatIntervalTypeList.ToList();
            comboBoxIntervalType.DataBindings.Add(new Binding("SelectedItem", ScheduleDto, "RepeatIntervalType"));
            numericUpDownBorderInterval.DataBindings.Add(new Binding("Value", ScheduleDto, "BorderSeachInterval"));
            comboBoxBorderType.DataSource = BorderSeachIntervalTypeList.ToList();
            comboBoxBorderType.DataBindings.Add(new Binding("SelectedItem", ScheduleDto, "BorderSeachIntervalType"));
            comboBoxBorderDirection.DataSource = BorderSeachIntervalDirectionList.ToList();
            comboBoxBorderDirection.DataBindings.Add(new Binding("SelectedItem", ScheduleDto, "BorderSeachIntervalDirection"));
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string err = "";
            if (ScheduleDto.RepeatInterval <= 0)
                err += "Необходимо указать интервал посторения \n\r";
            if (ScheduleDto.BorderSeachInterval <= 0)
                err += "Необходимо указать интервал поиска \n\r";

            if (!string.IsNullOrEmpty(err))
                MessageBox.Show(err, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                DialogResult = DialogResult.OK;
        }
    }
}
