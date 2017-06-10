namespace PracP4
{
  partial class GardenDesigner
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
      if (disposing && (components != null)) {
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
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.priceTextBox_ = new System.Windows.Forms.TextBox();
      this.sizeTextBox_ = new System.Windows.Forms.TextBox();
      this.pictureBoxGarden_ = new System.Windows.Forms.PictureBox();
      this.nameLabel_ = new System.Windows.Forms.Label();
      this.sizeLabel_ = new System.Windows.Forms.Label();
      this.priceLabel_ = new System.Windows.Forms.Label();
      this.nameTextBox_ = new System.Windows.Forms.TextBox();
      this.finishButton_ = new System.Windows.Forms.Button();
      this.tableLayoutPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGarden_)).BeginInit();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 3;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
      this.tableLayoutPanel1.Controls.Add(this.priceTextBox_, 2, 2);
      this.tableLayoutPanel1.Controls.Add(this.sizeTextBox_, 2, 1);
      this.tableLayoutPanel1.Controls.Add(this.pictureBoxGarden_, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.nameLabel_, 1, 0);
      this.tableLayoutPanel1.Controls.Add(this.sizeLabel_, 1, 1);
      this.tableLayoutPanel1.Controls.Add(this.priceLabel_, 1, 2);
      this.tableLayoutPanel1.Controls.Add(this.nameTextBox_, 2, 0);
      this.tableLayoutPanel1.Controls.Add(this.finishButton_, 2, 4);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 5;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(689, 385);
      this.tableLayoutPanel1.TabIndex = 0;
      // 
      // priceTextBox_
      // 
      this.priceTextBox_.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.priceTextBox_.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.priceTextBox_.Location = new System.Drawing.Point(492, 202);
      this.priceTextBox_.Name = "priceTextBox_";
      this.priceTextBox_.Size = new System.Drawing.Size(194, 26);
      this.priceTextBox_.TabIndex = 6;
      this.priceTextBox_.Text = "1.50";
      // 
      // sizeTextBox_
      // 
      this.sizeTextBox_.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.sizeTextBox_.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.sizeTextBox_.Location = new System.Drawing.Point(492, 125);
      this.sizeTextBox_.Name = "sizeTextBox_";
      this.sizeTextBox_.Size = new System.Drawing.Size(194, 26);
      this.sizeTextBox_.TabIndex = 5;
      this.sizeTextBox_.Text = "8";
      // 
      // pictureBoxGarden_
      // 
      this.pictureBoxGarden_.BackColor = System.Drawing.SystemColors.Window;
      this.pictureBoxGarden_.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pictureBoxGarden_.Location = new System.Drawing.Point(3, 3);
      this.pictureBoxGarden_.Name = "pictureBoxGarden_";
      this.tableLayoutPanel1.SetRowSpan(this.pictureBoxGarden_, 5);
      this.pictureBoxGarden_.Size = new System.Drawing.Size(417, 379);
      this.pictureBoxGarden_.TabIndex = 0;
      this.pictureBoxGarden_.TabStop = false;
      this.pictureBoxGarden_.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxGarden__Paint);
      this.pictureBoxGarden_.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxGarden__MouseClick);
      // 
      // nameLabel_
      // 
      this.nameLabel_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.nameLabel_.AutoSize = true;
      this.nameLabel_.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.nameLabel_.Location = new System.Drawing.Point(426, 51);
      this.nameLabel_.Name = "nameLabel_";
      this.nameLabel_.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
      this.nameLabel_.Size = new System.Drawing.Size(60, 26);
      this.nameLabel_.TabIndex = 1;
      this.nameLabel_.Text = "Name:";
      // 
      // sizeLabel_
      // 
      this.sizeLabel_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.sizeLabel_.AutoSize = true;
      this.sizeLabel_.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.sizeLabel_.Location = new System.Drawing.Point(426, 128);
      this.sizeLabel_.Name = "sizeLabel_";
      this.sizeLabel_.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
      this.sizeLabel_.Size = new System.Drawing.Size(49, 26);
      this.sizeLabel_.TabIndex = 2;
      this.sizeLabel_.Text = "Size:";
      // 
      // priceLabel_
      // 
      this.priceLabel_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.priceLabel_.AutoSize = true;
      this.priceLabel_.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.priceLabel_.Location = new System.Drawing.Point(426, 205);
      this.priceLabel_.Name = "priceLabel_";
      this.priceLabel_.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
      this.priceLabel_.Size = new System.Drawing.Size(54, 26);
      this.priceLabel_.TabIndex = 3;
      this.priceLabel_.Text = "Price:";
      this.priceLabel_.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
      this.priceLabel_.UseMnemonic = false;
      // 
      // nameTextBox_
      // 
      this.nameTextBox_.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.nameTextBox_.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.nameTextBox_.Location = new System.Drawing.Point(492, 48);
      this.nameTextBox_.Name = "nameTextBox_";
      this.nameTextBox_.Size = new System.Drawing.Size(194, 26);
      this.nameTextBox_.TabIndex = 4;
      this.nameTextBox_.Text = "Daisy";
      // 
      // finishButton_
      // 
      this.finishButton_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.finishButton_.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.finishButton_.Location = new System.Drawing.Point(492, 351);
      this.finishButton_.Name = "finishButton_";
      this.finishButton_.Size = new System.Drawing.Size(194, 31);
      this.finishButton_.TabIndex = 7;
      this.finishButton_.Text = "Finish";
      this.finishButton_.UseVisualStyleBackColor = true;
      // 
      // GardenDesigner
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(689, 385);
      this.Controls.Add(this.tableLayoutPanel1);
      this.Name = "GardenDesigner";
      this.Text = "Garden Designer";
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGarden_)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.TextBox priceTextBox_;
    private System.Windows.Forms.TextBox sizeTextBox_;
    private System.Windows.Forms.PictureBox pictureBoxGarden_;
    private System.Windows.Forms.Label nameLabel_;
    private System.Windows.Forms.Label sizeLabel_;
    private System.Windows.Forms.Label priceLabel_;
    private System.Windows.Forms.TextBox nameTextBox_;
    private System.Windows.Forms.Button finishButton_;
  }
}

