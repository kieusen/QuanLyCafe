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
    public partial class frmUserInfo : Form
    {
        private Account _account;

        private event EventHandler<Account> updateAccount;

        public event EventHandler<Account> UpdateAccount
        {
            add { updateAccount += value; }
            remove { updateAccount -= value; }
        }

        public frmUserInfo(Account account)
        {
            InitializeComponent();

            _account = account;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDisplayName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đầy đủ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDisplayName.Focus();
                return;
            }

            if (AccountDAO.Instance.UpdateInfo(_account.Id, txtDisplayName.Text))
            {                
                _account = AccountDAO.Instance.GetAccountByUserName(_account.UserName);
                updateAccount?.Invoke(this, _account);

                MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra, vui lòng xem lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmUserInfo_Load(object sender, EventArgs e)
        {
            txtUserName.Text = _account.UserName;
            txtDisplayName.Text = _account.DisplayName;
        }
    }
}
