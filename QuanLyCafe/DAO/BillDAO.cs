using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCafe.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;
        public static BillDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new BillDAO();
                return instance;
            }
            set
            {
                instance = value;
            }
        }
        private BillDAO() { }
        public bool UpdateDiscount(string idBill, int discount)
        {
            string query = $"UPDATE Bill SET discount = {discount} WHERE id = '{idBill}' ";
            return DataProvider.Instance.ExecuteNonQuery(query);
        }

        public DataTable GetByDateIn(DateTime fDate, DateTime tDate)
        {
            string query = $@"EXEC USP_Bill_By_Date_In @from_date , @to_date ";
            return DataProvider.Instance.FillData(query, new object[] { fDate, tDate });
        }

        public DataTable GetByDateOut(DateTime fDate, DateTime tDate)
        {
            string query = $@"EXEC USP_Bill_By_Date_Out @from_date , @to_date ";
            return DataProvider.Instance.FillData(query, new object[] { fDate, tDate });
        }
    }
}
