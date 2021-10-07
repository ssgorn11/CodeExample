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
    public partial class TagEditForm : Form
    {
        public TagDto TagDto { get; private set; }

        public TagEditForm()
        {
            InitializeComponent();
            TagDto = new TagDto();
            this.Text = "Создание ТЭГа";
        }

        public TagEditForm(TagDto dto)
            : this()
        {
            TagDto = dto;
            this.Text = "Редактирование ТЭГа";
        }

        private void TagEditForm_Load(object sender, EventArgs e)
        {
            textBoxTAG.DataBindings.Add(new Binding("Text", TagDto, "Tag"));
            textBoxComment.DataBindings.Add(new Binding("Text", TagDto, "Comment"));
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string err = "";
            if (string.IsNullOrEmpty(TagDto.Tag))
                err += "Необходимо указать ТЭГ \n\r";

            if (!string.IsNullOrEmpty(err))
                MessageBox.Show(err, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                DialogResult = DialogResult.OK;
        }

    }
}
