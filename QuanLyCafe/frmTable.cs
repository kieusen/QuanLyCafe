using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QuanLyCafe.DAO;
using QuanLyCafe.DTO;

namespace QuanLyCafe
{
    public partial class frmTable : Form
    {
        private event EventHandler tableChanged;
        public event EventHandler TableChanged
        {
            add { tableChanged += value; }
            remove { tableChanged -= value; }
        }
        private void LoadList()
        {            
            dgvTable.EnableHeadersVisualStyles = false;        
            dgvTable.Columns["nameTable"].HeaderCell.Style.Font = new Font("Tahoma", 9, FontStyle.Bold);

            dgvTable.AutoGenerateColumns = false;
            dgvTable.DataSource = TableFoodDAO.Instance.GetTable();
        }

        private int Delete(int idTable, string nameTable)
        {
            if (MessageBox.Show($"Bạn thực sự muốn xóa {nameTable}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int result = TableFoodDAO.Instance.Delete(idTable);

                switch (result)
                {
                    case -1: // Dang sua dung ko xoa duoc
                        MessageBox.Show("Thông tin đang sử dụng, không được xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 0: // Xoa ko thanh cong
                        MessageBox.Show("Xóa chưa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 1:
                        // Xoa thanh cong
                        tableChanged?.Invoke(this, new EventArgs());
                        break;
                }
                return result;
            }

            return 0;
        }

        public frmTable()
        {
            InitializeComponent();
        }
        private void frmTable_Load(object sender, EventArgs e)
        {
            LoadList();            
        }

        private void dgvTable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTable.CurrentRow != null)
            {
                DataGridViewRow currentRow = dgvTable.CurrentRow;

                int idTable = currentRow.Cells["idTable"].Value == DBNull.Value ? 0 : Convert.ToInt32(currentRow.Cells["idTable"].Value);

                string nameTable = currentRow.Cells["nameTable"].Value == DBNull.Value ? "" : currentRow.Cells["nameTable"].Value.ToString();

                int idNew = TableFoodDAO.Instance.InsertOrUpdate(idTable, nameTable);

                if (idNew > 0)
                {
                    tableChanged?.Invoke(this, new EventArgs());

                    currentRow.Cells["idTable"].Value = idNew;
                }
            }
        }

        private void dgvTable_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            // DBNull co gia tri rong
            if (dgvTable.CurrentRow.Cells["idTable"].Value != DBNull.Value)
            {
                DataGridViewRow currentRow = dgvTable.CurrentRow;

                int idTable = Convert.ToInt32(currentRow.Cells["idTable"].Value);
                string nameTable = currentRow.Cells["nameTable"].Value.ToString();

                if (Delete(idTable, nameTable) < 1)
                    e.Cancel = true;
            }
            else
                e.Cancel = true;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvTable.SelectedCells[0].OwningRow.Cells[0].Value != DBNull.Value)
            {
                int rowIndex = dgvTable.SelectedCells[0].RowIndex;

                int idTable = Convert.ToInt32(dgvTable.Rows[rowIndex].Cells[0].Value);
                string nameTable = dgvTable.Rows[rowIndex].Cells[1].Value.ToString();

                if (Delete(idTable, nameTable) == 1)
                {
                    LoadList();
                    if (rowIndex > 0)
                        dgvTable.CurrentCell = dgvTable.Rows[rowIndex - 1].Cells[1];
                }
            }           
        }
    }
}
