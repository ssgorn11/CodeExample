
namespace DataLoader.Admin.Client
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageSchedule = new System.Windows.Forms.TabPage();
            this.ucSchedule1 = new DataLoader.Admin.Client.ucSchedule();
            this.tabPageTags = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ucTags1 = new DataLoader.Admin.Client.UserControls.ucTags();
            this.tabControlMain.SuspendLayout();
            this.tabPageSchedule.SuspendLayout();
            this.tabPageTags.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageSchedule);
            this.tabControlMain.Controls.Add(this.tabPageTags);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1159, 660);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabPageSchedule
            // 
            this.tabPageSchedule.Controls.Add(this.ucSchedule1);
            this.tabPageSchedule.Location = new System.Drawing.Point(4, 22);
            this.tabPageSchedule.Name = "tabPageSchedule";
            this.tabPageSchedule.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSchedule.Size = new System.Drawing.Size(1151, 634);
            this.tabPageSchedule.TabIndex = 0;
            this.tabPageSchedule.Text = "Расписания";
            this.tabPageSchedule.UseVisualStyleBackColor = true;
            // 
            // ucSchedule1
            // 
            this.ucSchedule1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSchedule1.Location = new System.Drawing.Point(3, 3);
            this.ucSchedule1.Name = "ucSchedule1";
            this.ucSchedule1.Size = new System.Drawing.Size(1145, 628);
            this.ucSchedule1.TabIndex = 0;
            // 
            // tabPageTags
            // 
            this.tabPageTags.Controls.Add(this.ucTags1);
            this.tabPageTags.Location = new System.Drawing.Point(4, 22);
            this.tabPageTags.Name = "tabPageTags";
            this.tabPageTags.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTags.Size = new System.Drawing.Size(1151, 634);
            this.tabPageTags.TabIndex = 1;
            this.tabPageTags.Text = "ТЭГи";
            this.tabPageTags.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 660);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1159, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ucTags1
            // 
            this.ucTags1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTags1.Location = new System.Drawing.Point(3, 3);
            this.ucTags1.Name = "ucTags1";
            this.ucTags1.Size = new System.Drawing.Size(1145, 628);
            this.ucTags1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1159, 682);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.statusStrip1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Администрирование расписаний";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageSchedule.ResumeLayout(false);
            this.tabPageTags.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageSchedule;
        private System.Windows.Forms.TabPage tabPageTags;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private ucSchedule ucSchedule1;
        private UserControls.ucTags ucTags1;
    }
}

