using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCafe.DAO;
using QuanLyCafe.DTO;

namespace QuanLyCafe
{
    public partial class frmFood : Form
    {
        private event EventHandler foodChanged;
        public event EventHandler FoodChanged
        {
            add { foodChanged += value; }   
            remove { foodChanged -= value; }
        }

        private void LoadList()
        {           
            dgvFood.AutoGenerateColumns = false;
            foreach (DataGridViewColumn col in dgvFood.Columns)
            {
                col.HeaderCell.Style.Font = new Font("Tahoma", 9, FontStyle.Bold);
            }

            if (int.TryParse(cbCategoryFillter.SelectedValue.ToString(), out int selectedValue))
            {
                if (selectedValue == 0)
                {
                    dgvFood.DataSource = FoodDAO.Instance.GetList();
                    dgvFood.Columns["NameCate"].Visible = true;
                }
                else
                {
                    dgvFood.DataSource = FoodDAO.Instance.GetByCate(selectedValue);
                    dgvFood.Columns["NameCate"].Visible = false;
                }

                AddFoodBinding();
            }            
        }

        private void FocusListById(int id)
        {
            foreach (DataGridViewRow item in dgvFood.Rows)
            {
                if (Convert.ToInt32(item.Cells[0].Value) == id)
                {
                    dgvFood.CurrentCell = dgvFood[2, item.Index];
                    return;
                }
            }
        }

        private void LoadCateFilter()
        {
            cbCategoryFillter.SelectedValueChanged -= cbCategoryFillter_SelectedValueChanged;

            DataTable table = FoodCategoryDAO.Instance.GetTable();
            DataRow topItem = table.NewRow();
            topItem[0] = 0;
            topItem[1] = "Tất cả";
            table.Rows.InsertAt(topItem, 0);

            cbCategoryFillter.DataSource = table;
            cbCategoryFillter.DisplayMember = "Name";
            cbCategoryFillter.ValueMember = "Id";

            cbCategoryFillter.SelectedValueChanged += cbCategoryFillter_SelectedValueChanged;
        }

        private void LoadCateDetail()
        {
            cbCategory.DataSource = FoodCategoryDAO.Instance.GetList();
            cbCategory.DisplayMember = "Name";
            cbCategory.ValueMember = "Id";
        }

        private void AddFoodBinding()
        {
            cbCategory.DataBindings.Clear();
            cbCategory.DataBindings.Add(new Binding("SelectedValue", dgvFood.DataSource, "IdCategory"));
            
            txtNameFood.DataBindings.Clear();
            txtNameFood.DataBindings.Add(new Binding("Text", dgvFood.DataSource, "Name"));

            nudPrice.DataBindings.Clear();
            nudPrice.Maximum = decimal.MaxValue;
            nudPrice.DataBindings.Add(new Binding("Value", dgvFood.DataSource, "Price"));
        }

        private void LoadData()
        {           
            LoadCateFilter();
            LoadCateDetail();
            LoadList();            
        }

        public frmFood()
        {
            InitializeComponent();
        }

        private void frmFood_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cbCategoryFillter_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadList();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNameFood.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên món", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNameFood.Focus();
                    return;
                }

                string name = txtNameFood.Text;
                int idCate = Convert.ToInt32(cbCategory.SelectedValue);
                decimal price = nudPrice.Value;

                int id = FoodDAO.Instance.Insert(name, idCate, price);
                if (id > 0)
                {
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        
                    LoadList();
                    FocusListById(id);
                    
                    foodChanged?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    MessageBox.Show("Thêm không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNameFood.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên món", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNameFood.Focus();
                    return;
                }

                int id = Convert.ToInt32(dgvFood.CurrentCell.OwningRow.Cells[0].Value);
                string name = txtNameFood.Text;
                int idCate = Convert.ToInt32(cbCategory.SelectedValue);
                decimal price = nudPrice.Value;
                
                if (FoodDAO.Instance.Update(id, name, idCate, price))
                {
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadList();
                    FocusListById(id);

                    foodChanged?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    MessageBox.Show("Cập nhật không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show($"Bạn thật sự muốn xóa {txtNameFood.Text}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dgvFood.CurrentCell.OwningRow.Cells[0].Value);

                    if (FoodDAO.Instance.Used(id))
                    {
                        MessageBox.Show("Món đã được thêm vào hóa đơn, không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (FoodDAO.Instance.Delete(id))
                        {
                            MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LoadList();

                            foodChanged?.Invoke(this, EventArgs.Empty);
                        }
                        else
                        {
                            MessageBox.Show("Xóa không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
