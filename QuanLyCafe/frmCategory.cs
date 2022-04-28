using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QuanLyCafe.DAO;
using QuanLyCafe.DTO;

namespace QuanLyCafe
{
    public partial class frmCategory : Form
    {
        private event EventHandler categoryChanged;
        public event EventHandler CategoryChanged
        {
            add { categoryChanged += value; }
            remove { categoryChanged -= value; }
        }
        private void LoadList()
        {            
            dgvCategories.EnableHeadersVisualStyles = false;        
            dgvCategories.Columns["nameCate"].HeaderCell.Style.Font = new Font("Tahoma", 9, FontStyle.Bold);

            dgvCategories.DataSource = FoodCategoryDAO.Instance.GetTable();            
        }

        private int Delete(int idCate, string nameCate)
        {
            if (MessageBox.Show($"Bạn thực sự muốn xóa {nameCate}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int result = FoodCategoryDAO.Instance.Delete(idCate);

                switch (result)
                {
                    case -1: // Dang sua dung ko xoa duoc
                        MessageBox.Show("Thông tin đang sử dụng, không được xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 0: // Xoa ko thanh cong
                        MessageBox.Show("Xóa chưa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);                        
                        break;
                    case 1: // Xoa thanh cong
                        categoryChanged?.Invoke(this, new EventArgs());
                        break;
                }
                return result;
            }

            return 0;
        }
        public frmCategory()
        {
            InitializeComponent();
        }
        private void frmCategory_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        private void dgvCategories_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCategories.CurrentRow != null)
            {                             
                DataGridViewRow currentRow = dgvCategories.CurrentRow;

                int idCate = currentRow.Cells["idCate"].Value == DBNull.Value ? 0 : Convert.ToInt32(currentRow.Cells["idCate"].Value);

                string nameCate = currentRow.Cells["nameCate"].Value == DBNull.Value ? "" : currentRow.Cells["nameCate"].Value.ToString();

                int idNew = FoodCategoryDAO.Instance.InsertOrUpdate(idCate, nameCate);

                if (idNew > 0)
                {
                    categoryChanged?.Invoke(this, new EventArgs());

                    currentRow.Cells["idCate"].Value = idNew;
                }
            }
        }

        private void dgvCategories_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            // DBNull co gia tri rong
            if(dgvCategories.CurrentRow.Cells["idCate"].Value != DBNull.Value)
            {
                DataGridViewRow currentRow = dgvCategories.CurrentRow;

                int idCate = Convert.ToInt32(currentRow.Cells["idCate"].Value);
                string nameCate = currentRow.Cells["nameCate"].Value.ToString();

                if (Delete(idCate, nameCate) < 1)
                    e.Cancel = true;
            }
            else
                e.Cancel= true;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvCategories.SelectedCells.Count > 0)
            {
                int rowIndex = dgvCategories.SelectedCells[0].RowIndex;

                int idCate = (int)dgvCategories.Rows[rowIndex].Cells[0].Value;
                string nameCate = dgvCategories.Rows[rowIndex].Cells[1].Value.ToString();

                if (Delete(idCate, nameCate) == 1)
                {
                    LoadList();
                    if (rowIndex > 0)
                        dgvCategories.CurrentCell = dgvCategories.Rows[rowIndex - 1].Cells[1];
                }          
            }
        }
    }
}
