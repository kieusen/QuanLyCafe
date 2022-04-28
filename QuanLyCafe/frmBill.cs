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

namespace QuanLyCafe
{
    public partial class frmBill : Form
    {
        private void InitData()
        {
            dtpFDate.ValueChanged -= dtpFDate_ValueChanged;
            dtpTDate.ValueChanged -= dtpTDate_ValueChanged;

            var firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            dtpFDate.Value = firstDayOfMonth;
            dtpTDate.Value = lastDayOfMonth;

            dtpFDate.ValueChanged += dtpFDate_ValueChanged;
            dtpTDate.ValueChanged += dtpTDate_ValueChanged;
        }
        private void LoadList()
        {
            dgvBill.AutoGenerateColumns = false;
            foreach (DataGridViewColumn col in dgvBill.Columns)
            {
                col.HeaderCell.Style.Font = new Font("Tahoma", 9, FontStyle.Bold);
            }

            if (rdoDateCheckIn.Checked)
                dgvBill.DataSource = BillDAO.Instance.GetByDateIn(dtpFDate.Value, dtpTDate.Value);
            else if (rdoDateCheckOut.Checked)
                dgvBill.DataSource = BillDAO.Instance.GetByDateOut(dtpFDate.Value, dtpTDate.Value);

            LoadBillInfo();
        }

        private void LoadBillInfo()
        {
            if (dgvBill.CurrentCell != null)
            {
                string idBill = Convert.ToString(dgvBill.CurrentCell.OwningRow.Cells[0].Value);

                dgvBillInfo.AutoGenerateColumns = false;
                foreach (DataGridViewColumn col in dgvBillInfo.Columns)
                {
                    col.HeaderCell.Style.Font = new Font("Tahoma", 9, FontStyle.Bold);
                }

                dgvBillInfo.DataSource = BillInfoDAO.Instance.GetByBill(idBill);
            }
        }

        public frmBill()
        {
            InitializeComponent();
        }

        private void frmBill_Load(object sender, EventArgs e)
        {
            InitData();
            LoadList();
        }

        private void dtpFDate_ValueChanged(object sender, EventArgs e)
        {
            LoadList();
        }

        private void dtpTDate_ValueChanged(object sender, EventArgs e)
        {
            LoadList();
        }

        private void dgvBill_SelectionChanged(object sender, EventArgs e)
        {
            LoadBillInfo();
        }

        private void rdoDateCheckIn_CheckedChanged(object sender, EventArgs e)
        {
            LoadList();
        }

        private void rdoDateCheckOut_CheckedChanged(object sender, EventArgs e)
        {
            LoadList();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvBill.SelectedCells.Count > 0)
            {
                string idBill = Convert.ToString(dgvBill.CurrentCell.OwningRow.Cells[0].Value);
                Reports.crpBillInfo crpBillInfo = new Reports.crpBillInfo();
                crpBillInfo.SetDataSource(BillInfoDAO.Instance.GetByBill(idBill));

                frmReport frm = new frmReport();
                frm.crpReport.ReportSource = crpBillInfo;
                frm.ShowDialog();
            }
                   
        }
    }
}
