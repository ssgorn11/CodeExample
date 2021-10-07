
namespace DataLoader.Admin.Client
{
    partial class ucSchedule
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridViewSchedule = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeStartDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.repeatIntervalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.repeatIntervalTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.borderSeachIntervalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.borderSeachIntervalTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.borderSeachIntervalDirectionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.isActiveDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bindingSourceScedule = new System.Windows.Forms.BindingSource(this.components);
            this.toolStripSchedule = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDelete = new System.Windows.Forms.ToolStripButton();
            this.ucScheduleTag1 = new DataLoader.Admin.Client.ucScheduleTag();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSchedule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceScedule)).BeginInit();
            this.toolStripSchedule.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridViewSchedule);
            this.splitContainer1.Panel1.Controls.Add(this.toolStripSchedule);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ucScheduleTag1);
            this.splitContainer1.Size = new System.Drawing.Size(1165, 704);
            this.splitContainer1.SplitterDistance = 857;
            this.splitContainer1.TabIndex = 1;
            // 
            // dataGridViewSchedule
            // 
            this.dataGridViewSchedule.AutoGenerateColumns = false;
            this.dataGridViewSchedule.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSchedule.ColumnHeadersHeight = 50;
            this.dataGridViewSchedule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.timeStartDataGridViewTextBoxColumn,
            this.repeatIntervalDataGridViewTextBoxColumn,
            this.repeatIntervalTypeDataGridViewTextBoxColumn,
            this.borderSeachIntervalDataGridViewTextBoxColumn,
            this.borderSeachIntervalTypeDataGridViewTextBoxColumn,
            this.borderSeachIntervalDirectionDataGridViewTextBoxColumn,
            this.isActiveDataGridViewTextBoxColumn});
            this.dataGridViewSchedule.DataSource = this.bindingSourceScedule;
            this.dataGridViewSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSchedule.Location = new System.Drawing.Point(0, 25);
            this.dataGridViewSchedule.Name = "dataGridViewSchedule";
            this.dataGridViewSchedule.ReadOnly = true;
            this.dataGridViewSchedule.Size = new System.Drawing.Size(857, 679);
            this.dataGridViewSchedule.TabIndex = 1;
            this.dataGridViewSchedule.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSchedule_CellDoubleClick);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.idDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.idDataGridViewTextBoxColumn.FillWeight = 183.1405F;
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Width = 41;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.FillWeight = 67.30414F;
            this.nameDataGridViewTextBoxColumn.HeaderText = "Название расписания";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // timeStartDataGridViewTextBoxColumn
            // 
            this.timeStartDataGridViewTextBoxColumn.DataPropertyName = "TimeStart";
            this.timeStartDataGridViewTextBoxColumn.FillWeight = 67.30414F;
            this.timeStartDataGridViewTextBoxColumn.HeaderText = "Время запуска";
            this.timeStartDataGridViewTextBoxColumn.Name = "timeStartDataGridViewTextBoxColumn";
            this.timeStartDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // repeatIntervalDataGridViewTextBoxColumn
            // 
            this.repeatIntervalDataGridViewTextBoxColumn.DataPropertyName = "RepeatInterval";
            this.repeatIntervalDataGridViewTextBoxColumn.FillWeight = 67.30414F;
            this.repeatIntervalDataGridViewTextBoxColumn.HeaderText = "Повторять каждые";
            this.repeatIntervalDataGridViewTextBoxColumn.Name = "repeatIntervalDataGridViewTextBoxColumn";
            this.repeatIntervalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // repeatIntervalTypeDataGridViewTextBoxColumn
            // 
            this.repeatIntervalTypeDataGridViewTextBoxColumn.DataPropertyName = "RepeatIntervalType";
            this.repeatIntervalTypeDataGridViewTextBoxColumn.FillWeight = 67.30414F;
            this.repeatIntervalTypeDataGridViewTextBoxColumn.HeaderText = "Тип времени поиска";
            this.repeatIntervalTypeDataGridViewTextBoxColumn.Name = "repeatIntervalTypeDataGridViewTextBoxColumn";
            this.repeatIntervalTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.repeatIntervalTypeDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.repeatIntervalTypeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // borderSeachIntervalDataGridViewTextBoxColumn
            // 
            this.borderSeachIntervalDataGridViewTextBoxColumn.DataPropertyName = "BorderSeachInterval";
            this.borderSeachIntervalDataGridViewTextBoxColumn.FillWeight = 67.30414F;
            this.borderSeachIntervalDataGridViewTextBoxColumn.HeaderText = "Искать в границах";
            this.borderSeachIntervalDataGridViewTextBoxColumn.Name = "borderSeachIntervalDataGridViewTextBoxColumn";
            this.borderSeachIntervalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // borderSeachIntervalTypeDataGridViewTextBoxColumn
            // 
            this.borderSeachIntervalTypeDataGridViewTextBoxColumn.DataPropertyName = "BorderSeachIntervalType";
            this.borderSeachIntervalTypeDataGridViewTextBoxColumn.FillWeight = 67.30414F;
            this.borderSeachIntervalTypeDataGridViewTextBoxColumn.HeaderText = "Тип времени границы";
            this.borderSeachIntervalTypeDataGridViewTextBoxColumn.Name = "borderSeachIntervalTypeDataGridViewTextBoxColumn";
            this.borderSeachIntervalTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.borderSeachIntervalTypeDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.borderSeachIntervalTypeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // borderSeachIntervalDirectionDataGridViewTextBoxColumn
            // 
            this.borderSeachIntervalDirectionDataGridViewTextBoxColumn.DataPropertyName = "BorderSeachIntervalDirection";
            this.borderSeachIntervalDirectionDataGridViewTextBoxColumn.FillWeight = 67.30414F;
            this.borderSeachIntervalDirectionDataGridViewTextBoxColumn.HeaderText = "В направлениях";
            this.borderSeachIntervalDirectionDataGridViewTextBoxColumn.Name = "borderSeachIntervalDirectionDataGridViewTextBoxColumn";
            this.borderSeachIntervalDirectionDataGridViewTextBoxColumn.ReadOnly = true;
            this.borderSeachIntervalDirectionDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.borderSeachIntervalDirectionDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // isActiveDataGridViewTextBoxColumn
            // 
            this.isActiveDataGridViewTextBoxColumn.DataPropertyName = "IsActive";
            this.isActiveDataGridViewTextBoxColumn.FillWeight = 67.30414F;
            this.isActiveDataGridViewTextBoxColumn.HeaderText = "Активно";
            this.isActiveDataGridViewTextBoxColumn.Name = "isActiveDataGridViewTextBoxColumn";
            this.isActiveDataGridViewTextBoxColumn.ReadOnly = true;
            this.isActiveDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.isActiveDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // bindingSourceScedule
            // 
            this.bindingSourceScedule.DataSource = typeof(DataLoader.Service.Contract.ScheduleDto);
            this.bindingSourceScedule.CurrentChanged += new System.EventHandler(this.bindingSourceScedule_CurrentChanged);
            // 
            // toolStripSchedule
            // 
            this.toolStripSchedule.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonRefresh,
            this.toolStripSeparator1,
            this.toolStripButtonAdd,
            this.toolStripButtonEdit,
            this.toolStripButtonDelete});
            this.toolStripSchedule.Location = new System.Drawing.Point(0, 0);
            this.toolStripSchedule.Name = "toolStripSchedule";
            this.toolStripSchedule.Size = new System.Drawing.Size(857, 25);
            this.toolStripSchedule.TabIndex = 0;
            this.toolStripSchedule.Text = "toolStrip1";
            // 
            // toolStripButtonRefresh
            // 
            this.toolStripButtonRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRefresh.Image = global::DataLoader.Admin.Client.Properties.Resources.refresh;
            this.toolStripButtonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRefresh.Name = "toolStripButtonRefresh";
            this.toolStripButtonRefresh.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonRefresh.Text = "toolStripButton1";
            this.toolStripButtonRefresh.Click += new System.EventHandler(this.toolStripButtonRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonAdd
            // 
            this.toolStripButtonAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAdd.Image = global::DataLoader.Admin.Client.Properties.Resources.add;
            this.toolStripButtonAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAdd.Name = "toolStripButtonAdd";
            this.toolStripButtonAdd.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonAdd.Text = "toolStripButton2";
            this.toolStripButtonAdd.Click += new System.EventHandler(this.toolStripButtonAdd_Click);
            // 
            // toolStripButtonEdit
            // 
            this.toolStripButtonEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEdit.Image = global::DataLoader.Admin.Client.Properties.Resources.edit1;
            this.toolStripButtonEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEdit.Name = "toolStripButtonEdit";
            this.toolStripButtonEdit.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonEdit.Text = "toolStripButton3";
            this.toolStripButtonEdit.Click += new System.EventHandler(this.toolStripButtonEdit_Click);
            // 
            // toolStripButtonDelete
            // 
            this.toolStripButtonDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDelete.Image = global::DataLoader.Admin.Client.Properties.Resources.delete;
            this.toolStripButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDelete.Name = "toolStripButtonDelete";
            this.toolStripButtonDelete.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonDelete.Text = "toolStripButton4";
            this.toolStripButtonDelete.Click += new System.EventHandler(this.toolStripButtonDelete_Click);
            // 
            // ucScheduleTag1
            // 
            this.ucScheduleTag1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucScheduleTag1.Location = new System.Drawing.Point(0, 0);
            this.ucScheduleTag1.Name = "ucScheduleTag1";
            this.ucScheduleTag1.Size = new System.Drawing.Size(304, 704);
            this.ucScheduleTag1.TabIndex = 0;
            // 
            // ucSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ucSchedule";
            this.Size = new System.Drawing.Size(1165, 704);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSchedule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceScedule)).EndInit();
            this.toolStripSchedule.ResumeLayout(false);
            this.toolStripSchedule.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridViewSchedule;
        private System.Windows.Forms.ToolStrip toolStripSchedule;
        private System.Windows.Forms.BindingSource bindingSourceScedule;
        private ucScheduleTag ucScheduleTag1;
        private System.Windows.Forms.ToolStripButton toolStripButtonRefresh;
        private System.Windows.Forms.ToolStripButton toolStripButtonAdd;
        private System.Windows.Forms.ToolStripButton toolStripButtonEdit;
        private System.Windows.Forms.ToolStripButton toolStripButtonDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeStartDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn repeatIntervalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn repeatIntervalTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn borderSeachIntervalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn borderSeachIntervalTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn borderSeachIntervalDirectionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isActiveDataGridViewTextBoxColumn;
    }
}
