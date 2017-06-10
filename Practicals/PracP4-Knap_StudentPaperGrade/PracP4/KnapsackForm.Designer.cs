namespace PracP4
{
  partial class KnapsackForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel_ = new System.Windows.Forms.TableLayoutPanel();
            this.packedItemsLabel_ = new System.Windows.Forms.Label();
            this.containersLabel_ = new System.Windows.Forms.Label();
            this.unpackedItemsLabel_ = new System.Windows.Forms.Label();
            this.packedWeightNameLabel_ = new System.Windows.Forms.Label();
            this.packedVolumeNameLabel_ = new System.Windows.Forms.Label();
            this.packedValueNameLabel_ = new System.Windows.Forms.Label();
            this.packedWeightLabel_ = new System.Windows.Forms.Label();
            this.packedVolumeLabel_ = new System.Windows.Forms.Label();
            this.packedValueLabel_ = new System.Windows.Forms.Label();
            this.openButton_ = new System.Windows.Forms.Button();
            this.addButton_ = new System.Windows.Forms.Button();
            this.removeButton_ = new System.Windows.Forms.Button();
            this.dataGridView1_unpackedItems = new System.Windows.Forms.DataGridView();
            this.dataGridView2_containers = new System.Windows.Forms.DataGridView();
            this.dataGridView3_packedItems = new System.Windows.Forms.DataGridView();
            this.button_autoPack = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel_.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1_unpackedItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2_containers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3_packedItems)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel_
            // 
            this.tableLayoutPanel_.ColumnCount = 6;
            this.tableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel_.Controls.Add(this.packedItemsLabel_, 4, 0);
            this.tableLayoutPanel_.Controls.Add(this.containersLabel_, 2, 0);
            this.tableLayoutPanel_.Controls.Add(this.unpackedItemsLabel_, 0, 0);
            this.tableLayoutPanel_.Controls.Add(this.packedWeightNameLabel_, 0, 2);
            this.tableLayoutPanel_.Controls.Add(this.packedVolumeNameLabel_, 2, 2);
            this.tableLayoutPanel_.Controls.Add(this.packedValueNameLabel_, 4, 2);
            this.tableLayoutPanel_.Controls.Add(this.packedWeightLabel_, 1, 2);
            this.tableLayoutPanel_.Controls.Add(this.packedVolumeLabel_, 3, 2);
            this.tableLayoutPanel_.Controls.Add(this.packedValueLabel_, 5, 2);
            this.tableLayoutPanel_.Controls.Add(this.openButton_, 1, 3);
            this.tableLayoutPanel_.Controls.Add(this.addButton_, 2, 3);
            this.tableLayoutPanel_.Controls.Add(this.removeButton_, 3, 3);
            this.tableLayoutPanel_.Controls.Add(this.dataGridView1_unpackedItems, 0, 1);
            this.tableLayoutPanel_.Controls.Add(this.dataGridView2_containers, 2, 1);
            this.tableLayoutPanel_.Controls.Add(this.dataGridView3_packedItems, 4, 1);
            this.tableLayoutPanel_.Controls.Add(this.button_autoPack, 4, 3);
            this.tableLayoutPanel_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_.Name = "tableLayoutPanel_";
            this.tableLayoutPanel_.RowCount = 4;
            this.tableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel_.Size = new System.Drawing.Size(1209, 522);
            this.tableLayoutPanel_.TabIndex = 0;
            // 
            // packedItemsLabel_
            // 
            this.packedItemsLabel_.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.packedItemsLabel_.AutoSize = true;
            this.tableLayoutPanel_.SetColumnSpan(this.packedItemsLabel_, 2);
            this.packedItemsLabel_.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.packedItemsLabel_.Location = new System.Drawing.Point(807, 5);
            this.packedItemsLabel_.Name = "packedItemsLabel_";
            this.packedItemsLabel_.Size = new System.Drawing.Size(116, 20);
            this.packedItemsLabel_.TabIndex = 2;
            this.packedItemsLabel_.Text = "Packed items";
            // 
            // containersLabel_
            // 
            this.containersLabel_.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.containersLabel_.AutoSize = true;
            this.tableLayoutPanel_.SetColumnSpan(this.containersLabel_, 2);
            this.containersLabel_.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.containersLabel_.Location = new System.Drawing.Point(405, 5);
            this.containersLabel_.Name = "containersLabel_";
            this.containersLabel_.Size = new System.Drawing.Size(96, 20);
            this.containersLabel_.TabIndex = 1;
            this.containersLabel_.Text = "Containers";
            // 
            // unpackedItemsLabel_
            // 
            this.unpackedItemsLabel_.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.unpackedItemsLabel_.AutoSize = true;
            this.tableLayoutPanel_.SetColumnSpan(this.unpackedItemsLabel_, 2);
            this.unpackedItemsLabel_.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unpackedItemsLabel_.Location = new System.Drawing.Point(3, 5);
            this.unpackedItemsLabel_.Name = "unpackedItemsLabel_";
            this.unpackedItemsLabel_.Size = new System.Drawing.Size(138, 20);
            this.unpackedItemsLabel_.TabIndex = 0;
            this.unpackedItemsLabel_.Text = "Unpacked items";
            // 
            // packedWeightNameLabel_
            // 
            this.packedWeightNameLabel_.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.packedWeightNameLabel_.AutoSize = true;
            this.packedWeightNameLabel_.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.packedWeightNameLabel_.Location = new System.Drawing.Point(3, 461);
            this.packedWeightNameLabel_.Name = "packedWeightNameLabel_";
            this.packedWeightNameLabel_.Size = new System.Drawing.Size(108, 18);
            this.packedWeightNameLabel_.TabIndex = 3;
            this.packedWeightNameLabel_.Text = "Packed weight:";
            // 
            // packedVolumeNameLabel_
            // 
            this.packedVolumeNameLabel_.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.packedVolumeNameLabel_.AutoSize = true;
            this.packedVolumeNameLabel_.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.packedVolumeNameLabel_.Location = new System.Drawing.Point(405, 461);
            this.packedVolumeNameLabel_.Name = "packedVolumeNameLabel_";
            this.packedVolumeNameLabel_.Size = new System.Drawing.Size(114, 18);
            this.packedVolumeNameLabel_.TabIndex = 4;
            this.packedVolumeNameLabel_.Text = "Packed volume:";
            // 
            // packedValueNameLabel_
            // 
            this.packedValueNameLabel_.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.packedValueNameLabel_.AutoSize = true;
            this.packedValueNameLabel_.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.packedValueNameLabel_.Location = new System.Drawing.Point(807, 461);
            this.packedValueNameLabel_.Name = "packedValueNameLabel_";
            this.packedValueNameLabel_.Size = new System.Drawing.Size(100, 18);
            this.packedValueNameLabel_.TabIndex = 5;
            this.packedValueNameLabel_.Text = "Packed value:";
            // 
            // packedWeightLabel_
            // 
            this.packedWeightLabel_.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.packedWeightLabel_.AutoSize = true;
            this.packedWeightLabel_.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.packedWeightLabel_.Location = new System.Drawing.Point(204, 461);
            this.packedWeightLabel_.Name = "packedWeightLabel_";
            this.packedWeightLabel_.Size = new System.Drawing.Size(64, 18);
            this.packedWeightLabel_.TabIndex = 6;
            this.packedWeightLabel_.Text = "0.000 kg";
            // 
            // packedVolumeLabel_
            // 
            this.packedVolumeLabel_.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.packedVolumeLabel_.AutoSize = true;
            this.packedVolumeLabel_.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.packedVolumeLabel_.Location = new System.Drawing.Point(606, 461);
            this.packedVolumeLabel_.Name = "packedVolumeLabel_";
            this.packedVolumeLabel_.Size = new System.Drawing.Size(49, 18);
            this.packedVolumeLabel_.TabIndex = 7;
            this.packedVolumeLabel_.Text = "0 ccm";
            // 
            // packedValueLabel_
            // 
            this.packedValueLabel_.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.packedValueLabel_.AutoSize = true;
            this.packedValueLabel_.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.packedValueLabel_.Location = new System.Drawing.Point(1008, 461);
            this.packedValueLabel_.Name = "packedValueLabel_";
            this.packedValueLabel_.Size = new System.Drawing.Size(44, 18);
            this.packedValueLabel_.TabIndex = 8;
            this.packedValueLabel_.Text = "$0.00";
            // 
            // openButton_
            // 
            this.openButton_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openButton_.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openButton_.Location = new System.Drawing.Point(204, 488);
            this.openButton_.Name = "openButton_";
            this.openButton_.Size = new System.Drawing.Size(195, 31);
            this.openButton_.TabIndex = 9;
            this.openButton_.Text = "Open";
            this.openButton_.UseVisualStyleBackColor = true;
            this.openButton_.Click += new System.EventHandler(this.openButton__Click);
            // 
            // addButton_
            // 
            this.addButton_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addButton_.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButton_.Location = new System.Drawing.Point(405, 488);
            this.addButton_.Name = "addButton_";
            this.addButton_.Size = new System.Drawing.Size(195, 31);
            this.addButton_.TabIndex = 10;
            this.addButton_.Text = "Add";
            this.addButton_.UseVisualStyleBackColor = true;
            this.addButton_.Click += new System.EventHandler(this.addButton__Click);
            // 
            // removeButton_
            // 
            this.removeButton_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.removeButton_.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeButton_.Location = new System.Drawing.Point(606, 488);
            this.removeButton_.Name = "removeButton_";
            this.removeButton_.Size = new System.Drawing.Size(195, 31);
            this.removeButton_.TabIndex = 11;
            this.removeButton_.Text = "Remove";
            this.removeButton_.UseVisualStyleBackColor = true;
            this.removeButton_.Click += new System.EventHandler(this.removeButton__Click);
            // 
            // dataGridView1_unpackedItems
            // 
            this.dataGridView1_unpackedItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel_.SetColumnSpan(this.dataGridView1_unpackedItems, 2);
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.Format = "N4";
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1_unpackedItems.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1_unpackedItems.Location = new System.Drawing.Point(3, 33);
            this.dataGridView1_unpackedItems.Name = "dataGridView1_unpackedItems";
            this.dataGridView1_unpackedItems.RowTemplate.Height = 23;
            this.dataGridView1_unpackedItems.Size = new System.Drawing.Size(396, 419);
            this.dataGridView1_unpackedItems.TabIndex = 12;
            // 
            // dataGridView2_containers
            // 
            this.dataGridView2_containers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel_.SetColumnSpan(this.dataGridView2_containers, 2);
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Format = "N4";
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2_containers.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView2_containers.Location = new System.Drawing.Point(405, 33);
            this.dataGridView2_containers.Name = "dataGridView2_containers";
            this.dataGridView2_containers.RowTemplate.Height = 23;
            this.dataGridView2_containers.Size = new System.Drawing.Size(396, 419);
            this.dataGridView2_containers.TabIndex = 13;
            this.dataGridView2_containers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_containers_CellClick);
            // 
            // dataGridView3_packedItems
            // 
            this.dataGridView3_packedItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel_.SetColumnSpan(this.dataGridView3_packedItems, 2);
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Format = "N4";
            dataGridViewCellStyle3.NullValue = null;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView3_packedItems.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView3_packedItems.Location = new System.Drawing.Point(807, 33);
            this.dataGridView3_packedItems.Name = "dataGridView3_packedItems";
            this.dataGridView3_packedItems.RowTemplate.Height = 23;
            this.dataGridView3_packedItems.Size = new System.Drawing.Size(399, 419);
            this.dataGridView3_packedItems.TabIndex = 14;
            // 
            // button_autoPack
            // 
            this.button_autoPack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.button_autoPack.ForeColor = System.Drawing.Color.Black;
            this.button_autoPack.Location = new System.Drawing.Point(807, 488);
            this.button_autoPack.Name = "button_autoPack";
            this.button_autoPack.Size = new System.Drawing.Size(195, 31);
            this.button_autoPack.TabIndex = 15;
            this.button_autoPack.Text = "Auto Pack";
            this.button_autoPack.UseVisualStyleBackColor = true;
            this.button_autoPack.Click += new System.EventHandler(this.button_autoPack_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "CSV File";
            // 
            // KnapsackForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 522);
            this.Controls.Add(this.tableLayoutPanel_);
            this.Name = "KnapsackForm";
            this.Text = "Knapsacks";
            this.tableLayoutPanel_.ResumeLayout(false);
            this.tableLayoutPanel_.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1_unpackedItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2_containers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3_packedItems)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_;
    private System.Windows.Forms.Label packedItemsLabel_;
    private System.Windows.Forms.Label containersLabel_;
    private System.Windows.Forms.Label unpackedItemsLabel_;
    private System.Windows.Forms.Label packedWeightNameLabel_;
    private System.Windows.Forms.Label packedVolumeNameLabel_;
    private System.Windows.Forms.Label packedValueNameLabel_;
    private System.Windows.Forms.Label packedWeightLabel_;
    private System.Windows.Forms.Label packedVolumeLabel_;
    private System.Windows.Forms.Label packedValueLabel_;
    private System.Windows.Forms.Button openButton_;
    private System.Windows.Forms.Button addButton_;
    private System.Windows.Forms.Button removeButton_;
        private System.Windows.Forms.DataGridView dataGridView1_unpackedItems;
        private System.Windows.Forms.DataGridView dataGridView2_containers;
        private System.Windows.Forms.DataGridView dataGridView3_packedItems;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button_autoPack;
    }
}

