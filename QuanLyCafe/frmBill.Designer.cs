namespace QuanLyCafe
{
    partial class frmBill
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBill));
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdoDateCheckIn = new System.Windows.Forms.RadioButton();
            this.rdoDateCheckOut = new System.Windows.Forms.RadioButton();
            this.dtpTDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvBill = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateCheckIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateCheckOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiscountPercent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvBillInfo = new System.Windows.Forms.DataGridView();
            this.NameFood = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvBillInfoAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPrint = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBill)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.rdoDateCheckIn);
            this.panel1.Controls.Add(this.rdoDateCheckOut);
            this.panel1.Controls.Add(this.dtpTDate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtpFDate);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1182, 44);
            this.panel1.TabIndex = 0;
            // 
            // rdoDateCheckIn
            // 
            this.rdoDateCheckIn.AutoSize = true;
            this.rdoDateCheckIn.Checked = true;
            this.rdoDateCheckIn.Location = new System.Drawing.Point(90, 10);
            this.rdoDateCheckIn.Name = "rdoDateCheckIn";
            this.rdoDateCheckIn.Size = new System.Drawing.Size(92, 22);
            this.rdoDateCheckIn.TabIndex = 2;
            this.rdoDateCheckIn.TabStop = true;
            this.rdoDateCheckIn.Text = "Ngày vào";
            this.rdoDateCheckIn.UseVisualStyleBackColor = true;
            this.rdoDateCheckIn.CheckedChanged += new System.EventHandler(this.rdoDateCheckIn_CheckedChanged);
            // 
            // rdoDateCheckOut
            // 
            this.rdoDateCheckOut.AutoSize = true;
            this.rdoDateCheckOut.Location = new System.Drawing.Point(188, 10);
            this.rdoDateCheckOut.Name = "rdoDateCheckOut";
            this.rdoDateCheckOut.Size = new System.Drawing.Size(81, 22);
            this.rdoDateCheckOut.TabIndex = 2;
            this.rdoDateCheckOut.Text = "Ngày ra";
            this.rdoDateCheckOut.UseVisualStyleBackColor = true;
            this.rdoDateCheckOut.CheckedChanged += new System.EventHandler(this.rdoDateCheckOut_CheckedChanged);
            // 
            // dtpTDate
            // 
            this.dtpTDate.CustomFormat = "dd/MM/yyyy";
            this.dtpTDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTDate.Location = new System.Drawing.Point(595, 8);
            this.dtpTDate.Name = "dtpTDate";
            this.dtpTDate.Size = new System.Drawing.Size(122, 26);
            this.dtpTDate.TabIndex = 1;
            this.dtpTDate.ValueChanged += new System.EventHandler(this.dtpTDate_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(518, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Đến ngày";
            // 
            // dtpFDate
            // 
            this.dtpFDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFDate.Location = new System.Drawing.Point(367, 8);
            this.dtpFDate.Name = "dtpFDate";
            this.dtpFDate.Size = new System.Drawing.Size(122, 26);
            this.dtpFDate.TabIndex = 0;
            this.dtpFDate.ValueChanged += new System.EventHandler(this.dtpFDate_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "Xem theo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(297, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày";
            // 
            // dgvBill
            // 
            this.dgvBill.AllowUserToAddRows = false;
            this.dgvBill.AllowUserToDeleteRows = false;
            this.dgvBill.AllowUserToResizeRows = false;
            this.dgvBill.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvBill.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBill.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.DateCheckIn,
            this.DateCheckOut,
            this.Amount,
            this.DiscountPercent,
            this.Total});
            this.dgvBill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBill.Location = new System.Drawing.Point(0, 0);
            this.dgvBill.MultiSelect = false;
            this.dgvBill.Name = "dgvBill";
            this.dgvBill.ReadOnly = true;
            this.dgvBill.RowHeadersWidth = 30;
            this.dgvBill.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvBill.RowTemplate.Height = 24;
            this.dgvBill.Size = new System.Drawing.Size(782, 629);
            this.dgvBill.TabIndex = 0;
            this.dgvBill.SelectionChanged += new System.EventHandler(this.dgvBill_SelectionChanged);
            // 
            // Id
            // 
            this.Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Hóa đơn";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // DateCheckIn
            // 
            this.DateCheckIn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DateCheckIn.DataPropertyName = "date_check_in";
            dataGridViewCellStyle1.Format = "dd/MM/yyyy hh:mm:ss";
            this.DateCheckIn.DefaultCellStyle = dataGridViewCellStyle1;
            this.DateCheckIn.HeaderText = "Ngày vào";
            this.DateCheckIn.MinimumWidth = 6;
            this.DateCheckIn.Name = "DateCheckIn";
            this.DateCheckIn.ReadOnly = true;
            // 
            // DateCheckOut
            // 
            this.DateCheckOut.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DateCheckOut.DataPropertyName = "date_check_out";
            dataGridViewCellStyle2.Format = "dd/MM/yyyy hh:mm:ss";
            this.DateCheckOut.DefaultCellStyle = dataGridViewCellStyle2;
            this.DateCheckOut.HeaderText = "Ngày ra";
            this.DateCheckOut.MinimumWidth = 6;
            this.DateCheckOut.Name = "DateCheckOut";
            this.DateCheckOut.ReadOnly = true;
            this.DateCheckOut.Width = 89;
            // 
            // Amount
            // 
            this.Amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Amount.DataPropertyName = "amount";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "c0";
            this.Amount.DefaultCellStyle = dataGridViewCellStyle3;
            this.Amount.HeaderText = "Tổng tiền";
            this.Amount.MinimumWidth = 6;
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            this.Amount.Width = 99;
            // 
            // DiscountPercent
            // 
            this.DiscountPercent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DiscountPercent.DataPropertyName = "discount_percent";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DiscountPercent.DefaultCellStyle = dataGridViewCellStyle4;
            this.DiscountPercent.HeaderText = "Giảm giá";
            this.DiscountPercent.MinimumWidth = 6;
            this.DiscountPercent.Name = "DiscountPercent";
            this.DiscountPercent.ReadOnly = true;
            this.DiscountPercent.Width = 93;
            // 
            // Total
            // 
            this.Total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Total.DataPropertyName = "total";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "c0";
            this.Total.DefaultCellStyle = dataGridViewCellStyle5;
            this.Total.HeaderText = "Tổng cộng";
            this.Total.MinimumWidth = 6;
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            this.Total.Width = 107;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvBill);
            this.panel2.Controls.Add(this.dgvBillInfo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 44);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1182, 629);
            this.panel2.TabIndex = 1;
            // 
            // dgvBillInfo
            // 
            this.dgvBillInfo.AllowUserToAddRows = false;
            this.dgvBillInfo.AllowUserToDeleteRows = false;
            this.dgvBillInfo.AllowUserToResizeRows = false;
            this.dgvBillInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvBillInfo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvBillInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBillInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBillInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameFood,
            this.Quantity,
            this.Price,
            this.dgvBillInfoAmount});
            this.dgvBillInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.dgvBillInfo.Location = new System.Drawing.Point(782, 0);
            this.dgvBillInfo.MultiSelect = false;
            this.dgvBillInfo.Name = "dgvBillInfo";
            this.dgvBillInfo.ReadOnly = true;
            this.dgvBillInfo.RowHeadersVisible = false;
            this.dgvBillInfo.RowHeadersWidth = 51;
            this.dgvBillInfo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvBillInfo.RowTemplate.Height = 24;
            this.dgvBillInfo.Size = new System.Drawing.Size(400, 629);
            this.dgvBillInfo.TabIndex = 1;
            // 
            // NameFood
            // 
            this.NameFood.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NameFood.DataPropertyName = "name_food";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.NameFood.DefaultCellStyle = dataGridViewCellStyle6;
            this.NameFood.HeaderText = "Tên món";
            this.NameFood.MinimumWidth = 6;
            this.NameFood.Name = "NameFood";
            this.NameFood.ReadOnly = true;
            // 
            // Quantity
            // 
            this.Quantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Quantity.DataPropertyName = "quantity";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Quantity.DefaultCellStyle = dataGridViewCellStyle7;
            this.Quantity.HeaderText = "Số lượng";
            this.Quantity.MinimumWidth = 6;
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            this.Quantity.Width = 93;
            // 
            // Price
            // 
            this.Price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Price.DataPropertyName = "price";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "c0";
            this.Price.DefaultCellStyle = dataGridViewCellStyle8;
            this.Price.HeaderText = "Giá";
            this.Price.MinimumWidth = 6;
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Width = 57;
            // 
            // dgvBillInfoAmount
            // 
            this.dgvBillInfoAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvBillInfoAmount.DataPropertyName = "amount";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "c0";
            this.dgvBillInfoAmount.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvBillInfoAmount.HeaderText = "Tổng tiền";
            this.dgvBillInfoAmount.MinimumWidth = 6;
            this.dgvBillInfoAmount.Name = "dgvBillInfoAmount";
            this.dgvBillInfoAmount.ReadOnly = true;
            this.dgvBillInfoAmount.Width = 99;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(739, 8);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(115, 26);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.Text = "In hóa đơn";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // frmBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1182, 673);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBill";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Danh sách hóa đơn";
            this.Load += new System.EventHandler(this.frmBill_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBill)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvBill;
        private System.Windows.Forms.DateTimePicker dtpTDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvBillInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameFood;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvBillInfoAmount;
        private System.Windows.Forms.RadioButton rdoDateCheckIn;
        private System.Windows.Forms.RadioButton rdoDateCheckOut;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateCheckIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateCheckOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiscountPercent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.Button btnPrint;
    }
}