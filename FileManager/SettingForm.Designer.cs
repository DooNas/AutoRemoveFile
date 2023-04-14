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
            Logbt_Check = new System.Windows.Forms.Button();
            lb_Path = new System.Windows.Forms.Label();
            Logtb_Path = new System.Windows.Forms.TextBox();
            SuspendLayout();
            // 
            // Logbt_Check
            // 
            Logbt_Check.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            Logbt_Check.Location = new System.Drawing.Point(504, 16);
            Logbt_Check.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Logbt_Check.Name = "Logbt_Check";
            Logbt_Check.Size = new System.Drawing.Size(109, 33);
            Logbt_Check.TabIndex = 8;
            Logbt_Check.Text = "CHECK";
            Logbt_Check.UseVisualStyleBackColor = true;
            // 
            // lb_Path
            // 
            lb_Path.AutoSize = true;
            lb_Path.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lb_Path.Location = new System.Drawing.Point(16, 20);
            lb_Path.Name = "lb_Path";
            lb_Path.Size = new System.Drawing.Size(71, 20);
            lb_Path.TabIndex = 7;
            lb_Path.Text = "PATH :";
            // 
            // Logtb_Path
            // 
            Logtb_Path.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            Logtb_Path.Location = new System.Drawing.Point(98, 16);
            Logtb_Path.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Logtb_Path.Name = "Logtb_Path";
            Logtb_Path.Size = new System.Drawing.Size(399, 27);
            Logtb_Path.TabIndex = 6;
            Logtb_Path.TabStop = false;
            Logtb_Path.Text = "D:\\DAT";
            // 
            // SettingForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ClientSize = new System.Drawing.Size(627, 60);
            Controls.Add(Logbt_Check);
            Controls.Add(lb_Path);
            Controls.Add(Logtb_Path);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "SettingForm";
            Text = "LogPathSetting";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button Logbt_Check;
        private System.Windows.Forms.Label lb_Path;
        private System.Windows.Forms.TextBox Logtb_Path;
    }
}