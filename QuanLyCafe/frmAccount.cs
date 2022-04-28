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
    public partial class frmAccount : Form
    {
        private readonly Account _account;

        private event EventHandler accountChange;
        public event EventHandler AccountChange
        {
            add { accountChange += value; }
            remove { accountChange -= value; }
        }
        
        private void LoadList()
        {
            dgvAccount.SelectionChanged -= dgvAccount_SelectionChanged;
            dgvAccount.AutoGenerateColumns = false;
            foreach (DataGridViewColumn col in dgvAccount.Columns)
            {
                col.HeaderCell.Style.Font = new Font("Tahoma", 9, FontStyle.Bold);
            }            

            dgvAccount.DataSource = AccountDAO.Instance.GetTable();
            AddBinding();

            SetStateDelete();

            dgvAccount.SelectionChanged += dgvAccount_SelectionChanged;
        }

        private void FocusListById(int id)
        {
            foreach (DataGridViewRow item in dgvAccount.Rows)
            {
                if (Convert.ToInt32(item.Cells[0].Value) == id)
                {
                    dgvAccount.CurrentCell = dgvAccount[2, item.Index];
                    SetStateDelete();
                    return;
                }
            }
        }

        private void AddBinding()
        {
            txtUserName.DataBindings.Clear();
            txtUserName.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "user_name"));

            txtDisplayName.DataBindings.Clear();
            txtDisplayName.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "display_name"));

            cbTypeUser.DataBindings.Clear();
            cbTypeUser.DataBindings.Add(new Binding("SelectedIndex", dgvAccount.DataSource, "type"));
        }

        private void SetStateDelete()
        {
            int id = Convert.ToInt32(dgvAccount.CurrentCell.OwningRow.Cells[0].Value);
            btnDelete.Enabled = _account.Id != id;
        }

        public frmAccount(Account account)
        {
            InitializeComponent();

            _account = account;
        }

        private void frmAccount_Load(object sender, EventArgs e)
        {
            LoadList();            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llbResetPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (MessageBox.Show($"Bạn thật sự muốn đặt lại mật khẩu cho {txtUserName.Text} - {txtDisplayName.Text}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dgvAccount.CurrentCell.OwningRow.Cells[0].Value);
                    if (AccountDAO.Instance.ResetPass(id))
                    {
                        MessageBox.Show("Đặt lại mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadList();
                        FocusListById(id);

                        if (_account.Id == id) // Cap nhat user hien tai
                        {
                            accountChange?.Invoke(this, EventArgs.Empty);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Đặt lại mật khẩu không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
                if (MessageBox.Show($"Bạn thật sự muốn xóa {txtUserName.Text} - {txtDisplayName.Text}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {                    
                    int id = Convert.ToInt32(dgvAccount.CurrentCell.OwningRow.Cells[0].Value);

                    if (id == _account.Id)
                    {
                        MessageBox.Show("Không thể xóa người dùng hiện tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                    if (AccountDAO.Instance.Used(id))
                    {
                        MessageBox.Show("Người dùng đã tạo hóa đơn, không xóa được!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (AccountDAO.Instance.Delete(id))
                    {
                        MessageBox.Show("Xóa người dùng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadList();
                        FocusListById(id);
                    }
                    else
                    {
                        MessageBox.Show("Xóa người dùng không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }

        private void dgvAccount_SelectionChanged(object sender, EventArgs e)
        {
            SetStateDelete();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtDisplayName.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên đầy đủ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDisplayName.Focus();
                    return;
                }

                int id = Convert.ToInt32(dgvAccount.CurrentCell.OwningRow.Cells[0].Value);                
                string displayName = txtDisplayName.Text;
                int type = Convert.ToInt32(cbTypeUser.SelectedIndex);
                
                if (AccountDAO.Instance.Update(id, displayName, type))
                {
                    MessageBox.Show("Cập nhật người dùng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadList();
                    FocusListById(id);

                    if (_account.Id == id) // Cap nhat user hien tai
                    {
                        accountChange?.Invoke(this, EventArgs.Empty);
                    }
                }
                else
                {
                    MessageBox.Show("Cập nhật người dùng không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtUserName.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUserName.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtDisplayName.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên đầy đủ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDisplayName.Focus();
                    return;
                }

                string userName = txtUserName.Text;
                string displayName = txtDisplayName.Text;
                int type = Convert.ToInt32(cbTypeUser.SelectedIndex);

                int id = AccountDAO.Instance.Insert(userName, displayName, type);
                if (id > 0)
                {
                    MessageBox.Show("Thêm người dùng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadList();
                    FocusListById(id);
                }
                else
                {
                    MessageBox.Show("Thêm người dùng không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }
    }
}
