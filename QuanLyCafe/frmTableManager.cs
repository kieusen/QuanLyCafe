using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using QuanLyCafe.DAO;
using QuanLyCafe.DTO;

namespace QuanLyCafe
{
    public partial class frmTableManager : Form
    {
        private Account _account;
        private int oldQty;

        //public static bool accountChange;        

        private void LoadData()
        {
            try
            {
                LoadTable();
                LoadFood();
                FormatBillInfo();
                LoadBillInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }

        private void LoadMenuStrip()
        {
            adminToolStripMenuItem.Visible = _account.Type == 1;
            adminToolStripMenuItem.Enabled = _account.Type == 1;
        }

        private void LoadStatusBar()
        {
            slbUseName.Text = _account.DisplayName;

            slbDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            slbDateTime.Alignment = ToolStripItemAlignment.Right;
        }

        private void LoadTable()
        {
            flpTable.Controls.Clear();

            foreach (var item in TableFoodDAO.Instance.GetList())
            {
                Button b = new Button() { Size = new Size(70, 70) };
                b.Tag = item;
                b.Cursor = Cursors.Hand;
                b.Click += B_Click;

                FormatTable(b);

                flpTable.Controls.Add(b);
            }

            if (flpTable.Controls.Count > 0)
            {
                flpTable.Controls[0].Select();
                B_Click(flpTable.Controls[0], new EventArgs());
            }
        }

        private void FormatTable(Button btn)
        {
            TableFood table = (btn.Tag) as TableFood;
            btn.Text = table.Name;

            switch (table.Status)
            {
                case 0: // Ban trong
                    btn.BackColor = Color.LightBlue;
                    btn.Text += Environment.NewLine + "Trống";
                    break;
                case 1: // Ban trong
                    btn.BackColor = Color.LightPink;
                    btn.Text += Environment.NewLine + "Có người";
                    break;
            }

            LoadStatusTable(table);
        }

        private void RefreshTable(Button btn, bool isActive = true)
        {
            TableFood table = btn.Tag as TableFood;
            int idTable = table.Id;
            btn.Tag = TableFoodDAO.Instance.GetById(idTable);
            dgvBillInfo.Tag = btn.Tag;

            FormatTable(btn);
            if (isActive)
            {
                btn.BackColor = Color.LightGreen;
                LoadBillInfo();
            }                
        }

        private void LoadFood()
        {
            cbCategory.DataSource = FoodCategoryDAO.Instance.GetList();
            cbCategory.DisplayMember = "Name";
        }

        private void FormatBillInfo()
        {
            dgvBillInfo.EnableHeadersVisualStyles = false;

            foreach (DataGridViewColumn col in dgvBillInfo.Columns)
            {
                col.HeaderCell.Style.Font = new Font("Tahoma", 9, FontStyle.Bold, GraphicsUnit.Point);
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            
            dgvBillInfo.RowsDefaultCellStyle.SelectionBackColor = SystemColors.ActiveCaption;
            dgvBillInfo.RowsDefaultCellStyle.SelectionForeColor = SystemColors.ControlText;
        }
        private void LoadBillInfo()
        {
            if (dgvBillInfo.Tag != null)
            {
                int idTable = (dgvBillInfo.Tag as TableFood).Id;
                List<BillInfo> listInfo = TableFoodDAO.Instance.GetBillInfo(idTable);                
                dgvBillInfo.DataSource = listInfo;

                decimal amount = 0;
                foreach (var item in listInfo)
                {
                    amount += item.Amount;
                }

                lbAmount.Text = amount.ToString("c0");
                lbTotal.Text = (amount - amount * nudDiscount.Value / 100).ToString("c0");

            }
        }

        private void LoadStatusTable(TableFood table)
        {
            bool isNotEmpty = table.Status == 1;

            btnPayment.Enabled = isNotEmpty;
            btnCancel.Enabled = isNotEmpty;

            btnChangeTable.Enabled = isNotEmpty;

            nudDiscount.Value = TableFoodDAO.Instance.GetBill(table.Id).Discount;
            nudDiscount.Enabled = isNotEmpty;
        }

        private Button GetButtonByIdTable(int idTable)
        {
            foreach (var item in flpTable.Controls)
            {
                if (item.GetType() == typeof(Button))
                {
                    Button btn = (Button)item;
                    TableFood table = (btn.Tag as TableFood);

                    if (table.Id == idTable)
                    {
                        return btn;
                    }
                }
            }

            return null;
        }

        public frmTableManager(Account account)
        {
            InitializeComponent();

            _account = account;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadMenuStrip();
            LoadStatusBar();
            LoadData();            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            slbDateTime.Text = DateTime.Now.ToString("dddd, dd/MM/yyyy hh:mm:ss");
        }

        private void B_Click(object sender, EventArgs e)
        {
            // Format lai button cu
            if (grbBillInfo.Tag != null)
                FormatTable(grbBillInfo.Tag as Button);

            Button btn = sender as Button;
            TableFood table = btn.Tag as TableFood;
                        
            // Gan button moi
            grbBillInfo.Text = table.Name;
            grbBillInfo.Tag = btn;
            btn.BackColor = Color.LightGreen;

            // Gan table
            dgvBillInfo.Tag = table;            

            cbTable.DataSource = TableFoodDAO.Instance.GetList(table.Id);
            cbTable.DisplayMember = "Name";

            LoadStatusTable(table);

            LoadBillInfo();
        }

        private void refeshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {      
            if (dgvBillInfo.Tag == null)
            {
                MessageBox.Show("Vui lòng chọn bàn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if (cbFood.SelectedValue != null)
                {                    
                    int idTable = (dgvBillInfo.Tag as TableFood).Id;
                    int idFood = (cbFood.SelectedValue as Food).Id;
                    int quantity = (int)nudQuantity.Value;
                    int idUser = _account.Id;

                    if (TableFoodDAO.Instance.AddBillInfo(idTable, idFood, quantity, idUser))
                    {
                        // Refresh lai button duoc chon
                        RefreshTable(grbBillInfo.Tag as Button);

                        nudQuantity.Value = 1;
                    }
                }
            }
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idCate = (cbCategory.SelectedValue as FoodCategory).Id;            

            List<Food> listFood = FoodDAO.Instance.GetByCate(idCate);
            if (listFood.Count > 0)
            {
                cbFood.DataSource = listFood;
                cbFood.DisplayMember = "Name";
                btnAdd.Enabled = true;
            }
            else
            {
                cbFood.DataSource = null;
                btnAdd.Enabled = false;
            }
        }

        private void dgvBillInfo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int qty = (int)dgvBillInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            if (qty != oldQty)
            {
                string idBill = dgvBillInfo.Rows[e.RowIndex].Cells[0].Value.ToString();
                int idFood = (int)dgvBillInfo.Rows[e.RowIndex].Cells[1].Value;

                if (qty > 0)
                {
                    BillInfoDAO.Instance.UpdateQty(idBill, idFood, qty);                    
                }
                else
                {
                    if (MessageBox.Show("Bạn thật sự muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        BillInfoDAO.Instance.Delete(idBill, idFood);
                        Button btn = grbBillInfo.Tag as Button;
                        RefreshTable(btn, false);
                        btn.BackColor = Color.LightGreen;                        
                    }
                }
                BeginInvoke(new MethodInvoker(LoadBillInfo));
            }          
        }
        
        private void dgvBillInfo_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            oldQty = (int)dgvBillInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (dgvBillInfo.Tag == null)
            {
                MessageBox.Show("Vui lòng chọn bàn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                TableFood table = dgvBillInfo.Tag as TableFood;

                if (table.Status == 1) // Ban co nguoi thi moi huy
                {
                    DialogResult dialogResult = MessageBox.Show($"Bạn thật sự muốn hủy đơn của {table.Name}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialogResult == DialogResult.Yes)
                    {
                        int idTable = table.Id;
                        if (TableFoodDAO.Instance.Cancel(idTable))
                        {
                            // Refresh lai button duoc chon
                            RefreshTable(grbBillInfo.Tag as Button);

                            MessageBox.Show("Hủy bàn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Hủy bàn chưa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }
            }
        }        

        private void nudDiscount_Leave(object sender, EventArgs e)
        {
            decimal.TryParse(lbAmount.Text, System.Globalization.NumberStyles.Currency, System.Globalization.CultureInfo.GetCultureInfo("vi-VN"), out decimal amount);
            lbTotal.Text = (amount - amount * nudDiscount.Value / 100).ToString("c0");

            int idTable = (dgvBillInfo.Tag as TableFood).Id;
            string idBill = TableFoodDAO.Instance.GetBill(idTable).Id;
            BillDAO.Instance.UpdateDiscount(idBill, (int)nudDiscount.Value);
        }

        private void nudDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                nudDiscount_Leave(sender, e);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvBillInfo.SelectedCells.Count > 0)
            {
                if (MessageBox.Show("Bạn thật sự muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string idBill = dgvBillInfo.SelectedCells[0].OwningRow.Cells[0].Value.ToString();
                    int idFood = (int) dgvBillInfo.SelectedCells[0].OwningRow.Cells[1].Value;

                    if (BillInfoDAO.Instance.Delete(idBill, idFood))
                    {
                        // Refresh lai button duoc chon
                        RefreshTable(grbBillInfo.Tag as Button);
                    }
                }
            }
        }

        private void btnMoveTable_Click(object sender, EventArgs e)
        {
            TableFood tableFrom = dgvBillInfo.Tag as TableFood;
            TableFood tableTo = cbTable.SelectedValue as TableFood;

            DialogResult dialogResult = MessageBox.Show($"Bạn thật sự muốn đổi {tableFrom.Name} và {tableTo.Name}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(dialogResult == DialogResult.Yes)
            {
                if (TableFoodDAO.Instance.Change(tableFrom.Id, tableTo.Id))
                {
                    // Refresh button ban chuyen den
                    Button btnTo = GetButtonByIdTable(tableTo.Id);
                    if (btnTo != null)
                        RefreshTable(btnTo, false);

                    // Refresh lai button dang chon
                    RefreshTable(grbBillInfo.Tag as Button);

                    MessageBox.Show("Đổi bàn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Đổi bàn chưa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnMergeTable_Click(object sender, EventArgs e)
        {
            TableFood tableFrom = cbTable.SelectedValue as TableFood;
            TableFood tableTo = dgvBillInfo.Tag as TableFood;

            if (tableFrom.Status == 0)
            {
                MessageBox.Show($"{tableFrom.Name} là bàn trống, vui lòng chọn bàn khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            DialogResult dialogResult = MessageBox.Show($"Bạn thật sự muốn gộp {tableFrom.Name} vào {tableTo.Name}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                if(TableFoodDAO.Instance.Merge(tableFrom.Id, tableTo.Id, _account.Id))
                {
                    // Refresh button ban duoc gop
                    Button btnFrom = GetButtonByIdTable(tableFrom.Id);
                    if (btnFrom != null)
                        RefreshTable(btnFrom, false);

                    // Refresh lai button dang chon
                    RefreshTable(grbBillInfo.Tag as Button);

                    MessageBox.Show("Gộp bàn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Gộp bàn chưa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show($"Bạn thật sự muốn thanh toán?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                TableFood table = dgvBillInfo.Tag as TableFood;
                if (TableFoodDAO.Instance.Payment(table.Id))
                {
                    RefreshTable(grbBillInfo.Tag as Button);
                    MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("hanh toán chưa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cbTable_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1)
                return;

            ComboBox cb = sender as ComboBox;

            using (SolidBrush brush = new SolidBrush(e.ForeColor))
            {
                Font font = cb.Font;
                //Brush brush = Brushes.Black;
                string text = (cb.Items[e.Index] as TableFood).Name;
                int status = (cb.Items[e.Index] as TableFood).Status;

                if (status == 0) // Ban trong
                {
                    text += " - Trống";
                    //font = new Font(font, FontStyle.Bold);
                }

                e.DrawBackground();
                e.Graphics.DrawString(text, font, brush, e.Bounds);
                e.DrawFocusRectangle();
            }
        }

        private void LogOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin.isLogOut = true;
            this.Close();
        }

        private void userInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            //accountChange = false;
            frmUserInfo frm = new frmUserInfo(_account);
            frm.UpdateAccount += Frm_UpdateAccount;
            frm.ShowDialog();

            /*
            if (accountChange)
            {
                _account = AccountDAO.Instance.GetAccountByUserName(_account.UserName);
                LoadStatusBar();
            }*/
        }

        private void Frm_UpdateAccount(object sender, Account e)
        {
            _account = e;
            LoadStatusBar();
        }

        private void changePassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePass frm = new frmChangePass(_account);
            frm.UpdatePass += Frm_UpdatePass;
            frm.ShowDialog();
        }

        private void Frm_UpdatePass(object sender, Account e)
        {
            _account = e;
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategory frm = new frmCategory();
            frm.CategoryChanged += Frm_CategoryChanged;
            frm.ShowDialog();
        }

        private void Frm_CategoryChanged(object sender, EventArgs e)
        {
            LoadFood();
        }

        private void tableToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmTable frm = new frmTable();
            frm.TableChanged += Frm_TableChanged;
            frm.ShowDialog();
        }

        private void Frm_TableChanged(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void foodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFood frm = new frmFood();
            frm.FoodChanged += Frm_FoodChanged;
            frm.ShowDialog();
        }

        private void Frm_FoodChanged(object sender, EventArgs e)
        {
            LoadFood();
            LoadBillInfo();
        }

        private void billToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmBill frm = new frmBill();
            frm.ShowDialog();
        }

        private void accountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAccount frm = new frmAccount(_account);
            frm.AccountChange += Frm_AccountChange;
            frm.ShowDialog();
        }

        private void Frm_AccountChange(object sender, EventArgs e)
        {
            _account = AccountDAO.Instance.GetAccountByUserName(_account.UserName);
            LoadStatusBar();
        }
    }
}
