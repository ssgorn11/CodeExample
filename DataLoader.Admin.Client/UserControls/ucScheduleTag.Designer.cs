
namespace DataLoader.Admin.Client
{
    partial class ucScheduleTag
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucScheduleTag));
            this.dataGridViewSceduleTags = new System.Windows.Forms.DataGridView();
            this.bindingSourceTag = new System.Windows.Forms.BindingSource(this.components);
            this.toolStripSceduleTags = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonBound = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonUnBound = new System.Windows.Forms.ToolStripButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxFind = new System.Windows.Forms.TextBox();
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.idDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tagDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeOfIntervalSearchDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.commentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSceduleTags)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceTag)).BeginInit();
            this.toolStripSceduleTags.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewSceduleTags
            // 
            this.dataGridViewSceduleTags.AutoGenerateColumns = false;
            this.dataGridViewSceduleTags.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSceduleTags.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn1,
            this.tagDataGridViewTextBoxColumn,
            this.typeOfIntervalSearchDataGridViewTextBoxColumn,
            this.commentDataGridViewTextBoxColumn});
            this.dataGridViewSceduleTags.DataSource = this.bindingSourceTag;
            this.dataGridViewSceduleTags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSceduleTags.Location = new System.Drawing.Point(0, 52);
            this.dataGridViewSceduleTags.Name = "dataGridViewSceduleTags";
            this.dataGridViewSceduleTags.ReadOnly = true;
            this.dataGridViewSceduleTags.Size = new System.Drawing.Size(505, 493);
            this.dataGridViewSceduleTags.TabIndex = 1;
            // 
            // bindingSourceTag
            // 
            this.bindingSourceTag.DataSource = typeof(DataLoader.Service.Contract.ScheduleTagDto);
            // 
            // toolStripSceduleTags
            // 
            this.toolStripSceduleTags.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonRefresh,
            this.toolStripSeparator1,
            this.toolStripButtonBound,
            this.toolStripButtonUnBound});
            this.toolStripSceduleTags.Location = new System.Drawing.Point(0, 0);
            this.toolStripSceduleTags.Name = "toolStripSceduleTags";
            this.toolStripSceduleTags.Size = new System.Drawing.Size(505, 25);
            this.toolStripSceduleTags.TabIndex = 0;
            this.toolStripSceduleTags.Text = "toolStrip2";
            // 
            // toolStripButtonRefresh
            // 
            this.toolStripButtonRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRefresh.Image = global::DataLoader.Admin.Client.Properties.Resources.refresh;
            this.toolStripButtonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRefresh.Name = "toolStripButtonRefresh";
            this.toolStripButtonRefresh.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonRefresh.Text = "toolStripButton1";
            this.toolStripButtonRefresh.ToolTipText = "Обновить данные";
            this.toolStripButtonRefresh.Click += new System.EventHandler(this.toolStripButtonRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonBound
            // 
            this.toolStripButtonBound.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonBound.Image = global::DataLoader.Admin.Client.Properties.Resources.navigate_plus;
            this.toolStripButtonBound.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonBound.Name = "toolStripButtonBound";
            this.toolStripButtonBound.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonBound.Text = "toolStripButton2";
            this.toolStripButtonBound.ToolTipText = "Привязать ТЭГи к расписанию";
            this.toolStripButtonBound.Click += new System.EventHandler(this.toolStripButtonBound_Click);
            // 
            // toolStripButtonUnBound
            // 
            this.toolStripButtonUnBound.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonUnBound.Image = global::DataLoader.Admin.Client.Properties.Resources.navigate_minus;
            this.toolStripButtonUnBound.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonUnBound.Name = "toolStripButtonUnBound";
            this.toolStripButtonUnBound.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonUnBound.Text = "toolStripButton3";
            this.toolStripButtonUnBound.ToolTipText = "Отвязать ТЭГи от расписания";
            this.toolStripButtonUnBound.Click += new System.EventHandler(this.toolStripButtonUnBound_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxFind);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(505, 27);
            this.panel1.TabIndex = 2;
            // 
            // textBoxFind
            // 
            this.textBoxFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFind.Location = new System.Drawing.Point(3, 4);
            this.textBoxFind.Name = "textBoxFind";
            this.textBoxFind.Size = new System.Drawing.Size(499, 20);
            this.textBoxFind.TabIndex = 0;
            this.toolTip1.SetToolTip(this.textBoxFind, "Фильтр по ТЭГу");
            this.textBoxFind.TextChanged += new System.EventHandler(this.textBoxFind_TextChanged);
            // 
            // idDataGridViewTextBoxColumn1
            // 
            this.idDataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn1.FillWeight = 101.5228F;
            this.idDataGridViewTextBoxColumn1.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
            this.idDataGridViewTextBoxColumn1.ReadOnly = true;
            this.idDataGridViewTextBoxColumn1.Visible = false;
            // 
            // tagDataGridViewTextBoxColumn
            // 
            this.tagDataGridViewTextBoxColumn.DataPropertyName = "Tag";
            this.tagDataGridViewTextBoxColumn.FillWeight = 99.49239F;
            this.tagDataGridViewTextBoxColumn.HeaderText = "Tag";
            this.tagDataGridViewTextBoxColumn.Name = "tagDataGridViewTextBoxColumn";
            this.tagDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // typeOfIntervalSearchDataGridViewTextBoxColumn
            // 
            this.typeOfIntervalSearchDataGridViewTextBoxColumn.DataPropertyName = "TypeOfIntervalSearch";
            this.typeOfIntervalSearchDataGridViewTextBoxColumn.FillWeight = 99.49239F;
            this.typeOfIntervalSearchDataGridViewTextBoxColumn.HeaderText = "Искать значение";
            this.typeOfIntervalSearchDataGridViewTextBoxColumn.Name = "typeOfIntervalSearchDataGridViewTextBoxColumn";
            this.typeOfIntervalSearchDataGridViewTextBoxColumn.ReadOnly = true;
            this.typeOfIntervalSearchDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.typeOfIntervalSearchDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.typeOfIntervalSearchDataGridViewTextBoxColumn.ToolTipText = resources.GetString("typeOfIntervalSearchDataGridViewTextBoxColumn.ToolTipText");
            // 
            // commentDataGridViewTextBoxColumn
            // 
            this.commentDataGridViewTextBoxColumn.DataPropertyName = "Comment";
            this.commentDataGridViewTextBoxColumn.FillWeight = 99.49239F;
            this.commentDataGridViewTextBoxColumn.HeaderText = "Коментарий";
            this.commentDataGridViewTextBoxColumn.Name = "commentDataGridViewTextBoxColumn";
            this.commentDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ucScheduleTag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridViewSceduleTags);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStripSceduleTags);
            this.Name = "ucScheduleTag";
            this.Size = new System.Drawing.Size(505, 545);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSceduleTags)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceTag)).EndInit();
            this.toolStripSceduleTags.ResumeLayout(false);
            this.toolStripSceduleTags.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewSceduleTags;
        private System.Windows.Forms.ToolStrip toolStripSceduleTags;
        private System.Windows.Forms.BindingSource bindingSourceTag;
        private System.Windows.Forms.ToolStripButton toolStripButtonRefresh;
        private System.Windows.Forms.ToolStripButton toolStripButtonBound;
        private System.Windows.Forms.ToolStripButton toolStripButtonUnBound;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxFind;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tagDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn typeOfIntervalSearchDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn commentDataGridViewTextBoxColumn;
    }
}
