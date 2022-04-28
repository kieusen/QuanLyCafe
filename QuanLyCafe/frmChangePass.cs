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
    public partial class frmChangePass : Form
    {
        private Account _account;

        private event EventHandler<Account> updatePass;
        public event EventHandler<Account> UpdatePass
        {
            add { updatePass += value; }
            remove { updatePass -= value; }
        }

        public frmChangePass(Account account)
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
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }
            
            if (string.IsNullOrEmpty(txtNewPass.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPass.Focus();
                return;
            }

            if (txtNewPass.Text != txtRetypePass.Text)
            {
                MessageBox.Show("Mật khẩu nhập lại chưa giống với mật khẩu mới, vui lòng xem lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRetypePass.Focus();
                return;
            }

            if (AccountDAO.Instance.Encrypt(txtPassword.Text) != _account.Password)
            {
                MessageBox.Show("Mật khẩu không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            if(AccountDAO.Instance.ChangePass(_account.Id, txtNewPass.Text))
            {                
                MessageBox.Show("Đổi mật khẩu thành thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refresh lai account
                _account = AccountDAO.Instance.GetAccountByUserName(_account.UserName);

                updatePass?.Invoke(this, _account);

                txtPassword.ResetText();
                txtPassword.Focus();
                txtNewPass.ResetText();
                txtRetypePass.ResetText();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra, vui lòng xem lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmUserInfo_Load(object sender, EventArgs e)
        {
            txtUserName.Text = _account.UserName;
        }
    }
}
