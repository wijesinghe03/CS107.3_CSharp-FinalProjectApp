namespace horizon_travels_and_tours
{
    partial class Billingdatatable
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox_searchbill = new System.Windows.Forms.TextBox();
            this.button_searchbill = new System.Windows.Forms.Button();
            this.DataGridView_bill = new Guna.UI2.WinForms.Guna2DataGridView();
            this.panel6 = new System.Windows.Forms.Panel();
            this.textBox_bid = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button_print = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_bill)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Indigo;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(917, 45);
            this.panel1.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MV Boli", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(344, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Billing Data Table";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::horizon_travels_and_tours.Properties.Resources.IMG_95571;
            this.pictureBox1.Location = new System.Drawing.Point(280, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(58, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // textBox_searchbill
            // 
            this.textBox_searchbill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_searchbill.BackColor = System.Drawing.Color.DarkGray;
            this.textBox_searchbill.Location = new System.Drawing.Point(610, 62);
            this.textBox_searchbill.Name = "textBox_searchbill";
            this.textBox_searchbill.Size = new System.Drawing.Size(166, 26);
            this.textBox_searchbill.TabIndex = 83;
            // 
            // button_searchbill
            // 
            this.button_searchbill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_searchbill.BackColor = System.Drawing.Color.Blue;
            this.button_searchbill.FlatAppearance.BorderSize = 0;
            this.button_searchbill.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button_searchbill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_searchbill.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_searchbill.ForeColor = System.Drawing.Color.White;
            this.button_searchbill.Location = new System.Drawing.Point(796, 55);
            this.button_searchbill.Name = "button_searchbill";
            this.button_searchbill.Size = new System.Drawing.Size(111, 33);
            this.button_searchbill.TabIndex = 82;
            this.button_searchbill.Text = "Search";
            this.button_searchbill.UseVisualStyleBackColor = false;
            this.button_searchbill.Click += new System.EventHandler(this.button_searchbill_Click);
            // 
            // DataGridView_bill
            // 
            this.DataGridView_bill.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.DataGridView_bill.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridView_bill.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridView_bill.BackgroundColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView_bill.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridView_bill.ColumnHeadersHeight = 24;
            this.DataGridView_bill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridView_bill.DefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridView_bill.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DataGridView_bill.Location = new System.Drawing.Point(0, 104);
            this.DataGridView_bill.Name = "DataGridView_bill";
            this.DataGridView_bill.RowHeadersVisible = false;
            this.DataGridView_bill.RowHeadersWidth = 30;
            this.DataGridView_bill.RowTemplate.Height = 80;
            this.DataGridView_bill.Size = new System.Drawing.Size(917, 427);
            this.DataGridView_bill.TabIndex = 84;
            this.DataGridView_bill.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.DataGridView_bill.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DataGridView_bill.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DataGridView_bill.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.DataGridView_bill.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.DataGridView_bill.ThemeStyle.BackColor = System.Drawing.Color.DarkGray;
            this.DataGridView_bill.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DataGridView_bill.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.DataGridView_bill.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DataGridView_bill.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataGridView_bill.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DataGridView_bill.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DataGridView_bill.ThemeStyle.HeaderStyle.Height = 24;
            this.DataGridView_bill.ThemeStyle.ReadOnly = false;
            this.DataGridView_bill.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.DataGridView_bill.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DataGridView_bill.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataGridView_bill.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.DataGridView_bill.ThemeStyle.RowsStyle.Height = 80;
            this.DataGridView_bill.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DataGridView_bill.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // panel6
            // 
            this.panel6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel6.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel6.Location = new System.Drawing.Point(336, 574);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(237, 1);
            this.panel6.TabIndex = 87;
            // 
            // textBox_bid
            // 
            this.textBox_bid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_bid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_bid.Location = new System.Drawing.Point(333, 556);
            this.textBox_bid.Name = "textBox_bid";
            this.textBox_bid.Size = new System.Drawing.Size(237, 19);
            this.textBox_bid.TabIndex = 86;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Indigo;
            this.label5.Location = new System.Drawing.Point(274, 556);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 19);
            this.label5.TabIndex = 85;
            this.label5.Text = "Id:";
            // 
            // button_print
            // 
            this.button_print.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_print.BackColor = System.Drawing.Color.White;
            this.button_print.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button_print.FlatAppearance.BorderSize = 10;
            this.button_print.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button_print.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_print.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_print.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button_print.Location = new System.Drawing.Point(386, 587);
            this.button_print.Name = "button_print";
            this.button_print.Size = new System.Drawing.Size(111, 33);
            this.button_print.TabIndex = 88;
            this.button_print.Text = "Print";
            this.button_print.UseVisualStyleBackColor = false;
            this.button_print.Click += new System.EventHandler(this.button_print_Click);
            // 
            // Billingdatatable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(917, 632);
            this.Controls.Add(this.button_print);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.textBox_bid);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.DataGridView_bill);
            this.Controls.Add(this.textBox_searchbill);
            this.Controls.Add(this.button_searchbill);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Billingdatatable";
            this.Text = "Billingdatatable";
            this.Load += new System.EventHandler(this.Billingdatatable_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_bill)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox_searchbill;
        private System.Windows.Forms.Button button_searchbill;
        private Guna.UI2.WinForms.Guna2DataGridView DataGridView_bill;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox textBox_bid;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_print;
    }
}