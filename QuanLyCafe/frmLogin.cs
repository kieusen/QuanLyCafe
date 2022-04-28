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
    public partial class frmLogin : Form
    {
        public static bool isLogOut;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtUserName.Text = "Admin";
            txtPassword.Text = "1";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {   
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                MessageBox.Show("Tên đăng nhập chưa có, vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUserName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Mật khẩu chưa có, vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            string userName = txtUserName.Text;
            string password = txtPassword.Text;

            if (Login(userName, password))
            {
                this.Hide();

                isLogOut = false;
                Account account = AccountDAO.Instance.GetAccountByUserName(userName);
                frmTableManager frm = new frmTableManager(account);                
                frm.ShowDialog();

                if (isLogOut)
                {
                    this.Show();

                    txtUserName.ResetText();
                    txtPassword.ResetText();
                    txtUserName.Focus();
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu chưa đúng, vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUserName.Focus();
                return;
            }
        }

        private bool Login(string userName, string password)
        {
            return AccountDAO.Instance.Login(userName, password);
        }
    }
}
