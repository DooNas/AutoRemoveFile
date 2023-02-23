namespace AutoRemoveFile
{
    partial class LogForm
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
            this.Logbt_Check = new System.Windows.Forms.Button();
            this.lb_Path = new System.Windows.Forms.Label();
            this.Logtb_Path = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Logbt_Check
            // 
            this.Logbt_Check.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Logbt_Check.Location = new System.Drawing.Point(448, 12);
            this.Logbt_Check.Name = "Logbt_Check";
            this.Logbt_Check.Size = new System.Drawing.Size(97, 25);
            this.Logbt_Check.TabIndex = 8;
            this.Logbt_Check.Text = "CHECK";
            this.Logbt_Check.UseVisualStyleBackColor = true;
            this.Logbt_Check.Click += new System.EventHandler(this.Logbt_Check_Click);
            // 
            // lb_Path
            // 
            this.lb_Path.AutoSize = true;
            this.lb_Path.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_Path.Location = new System.Drawing.Point(14, 15);
            this.lb_Path.Name = "lb_Path";
            this.lb_Path.Size = new System.Drawing.Size(71, 20);
            this.lb_Path.TabIndex = 7;
            this.lb_Path.Text = "PATH :";
            // 
            // Logtb_Path
            // 
            this.Logtb_Path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Logtb_Path.Location = new System.Drawing.Point(87, 12);
            this.Logtb_Path.Name = "Logtb_Path";
            this.Logtb_Path.Size = new System.Drawing.Size(355, 25);
            this.Logtb_Path.TabIndex = 6;
            this.Logtb_Path.Text = "D:\\DAT";
            this.Logtb_Path.Click += new System.EventHandler(this.Logtb_Path_Click);
            // 
            // LogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(557, 45);
            this.Controls.Add(this.Logbt_Check);
            this.Controls.Add(this.lb_Path);
            this.Controls.Add(this.Logtb_Path);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "LogForm";
            this.Text = "LogForm";
            this.Load += new System.EventHandler(this.LogForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Logbt_Check;
        private System.Windows.Forms.Label lb_Path;
        private System.Windows.Forms.TextBox Logtb_Path;
    }
}