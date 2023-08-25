namespace CPSTester
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.CPSBtn = new System.Windows.Forms.Button();
            this.comboBoxDuration = new System.Windows.Forms.ComboBox();
            this.lblCPS = new System.Windows.Forms.Label();
            this.lblClickCount = new System.Windows.Forms.Label();
            this.lblRemainingTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CPSBtn
            // 
            this.CPSBtn.Font = new System.Drawing.Font("微软雅黑", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CPSBtn.Location = new System.Drawing.Point(6, 64);
            this.CPSBtn.Name = "CPSBtn";
            this.CPSBtn.Size = new System.Drawing.Size(791, 384);
            this.CPSBtn.TabIndex = 0;
            this.CPSBtn.Text = "button1";
            this.CPSBtn.UseVisualStyleBackColor = true;
            this.CPSBtn.Click += new System.EventHandler(this.CPSbtn_Click);
            // 
            // comboBoxDuration
            // 
            this.comboBoxDuration.FormattingEnabled = true;
            this.comboBoxDuration.Location = new System.Drawing.Point(456, 16);
            this.comboBoxDuration.Name = "comboBoxDuration";
            this.comboBoxDuration.Size = new System.Drawing.Size(323, 20);
            this.comboBoxDuration.TabIndex = 1;
            // 
            // lblCPS
            // 
            this.lblCPS.AutoSize = true;
            this.lblCPS.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCPS.Location = new System.Drawing.Point(21, 16);
            this.lblCPS.Name = "lblCPS";
            this.lblCPS.Size = new System.Drawing.Size(55, 21);
            this.lblCPS.TabIndex = 2;
            this.lblCPS.Text = "label1";
            this.lblCPS.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblClickCount
            // 
            this.lblClickCount.AutoSize = true;
            this.lblClickCount.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblClickCount.Location = new System.Drawing.Point(144, 16);
            this.lblClickCount.Name = "lblClickCount";
            this.lblClickCount.Size = new System.Drawing.Size(55, 21);
            this.lblClickCount.TabIndex = 3;
            this.lblClickCount.Text = "label1";
            // 
            // lblRemainingTime
            // 
            this.lblRemainingTime.AutoSize = true;
            this.lblRemainingTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRemainingTime.Location = new System.Drawing.Point(283, 16);
            this.lblRemainingTime.Name = "lblRemainingTime";
            this.lblRemainingTime.Size = new System.Drawing.Size(55, 21);
            this.lblRemainingTime.TabIndex = 4;
            this.lblRemainingTime.Text = "label2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblRemainingTime);
            this.Controls.Add(this.lblClickCount);
            this.Controls.Add(this.lblCPS);
            this.Controls.Add(this.comboBoxDuration);
            this.Controls.Add(this.CPSBtn);
            this.Name = "Form1";
            this.Text = "CPSTester";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CPSBtn;
        private System.Windows.Forms.ComboBox comboBoxDuration;
        private System.Windows.Forms.Label lblCPS;
        private System.Windows.Forms.Label lblClickCount;
        private System.Windows.Forms.Label lblRemainingTime;
    }
}

