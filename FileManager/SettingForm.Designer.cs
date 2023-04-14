namespace DeleteFileController
{
    partial class SettingForm
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
            bt_Save = new System.Windows.Forms.Button();
            lbTitle_SuperPath = new System.Windows.Forms.Label();
            tb_SuperPath = new System.Windows.Forms.TextBox();
            lbTitle_LogPath = new System.Windows.Forms.Label();
            tb_LogPath = new System.Windows.Forms.TextBox();
            lbTitle_IntervalTime = new System.Windows.Forms.Label();
            tb_IntervalTime = new System.Windows.Forms.TextBox();
            lbTitle_StandardDay = new System.Windows.Forms.Label();
            tb_StandardDay = new System.Windows.Forms.TextBox();
            lbTitle_Hours = new System.Windows.Forms.Label();
            lbTitle_Days = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // bt_Save
            // 
            bt_Save.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            bt_Save.Location = new System.Drawing.Point(335, 77);
            bt_Save.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            bt_Save.Name = "bt_Save";
            bt_Save.Size = new System.Drawing.Size(248, 62);
            bt_Save.TabIndex = 8;
            bt_Save.Text = "SAVE";
            bt_Save.UseVisualStyleBackColor = true;
            bt_Save.Click += bt_Save_Click;
            // 
            // lbTitle_SuperPath
            // 
            lbTitle_SuperPath.AutoSize = true;
            lbTitle_SuperPath.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lbTitle_SuperPath.Location = new System.Drawing.Point(16, 3);
            lbTitle_SuperPath.Name = "lbTitle_SuperPath";
            lbTitle_SuperPath.Size = new System.Drawing.Size(130, 28);
            lbTitle_SuperPath.TabIndex = 7;
            lbTitle_SuperPath.Text = "MAIN PATH :";
            // 
            // tb_SuperPath
            // 
            tb_SuperPath.Location = new System.Drawing.Point(153, 7);
            tb_SuperPath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tb_SuperPath.Name = "tb_SuperPath";
            tb_SuperPath.Size = new System.Drawing.Size(430, 27);
            tb_SuperPath.TabIndex = 6;
            tb_SuperPath.TabStop = false;
            tb_SuperPath.Click += tb_SuperPath_Click;
            // 
            // lbTitle_LogPath
            // 
            lbTitle_LogPath.AutoSize = true;
            lbTitle_LogPath.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lbTitle_LogPath.Location = new System.Drawing.Point(29, 38);
            lbTitle_LogPath.Name = "lbTitle_LogPath";
            lbTitle_LogPath.Size = new System.Drawing.Size(118, 28);
            lbTitle_LogPath.TabIndex = 10;
            lbTitle_LogPath.Text = "LOG PATH :";
            // 
            // tb_LogPath
            // 
            tb_LogPath.Location = new System.Drawing.Point(153, 42);
            tb_LogPath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tb_LogPath.Name = "tb_LogPath";
            tb_LogPath.Size = new System.Drawing.Size(430, 27);
            tb_LogPath.TabIndex = 9;
            tb_LogPath.TabStop = false;
            tb_LogPath.Click += tb_LogPath_Click;
            // 
            // lbTitle_IntervalTime
            // 
            lbTitle_IntervalTime.AutoSize = true;
            lbTitle_IntervalTime.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lbTitle_IntervalTime.Location = new System.Drawing.Point(35, 73);
            lbTitle_IntervalTime.Name = "lbTitle_IntervalTime";
            lbTitle_IntervalTime.Size = new System.Drawing.Size(112, 28);
            lbTitle_IntervalTime.TabIndex = 12;
            lbTitle_IntervalTime.Text = "INTERVAL :";
            // 
            // tb_IntervalTime
            // 
            tb_IntervalTime.Location = new System.Drawing.Point(153, 77);
            tb_IntervalTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tb_IntervalTime.Name = "tb_IntervalTime";
            tb_IntervalTime.Size = new System.Drawing.Size(37, 27);
            tb_IntervalTime.TabIndex = 11;
            tb_IntervalTime.TabStop = false;
            tb_IntervalTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbTitle_StandardDay
            // 
            lbTitle_StandardDay.AutoSize = true;
            lbTitle_StandardDay.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lbTitle_StandardDay.Location = new System.Drawing.Point(13, 108);
            lbTitle_StandardDay.Name = "lbTitle_StandardDay";
            lbTitle_StandardDay.Size = new System.Drawing.Size(133, 28);
            lbTitle_StandardDay.TabIndex = 14;
            lbTitle_StandardDay.Text = "DELETE DAY :";
            // 
            // tb_StandardDay
            // 
            tb_StandardDay.Location = new System.Drawing.Point(153, 112);
            tb_StandardDay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tb_StandardDay.Name = "tb_StandardDay";
            tb_StandardDay.Size = new System.Drawing.Size(37, 27);
            tb_StandardDay.TabIndex = 13;
            tb_StandardDay.TabStop = false;
            tb_StandardDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbTitle_Hours
            // 
            lbTitle_Hours.AutoSize = true;
            lbTitle_Hours.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lbTitle_Hours.Location = new System.Drawing.Point(190, 77);
            lbTitle_Hours.Name = "lbTitle_Hours";
            lbTitle_Hours.Size = new System.Drawing.Size(66, 28);
            lbTitle_Hours.TabIndex = 15;
            lbTitle_Hours.Text = "Hours";
            // 
            // lbTitle_Days
            // 
            lbTitle_Days.AutoSize = true;
            lbTitle_Days.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lbTitle_Days.Location = new System.Drawing.Point(190, 111);
            lbTitle_Days.Name = "lbTitle_Days";
            lbTitle_Days.Size = new System.Drawing.Size(106, 28);
            lbTitle_Days.TabIndex = 16;
            lbTitle_Days.Text = "Days After";
            // 
            // SettingForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(590, 146);
            ControlBox = false;
            Controls.Add(bt_Save);
            Controls.Add(lbTitle_StandardDay);
            Controls.Add(tb_StandardDay);
            Controls.Add(lbTitle_Days);
            Controls.Add(lbTitle_IntervalTime);
            Controls.Add(tb_IntervalTime);
            Controls.Add(lbTitle_Hours);
            Controls.Add(lbTitle_LogPath);
            Controls.Add(tb_LogPath);
            Controls.Add(lbTitle_SuperPath);
            Controls.Add(tb_SuperPath);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "SettingForm";
            Text = "LogPathSetting";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button bt_Save;
        private System.Windows.Forms.Label lbTitle_SuperPath;
        private System.Windows.Forms.TextBox tb_SuperPath;
        private System.Windows.Forms.Label lbTitle_LogPath;
        private System.Windows.Forms.TextBox tb_LogPath;
        private System.Windows.Forms.Label lbTitle_IntervalTime;
        private System.Windows.Forms.TextBox tb_IntervalTime;
        private System.Windows.Forms.Label lbTitle_StandardDay;
        private System.Windows.Forms.TextBox tb_StandardDay;
        private System.Windows.Forms.Label lbTitle_Hours;
        private System.Windows.Forms.Label lbTitle_Days;
    }
}