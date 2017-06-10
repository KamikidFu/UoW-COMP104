namespace Task2
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
            this.pictureBoxBowl_ = new System.Windows.Forms.PictureBox();
            this.textBoxNumSeeds_ = new System.Windows.Forms.TextBox();
            this.drawButton_ = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBowl_)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxBowl_
            // 
            this.pictureBoxBowl_.Location = new System.Drawing.Point(12, 13);
            this.pictureBoxBowl_.Name = "pictureBoxBowl_";
            this.pictureBoxBowl_.Size = new System.Drawing.Size(215, 117);
            this.pictureBoxBowl_.TabIndex = 0;
            this.pictureBoxBowl_.TabStop = false;
            // 
            // textBoxNumSeeds_
            // 
            this.textBoxNumSeeds_.Location = new System.Drawing.Point(12, 139);
            this.textBoxNumSeeds_.Name = "textBoxNumSeeds_";
            this.textBoxNumSeeds_.Size = new System.Drawing.Size(134, 20);
            this.textBoxNumSeeds_.TabIndex = 1;
            // 
            // drawButton_
            // 
            this.drawButton_.Location = new System.Drawing.Point(152, 136);
            this.drawButton_.Name = "drawButton_";
            this.drawButton_.Size = new System.Drawing.Size(75, 25);
            this.drawButton_.TabIndex = 2;
            this.drawButton_.Text = "Draw";
            this.drawButton_.UseVisualStyleBackColor = true;
            this.drawButton_.Click += new System.EventHandler(this.drawButton__Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 166);
            this.Controls.Add(this.drawButton_);
            this.Controls.Add(this.textBoxNumSeeds_);
            this.Controls.Add(this.pictureBoxBowl_);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBowl_)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxBowl_;
        private System.Windows.Forms.TextBox textBoxNumSeeds_;
        private System.Windows.Forms.Button drawButton_;
    }
}

